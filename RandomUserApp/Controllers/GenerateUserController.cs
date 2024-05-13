using Microsoft.AspNetCore.Mvc;
using RandomUserApp.Data;
using RandomUserApp.Models;
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

        public IActionResult GenerateUser()
        {
            return View();
        }
        public IActionResult GetRandomUser()
        {
            try
            {
                Services.RandomUserGenerator randomUserGenerator = new Services.RandomUserGenerator();
                RandomUser randomUser = randomUserGenerator.GetPerson();

                Person person = randomUserGenerator.ConvertResult(randomUser.results.FirstOrDefault());

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
                    _context.Person.Add(person);
                    _context.SaveChanges();

                    ViewBag.Saved = true;
                    return View("GenerateUser");
                }

                ViewBag.Saved = false;
                return View("GenerateUser");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocorreu um erro ao salvar usuário";
                return View("GenerateUser");
            }
        }
    }
}
