using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class OrderDao : IRepository<Order>
    {
        public static ShopPhoneDbContext db = null;
        public OrderDao()
        {
            db = new ShopPhoneDbContext();
        }
        public int Insert(Order entity)
        {
            try
            {
                db.Orders.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public bool Create(Order entity)
        {
            try
            {
                db.Orders.Add(entity);
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
                var entity = db.Orders.Find(id);
                db.Orders.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Order> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public Order ViewDetail(int id)
        {
            return db.Orders.FirstOrDefault(x => x.ID == id);
        }

        public bool Update(Order entity)
        {
            try
            {
                var oldOrder = db.Orders.Find(entity.ID);
                oldOrder.OwnerName = entity.OwnerName;
                oldOrder.PhoneNumber = entity.PhoneNumber;
                oldOrder.Address = entity.Address;
                oldOrder.Status = entity.Status;
                oldOrder.OrderDetails = entity.OrderDetails;
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
