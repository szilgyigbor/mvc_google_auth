using MVCGoogleAuth.Models;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth.Services
{
    public class NewsService: INewsService
    {
        public static List<News> AllNews = new List<News>();

        public List<News> GetNews()
        {
            return AllNews;
        }

        public News GetNewsById(int id)
        {
            return AllNews.SingleOrDefault(n => n.Id == id)!;
        }

        public News CreateNews(string userName, NewsDTO newsDto)
        {
            int newId = AllNews.Count + 1;

            while (AllNews.Any(n => n.Id == newId))
            {
                newId++;
            }

            News news = new News
            {
                Title = newsDto.Title!,
                Content = newsDto.Content!,
                ImageUrl = newsDto.ImageUrl!,
                Author = userName!
            };

            news.Id = newId;

            news.DateCreated = DateTime.Now;
            news.DateModified = DateTime.Now;

            AllNews.Add(news);

            return news;
        }

        public News UpdateNews(int id, NewsDTO newsDto)
        {
            News ThisNews = AllNews.SingleOrDefault(n => n.Id == id)!;
            ThisNews.Title = newsDto.Title;
            ThisNews.Content = newsDto.Content;
            ThisNews.ImageUrl = newsDto.ImageUrl;
            ThisNews.DateModified = DateTime.Now;
            
            return ThisNews;
        }

        public bool DeleteNews(int id)
        {
            News ThisNews = AllNews.SingleOrDefault(n => n.Id == id);
            if (ThisNews == null)
            {
                return false;
            }
            AllNews.Remove(ThisNews);
            return true;
        }
    }
}
