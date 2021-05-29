using Models.DAO;
using Models.EF;
using ShopPhone.Common;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new AccountDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var Account = new AccountDao().ViewDetail(id);
            return View(Account);
        }
        [HttpPost]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                account.Password = Encryptor.MD5Hash(account.Password);
                var id = dao.Create(account);
                if (id)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Add Account successfully");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AccountDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Account Account)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                var result = dao.Update(Account);
                if (result)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Modify successfully");
                }
            }
            return RedirectToAction("Index");
        }
    }
}