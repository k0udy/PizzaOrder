using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;
using DataAccess.Model;

namespace PizzaOrder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            PizzaDao pizzaDao = new PizzaDao();
            IList<Pizza> pizzas = pizzaDao.GetAll();

            return View(pizzas);
        }

    }
}