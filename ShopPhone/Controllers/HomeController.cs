using Models.DAO;
using Models.EF;
using ShopPhone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopPhone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var daoCategory = new CategoryDao();
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                Session["CountCart"] = 0;
            }
            else
            {
                Session["CountCart"] = cart.Items.Count();
            }
            ViewData["Category"] = daoCategory.GetAll();
            var daoImage = new ImageDao();
            if (daoImage.GetAll() != null)
            {
                ViewData["Product"] = daoImage.GetAll();
            }
            else
            {
                ViewData["Product"] = new List<Image>();
                ViewData["Slide"] = new List<Image>();
            }
            return View();
        }
    }
}