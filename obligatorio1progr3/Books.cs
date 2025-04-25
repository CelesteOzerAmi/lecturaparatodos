using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3
{
    public class Books
    {
        private int _id;
        private string _title;
        private string _author;
        private string _genre;
        private int _year;
        private string _subsidiary;
        private string _state;

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

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Subsidiary
        {
            get { return _subsidiary; }
            set { _subsidiary = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        public Books(int pId, string pTitle, string pAuthor, string pGenre, int pYear, string pSubsidiary, string pState)
        {
            _id = pId;
            _title = pTitle;
            _author = pAuthor;
            _genre = pGenre;
            _year = pYear;
            _subsidiary = pSubsidiary;
            _state = pState;
        }
    }
}
