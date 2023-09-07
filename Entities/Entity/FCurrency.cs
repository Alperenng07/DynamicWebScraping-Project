using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class FCurrency : BaseEntity
    {
        public string FCurrencyCode { get; set; }
        public string Country { get; set; }
        public string Icon { get; set; }
        public string UserCode { get; set; }
        public User User { get; set; }


    }
}
