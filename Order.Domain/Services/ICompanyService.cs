using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
   
    public interface ICompanyService
    {
        
        Task Add(Company company);

       
        Task<Company> GetById(int id);

       
        Task<List<Company>> GetAll();

        
        Task Delete(int id);

       
        Task Update(Company company);
    }
}
