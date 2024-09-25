using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly KpcosdbContext _context;

        public DiscountRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Discount> AddDiscountAsync(Discount discount)
        {
            var discountadd = await _context.Discounts.AddAsync(discount);
            if (discountadd != null)
            {
                throw new Exception("Discount have exist");
            }
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task DeleteDiscountAsync(int discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null)
            {
                throw new Exception("Discount not found");
            }
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
        }

        public async Task<Discount> GetDiscountAsync(int discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null)
            {
                return null;
            }
            return discount;
        }

        public async Task<List<Discount>> GetDiscountsAsync()
        {
            var discounts = await _context.Discounts.ToListAsync();
            if (discounts == null)
            {
                return null;
            }
            return discounts;
        }

        public async Task<Discount> UpdateDiscountAsync(Discount discount)
        {
            var discount1 = await _context.Discounts.FindAsync(discount.Id);
            if (discount1 == null)
            {
                throw new Exception("Discount not found");
            }
            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return discount;
        }
    }
}