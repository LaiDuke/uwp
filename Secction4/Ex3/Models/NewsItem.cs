using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models
{
    class NewsItem
    {
        public int Id { get; set; }
        public String Category { get; set; }
        public String Headline { get; set; }
        public String Subhead { get; set; }
        public String Dateline { get; set; }
        public String Image { get; set; }
    }
}
