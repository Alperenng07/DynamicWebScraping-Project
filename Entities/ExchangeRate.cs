using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ExchangeRate:BaseEntity
    {
        public DateTime Date { get; set; }
       

        public int Buy { get; set; }

        public int Sale { get; set; }

        public int EffectiveBuy { get; set; }

        public int EffectiveSale { get; set; }



        public string FCurrencyCode { get; set; }
        public FCurrency Currency { get; set; }
    }
}
