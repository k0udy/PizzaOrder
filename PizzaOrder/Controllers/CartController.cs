using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;
using DataAccess.Model;

namespace PizzaOrder.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {

            return View();
        }

        
        public ActionResult AddToCart(int id)
        {
            PizzaDao pizzaDao = new PizzaDao();
            Pizza p = pizzaDao.GetById(id);

            Order order = new Order
            {
                Id = p.Id,
                OrderDate = System.DateTime.Now,
                OrderedPizza = p.Name,
                Price = p.Price,
                CustomerAddress = "",
                CustomerName = "",
                PizzaCount = 1
            };
            TempData["myOrder"] = order;

            return View(order);
        }

        public ActionResult RemoveFromCart()
        {

            return RedirectToAction("Index");
        }

        public ActionResult FinishingOrder()
        {
            if (TempData["myOrder"] != null)
            {
                Order order = new Order();
                order = (Order) TempData["myOrder"];

                return View(order);
            }
            else return View();
        }

        [HttpPost]
        public ActionResult SendingOrder(Order order)
        {
            if (order != null)
            {
                int id = order.Id;
                DateTime orderDate = order.OrderDate;
                string orderedPizza = order.OrderedPizza;
                int pizzaCount = order.PizzaCount;
                string price = order.Price.ToString("##.###");
                string customerName = order.CustomerName;
                string customerAddress = order.CustomerAddress;

                System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\objednavka.txt");
                file.WriteLine("ID objednavky: " + id);
                file.WriteLine("Datum objednavky: " + orderDate);
                file.WriteLine("Nazev pizzy: " + orderedPizza);
                file.WriteLine("Pocet pizz: " + pizzaCount);
                file.WriteLine("Celkova cena: " + price + "Kc");
                file.WriteLine("Jmeno zakaznika: " + customerName);
                file.WriteLine("Adresa zakaznika: " + customerAddress);
                
                file.Close();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}