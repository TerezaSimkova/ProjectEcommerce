using ProjectEcommerce.CORE.Entities;
using ProjectEcommerce.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.EF.Repository
{
    public class RepositoryUtenteEF : IRepositoryUtente
    {
        private readonly ProdottoContext pxt;

        public RepositoryUtenteEF()
        {
            pxt = new ProdottoContext();
        }

        public Utente Add(Utente utente)
        {
            pxt.Utenti.Add(utente);
            pxt.SaveChanges();
            return utente;
        }

        public bool Delete(Utente utente)
        {
            pxt.Utenti.Remove(utente);
            pxt.SaveChanges();
            return true;
        }

        public List<Utente> GetAll()
        {
            return pxt.Utenti.ToList();
        }

        public Utente GetByUsername(string username)
        {
            var utenteByUsername = pxt.Utenti.FirstOrDefault(u => u.Username == username);
            return utenteByUsername;
        }

        public Utente Update(Utente utente)
        {
            var oldUtente = pxt.Utenti.FirstOrDefault(u => u.Id == utente.Id);
            oldUtente.Nome = utente.Nome;
            oldUtente.Username = utente.Username;
            oldUtente.Password = utente.Password;
            oldUtente.Ruolo = utente.Ruolo;
            pxt.SaveChanges();
            return utente;
        }
    }
}
