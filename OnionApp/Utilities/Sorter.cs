using System.Collections.Generic;
using System.Linq;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Utilities
{
    public static class Sorter
    {
        public static IEnumerable<RelationBasicInfoDto> RelationOrderBy(this IEnumerable<RelationBasicInfoDto> relations, string sortOrder)
        {
            if (sortOrder != null && relations != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "name":
                        relations = relations.ToList().OrderBy(x => x.Name);
                        break;
                    case "fullname":
                        relations = relations.ToList().OrderBy(x => x.FullName);
                        break;
                    case "telephone":
                        relations = relations.ToList().OrderBy(x => x.TelephoneNumber);
                        break;
                    case "email":
                        relations = relations.ToList().OrderBy(x => x.EMailAddress);
                        break;
                    case "country":
                        relations = relations.ToList().OrderBy(x => x.CountryName);
                        break;
                    case "city":
                        relations = relations.ToList().OrderBy(x => x.City);
                        break;
                    case "street":
                        relations = relations.ToList().OrderBy(x => x.Street);
                        break;
                    case "postalcode":
                        relations = relations.ToList().OrderBy(x => x.PostalCode);
                        break;
                }
            }

            return relations;
        }
    }
}
