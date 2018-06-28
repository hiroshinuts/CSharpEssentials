using DropDownList_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownList_Ajax.Controllers
{

    // LINK STACKOVERFLOW --https://stackoverflow.com/questions/22295191/i-want-to-fill-city-dropdown-automatically-from-database-according-to-state-drop

    public class HomeController : Controller
    {
        private void LoadDDLBancoDados()
        {
            //Lista que pegarei do BD
            List<InfoBd> listaInfoBd = new List<InfoBd>()
            {
                new InfoBd{ID = 1, NAME = "Babara"},
                new InfoBd{ID = 2, NAME = "Duko" },
                new InfoBd{ID = 3, NAME = "Doren"},
                new InfoBd{ID = 4, NAME = "Niko" },
                new InfoBd{ID = 2, NAME = "Mavin" }
            };                     

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var itemListaBd in listaInfoBd)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = itemListaBd.ID.ToString();
                sli.Value = itemListaBd.NAME;

                items.Add(sli);
            }

            ViewBag.ItensDDLBD = items;
        }

        [HttpPost]
        public JsonResult LoadDDLStringPosicao(string itemSelecionado)
        {
            //Item selecionado é o item para buscar na tabela
            //https://stackoverflow.com/questions/19737509/cant-use-returned-list-from-ajax-call

            List<string> listaString = new List<string>();

            listaString.Add("RetornoBdBabara");
            listaString.Add("RetornoBdDuko");
            listaString.Add("RetornoBdDoren");
            listaString.Add("RetornoPopops");

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var itemListaBd in listaString)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = itemListaBd;
                sli.Text = itemListaBd;

                items.Add(sli);
            }
                ViewBag.ItensDDLAJAX = items;

            return Json(listaString, JsonRequestBehavior.AllowGet);

        }
        
        // GET: Home
        public ActionResult Index()
        {
            LoadDDLBancoDados();

            return View();
        }

        [HttpPost]
        public ActionResult ChamaDDL(string ItemSelecionadoDoPrimeiroDDL)
        {
            LoadDDLBancoDados();
            ViewBag.Dados = LoadDDLStringPosicao(ItemSelecionadoDoPrimeiroDDL);


            return View("Index", ViewBag.Dados);
        }

    }
}