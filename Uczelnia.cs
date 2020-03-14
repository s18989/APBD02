using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace APBD02
{
    [XmlRootAttribute("Uczelnia")]
    public class Uczelnia
    {
        [XmlAttribute]
        public string utworzono { get; set; }



        [XmlAttribute]
        public string autor { get; set; }



        public HashSet<Student> ListaStudentow { get; set; }
        public List<Studia> ListaStudiow { get; set; }


        public Uczelnia()
        {
            utworzono = DateTime.Now.ToShortDateString();
            ListaStudiow = new List<Studia>();
        }

        public void liczbaStudentow()
        {
            foreach (var student in ListaStudentow)
            {
                var studia = student.studia;
                if(studia == null)
                {
                    ListaStudiow.Add(new Studia
                    {
                        studia = student.studia.studia,
                        liczbaStudentow = 1
                    });
                }
                else
                {
                    studia.liczbaStudentow += 1;
                }
            }
        }
    }
}
