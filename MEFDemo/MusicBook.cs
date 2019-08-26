using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MEFDemo
{
    // Contract name could be same or not, to categorize classes when importing
    [Export("MusicBook", typeof(IBookService))]
    //[Export("MusicBook")] // TAG_TWO: No type specified, force convert when importing
    public class MusicBook : IBookService
    {
        // Export private property
        [Export(typeof(string))]
        private string _privateBookName = "Private Music BookName";
        // Export public property
        [Export(typeof(string))]
        public string _publicBookName = "Public Music BookName";

        public string BookName { get; set; }

        // Export public method
        [Export(typeof(Func<string>))]
        public string GetBookName()
        {
            return "MusicBook";
        }

        // Export private method
        [Export(typeof(Func<int,string>))]
        public string getBookPrice(int price)
        {
            return "$" + price;
        }
    }

    [Export("MusicBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook";
        }
    }

    [Export("MusicBook", typeof(IBookService))]
    public class HistoryBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "HistoryBook";
        }
    }
}
