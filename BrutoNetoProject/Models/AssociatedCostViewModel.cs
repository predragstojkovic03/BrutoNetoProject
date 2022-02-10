using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BrutoNetoProject.Models
{
    public class AssociatedCostViewModel
    {
        [DisplayName("Porez")]
        public decimal TaxRate { get; set; }

        [DisplayName("PIO na teret zaposlenog")]
        public decimal InsuranceOnEmployee { get; set; }

        [DisplayName("Zdravstvo na teret zaposlenog")]
        public decimal HealthCareOnEmployee { get; set; }

        [DisplayName("Nezaposlenost na teret zaposlenog")]
        public decimal UnemploymentOnEmployee { get; set; }

        [DisplayName("PIO na teret poslodavca")]
        public decimal InsuranceOnEmployer { get; set; }

        [DisplayName("Zdravstvo na teret poslodavca")]
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
