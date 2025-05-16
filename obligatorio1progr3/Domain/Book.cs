using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3.Domain
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _author;
        private Genre _genre;
        private int _year;
        private Subsidiary _subsidiary;
        private bool _available;

        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public Genre Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Subsidiary Subsidiary
        {
            get { return _subsidiary; }
            set { _subsidiary = value; }
        }

        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }


        public Book(int pId, string pTitle, string pAuthor, Genre pGenre, int pYear, Subsidiary pSubsidiary, bool pAvailable)
        {
            _id = pId;
            _title = pTitle;
            _author = pAuthor;
            _genre = pGenre;
            _year = pYear;
            _subsidiary = pSubsidiary;
            _available = pAvailable;
        }
    }
}
