using ProjectEcommerce.CORE;
using ProjectEcommerce.CORE.Entities;
using ProjectEcommerce.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProjectEcommerce.CORE.Prodotto;
using Role = ProjectEcommerce.MVC.Models.Role;

namespace ProjectEcommerce.MVC.Mapping
{
    public static class Helper
    {
        public static Prodotto ToProdotto(this ProdottoViewModel prodottoViewModel)
        {

            return new Prodotto
            {
                Id = prodottoViewModel.Id,
                CodiceProdotto = prodottoViewModel.CodiceProdotto,
                Descrizione = prodottoViewModel.Descrizione,
                PrezzoAlPubblico = prodottoViewModel.PrezzoAlPubblico,
                PrezzoFornitore = prodottoViewModel.PrezzoFornitore,
                Tipologia = (EnumTipologia)prodottoViewModel.Tipologia
            };
        }

        public static ProdottoViewModel ToProdottoViewModel(this Prodotto prodotto)
        {
            return new ProdottoViewModel
            {
                Id = prodotto.Id,
                CodiceProdotto = prodotto.CodiceProdotto,
                Descrizione = prodotto.Descrizione,
                PrezzoAlPubblico = prodotto.PrezzoAlPubblico,
                PrezzoFornitore = prodotto.PrezzoFornitore,
                Tipologia = (ProdottoViewModel.EnumTipologia)prodotto.Tipologia
            };
        }

        public static Utente ToUtente(this UtenteLoginViewModel utenteViewModel)
        {

            return new Utente
            {
                Id = utenteViewModel.Id,
                Nome = utenteViewModel.Nome,
                Username = utenteViewModel.Username,
                Password = utenteViewModel.Password,
                Ruolo = (CORE.Entities.Role)utenteViewModel.Ruolo

            };
        }

        public static UtenteLoginViewModel ToUtenteViewModel(this Utente utente)
        {
            return new UtenteLoginViewModel
            {
                Id = utente.Id,
                Nome = utente.Nome,
                Username = utente.Username,
                Password = utente.Password,
                Ruolo = (Role)utente.Ruolo

            };
        }
    }
}
