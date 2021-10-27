using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectEcommerce.CORE.BusinessLayer;
using ProjectEcommerce.MVC.Mapping;
using ProjectEcommerce.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEcommerce.MVC.Controllers
{
    public class ProdottiController : Controller
    {
        private readonly IBusinessLayer BL;
        //costruttore
        public ProdottiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var prodotti = BL.GetAllProdotti();

            List<ProdottoViewModel> prodottoViewModels = new List<ProdottoViewModel>();

            foreach (var item in prodotti)
            {
                prodottoViewModels.Add(item.ToProdottoViewModel());
            }

            return View(prodottoViewModels);
        }
        [HttpGet("Prodotti/Details/{id}")]
        public IActionResult Details(int id)
        {
            var prodotto = BL.GetAllProdotti().FirstOrDefault(c => c.Id == id);

            var prodottoViewModel = prodotto.ToProdottoViewModel();
            return View(prodottoViewModel);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(ProdottoViewModel prodottoViewModel)
        {
            if (ModelState.IsValid) 
            {
                var prodotto = prodottoViewModel.ToProdotto();
                BL.InserisciNuovoProdotto(prodotto);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(prodottoViewModel);
        }
        #endregion

        #region Update
        [HttpGet("Prodotti/Update/{codiceProdotto}")]
        public IActionResult Update(string codiceProdotto)
        {
            var prodotto = BL.GetAllProdotti().Find(s => s.CodiceProdotto == codiceProdotto);
            var conversione = prodotto.ToProdottoViewModel();
            return View(conversione);
        }
        [HttpPost]
        public IActionResult Update(ProdottoViewModel prodottoViewModel)
        {
            if (ModelState.IsValid)
            {
                var prodotto = prodottoViewModel.ToProdotto();
                BL.ModificaProdotto(prodotto.CodiceProdotto, prodotto.Descrizione, prodotto.PrezzoAlPubblico,prodotto.Tipologia);
                return RedirectToAction(nameof(Index));
            }
            return View(prodottoViewModel);
        }
        #endregion

        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value=1, Text="Elettronica"},
                new { Value=1, Text="Abbigliamento"},
                new { Value=3, Text="Casalinghi"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
