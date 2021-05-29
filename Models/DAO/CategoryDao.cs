using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class CategoryDao : IRepository<Category>
    {
        public static ShopPhoneDbContext db = null;
        public CategoryDao()
        {
            db = new ShopPhoneDbContext();
        }
        public bool Create(Category entity)
        {
            try
            {
                db.Categories.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Category> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category ViewDetail(int id)
        {
            return db.Categories.FirstOrDefault(x => x.ID == id);
        }
        public bool Update(Category entity)
        {
            try
            {
                var oldCategory = db.Categories.Find(entity.ID);
                oldCategory.Name = entity.Name;
                oldCategory.Brands = entity.Brands;
                oldCategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var Category = db.Categories.Find(id);
                db.Categories.Remove(Category);
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
