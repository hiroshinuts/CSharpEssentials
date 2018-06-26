using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AjaxDropDownList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> listaString = new List<string>();

            listaString.Add("Primeiro Item");
            listaString.Add("Segundo Item");
            listaString.Add("Terceiro Item");
            listaString.Add("Quarto Item");
            listaString.Add("Quinto Item");

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var itemDdl in listaString)
            {               
               items.Add(new SelectListItem { Text = itemDdl, Value = itemDdl });
            }
                                 
            return View();
        }

        public ActionResult Cadastra(string ddl2)
        {

           

            return View();
        }
    }
}