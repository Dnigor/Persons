using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data;
using System.Collections;
using System.Data.Objects;

using System.Linq;

using System.Net;
using System.Net.Sockets;


/// <summary>
/// Summary description for JSONconverter
/// </summary>
/// 
namespace AppServer
{
    public class JSONconverter
    {
        public JSONconverter()
        {

        }

        public string toJSONstring(IQueryable<person> data)
        {
                        
            serPerson sp;
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(serPerson));

            foreach (person p in data) 
            {
                sp = new serPerson();

                sp.id = p.ID;
                sp.fname = p.FName;
                sp.lname = p.LName;

                ser.WriteObject(stream, sp);
                stream.Write(new ASCIIEncoding().GetBytes("!"), 0 , 1); 
            }
            
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }



        public void fromJSONstring(PersonsEntities personsContext, string jsonstring)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(new ASCIIEncoding().GetBytes(jsonstring), 0, jsonstring.Length);
            stream.Position = 0;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(serPerson));
            serPerson person = (serPerson)ser.ReadObject(stream);

            var record = personsContext.persons.First(p => p.ID == person.id);
            record.FName = person.fname;
            record.LName = person.lname;
        }

    }

}