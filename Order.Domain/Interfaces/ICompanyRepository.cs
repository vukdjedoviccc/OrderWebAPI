using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    
    public interface ICompanyRepository
    {
       
        Task SaveChanges();
        
        Task Add(Company company);
        
        Task Delete(int id);
        
        Task<List<Company>> GetAll();
       
        Task<Company> GetById(int id);
       
        Task Update(Company company);
    }
}
