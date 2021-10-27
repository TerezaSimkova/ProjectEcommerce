using ProjectEcommerce.CORE;
using ProjectEcommerce.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEcommerce.EF
{
    public class RepositoryProdottoEF : IRepositoryProdotto
    {
        private readonly ProdottoContext pxt;

        public RepositoryProdottoEF()
        {
            pxt = new ProdottoContext();
        }
        public Prodotto Add(Prodotto prodotto)
        {
            pxt.Prodotti.Add(prodotto);
            pxt.SaveChanges();
            return prodotto;
        }

        public bool Delete(Prodotto prodotto)
        {
            pxt.Prodotti.Remove(prodotto);
            pxt.SaveChanges();
            return true;
        }

        public List<Prodotto> GetAll()
        {
            return pxt.Prodotti.ToList();
        }

        public Prodotto Update(Prodotto prodotto)
        {
            var oldProdotto = pxt.Prodotti.FirstOrDefault(p => p.Id == prodotto.Id);
            oldProdotto.Descrizione = prodotto.Descrizione;
            oldProdotto.PrezzoAlPubblico = prodotto.PrezzoAlPubblico;
            oldProdotto.Tipologia = prodotto.Tipologia;
            pxt.SaveChanges();
            return prodotto;
        }

        public void UpdateProdotto(string codiceProdotto, string descrizione, decimal prezzoAlPubblico, Prodotto.EnumTipologia tipologia)
        {
            var oldProdotto = pxt.Prodotti.FirstOrDefault(p => p.CodiceProdotto == codiceProdotto);
            oldProdotto.Descrizione = descrizione;
            oldProdotto.PrezzoAlPubblico = prezzoAlPubblico;
            oldProdotto.Tipologia = tipologia;
            pxt.SaveChanges();
        }
    }
}
