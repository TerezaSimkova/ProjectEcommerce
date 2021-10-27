using ProjectEcommerce.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.CORE.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryProdotto prodottoRepo;

        public BusinessLayer(IRepositoryProdotto prodotto)
        {
            prodottoRepo = prodotto;

        }

        public List<Prodotto> GetAllProdotti()
        {
            return prodottoRepo.GetAll();
        }

        public bool InserisciNuovoProdotto(Prodotto prodotto)
        {
            Prodotto pro = prodottoRepo.GetAll().FirstOrDefault(p => p.CodiceProdotto == prodotto.CodiceProdotto);
            if (pro != null)
            {
                return false;
            }
            prodottoRepo.Add(prodotto);
            return true;
        }

        public bool ModificaProdotto(string codiceProdotto, string descrizione, decimal prezzoAlPubblico, Prodotto.EnumTipologia tipologia)
        {
            prodottoRepo.UpdateProdotto(codiceProdotto, descrizione, prezzoAlPubblico, tipologia);
            return true;
        }
    }
}
