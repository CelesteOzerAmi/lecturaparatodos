using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Rental
    {
        private int id;
        private Client client;
        private string clientType;
        private Book book;
        private DateTime startDate;
        private DateTime endDate;
        private bool returned;

        public int Id { get => id; set => id = value; }
        public Client Client { get => client; set => client = value; }
        public string ClientType { get => clientType; set => clientType = value; }
        public Book Book { get => book; set => book = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public bool Returned { get => returned; set => returned = value; }

        public Rental(int pId, Client pClient, string pClientType, Book pBook, DateTime pStartDate, DateTime pEndDate, bool pReturned)
        {
            this.id = pId;
            this.client = pClient;
            this.clientType = pClientType;
            this.book = pBook;
            this.startDate = pStartDate;
            this.endDate = pEndDate;
            this.returned = pReturned;
        }
    }
}
