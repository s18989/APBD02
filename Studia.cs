using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD02
{
    public class Studia
    {
        [XmlAttribute]
        public string studia { get; set; }


        public string typStudiow { get; set; }

        [XmlAttribute]
        public int liczbaStudentow { get; set; }
    }
}
