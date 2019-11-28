using System;

namespace OnionApp.Domain.Core
{
    public class Country
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISO3166_2 { get; set; }
        public string ISO3166_3 { get; set; }
        public Guid? DefaultVatId { get; set; }
        public string PostalCodeFormat { get; set; }
    }
}
