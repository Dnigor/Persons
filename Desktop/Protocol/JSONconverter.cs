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


using System.Linq;

using System.Net;
using System.Net.Sockets;


/// <summary>
/// Summary description for JSONconverter
/// </summary>
/// 
namespace Desktop
{
  /*  public class JSONconverter
    {
        public JSONconverter()
        {

        }

        public string toJSONstring(person record)
        {
            serPerson p = new serPerson();


            p.id = record.ID;
            p.fname = record.FName;
            p.lname = record.LName;

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(serPerson));
            ser.WriteObject(stream, p);


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
    */
}