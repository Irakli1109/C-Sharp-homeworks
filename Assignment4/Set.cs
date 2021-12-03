using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public delegate bool F<T>(T elt); //declaring delegate function

    class Set<T> :IEnumerable<T> where T : IComparable<T>//implements IEnumerable to be enumerable by foreach and constraint for T
    {
        public List<T> myList; //generic list container
        public int Count {  //read-only property count
            get
            {
                return myList.Count;
            } 
        }

        public bool IsEmpty //readonly property to check if set is empty
        {
            get
            {
                if (myList.Count == 0)
                    return true;  //empty
                else
                    return false; // not empty
            }
        }
        //default constructor
        public Set()
        {
            myList = new List<T>();
        }
        //explicit value constructor that gets IEnumerable type parameter
        public Set(IEnumerable<T> e)
        {
            myList = new List<T>();
            
            foreach(T item in e)
            {
                if(!this.Contains(item)) //if list does not have this particular item
                    myList.Add(item);
            }
            
        }


        public virtual bool Add(T item) //virtual method add that can be overided in child class
        {
            if (this.Contains(item)) //no same numbers
                return false;

            myList.Add(item); //add number in set
            return true;
        }

        public bool Remove(T item) //remove method
        {
            for (int i = 0; i < myList.Count; i++) //finding index
            {
                if (myList[i].Equals(item))
                {
                    myList.RemoveAt(i); //remove element from that index
                    return true;
                }
            }
            Console.WriteLine($"Could Not Find {item}!"); //no item found
            
            return false;
        }

        public bool Contains(T item) //checks if item is in set
        {
            for (int i = 0; i < myList.Count; i++)
                if (myList[i].Equals(item)) //found
                    return true;
            return false; //could not found
        }

        public static Set<T> operator +(Set<T> lhs, Set<T> rhs) //creating set union
        {
            Set<T> answer = new Set<T>(); //temporary variable with set type
           
            foreach(T item in lhs) //run through lhs
            {
                if(!answer.Contains(item))
                    answer.Add(item); //add items in answer with set rule 
            }

            foreach (T item in rhs) //run through rhs
            {
                if (!answer.Contains(item))
                    answer.Add(item); //add items in answer with set rule
            }

            return answer; //return union of sets
        }

        public Set<T> Filter(F<T> filterFunction) //filter method for filtering set based on delegate
        {
            var filteredSet = new Set<T>(); //yemporary set variable for filtered data
            
            foreach (T item in myList)
            {
                if(filterFunction(item)) //if true than add item in filtered set
                    filteredSet.Add(item);
            }

            return filteredSet; //return filtered data
        }

        private string display() //return string representation of set 
        {
            string temp = ""; //temporary variable
            foreach (var item in myList)
                temp += (item).ToString() + " "; //add itme in string
            return temp;
        }

        public IEnumerator<T> GetEnumerator() //getenumerator returns items from myList
        {
            foreach(var item in myList)
            {
                yield return item; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); //I return getenumerator 
        }

        public override string ToString()
        {
            return display(); //toString calls display function that returns string representation for set
        }
    }

    //SortedSet class inherits from Set
    class SortedSet<T> : Set<T> where T : IComparable<T> //constarint for T
    {

        public SortedSet(): base() { } //default constructor for SortedSet
        public SortedSet(IEnumerable<T> e) //explicit value constructor
        {
            myList = new List<T>();

            foreach (T item in e) //run through e
            {
                if (!this.Contains(item)) //add items according to set rule
                    myList.Add(item);
            }
            myList.Sort(); //sort myList
        }

        public override bool Add(T item) //add function for sortedset
        {

            if (this.IsEmpty) //if there is no element in set add this item
                myList.Add(item);
            else
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i].CompareTo(item) == 0) //if item is in list do not add again
                        return false;
                    else
                    {
                        if (myList[i].CompareTo(item) == 1) //myList[i] > item
                        {
                            //index was found
                            myList.Insert(i, item); //insert at this index
                            return true;
                        }
                        
                    }

                }
                myList.Add(item); //add item at the back if it is largest
            }
            
            return true;
        }
        public static SortedSet<T> operator +(SortedSet<T> lhs, SortedSet<T> rhs) //union for sortedsets
        {
            SortedSet<T> answer = new SortedSet<T>(); //temporary srotedset container

            foreach (T item in lhs.myList)
            {
                if (!answer.Contains(item)) //if item is not in lhs than add it in answer
                    answer.Add(item);
            }

            foreach (T item in rhs.myList) //if item is not in rhs than add it in answer
            {
                if (!answer.Contains(item))
                    answer.Add(item);
            }
            //answer.myList.Sort();
            return answer;
        }

        public new SortedSet<T> Filter(F<T> filterFunction) //filter function for SortedSet
        {
            var filteredSortedSet = new SortedSet<T>(); //filteredSortedSet container 

            foreach (T item in myList)
            {
                if (filterFunction(item)) //fillter according to delegate
                    filteredSortedSet.Add(item);
            }

            return filteredSortedSet; //return filtered Sorted Set
        }
    }
}
