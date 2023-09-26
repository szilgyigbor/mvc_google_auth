using MVCGoogleAuth.Models;

namespace MVCGoogleAuth.Services.Interfaces
{
    public interface INewsSevice
    {
        News GetNewsById(int id);

        News CreateNewsAsync(News news);

        News UpdateNewsAsync(News news);

        bool DeleteNewsAsync(int id);
    }
}
