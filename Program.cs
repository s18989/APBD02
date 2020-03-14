using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace APBD02
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sciezkaOdczytu = "dane.csv";
            var sciezkaOdczytu = @"C:\Users\Hubert\Desktop\APBD\APBD02\dane.csv";
            if (args.Length > 0)
            {
                sciezkaOdczytu = args[0];
            }

            var sciezkaZapisu = "result.xml";
            if (args.Length > 1)
            {
                sciezkaZapisu = args[1];
            }

            var formatDanych = "xml";
            if(args.Length > 2)
            {
                formatDanych = args[3];
            }

            Dziennik dziennik = new Dziennik();

            var plik = new FileInfo(sciezkaOdczytu);
            if (!plik.Directory.Exists)
            {
                dziennik.zapisz(plik.Directory + " nie istnieje");
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
                dziennik.Dispose();
            }

            if (!plik.Exists)
            {
                dziennik.zapisz(plik + " nie istnieje");
                throw new FileNotFoundException("Plik " + plik + " nie istnieje");
                dziennik.Dispose();
            }

            var linie = File.ReadLines(sciezkaOdczytu);
            var porownywacz = new StudentPorownywacz();
            var lista = new HashSet<Student>(porownywacz);
            var ilosc = 0;

            foreach(var linia in linie)
            {
                ilosc += 1;

                try
                {
                    var student = new Student(linia);
                    lista.Add(student);
                }
                catch (PustePoleException e)
                {
                    dziennik.zapisz(linia + " zawiera puste pola");
                }
                catch (BrakujaceDaneException e)
                {
                    dziennik.zapisz(linia + " brakuje danych");
                }
            }

            var uczelnia = new Uczelnia
            {
                ListaStudentow = lista,
                autor = "Hubert Strąk"
            };

            uczelnia.liczbaStudentow();

            if (formatDanych.Equals("xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Uczelnia));
                xmlSerializer.Serialize(File.Create(sciezkaZapisu), uczelnia);
            }
            else if (formatDanych.Equals("json"))
            {
                string wyjscie = JsonConvert.SerializeObject(uczelnia);
                var streamWriter = new System.IO.StreamWriter(sciezkaZapisu);
                streamWriter.WriteLine(wyjscie);
                streamWriter.Flush();
                streamWriter.Close();
            }
            dziennik.Dispose();
        }
    }
}
