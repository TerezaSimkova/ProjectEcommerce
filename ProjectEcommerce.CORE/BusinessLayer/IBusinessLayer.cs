﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Prodotto> GetAllProdotti();
        bool InserisciNuovoProdotto(Prodotto prodotto);
        bool ModificaProdotto(string codiceProdotto, string descrizione, decimal prezzoAlPubblico, Prodotto.EnumTipologia tipologia);
    }
}
