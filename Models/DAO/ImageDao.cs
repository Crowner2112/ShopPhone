using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class ImageDao : IRepository<Image>
    {
        public static ShopPhoneDbContext db = null;
        public ImageDao()
        {
            db = new ShopPhoneDbContext();
        }
        public bool Create(Image entity)
        {
            try
            {
                db.Images.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Image> GetAll()
        {
            return db.Images.Where(x => x.MainPic == true).ToList();
        }
        public IEnumerable<Image> GetAllByCategoryId(int id)
        {
            return db.Images.Where(x => x.MainPic == true && x.Product.Brand.CategoryID == id).ToList();
        }
        public IEnumerable<Image> GetByProID(int proID)
        {
            return db.Images.Where(x => x.ProductID == proID);
        }
        public Image GetMainPicByProID(int proID)
        {
            return db.Images.FirstOrDefault(x => x.ProductID == proID && x.MainPic == true);
        }
        public bool Delete(int id)
        {
            try
            {
                var entity = db.Images.Find(id);
                db.Images.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Image ViewDetail(int id)
        {
            return db.Images.Find(id);
        }

        public IEnumerable<Image> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Image> model = db.Images;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Update(Image entity)
        {
            try
            {
                var oldProd = db.Images.Find(entity.ID);
                oldProd.Link = entity.Link;
                oldProd.ProductID = entity.ProductID;
                oldProd.MainPic = entity.MainPic;
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
