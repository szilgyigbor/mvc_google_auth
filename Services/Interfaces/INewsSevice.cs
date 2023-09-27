using MVCGoogleAuth.Models;

namespace MVCGoogleAuth.Services.Interfaces
{
    public interface INewsSevice
    {
        List<News> GetNews();

        News GetNewsById(int id);

        News CreateNews(string userName, NewsDTO newsDto);

        News UpdateNews(int id, NewsDTO newsDto);

        bool DeleteNews(int id);
    }
}
