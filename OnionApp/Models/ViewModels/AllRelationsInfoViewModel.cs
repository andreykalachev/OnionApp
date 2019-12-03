using System.Collections.Generic;
using OnionApp.Domain.Models.DTO;

namespace OnionApp.Models.ViewModels
{
    public class AllRelationsInfoViewModel
    {
        public IList<RelationWithAddress> Relations { get; set; }

        public IList<CategoryBasicInfoDto> Categories { get; set; }
    }
}
