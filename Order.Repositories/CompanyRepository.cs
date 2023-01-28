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
    public class CompanyRepository : ICompanyRepository
    {
        // <summary>
        /// Properti datacontext-a zaduženog za rad sa bazom
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje 
        /// </summary>
        /// <param name="dataContext"></param>
        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Add(Company company)
        {
            var record = new CompanyRecord 
            {
                Adress = company.Adress,
                Email = company.Email,
                FullName = company.FullName,
                PhoneNumber = company.PhoneNumber,
                RegistrationNumber = company.RegistrationNumber,
            };
            await _dataContext.Companies.AddAsync(record);
        }

        public async Task Delete(int id)
        {
            var record = await _dataContext.Companies.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (record != null)
                _dataContext.Companies.Remove(record);
        }

        public async Task<List<Company>> GetAll()
        {
            var records = await _dataContext.Companies.AsNoTracking().ToListAsync();

            List<Company> companies = records.Select(x => new Company
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Adress = x.Adress,
                FullName = x.FullName,  
                RegistrationNumber = x.RegistrationNumber,
            }).ToList();
            return companies;
        }

        public async Task<Company> GetById(int id)
        {
            var record = await _dataContext.Companies.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();

            Company company = new Company
            {
                Id = record.Id,
                Adress = record.Adress,
                Email = record.Email,
                PhoneNumber = record.PhoneNumber,
                RegistrationNumber = record.RegistrationNumber,
                FullName = record.FullName,
            };
            return company;
        }

        public async Task Update(Company company)
        {
            var record = new CompanyRecord
            {
                Id = company.Id,
                Adress = company.Adress,
                Email = company.Email,
                PhoneNumber = company.PhoneNumber,
                FullName = company.FullName,
                RegistrationNumber = company.RegistrationNumber,
            };
            _dataContext.Companies.Update(record);
        }
    }
}
