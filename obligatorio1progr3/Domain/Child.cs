using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Child : Client
    {

        private bool authorization;

        public bool Authorization { get { return authorization; } set { authorization = value; } }  

        public Child(int pId, string pName, string pMail, int pPhoneNumber, Subsidiary pSubsidiary, bool pAuthorization)
            : base(pId, pName, pMail, pPhoneNumber, pSubsidiary)
        {
            this.authorization = pAuthorization;
        }

       
    }
}
