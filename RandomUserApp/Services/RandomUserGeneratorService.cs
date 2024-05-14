using Newtonsoft.Json;
using RandomUserApp.Models;
using RandomUserApp.ValueObjects;
using RandomUserApp.Utilities;
using RandomUserApp.Data;
using RandomUserApp.Repositories;

namespace RandomUserApp.Services
{
    public class RandomUserGeneratorService
    {
        private DataContext _context;

        public RandomUserGeneratorService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public RandomUser GetAPIRandomUser()
        {
            Repositories.APPConfigurationRepository appConfigurationRep = new Repositories.APPConfigurationRepository(_context);
            APPConfiguration configuration = appConfigurationRep.GetAppConfiguration();

            if (configuration == null)
                throw new ServiceException("Configuração não foi localizada. Consulte o suporte técnico.");

            HttpClient client = new HttpClient { BaseAddress = new Uri(configuration.BaseAddress) };
            HttpResponseMessage response = client.GetAsync(configuration.ApiURL).Result;

            RandomUser randomUser = new RandomUser();

            if (response.IsSuccessStatusCode)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                randomUser = JsonConvert.DeserializeObject<RandomUser>(stringResult);
            }

            if (randomUser == null)
                throw new ServiceException("Houve um erro ao gerar usuário.");

            return randomUser;
        }

        public Person ConvertResult(RandomUser randomUser)
        {
            Result result = randomUser.results.FirstOrDefault();

            if (result == null)
                throw new ServiceException("Resultado não encontrado.");

            Person person = new Person();

            person.FirstName = result.name.first;
            person.LastName = result.name.last;
            person.PostCode = result.location.postcode;
            person.Address = $"{result.location.street.name}, {result.location.street.number} - {result.location.city}, {result.location.state}, {result.location.country}";
            person.Gender = result.gender.GetGender();
            person.Image = result.picture.large;

            return person;
        }
    }
}
