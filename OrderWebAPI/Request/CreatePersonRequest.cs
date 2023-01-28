namespace OrderWebAPIFaza4.Request
{
    
    public class CreatePersonRequest
    {
        /// <summary>
        /// Ime osobe
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Prezime osobe
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Adresa kupca
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Telefon kupca
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email kupca
        /// </summary>
        public string Email { get; set; }
    }
}
