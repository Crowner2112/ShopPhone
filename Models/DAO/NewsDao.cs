using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class NewsDao : IRepository<News>
    {
        public static ShopPhoneDbContext db = null;
        public NewsDao()
        {
            db = new ShopPhoneDbContext();
        }

        public bool Create(News entity)
        {
            try
            {
                db.News.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object ViewDetail(int id)
        {
            return db.News.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = db.News.Find(id);
                db.News.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<News> ListAllPaging(int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Update(News entity)
        {
            try
            {
                var oldNews = db.News.Find(entity.ID);
                oldNews.Title = entity.Title;
                oldNews.Discription = entity.Discription;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
