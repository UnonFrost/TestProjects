using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using CommonTypes;

namespace ITestsProject
{
    class Program : ITestImplementation
    {
        public string AuthorName
        {
            get { return "Фрост Евгений Александрович"; }
        }

        static void Main(string[] args)
        {
            var t = new CommonTypes.Importer();
            t.DoImport();
            Console.WriteLine("{0} тест (-а, -ов) сделано", t.DoneNumberOfTests);
        }
    }
}
