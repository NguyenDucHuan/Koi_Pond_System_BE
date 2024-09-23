using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly KpcosdbContext _context;

        public DiscountRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<Discount> AddDiscountAsync(Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDiscountAsync(int discountId)
        {
            throw new NotImplementedException();
        }

        public Task<Discount> GetDiscountAsync(int discountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discount>> GetDiscountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Discount> UpdateDiscountAsync(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}