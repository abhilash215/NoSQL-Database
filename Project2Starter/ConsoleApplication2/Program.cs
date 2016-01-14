using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static System.Console;
using System.Threading.Tasks;

namespace XDocument_Create_Xml
{
    class PersistenceEngine
    {
        static void Main(string[] args)
        {
            XDocument doc = new XDocument();
            doc.Load (@"‪C:\Users\Ravi\Desktop\proj2demo.xml");
            Response.Write("<BR>" + doc.OuterXml);


            Console.WriteLine("");



        }
    }
}
