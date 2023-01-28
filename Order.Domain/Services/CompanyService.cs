using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom kompanije kako bi se pristupilo bazi
    /// </summary>
    public class CompanyService : ICompanyService
    {
        /// <summary>
        /// Properti interfejsa repozitorijuma kompanije koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly ICompanyRepository _companyRepository;
        /// <summary>
        /// Konstruktor sa parametrom repozitorijuma kompanije koji inicijalizuje ovaj repozitorijum
        /// </summary>
        /// <param name="companyRepository"></param>
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task Add(Company company)
        {
            await _companyRepository.Add(company);
            await _companyRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _companyRepository.Delete(id);
            await _companyRepository.SaveChanges();
        }

        public async Task<List<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetById(id);
        }

        public async Task Update(Company company)
        {
            await _companyRepository.Update(company);
            await _companyRepository.SaveChanges();
        }
    }
}
