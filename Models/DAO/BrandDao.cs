using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class BrandDao : IRepository<Brand>
    {
        public static ShopPhoneDbContext db = null;
        public BrandDao()
        {
            db = new ShopPhoneDbContext();
        }
        public bool Create(Brand entity)
        {
            try
            {
                db.Brands.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Brand ViewDetail(int id)
        {
            return db.Brands.Find(id);
        }

        public IEnumerable<Brand> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Brand> model = db.Brands;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool Update(Brand entity)
        {
            try
            {
                var oldBrand = db.Brands.Find(entity.ID);
                oldBrand.Name = entity.Name;
                oldBrand.Products = entity.Products;
                oldBrand.Status = entity.Status;
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
                var entity = db.Brands.Find(id);
                db.Brands.Remove(entity);
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
