using Models.DAO;
using System.Linq;
using System.Web.Mvc;

namespace ShopPhone.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            var daoPro = new ProductDao();
            var daoImage = new ImageDao();
            ViewData["Item"] = daoPro.GetById(id);
            ViewData["Images"] = daoImage.GetByProID(id).ToList();
            return View();
        }
    }
}