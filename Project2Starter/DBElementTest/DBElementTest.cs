﻿///////////////////////////////////////////////////////////////
// DBElement.cs - Test DBElement and DBExtensions            //
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
 * This package replaces DBElement test stub to remove
 * circular package references.
 *
 * Now this testing depends on the class definitions in DBElement
 * and the extension methods defined in DBExtensions.  We no longer
 * need to define extension methods in DBElement.
 */
 /*
 *Public Interface
 *------------------
 *Main()
 *-used to test the DBElement Package
/*
 * Maintenance:
 * ------------
 * Required Files: 
 *   DBElementTest.cs,  DBElement.cs,Display.cs
 *   DBExtensions.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.1 : 09 Oct 15
 *- added comments
 * ver 1.0 : 24 Sep 15
 * - first release
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project2_code
{
    class DBElementTest
    {
        // Main Method to test the implementation of DBElement Package
        static void Main(string[] args)
        {
            "Testing DBElement Package".title('=');
            WriteLine();

            Write("\n --- Test DBElement<int,string> ---");
            WriteLine();
            // new elements for  int and string database
            DBElement<int, string> elem1 = new DBElement<int, string>();
            Write(elem1.showElement<int, string>());
            WriteLine();

            DBElement<int, string> elem2 = new DBElement<int, string>("Darth Vader", "Evil Overlord");
            elem2.payload = "The Empire strikes back!";
            Write(elem2.showElement<int, string>());
            WriteLine();

            var elem3 = new DBElement<int, string>("Luke Skywalker", "Young HotShot");
            elem3.children = new List<int> { 1, 2, 7 };
            elem3.payload = "X-Wing fighter in swamp - Oh oh!";
            Write(elem3.showElement<int, string>());
            WriteLine();

            Write("\n --- Test DBElement<string,List<string>> ---");
            WriteLine();

            //new elements for  string and list of strings database
            DBElement<string, List<string>> newelem1 = new DBElement<string, List<string>>();
            newelem1.name = "newelem1";
            newelem1.descr = "test new type";
            newelem1.payload = new List<string> { "one", "two", "three" };
            Write(newelem1.showElement<string, List<string>, string>());
            WriteLine();

            DBElement<string, List<string>> newerelem1 = new DBElement<string, List<string>>();
            newerelem1.name = "newerelem1";
            newerelem1.descr = "same stuff";
            newerelem1.children.Add("first_key");
            newerelem1.children.Add("second_key");
            newerelem1.payload = new List<string> { "alpha", "beta", "gamma" };
            newerelem1.payload.AddRange(new[] { "delta", "epsilon" });
            Write(newerelem1.showElement<string, List<string>, string>());
            WriteLine();

            Write("\n\n");
        }
    }
}
