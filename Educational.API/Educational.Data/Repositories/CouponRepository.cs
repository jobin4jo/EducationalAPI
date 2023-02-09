using Educational.DataContracts.DataTransferObjects.Coupon;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
  public class CouponRepository:ICouponRepository
    {
        private readonly EducationalContext _context;
        public CouponRepository(EducationalContext context)
        {
            this._context = context;
        }

        public async Task<int> CouponDeletebyId(int id)
        {
            var couponData = await this._context.TbCoupons.FindAsync(id);
            couponData.Status = 0;
            _context.Entry(couponData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return couponData.CouponId;
        }

        public async Task<int> CreateCoupon(CouponRequestDTO couponRequest)
        {
            TbCoupon tbCoupon = new TbCoupon();
            tbCoupon.CouponString=couponRequest.CouponString;
            tbCoupon.PurposeOfCoupon=couponRequest.PurposeOfCoupon;
            tbCoupon.ActiveFlag = 1;
            tbCoupon.DiscountPercentage=couponRequest.DiscountPercentage;
            tbCoupon.StartDate=couponRequest.StartDate;
            tbCoupon.EndDate = couponRequest.EndDate;
            tbCoupon.Status = 1;
            _context.TbCoupons.AddAsync(tbCoupon);
            await _context.SaveChangesAsync();
            return tbCoupon.CouponId;
        }

        public async Task<List<CouponResponseDTO>> GetAllCoupon()
        {
            List<CouponResponseDTO> coupons = await (from co in _context.TbCoupons
                                                     where co.Status == 1
                                                     select (new CouponResponseDTO
                                                     {
                                                         CouponId = co.CouponId,
                                                         CouponString = co.CouponString,
                                                         PurposeOfCoupon = co.PurposeOfCoupon,
                                                         ActiveFlag = co.ActiveFlag,
                                                         StartDate = co.StartDate,
                                                         EndDate = co.EndDate,
                                                         Status = co.Status,
                                                         DiscountPercentage = co.DiscountPercentage,


                                                     })).ToListAsync();
            return coupons;
        }

        public async  Task<CouponResponseDTO> GetCouponById(int id)
        {
            CouponResponseDTO coupons = await(from co in _context.TbCoupons
                                                    where co.Status == 1 && co.CouponId == id
                                                    select (new CouponResponseDTO
                                                    {
                                                        CouponId = co.CouponId,
                                                        CouponString = co.CouponString,
                                                        PurposeOfCoupon = co.PurposeOfCoupon,
                                                        ActiveFlag = co.ActiveFlag,
                                                        StartDate = co.StartDate,
                                                        EndDate = co.EndDate,
                                                        Status = co.Status,
                                                        DiscountPercentage = co.DiscountPercentage,


                                                    })).FirstAsync();
            return coupons;
        }

        public Task<CouponResponseDTO> UpdateCoupon(CouponRequestDTO couponRequest, int id)
        {
            throw new NotImplementedException();
        }
    }
}
