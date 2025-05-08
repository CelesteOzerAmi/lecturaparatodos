using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Genre
    {
        private int id;
        private string name;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Genre(int pId, string pName)
        {
            this.id = pId;
            this.name = pName;
        }
    }
}
