using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Gallery.Classes;
using Gallery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallery.Forms
{
    public partial class f_setting : DevExpress.XtraEditors.XtraForm
    {
        public f_setting()
        {
            InitializeComponent();
            loadSetting();
        }

        void loadSetting()
        {
            foreach (SearchFolders sf in Global.DBControl.SelectAll_SearchFolders())
                tl_path.Nodes.Add(sf.Id, sf.Path);
            b_delPath.Enabled = tl_path.Nodes.Count > 0;
        }

        #region tp_folder
        private void b_addPath_Click(object sender, EventArgs e)
        {
            bool CheckCopy = false;

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                fd.ShowDialog();
                for (int i = 0; i < tl_path.Nodes.Count; i++)
                {
                    if ((string)tl_path.Nodes[i].GetValue(tl_p_path) == fd.SelectedPath)
                    {
                        CheckCopy = true;
                        break;
                    }
                }

                if (!CheckCopy) 
                    tl_path.Nodes.Add(
                        Global.DBControl.InsertGetId(new SearchFolders { Path = fd.SelectedPath }),
                        fd.SelectedPath);
            }
            b_delPath.Enabled = tl_path.Nodes.Count > 0;
        }

        private void b_delPath_Click(object sender, EventArgs e)
        {
            if (tl_path.FocusedNode != null)
            {
                Global.DBControl.Delete(new SearchFolders { Id = (int)tl_path.FocusedNode.GetValue(tl_p_id) });
                tl_path.FocusedNode.Remove();
            }
        }
        #endregion
    }
}
