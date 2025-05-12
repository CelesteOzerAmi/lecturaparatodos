using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Senior : Client
    {

        private bool discount;

        public bool Discount { get { return discount; } set { discount = value; } }

        public Senior(int pId, string pName, string pMail, int pPhoneNumber, Subsidiary pSubsidiary, bool pDiscount)
            : base(pId, pName, pMail, pPhoneNumber, pSubsidiary)
        {
            this.discount = pDiscount;
        }


    }
}
