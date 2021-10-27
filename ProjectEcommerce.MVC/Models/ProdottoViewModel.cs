using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEcommerce.MVC.Models
{
    public class ProdottoViewModel
    {
        public int Id { get; set; }
        public string CodiceProdotto { get; set; }
        public string Descrizione { get; set; }
        public EnumTipologia Tipologia { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrezzoAlPubblico { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PrezzoFornitore { get; set; }

        public enum EnumTipologia
        {
            Elettronica = 1,
            Abbigliamento = 2,
            Casalinghi = 3
        }
    }
}
