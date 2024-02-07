using GestionContact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.BLL.Services
{
    public class ContactService(HttpClient client)
    {
        public async Task<List<Contact>> Get()
        {
            List<Contact> list = await client.GetFromJsonAsync<List<Contact>>("/contacts");
            return list;
        }

        public async Task Add(Contact c, Address a)
        {
            HttpResponseMessage message = await client.PostAsJsonAsync("/contacts", c);
            Contact nC = await message.Content.ReadFromJsonAsync<Contact>();

            a.ContactId = nC.Id;

            await client.PostAsJsonAsync("/addresses", a);
        }

        public async Task<Contact> GetById(int id)
        {
            Contact c = await client.GetFromJsonAsync<Contact>("/contacts/" + id);

            List<Address> addresses = await client.GetFromJsonAsync<List<Address>>("/addresses/?contactId="+id);
            c.Addresses = addresses;

            return c;
        }
    }
}
