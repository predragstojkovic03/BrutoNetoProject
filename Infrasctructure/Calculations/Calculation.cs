using System;
using System.Collections.Generic;
using System.Text;
using Core.Data.Entities;

namespace Infrasctructure.Calculations
{
    public static class Calculation
    {
        public static AssociatedCostDto CalculateAssociatedCost(decimal neto)
        {
            AssociatedCostDto associatedCost = new AssociatedCostDto();
            decimal bruto;
            decimal result;

            if (neto < 28402)
                bruto = ((neto - 1830) + (decimal)0.199 * 28402) / (decimal)0.9;

            else if (neto > 405750)
                bruto = ((neto - 1830) + (decimal)0.199 * 405750) / (decimal)0.9;

            else
                bruto = (neto - 1830) / (decimal)0.701;

            associatedCost.TaxRate += (bruto - 18300) * (decimal)0.1;
            associatedCost.InsuranceOnEmployee += bruto * (decimal)0.14;
            associatedCost.HealthCareOnEmployee += bruto * (decimal)0.0515;
            associatedCost.UnemploymentOnEmployee += bruto * (decimal)0.0075;
            associatedCost.InsuranceOnEmployer += bruto * (decimal)0.115;
            associatedCost.HealthCareOnEmployer += bruto * (decimal)0.0515;

            return associatedCost;
        }
    }
}
