using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers
{
    public class Devs
    {
        //constructors
        public Devs() { }
        public Devs(int iD, string firstName, string lastName, bool accessPluralsight)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            AccessPluralsight = accessPluralsight;
        }

        //properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = LastName + ", " + FirstName;
                return fullName;
            }
        }
        public bool AccessPluralsight { get; set; }
    }
}
