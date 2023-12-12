using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gallery.CustomComponents
{
    public partial class yZoomPicturBox : XtraUserControl
    {
        public yZoomPicturBox()
        {
            InitializeComponent();
            MouseWheel += (s, e) =>
            {
                if (pictureBox1.Image != null)
                {
                    int wOld = pictureBox1.Width;
                    int hOld = pictureBox1.Height;

                    if (pictureBox1.Dock == DockStyle.Fill)
                    {
                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Width = Width;
                    }

                    pictureBox1.Width += e.Delta;
                    pictureBox1.Height = (int)(pictureBox1.Width / (pictureBox1.Image.Width * 0.01) * (pictureBox1.Image.Height * 0.01));

                    pictureBox1.Left -= (pictureBox1.Width - wOld) / 2;
                    pictureBox1.Top -= (pictureBox1.Height - hOld) / 2;

                    moveBox(pictureBox1.Left, pictureBox1.Top);
                }
            };
        }

        public void setIMG(string path)
        {
            pictureBox1.Image = GetCopyImage(path);
            pictureBox1.Visible = pictureBox1.Image != null;
            pictureBox1.MinimumSize = new Size(pictureBox1.Image.Width / 4, pictureBox1.Image.Height / 4);
            pictureBox1.MaximumSize = new Size(pictureBox1.Image.Width * 8, pictureBox1.Image.Height * 8);
            pictureBox1.Dock = DockStyle.Fill;
        }

        private Image GetCopyImage(string path)
        {
            try
            {
                using (Image im = Image.FromFile(path))
                {
                    Bitmap bm = new Bitmap(im);
                    return bm;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        static Boolean moveImg = false;
        static Point mouseStartPos;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStartPos = Cursor.Position;
            if (pictureBox1.Dock != DockStyle.Fill)
            moveImg = true;
        }

        private void moveBox(int mX, int mY)
        {
            if (Width > pictureBox1.Width)
                pictureBox1.Left = mX > 0 && mX < -(pictureBox1.Width - Width) ? mX : mX < -(pictureBox1.Width - Width) ? 0 : -(pictureBox1.Width - Width);
            if (Height > pictureBox1.Height)
                pictureBox1.Top = mY > 0 && mY < -(pictureBox1.Height - Height) ? mY : mY < -(pictureBox1.Height - Height) ? 0 : -(pictureBox1.Height - Height);

            if (Width < pictureBox1.Width)
                pictureBox1.Left = mX < 0 && mX > -(pictureBox1.Width - Width) ? mX : mX > -(pictureBox1.Width - Width) ? 0 : -(pictureBox1.Width - Width);
            if (Height < pictureBox1.Height)
                pictureBox1.Top = mY < 0 && mY > -(pictureBox1.Height - Height) ? mY : mY > -(pictureBox1.Height - Height) ? 0 : -(pictureBox1.Height - Height);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveImg)
            {
                moveBox(pictureBox1.Left + (Cursor.Position.X - mouseStartPos.X), pictureBox1.Top + (Cursor.Position.Y - mouseStartPos.Y));
                mouseStartPos = Cursor.Position;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moveImg = false;
        }

        private void yZoomPicturBox_Resize(object sender, EventArgs e)
        {
            moveBox(pictureBox1.Left, pictureBox1.Top);
        }

        private void yZoomPicturBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                    System.IO.FileInfo fi = new System.IO.FileInfo(files[0]);
                    if (System.IO.File.Exists(fi.FullName) &&
                        (fi.Extension == ".PNG" || fi.Extension == ".png" ||
                        fi.Extension == ".JPEG" || fi.Extension == ".jpeg" ||
                        fi.Extension == ".JPG" || fi.Extension == ".jpg"))
                    {
                        setIMG(fi.FullName);
                    }

                }
                catch { }
            }
        }

        private void yZoomPicturBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("DoubleMouseClick")]
        public event MouseEventHandler DoubleMouseClick;
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Dock == DockStyle.None)
            {
                pictureBox1.Dock = DockStyle.Fill;
                if (DoubleMouseClick != null)
                    DoubleMouseClick(this, e);
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("FillMouseClick")]
        public event MouseEventHandler FillMouseClick;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (pictureBox1.Dock == DockStyle.Fill)
                if (FillMouseClick != null)
                    FillMouseClick(this, e);
        }
    }
}