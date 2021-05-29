using Models.DAO;
using System.Web.Mvc;

namespace ShopPhone.Controllers
{
    public class CategoryProductController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            var daoCategory = new CategoryDao();
            ViewData["Category"] = daoCategory.GetAll();
            var daoImage = new ImageDao();
            var model = daoImage.GetAllByCategoryId(id);
            return View(model);
        }
    }
}