using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.Entities
{
    public class AssociatedCostDto
    {
        public decimal TaxRate { get; set; }
        public decimal InsuranceOnEmployee { get; set; }
        public decimal HealthCareOnEmployee { get; set; }
        public decimal UnemploymentOnEmployee { get; set; }
        public decimal InsuranceOnEmployer { get; set; }
        public decimal HealthCareOnEmployer { get; set; }

        public decimal SumCost()
        {
            decimal sum = 0;

            sum += TaxRate;
            sum += InsuranceOnEmployee;
            sum += HealthCareOnEmployee;
            sum += UnemploymentOnEmployee;
            sum += InsuranceOnEmployer;
            sum += HealthCareOnEmployee;

            return sum;
        }
    }
   
}
