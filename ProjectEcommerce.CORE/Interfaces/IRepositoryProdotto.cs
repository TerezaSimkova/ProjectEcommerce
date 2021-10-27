using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.CORE.Interfaces
{
    public interface IRepositoryProdotto : IRepository<Prodotto>
    {
        void UpdateProdotto(string codiceProdotto, string descrizione, decimal prezzoAlPubblico, Prodotto.EnumTipologia tipologia);
    }
}
