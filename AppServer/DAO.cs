using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using System.Collections;
using System.Data.Objects;

namespace AppServer
{
    public class DAO
    {
        private PersonsEntities personsContext;
       
        public DAO()
        {
            personsContext = new PersonsEntities();
        
        }

        public IQueryable<person> GetRecords()
        {

            IQueryable<person> query = from p in personsContext.persons select p;

            return query;
           

        }

        public void Update(person p, int id) 
        {
            var record = personsContext.persons.First(q => q.ID == id);
            
        }
    }
}
