using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Manager
    {
        private int id;
        private string name;
        private int phoneNumber;

        public int Id { get { return id; }  set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public Manager(int pId, string pName, int pPhoneNumber)
        {
            this.id = pId;
            this.name = pName;
            this.phoneNumber = pPhoneNumber;
        }
    }
}
