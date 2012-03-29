using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    
    public class DBService : IDBService
    {

        [DataContract]
        internal class Person
        {
            [DataMember]
            internal int id;
            [DataMember]
            internal string fname;
            [DataMember]
            internal string lname;

        }

        private personsEntities personsContext;
        private JSONconverter conv;


        public DBService()
        {
            personsContext = new personsEntities();
            conv = new JSONconverter();
        }

        public object GetRecords()
        {

            IQueryable<person> query = from p in personsContext.persons select p;
            string result = "";
            foreach (person record in query)
            {

                result += conv.toJSONstring(record) + "!";
            }

            return result;
            //  ((ObjectQuery)query).Execute(MergeOption.AppendOnly);

        }


        public void AddPhoto(int index, byte[] bytes, string path)
        {
            var record = personsContext.persons.First(p => p.ID == index);
            record.Photo = bytes;
            record.PhotoPath = path;

            //SaveChanges();
        }

        public void SaveChanges(string jsonstring)
        {

            conv.fromJSONstring(personsContext, jsonstring);
            personsContext.SaveChanges();

        }
    }

}
