using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class OrderDetailDao : IRepository<OrderDetail>
    {
        public static ShopPhoneDbContext db = null;
        public OrderDetailDao()
        {
            db = new ShopPhoneDbContext();
        }
        public bool Create(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
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
                var entity = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<OrderDetail> ListAllPaging(int page, int pageSize)
        {
            IQueryable<OrderDetail> model = db.OrderDetails;
            return model.OrderBy(x => x.OrderID).ToPagedList(page, pageSize);
        }

        public IEnumerable<OrderDetail> ListAllPaging(int orderId, int page, int pageSize)
        {
            IQueryable<OrderDetail> model = db.OrderDetails;
            return model.Where(x => x.OrderID == orderId).OrderBy(x => x.OrderID).ToPagedList(page, pageSize);
        }

        public bool Update(OrderDetail entity)
        {
            return false;
        }
    }
}
