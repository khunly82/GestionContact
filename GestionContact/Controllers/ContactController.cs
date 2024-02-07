using GestionContact.BLL.Services;
using GestionContact.Domain.Entities;
using GestionContact.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionContact.Controllers
{
    public class ContactController(ContactService contactService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<ContactViewModel> model = (await contactService.Get())
                .Select(c => new ContactViewModel(c)).ToList();

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddContactForm form)
        {
            if(ModelState.IsValid)
            {
                await contactService.Add(new Contact
                {
                    LastName = form.LastName,
                    FirstName = form.FirstName,
                    BirthDate = form.BirthDate
                }, new Address
                {
                    Street = form.Street,
                    City = form.City,
                    Number = form.Number,
                });
                TempData["Info"] = "Bravo";
                return RedirectToAction("Index");
            }
            return View(form);
        }


        public async Task<IActionResult> Details(int id)
        {
            Contact model = await contactService.GetById(id);
            return View(new ContactDetailsViewModel(model));
        }
    }
}
