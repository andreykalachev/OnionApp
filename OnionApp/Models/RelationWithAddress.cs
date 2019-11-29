using System;

namespace OnionApp.Models
{
    public class RelationWithAddress
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string TelephoneNumber { get; set; }

        public string EMailAddress { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        //Number + NumberSuffix
        public string StreetNumber { get; set; }
    }
}
