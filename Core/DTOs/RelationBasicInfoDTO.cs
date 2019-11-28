using System;

namespace OnionApp.Domain.Core.DTOs
{
    public class RelationBasicInfoDto
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

        public int? Number { get; set; }

        public string NumberSuffix { get; set; }
    }
}
