using Microsoft.AspNetCore.Mvc;
using RandomUserApp.Data;
using RandomUserApp.Models;
using RandomUserApp.Services;
using RandomUserApp.Utilities;
using RandomUserApp.ValueObjects;

namespace RandomUserApp.Controllers
{
    public class GenerateUserController : Controller
    {
        private DataContext _context;

        public GenerateUserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GenerateUser()
        {
            dynamic? id = TempData["Id"];

            if (id != null && (int)id > 0)
            {
                PersonService personService = new PersonService(_context);
                Person person = personService.GetUserById(id);

                ViewBag.Update = true;

                return View(person);
            }
            else
                return View();
        }

        public IActionResult GetRandomUser()
        {
            try
            {
                Services.RandomUserGeneratorService randomUserGeneratorService = new Services.RandomUserGeneratorService(_context);

                RandomUser randomUser = randomUserGeneratorService.GetAPIRandomUser();
                Person person = randomUserGeneratorService.ConvertResult(randomUser);

                ViewBag.UserGenerated = true;

                return View("GenerateUser", person);
            }
            catch (ServiceException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GenerateUser");
            }
            catch (Exception)
            {
                //TODO: implementar serviço de log para tratar erros
                ViewBag.ErrorMessage = "Ocorreu um erro ao gerar usuário";
                return View("GenerateUser");
            }
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Services.PersonService personService = new Services.PersonService(_context);

                    personService.SavePerson(person);

                    ViewBag.Saved = true;
                    return View("GenerateUser");
                }
                else
                {
                    ViewBag.Saved = false;
                    return View("GenerateUser", person);
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Ocorreu um erro ao salvar usuário";
                return View("GenerateUser");
            }
        }

        public IActionResult Update(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Services.PersonService personService = new Services.PersonService(_context);
                    personService.UpdatePerson(person);

                    ViewBag.Updated = true;
                    return View("GenerateUser");
                }
                else
                {
                    return View("GenerateUser", person);
                }
            }
            catch (ServiceException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GenerateUser");
            }
            catch (Exception)
            {
                //TODO: implementar serviço de log para tratar erros
                ViewBag.ErrorMessage = "Ocorreu um erro ao gerar usuário";
                return View("GenerateUser");
            }
        }
    }
}
