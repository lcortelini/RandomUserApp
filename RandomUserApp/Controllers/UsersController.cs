using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUserApp.Data;
using RandomUserApp.Models;
using RandomUserApp.Services;
using RandomUserApp.Utilities;

namespace RandomUserApp.Controllers
{
    public class UsersController : Controller
    {
        private DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Users()
        {
            try
            {
                PersonService personService = new PersonService(_context);
                return View(personService.GetAllUsers());
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Ocorreu um erro ao buscar usuários";
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                PersonService personService = new PersonService(_context);
                personService.DeletePerson(id);

                return RedirectToAction("Users");
            }
            catch (ServiceException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Users");
            }
            catch (Exception)
            {
                //TODO: implementar serviço de log para tratar erros
                ViewBag.ErrorMessage = "Ocorreu um erro ao deletar usuário";
                return View("Users");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                TempData["Id"] = id;
                return RedirectToAction("GenerateUser", "GenerateUser");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Ocorreu um erro ao buscar usuário";
                return View();
            }
        }
    }
}
