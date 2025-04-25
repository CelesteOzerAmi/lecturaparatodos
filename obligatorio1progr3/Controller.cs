using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorio1progr3
{
    public class Controller
    {
        private static List<Books> mListBooks = new List<Books>();

        public List<Books> ListBooks()
        {
            return mListBooks;
        }

        public bool UploadBook(Books pBook)
        {
            mListBooks.Add(pBook);
            return true;
        }

        #region books menu

        
    #endregion
}
}
