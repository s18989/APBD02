using System;
using System.Xml.Serialization;

namespace APBD02
{
    public class Student
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }


        [XmlAttribute]
        public string numerIndeksu { get; set; }




        public Studia studia { get; set; }
        public string dataUrodzenia { get; set; }
        public string email { get; set; }
        public string imieMatki { get; set; }
        public string imieOjca { get; set; }

        public Student()
        {

        }

        public Student(string linia)
        {
            var podzial = linia.Split(",");
            if (podzial.Length < 9)
            {
                Console.WriteLine("Studnet " + podzial[0] + " " + podzial[1] + " nie został dodany, brakujące dane");
                throw new BrakujaceDaneException();
            }

            foreach(var wiersz in podzial)
            {
                if(wiersz.Trim() == "")
                {
                    Console.WriteLine("Studnet " + podzial[0] + " " + podzial[1] + " nie został dodany, pusty wiersz");
                    throw new PustePoleException();
                }
            }

            imie = podzial[0];
            nazwisko = podzial[1];
            studia = new Studia();
            studia.studia = podzial[2];
            studia.typStudiow = podzial[3];
            numerIndeksu = "s" + podzial[4];
            dataUrodzenia = podzial[5];
            email = podzial[6];
            imieMatki = podzial[7];
            imieOjca = podzial[8];
        }
        
    }

    public class PustePoleException : Exception
    {
    }
    public class BrakujaceDaneException : Exception
    {
    }

}
