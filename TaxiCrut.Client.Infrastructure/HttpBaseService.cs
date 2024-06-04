using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrut.Client.Infrastructure
{
    public abstract class HttpBaseService
    {
        protected readonly HttpClient httpClient;

        public HttpBaseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
