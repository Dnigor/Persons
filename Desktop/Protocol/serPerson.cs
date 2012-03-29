using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;



namespace Desktop
{
    [DataContract]
    public class serPerson
    {
        
            [DataMember]
            public int id;
            [DataMember]
            public string fname;
            [DataMember]
            public string lname;

    }
}
