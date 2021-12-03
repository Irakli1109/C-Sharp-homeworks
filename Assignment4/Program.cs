using System;
using System.Collections.Generic;
/*
 * Irakli Turabelidze
 * RedId: 824657178
 * 30 November, 2021
 */

namespace Assignment4

{
    class Program
    {
        //expression bodied methodes for filtering 
        static bool RemoveOdds(int val) => (val % 2 == 0) ? true : false;
        static bool RemoveEvens(int val) => (val % 2 == 0) ? false : true;
        
        static void Main(string[] args)
        { //create built in lists
            List<int> list1 = new List<int>() { 6,3,2,5,1,4};
            List<int> list2 = new List<int>() { 23,45,11,22,8};
            List<int> list3 = new List<int>() { 0,-3,1,5,9,2,0};
            List<string> list4 = new List<string>() { "Luka","Sandro","Nika","Giorgi", "Nino"};
            
            //cretae my own sets with deafault and explicit constructors
            Set<int> set1 = new Set<int>(list1);
            Set<int> set2 = new Set<int>(list2);
            Set<int> set3 = new Set<int>();
            Set<string> set4 = new Set<string>(list4);

            //cretae my own sortedsets with deafault and explicit constructors
            SortedSet<int> sortedset1 = new SortedSet<int>(list1);
            SortedSet<int> sortedset2 = new SortedSet<int>(list2);
            SortedSet<int> sortedset3 = new SortedSet<int>();
            SortedSet<string> sortedset4 = new SortedSet<string>(list4);

            //below is testing for functionality
            Console.Write("set1:       ");
            Console.WriteLine(set1);
            Console.Write("sortedset1: ");
            Console.WriteLine(sortedset1);

            Console.WriteLine();

            Console.Write("set2:       ");
            Console.WriteLine(set2);
            Console.Write("sortedset2: ");
            Console.WriteLine(sortedset2);

            //adding elemetns in set3
            set3.Add(10);
            set3.Add(9);
            set3.Add(8);
            set3.Add(7);
            set3.Add(6);

            //adding elemetns in sortedset3
            sortedset3.Add(10);
            sortedset3.Add(9);
            sortedset3.Add(8);
            sortedset3.Add(7);
            sortedset3.Add(6);

            Console.WriteLine();
            
            //output new set3 and sortedset3
            Console.Write("set3:       ");
            Console.WriteLine(set3);
            Console.Write("sortedset3: ");
            Console.WriteLine(sortedset3);

            //remove 8 from set3 ad output
            Console.WriteLine("\nRemove 8 from set3");
            set3.Remove(8);
            Console.WriteLine(set3);

            //remove 8 from sortedset3 ad output
            Console.WriteLine("\nRemove 8 from sortedset3");
            sortedset3.Remove(8);
            Console.WriteLine(sortedset3);

            //remove even numbers from sortedset1
            Console.WriteLine("\nRemove evens numbers from sortedset1");
            sortedset1 = sortedset1.Filter(RemoveEvens);
            Console.WriteLine(sortedset1);

            //remove even numbers from sortedset2
            Console.WriteLine("\nRemove odds numbers from sortedset2");
            sortedset2 = sortedset2.Filter(RemoveOdds);
            Console.WriteLine(sortedset2);

            //check if containers contain value 3
            Console.WriteLine("\nDoes sortedset1 contains 3 " + sortedset1.Contains(3));
            Console.WriteLine("Does sortedset2 contains 3 " + sortedset2.Contains(3));

            //showing that set can store strings as well because it is generic
            Console.WriteLine("\nset4       - " + set4);
            Console.WriteLine("sortedset4 - " + sortedset4);

            Console.WriteLine();
            //here is examples for unions
            set1 = set1 + set2 + set3;
            Console.WriteLine("Unions of all sets: " + set1);

            sortedset1 = sortedset1 + sortedset2 + sortedset3;
            Console.WriteLine("Unions of all sortedsets: " + sortedset1);
        }
    }
}
