using MVCGoogleAuth.Models;


namespace MVCGoogleAuth.Services
{
    public class NewsService
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

        public News CreateNewsAsync(News news)
        {
            int newId = AllNews.Count + 1;

            while (AllNews.Any(n => n.Id == newId))
            {
                newId++;
            }

            news.Id = newId;

            AllNews.Add(news);

            return news;
        }

        public News UpdateNewsAsync(News news)
        {
            News ThisNews = AllNews.SingleOrDefault(n => n.Id == news.Id)!;
            ThisNews.Title = news.Title;
            ThisNews.Content = news.Content;
            ThisNews.ImageUrl = news.ImageUrl;
            ThisNews.DateModified = DateTime.Now;
            
            return news;
        }

        public bool DeleteNewsAsync(int id)
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
