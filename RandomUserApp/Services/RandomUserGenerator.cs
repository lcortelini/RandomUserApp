using Newtonsoft.Json;
using RandomUserApp.Models;
using RandomUserApp.ValueObjects;
using RandomUserApp.Utilities;

namespace RandomUserApp.Services
{
    public class RandomUserGenerator
    {
        public RandomUser GetPerson()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://api.randomuser.me")
            };
            HttpResponseMessage response = client.GetAsync("https://randomuser.me/api/").Result;

            if (response.IsSuccessStatusCode)
            {
                var stringResult = response.Content.ReadAsStringAsync().Result;
                RandomUser person = JsonConvert.DeserializeObject<RandomUser>(stringResult);

                return person;
            }
            else
                throw new ServiceException("Houve um erro ao gerar usuário.");
        }

        public Person ConvertResult(Result result)
        {
            Person person = new Person();

            person.FirstName = result.name.first;
            person.LastName = result.name.last;
            person.PostCode = result.location.postcode;
            person.Address = $"{result.location.street.name}, {result.location.street.number} - {result.location.city}, {result.location.state}";
            person.Gender = result.gender.GetGender();
            person.Image = result.picture.large;

            return person;
        }
    }
}
