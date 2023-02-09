using Educational.DataContracts.DataTransferObjects.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
public  interface ICouponRepository
    {
        Task<int> CreateCoupon(CouponRequestDTO couponRequest);
        Task<CouponResponseDTO> UpdateCoupon(CouponRequestDTO couponRequest,int id);
        Task<int>CouponDeletebyId (int id);
        Task<List<CouponResponseDTO>> GetAllCoupon();
        Task<CouponResponseDTO> GetCouponById(int id);  
    }
}
