using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class ProductDao : IRepository<Product>
    {
        public static ShopPhoneDbContext db = null;
        public ProductDao()
        {
            db = new ShopPhoneDbContext();
        }
        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }
        public bool Create(Product entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = db.Products.Find(id);
                db.Products.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Update(Product entity)
        {
            try
            {
                var oldProd = db.Products.Find(entity.ID);
                oldProd.Name = entity.Name;
                oldProd.Price = entity.Price;
                oldProd.Warranty = entity.Warranty;
                oldProd.Discription = entity.Discription;
                oldProd.BrandID = entity.BrandID;
                oldProd.Status = entity.Status;
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
