using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Coupon
{
    public  class CouponResponseDTO
    {
        public int CouponId { get; set; }
        public string? CouponString { get; set; }
        public string? DiscountPercentage { get; set; }
        public int? Status { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PurposeOfCoupon { get; set; }
    }
}
