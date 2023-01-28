using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repositories
{
    /// <summary>
    /// Klasa koja predstavlja repozitorijum osobe za pozivanje odgovarajućih metoda koje rade direktno nad bazom
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        // <summary>
        /// Properti datacontext-a zaduženog za rad sa bazom
        /// </summary>
        private readonly DataContext _dataContext;
        /// <summary>
        /// Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje 
        /// </summary>
        /// <param name="dataContext"></param>
        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        } 
        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Add(Person person)
        {
            var record = new PersonRecord
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Adress = person.Adress,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
            };

            await _dataContext.Persons.AddAsync(record); 
        }

        public async Task Delete(int id)
        {
            var record = await _dataContext.Persons.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (record != null)
                _dataContext.Persons.Remove(record); 
        }

        public async Task<List<Person>> GetAll()
        {
            var records = await _dataContext.Persons.AsNoTracking().ToListAsync(); 
           
            List<Person> persons = records.Select(x => new Person
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Adress = x.Adress,
            }).ToList(); 
            return persons;
        }

        public async Task<Person> GetById(int id)
        {
            var record = await _dataContext.Persons.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();

            Person person = new Person
            {
                Id = record.Id,
                Adress = record.Adress,
                FirstName = record.FirstName,
                Email = record.Email,
                PhoneNumber = record.PhoneNumber,
                LastName = record.LastName,
            };
            return person;

        }

        public async Task Update(Person person)
        {
            var record = new PersonRecord
            {
               Id=person.Id,
               FirstName = person.FirstName,
               LastName = person.LastName,
               Adress = person.Adress,
               Email = person.Email,
               PhoneNumber = person.PhoneNumber,
            };
            _dataContext.Persons.Update(record);
        }
    }
}
