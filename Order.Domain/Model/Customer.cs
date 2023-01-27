using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
    
    public class Customer
    {
        private string _adress;
        private string _phoneNumber;
        private string _email;
        private int _id;

       
        public Customer()
        {

        }

       
        public Customer(string adress, string phoneNumber, string email, int id)
        {
            Adress = adress;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
        }

       
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _id = value;
            }
        }

        
        public string Adress 
        {
            get
            {
                return _adress;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 40);
                _adress = value;
            }
        }

        
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 10);
                _phoneNumber = value;
            }
        }

        
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 30);
                _email = value;
            }
        }
    }
}
