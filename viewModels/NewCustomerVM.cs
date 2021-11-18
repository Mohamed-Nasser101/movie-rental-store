using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;
namespace vidly.viewModels
{
    public class NewCustomerVM
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}