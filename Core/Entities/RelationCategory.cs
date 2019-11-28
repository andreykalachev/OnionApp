using System;

namespace OnionApp.Domain.Core.Entities
{
    public class RelationCategory
    {
        public Guid RelationId { get; set; }

        public Relation Relation { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
