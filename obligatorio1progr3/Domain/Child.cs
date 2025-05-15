using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Child : Client
    {

        private bool authorized;

        public bool Authorized { get { return authorized; } set { authorized = value; } }  

        public Child(int pId, string pName, string pMail, int pPhoneNumber, Subsidiary pSubsidiary, bool pAuthorized)
            : base(pId, pName, pMail, pPhoneNumber, pSubsidiary, "Child")
        {
            this.authorized = pAuthorized;
        }

       
    }
}
