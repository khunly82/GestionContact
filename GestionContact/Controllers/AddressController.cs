using GestionContact.BLL.Services;
using GestionContact.Domain.Entities;
using GestionContact.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionContact.Controllers
{
    public class AddressController(AddressService service) : Controller
    {
        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, AddAddressForm form)
        {
            if(ModelState.IsValid)
            {
                await service.Add(new Address
                {
                    City = form.City,
                    Number = form.Number,
                    Street = form.Street,
                    ContactId = id,
                });
                return RedirectToAction("Details", "Contact", new { Id = id });
            }
            return View(form);
        }
    }
}
