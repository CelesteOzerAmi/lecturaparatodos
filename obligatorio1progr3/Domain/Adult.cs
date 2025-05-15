using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Adult : Client
    {

        public Adult(int pId, string pName, string pMail, int pPhoneNumber, Subsidiary pSubsidiary) 
            : base(pId, pName, pMail, pPhoneNumber, pSubsidiary, "Adult")
        {
        }

        public override string ToString()
        {
            return $"id: {this.Id}, nombre: {this.Name}, teléfono: {this.PhoneNumber}";
        }
    }
}
