using Microsoft.EntityFrameworkCore;
using RandomUserApp.Data;
using RandomUserApp.Models;
using RandomUserApp.Repositories;
using RandomUserApp.Utilities;
using System;

namespace RandomUserApp.Services
{
    public class PersonService
    {
        private DataContext _context;

        public PersonService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public void UpdatePerson(Person person)
        {
            PersonRepository personRep = new PersonRepository(_context);
            personRep.Update(person);
        }

        public void SavePerson(Person person)
        {
            PersonRepository personRep = new PersonRepository(_context);
            personRep.Save(person);
        }

        public void DeletePerson(int id)
        {
            PersonRepository personRep = new PersonRepository(_context);
            Person person = personRep.GetById(id);

            if (person == null)
                throw new ServiceException("Registro não encontrado");

            personRep.Delete(person);
        }

        public IEnumerable<Person> GetAllUsers()
        {
            PersonRepository personRep = new PersonRepository(_context);
            return personRep.GetAll();
        }

        public Person GetUserById(int id)
        {
            PersonRepository personRep = new PersonRepository(_context);
            Person person = personRep.GetById(id);

            if (person == null)
                throw new ServiceException("Registro não encontrado");

            return person;
        }
    }
}
