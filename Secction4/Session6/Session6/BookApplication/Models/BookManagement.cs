using System.Collections.Generic;

namespace BookApplication.Models
{
    public class BookManagement
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book(){ Id=1,Title="The end of the ocean",Author="Maja Lunde",CoverImage="ms-appx:///Assets/Books/1.jpg"},
                new Book(){ Id=2,Title="Creative Business Startup",Author="Zel Brarel",CoverImage="ms-appx:///Assets/Books/2.jpg"},
                new Book(){ Id=3,Title="Graphic Girls",Author="Rodgiguez",CoverImage="ms-appx:///Assets/Books/3.jpg"}
            };
        }
    }
}
