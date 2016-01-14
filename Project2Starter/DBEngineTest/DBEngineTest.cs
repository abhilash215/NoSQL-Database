///////////////////////////////////////////////////////////////
// DBElement.cs - Test DBEngine and DBExtensions             //
// Ver 1.1                                                   //
// Application: Demonstration for CSE681-SMA, Project#2      //
// Language:    C#, ver 6.0, Visual Studio 2015              //
// Platform:    HP EliteBook,Core-i5, Windows 10             //
// Author:      Abhilash Udayashankar,SUID 778388557         //
//               (774) 540-1234 ,audayash@syr.edu            //
//Original Author:Jim Fawcett, CST 4-187, Syracuse University//
//              (315) 443-3948, jfawcett@twcny.rr.com        //
///////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package replaces DBEngine test stub to remove
 * circular package references.
 *
 * Now this testing depends on the class definitions in DBElement,
 * DBEngine, and the extension methods defined in DBExtensions.
 * We no longer need to define extension methods in DBEngine.
 */
 /*
* Public Interface
*------------------
*Main()
*-main method used to test the DBEngine Package
*/
/*
 * Maintenance:
 * ------------
 * Required Files: 
 *   DBEngineTest.cs,  DBElement.cs, DBEngine.cs,  
 *   DBExtensions.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.1 :09  Oct 15
 * -   added comments and remove function
 * ver 1.0 : 24 Sep 15
 * - first release
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project2_code
{
    class Program
    {
        static void Main(string[] args)
        {
            "Testing DBEngine Package".title('=');
            WriteLine();
            // New element being created
            Write("\n --- Test DBElement<int,string> ---");
            DBElement<int, string> elem1 = new DBElement<int, string>();
            elem1.payload = "a payload";
            Write(elem1.showElement<int, string>());
            WriteLine();
            // New element being created
            DBElement<int, string> elem2 = new DBElement<int, string>("Darth Vader", "Evil Overlord");
            elem2.payload = "The Empire strikes back!";
            Write(elem2.showElement<int, string>());
            WriteLine();
            // New element being created
            var elem3 = new DBElement<int, string>("Luke Skywalker", "Young HotShot");
            elem3.children.AddRange(new List<int> { 1, 5, 23 });
            elem3.payload = "X-Wing fighter in swamp - Oh oh!";
            Write(elem3.showElement<int, string>());
            WriteLine();

            Write("\n --- Test DBEngine<int,DBElement<int,string>> ---");

            int key = 0;
            Func<int> keyGen = () => { ++key; return key; };  // anonymous function to generate keys

            DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();
            bool p1 = db.insert(keyGen(), elem1);
            bool p2 = db.insert(keyGen(), elem2);
            bool p3 = db.insert(keyGen(), elem3);

            if (p1 && p2 && p3)
                Write("\n  all inserts succeeded");
            else
                Write("\n  at least one insert failed");
            db.show<int, DBElement<int, string>, string>();
            WriteLine();

            WriteLine("\n\n removing element of key 2");
            bool p4 = db.remove(2);
            db.show<int, DBElement<int, string>, string>();
            
            Write("\n --- Test DBElement<string,List<string>> ---");
            // New element being created of type string and list of strings
            DBElement<string, List<string>> newelem1 = new DBElement<string, List<string>>();
            newelem1.name = "newelem1";
            newelem1.descr = "test new type";
            newelem1.payload = new List<string> { "one", "two", "three" };
            Write(newelem1.showElement<string, List<string>>());
            WriteLine();

            Write("\n --- Test DBElement<string,List<string>> ---");
            DBElement<string, List<string>> newerelem1 = new DBElement<string, List<string>>();
            newerelem1.name = "newerelem1";
            newerelem1.descr = "better formatting";
            newerelem1.payload = new List<string> { "alpha", "beta", "gamma" };
            newerelem1.payload.Add("delta");
            newerelem1.payload.Add("epsilon");
            Write(newerelem1.showElement<string, List<string>, string>());
            WriteLine();

            //new elements being created
            DBElement<string, List<string>> newerelem2 = new DBElement<string, List<string>>();
            newerelem2.name = "newerelem2";
            newerelem2.descr = "better formatting";
            newerelem1.children.AddRange(new[] { "first", "second" });
            newerelem2.payload = new List<string> { "a", "b", "c" };
            newerelem2.payload.Add("d");
            newerelem2.payload.Add("e");
            Write(newerelem2.showElement<string, List<string>, string>());
            WriteLine();

            Write("\n --- Test DBEngine<string,DBElement<string,List<string>>> ---");

            int seed = 0;
            string skey = seed.ToString();
            Func<string> skeyGen = () =>
            {
                ++seed;
                skey = "string" + seed.ToString();
                skey = skey.GetHashCode().ToString();
                return skey;
            };
            // create a new database of string and list of string type
               DBEngine<string, DBElement<string, List<string>>> newdb =
              new DBEngine<string, DBElement<string, List<string>>>();
            newdb.insert(skeyGen(), newerelem1);
            newdb.insert(skeyGen(), newerelem2);
            newdb.show<string, DBElement<string, List<string>>, List<string>, string>();
            WriteLine();
            // removing element
            WriteLine("removing element ");
            newdb.remove("newerelem2");
            newdb.show<string, DBElement<string, List<string>>, List<string>, string>();

            // testing editing of metadata text
            "testing edits".title();
            db.show<int, DBElement<int, string>, string>();
            DBElement<int, string> editElement = new DBElement<int, string>();
            db.getValue(1, out editElement);
            editElement.showElement<int, string>();
            editElement.name = "editedName";
            editElement.descr = "editedDescription";
            db.show<int, DBElement<int, string>, string>();
            Write("\n\n");
        }
    }
}
