using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
    
    public class Company : Customer
    {
        private string _fullName;
        private string _registrationNumber;

       
        public Company() : base()
        {

        }

        
        public Company(string fullName, string registrationNumber, string adress, string phoneNumber, string email, int id) : base(adress, phoneNumber, email, id)
        {
            FullName = fullName;
            RegistrationNumber = registrationNumber;
        }

        
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 50);
                _fullName = value;
            }
        }

        
        public string RegistrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthEqualTo(value, 8);
                _registrationNumber = value;
            }
        }

    }
}
