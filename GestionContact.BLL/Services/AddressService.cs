using GestionContact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.BLL.Services
{
    public class AddressService(HttpClient client)
    {
        public async Task Add(Address a)
        {
            await client.PostAsJsonAsync("/addresses", a);
        }
    }
}
