using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3
{
    public class Subsidiary
    {
        private int id;
        private string name;
        private string city;
        private string address;
        private Manager manager;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Address { get { return address; } set { address = value; } }
        public Manager Manager { get { return manager; } set { manager = value; } }

        public Subsidiary(int pId, string pName, string pCity, string pAddress, Manager pManager)
        {
            this.id = pId;
            this.name = pName;
            this.city = pCity;
            this.address = pAddress;
            this.manager = pManager;
        }

    }
}
