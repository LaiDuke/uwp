using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Repository
{
    class NewsManagements
    {
        private static List<NewsItem> GetNewsItems()
        {
            return new List<NewsItem>()
            {
                new NewsItem()
                {
                    Id = 0,
                    Category = "Food",
                    Headline = "Huấn hoa hồng",
                    Dateline = "",
                    Image = "",
                    Subhead = ""
                },
                new NewsItem()
                {
                    Id = 0,
                    Category = "Food",
                    Headline = "Huấn hoa hồng",
                    Dateline = "",
                    Image = "",
                    Subhead = ""
                },
                new NewsItem()
                {
                    Id = 0,
                    Category = "Food",
                    Headline = "Huấn hoa hồng",
                    Dateline = "",
                    Image = "",
                    Subhead = ""
                }
            };
        }
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            newsItems.Clear();
            var filtered = GetNewsItems().Where(x => x.Category == category).ToList();
            foreach (var item in filtered)
            {
                newsItems.Add(item);
            }
        }
    }
}
