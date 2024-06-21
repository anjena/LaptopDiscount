using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopDiscount
{
    public enum EmployeeType
    {
        PartTime,       // No Discount
        PartialLoad,    // 5% Discount
        FullTime,       // 10% Discount
        CompanyPurchasing // 20% Discount
    }

    public class EmployeeDiscount
    {
        public EmployeeType EmployeeType { get; set; }
        public decimal Price { get; set; }
        public object Assert { get; set; }

        public decimal CalculateDiscountedPrice()
        {
            decimal discount = 0;

            switch (EmployeeType)
            {
                case EmployeeType.PartTime:
                    discount = 0; // No discount
                    break;
                case EmployeeType.PartialLoad:
                    discount = 0.05m; // 5% discount
                    break;
                case EmployeeType.FullTime:
                    discount = 0.10m; // 10% discount
                    break;
                case EmployeeType.CompanyPurchasing:
                    discount = 0.20m; // 20% discount
                    break;
            }

            return Price - (Price * discount);
        }
    }

}
