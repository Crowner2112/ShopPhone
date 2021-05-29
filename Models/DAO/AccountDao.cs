using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class AccountDao : IRepository<Account>
    {
        public static ShopPhoneDbContext db = null;
        public AccountDao()
        {
            db = new ShopPhoneDbContext();
        }
        public IEnumerable<Account> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Account> model = db.Accounts;
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public Account GetByEmail(string email)
        {
            return db.Accounts.SingleOrDefault(x => x.Email == email);
        }
        public Account GetById(int id)
        {
            return db.Accounts.Find(id);
        }
        public object ViewDetail(int id)
        {
            return db.Accounts.Find(id);
        }

        public bool Create(Account entity)
        {
            try
            {
                db.Accounts.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Account entity)
        {
            try
            {
                var oldAcc = db.Accounts.Find(entity.ID);
                oldAcc.Name = entity.Name;
                oldAcc.PhoneNumber = entity.PhoneNumber;
                oldAcc.Email = entity.Email;
                oldAcc.Address = entity.Address;
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
                var acc = db.Accounts.Find(id);
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int Login(string email, string passWord)
        {
            var result = db.Accounts.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0; //wrong email
            }
            else
            {
                if (result.Password == passWord)
                {
                    if (result.Role == true) return 1; //admin
                    else return -2; //customer
                }
                else
                {
                    return -1; //wrong password
                }
            }
        }
    }
}
