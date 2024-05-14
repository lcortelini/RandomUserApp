using Microsoft.EntityFrameworkCore;
using RandomUserApp.Data;
using RandomUserApp.Models;

namespace RandomUserApp.Repositories
{
    public class PersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.Person.Update(person);
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        public Person GetById(int id)
        {
            return _context.Person.SingleOrDefault(person => person.ID == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Person.AsEnumerable();
        }
    }
}
