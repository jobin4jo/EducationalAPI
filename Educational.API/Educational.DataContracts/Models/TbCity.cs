using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbCity
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string? CityName { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
