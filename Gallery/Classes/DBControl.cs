using System.Collections.Generic;
using System.Linq;
using Gallery.Models;
using LiteDB;

namespace Gallery.Classes
{
    public class DBControl
    {
        static LiteDatabase litedb;

        public DBControl(string DBName)
        {
            litedb = new LiteDatabase(DBName);
        }

        public void Insert<T>(T inModel)
        {
            var col = litedb.GetCollection<T>(typeof(T).Name);
            col.Insert(inModel);
        }

        public int InsertGetId<T>(T inModel)
        {
            var col = litedb.GetCollection<T>(typeof(T).Name);
            return col.Insert(inModel).AsInt32;            
        }

        public void Update<T>(T inModel)
        {
            var col = litedb.GetCollection<T>(typeof(T).Name);
            col.Update(inModel);
        }

        //--------------------------//  Пока так, потом сделаю универсальными  //--------------------------//

        public void Delete<T>(T inModel)
        {
            int in_id = (int)inModel.GetType().GetProperty("Id").GetValue(inModel);
            switch (typeof(T).Name)
            {
                case "SearchFolders":
                    var col1 = litedb.GetCollection<SearchFolders>("SearchFolders");
                    col1.EnsureIndex(x => x.Id);
                    col1.DeleteMany(x => x.Id.Equals(in_id));
                    break;

                case "ImageInfo":
                    var col2 = litedb.GetCollection<ImageInfo>("ImageInfo");
                    col2.EnsureIndex(x => x.Id);
                    col2.DeleteMany(x => x.Id.Equals(in_id));
                    break;
            }
        }
        
        //SelectById //Добавить

        public List<ImageInfo> selectImageInfoByPath(string inPath)
        {
            var col = litedb.GetCollection<ImageInfo>("ImageInfo");
            return col.Find(Query.EQ("Path", inPath)).ToList();
        }

        public List<ImageInfo> selectAll_ImageInfo()
        {
            var col = litedb.GetCollection<ImageInfo>("ImageInfo");
            return col.FindAll().ToList();            
        }

        public List<SearchFolders> selectAll_SearchFolders()
        {
            var col = litedb.GetCollection<SearchFolders>("SearchFolders");
            return col.FindAll().ToList();
            
        }
    }
}
