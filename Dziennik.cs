using System;
using System.Collections.Generic;
using System.Text;

namespace APBD02
{
    public class Dziennik : IDisposable
    {
        public System.IO.StreamWriter streamWriter;

        public Dziennik()
        {
            streamWriter = new System.IO.StreamWriter("log.txt");
        }
        public void zapisz(string msg)
        {
            streamWriter.WriteLine(DateTime.Now + "---->" + msg);
        }
        public void Dispose()
        {
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
