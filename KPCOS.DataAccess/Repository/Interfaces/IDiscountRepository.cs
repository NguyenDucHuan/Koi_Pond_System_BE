using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IDiscountRepository
    {
        Task<List<Discount>> GetDiscountsAsync();
        Task<Discount> GetDiscountAsync(int discountId);
        Task<Discount> AddDiscountAsync(Discount discount);
        Task<Discount> UpdateDiscountAsync(Discount discount);
        Task DeleteDiscountAsync(int discountId);
    }
}