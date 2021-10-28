using ProjectEcommerce.CORE.Entities;
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
        private readonly IRepositoryUtente utenteRepo;

        public BusinessLayer(IRepositoryProdotto prodotto, IRepositoryUtente utente)
        {
            prodottoRepo = prodotto;
            utenteRepo = utente;

        }
        #region Prodotto
        public bool EliminaProdotto(int id)
        {
            Prodotto p = prodottoRepo.GetAll().FirstOrDefault(p => p.Id == id);
            prodottoRepo.Delete(p);
            return true;
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
        #endregion

        #region Utente

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utenteRepo.GetByUsername(username);
        }

        public bool InserisciNuovoUtente(Utente utenteRegister)
        {
            Utente u = utenteRepo.Add(utenteRegister);
            if (u == null)
            {
                return false;
            }
            return true;
        }


        #endregion
    }
}
