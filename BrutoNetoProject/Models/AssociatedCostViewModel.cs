using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrutoNetoProject.Models
{
    public class AssociatedCostViewModel
    {
        public decimal TaxRate { get; set; }
        public decimal InsuranceOnEmployee { get; set; }
        public decimal HealthCareOnEmployee { get; set; }
        public decimal UnemploymentOnEmployee { get; set; }
        public decimal InsuranceOnEmployer { get; set; }
        public decimal HealthCareOnEmployer { get; set; }

        public static AssociatedCostViewModel MapFrom(AssociatedCostDto associatedCostDto)
        {
            AssociatedCostViewModel associatedCostViewModel = new AssociatedCostViewModel {
                TaxRate = associatedCostDto.TaxRate,
                HealthCareOnEmployee = associatedCostDto.HealthCareOnEmployee,
                HealthCareOnEmployer = associatedCostDto.HealthCareOnEmployer,
                InsuranceOnEmployee = associatedCostDto.InsuranceOnEmployee,
                InsuranceOnEmployer = associatedCostDto.InsuranceOnEmployer,
                UnemploymentOnEmployee = associatedCostDto.UnemploymentOnEmployee
            };     

            return associatedCostViewModel;
        }
    }
}
