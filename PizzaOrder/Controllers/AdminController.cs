using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Dao;
using DataAccess.Model;

namespace PizzaOrder.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            PizzaDao pizzaDao = new PizzaDao();
            IList<Pizza> pizzas = pizzaDao.GetAll();

            return View(pizzas);
        }

        public ActionResult Create()
        {
            IngredienceDao ingredienceDao = new IngredienceDao();
            IList<Ingredience> categories = ingredienceDao.GetAll();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Pizza pizza, int ingredienceId)
        {
            if (ModelState.IsValid)
            {
                IngredienceDao ingredienceDao = new IngredienceDao();
                Ingredience ingredience = ingredienceDao.GetById(ingredienceId);
                pizza.Ingredience = ingredience;


                PizzaDao pizzaDao = new PizzaDao();
                pizzaDao.Create(pizza);

                TempData["message-success"] = "Pizza byla uspesne pridana";

            }
            else
            {
                TempData["message-error"] = "Pizza se nepridala";
                return View("Create", pizza);
            }


            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            PizzaDao pizzaDao = new PizzaDao();
            IngredienceDao ingredienceDao = new IngredienceDao();

            Pizza p = pizzaDao.GetById(id);
            ViewBag.Categories = ingredienceDao.GetAll();

            return View(p);
        }

        public ActionResult Update(Pizza pizza, int ingredienceId)
        {
            try
            {
                PizzaDao pizzaDao = new PizzaDao();
                IngredienceDao ingredienceDao = new IngredienceDao();
                Ingredience ingredience = ingredienceDao.GetById(ingredienceId);
                pizza.Ingredience = ingredience;

                pizzaDao.Update(pizza);

                TempData["message-success"] = "Pizza " + pizza.Name + " byla upravena";
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index", "Admin");
        }


        public ActionResult Delete(int id)
        {
            try
            {
                PizzaDao pizzaDao = new PizzaDao();
                Pizza pizza = pizzaDao.GetById(id);

                pizzaDao.Delete(pizza);

                TempData["message-success"] = "Pizza " + pizza.Name + " byla smazana";
            }
            catch (Exception exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }


    }
}