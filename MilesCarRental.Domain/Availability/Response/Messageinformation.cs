using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Availability.Response
{
    /// <summary>
    /// Informational messages returned by the provider along with the search results.
    /// </summary>
    public class Messageinformation
    {
        public string code { get; set; }
        public string message { get; set; }
        public string level { get; set; }
    }

}
