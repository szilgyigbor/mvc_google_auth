﻿using MVCGoogleAuth.Models;
using MVCGoogleAuth.Services.Interfaces;

namespace MVCGoogleAuth.Services
{
    public class NewsService: INewsSevice
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

        public News UpdateNews(News news)
        {
            News ThisNews = AllNews.SingleOrDefault(n => n.Id == news.Id)!;
            ThisNews.Title = news.Title;
            ThisNews.Content = news.Content;
            ThisNews.ImageUrl = news.ImageUrl;
            ThisNews.DateModified = DateTime.Now;
            
            return news;
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
