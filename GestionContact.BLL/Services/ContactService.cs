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
            List<Address> listAddress = await client.GetFromJsonAsync<List<Address>>("/addresses");

            List<Contact> contacts = list.Join(listAddress, c => c.Id, a => a.ContactId, (c, a) => { c.Address = a; return c; }).ToList();

            return contacts;
        }

        public async Task Add(Contact c)
        {
            HttpResponseMessage message = await client.PostAsJsonAsync("/contacts", c);
            Contact nC = await message.Content.ReadFromJsonAsync<Contact>();

            c.Address.ContactId = nC.Id;

            await client.PostAsJsonAsync("/addresses", c.Address);
        }
    }
}
