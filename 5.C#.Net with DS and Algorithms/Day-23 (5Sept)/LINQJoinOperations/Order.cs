using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQJoinOperations
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public DateTime Datetime { get; set; }
        public int CustomerId { get; set; }
    }
}
