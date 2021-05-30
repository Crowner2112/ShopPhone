using Models.DAO;
using Models.EF;
using ShopPhone.Common;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            var model = new Account();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                account.Password = Encryptor.MD5Hash(account.Password);
                account.Role = false;
                var result = dao.Create(account);
                if (!result)
                {
                    return new ContentResult()
                    {
                        Content = "<script language='javascript' type='text/javascript'>alert('Đăng ký thất bại!');location.href='/Admin/Login'</script>"
                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "<script language='javascript' type='text/javascript'>alert('Đăng ký thành công!');location.href='/Admin/Login'</script>"
                    };
                }
            }
            else
            {
                return new ContentResult()
                {
                    Content = "<script language='javascript' type='text/javascript'>alert('Đăng ký thất bại!');location.href='/Admin/Login'</script>"
                };
            }
        }
    }
}