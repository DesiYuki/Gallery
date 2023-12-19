using System.Collections.Generic;
using System.Linq;
using Gallery.Models;
using LiteDB;

namespace Gallery.Classes
{
    public class DBControl
    {
        private static LiteDatabase liteDB;

        public DBControl(string DBName)
        {
            liteDB = new LiteDatabase(DBName);
        }

        public void Insert<T>(T inModel)
        {
            var col = liteDB.GetCollection<T>(typeof(T).Name);
            col.Insert(inModel);
        }

        public int InsertGetId<T>(T inModel)
        {
            var col = liteDB.GetCollection<T>(typeof(T).Name);
            return col.Insert(inModel).AsInt32;            
        }

        public void Update<T>(T inModel)
        {
            var col = liteDB.GetCollection<T>(typeof(T).Name);
            col.Update(inModel);
        }

        //--------------------------//  Пока так, потом сделаю универсальными  //--------------------------//

        public void Delete<T>(T inModel)
        {
            int in_id = (int)inModel.GetType().GetProperty("Id").GetValue(inModel);
            switch (typeof(T).Name)
            {
                case "SearchFolders":
                    var col1 = liteDB.GetCollection<SearchFolders>("SearchFolders");
                    col1.EnsureIndex(x => x.Id);
                    col1.DeleteMany(x => x.Id.Equals(in_id));
                    break;
            }
        }

        public List<SearchFolders> SelectAll_SearchFolders()
        {
            var col = liteDB.GetCollection<SearchFolders>("SearchFolders");
            return col.FindAll().ToList();
            
        }
    }
}
