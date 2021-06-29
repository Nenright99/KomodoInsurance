using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers
{
    public class DevRepo
    {
        //Initiate repository
        protected readonly List<Devs> _devDirectory = new List<Devs>();

        //Create
        public bool AddDeveloper(Devs newDev)
        {
            int count = _devDirectory.Count();
            _devDirectory.Add(newDev);
            bool wasAdded = (_devDirectory.Count > count) ? true : false;
            return wasAdded;
        }

        //Read

        public List<Devs> ReturnAll()
        {
            return _devDirectory;
        }
        public void DisplayAll()
        {
            foreach(Devs dev in _devDirectory)
            {
                string devInfo = $"{dev.ID.ToString()} {dev.FullName}; Access to Pluralsight: {dev.AccessPluralsight.ToString()}";
                Console.WriteLine(devInfo);
            }
        }

        public Devs GetByID(int ID)
        {
            foreach(Devs dev in _devDirectory)
            {
                if (dev.ID == ID)
                {
                    return dev;
                }
            }
                return null;
        }

        //Update
        public bool UpdateDev(int ID, Devs updatedDev)
        {
            Devs oldInfo = GetByID(ID);
            if (oldInfo != null)
            {
                oldInfo.ID = updatedDev.ID;
                oldInfo.FirstName = updatedDev.FirstName;
                oldInfo.LastName = updatedDev.LastName;
                oldInfo.AccessPluralsight = updatedDev.AccessPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDev(Devs dev)
        {
            bool removeResult = _devDirectory.Remove(dev);
            return removeResult;
        }

    }
}
