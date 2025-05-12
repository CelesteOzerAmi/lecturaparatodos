using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Client
    {
        private int id;
        private string name;
        private string mail;
        private int phoneNumber;
        private Subsidiary subsidiary;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Mail { get => mail; set => mail = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public Subsidiary Subsidiary { get => subsidiary; set => subsidiary = value; }

        public Client(int pId, string pName, string pMail, int pPhoneNumber, Subsidiary pSubsidiary)
        {
            this.id = pId;
            this.name = pName;
            this.mail = pMail;
            this.phoneNumber = pPhoneNumber;
            this.subsidiary = pSubsidiary;
        }
    }
}
