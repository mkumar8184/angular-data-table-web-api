using System;
using System.Collections.Generic;

namespace DbLayer.Entity
{
    public partial class UserInfo
    {
        public string UserId { get; set; } = null!;
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
        public string CompanyName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }
        public enum E
        {
            UserName,
            UserId,
            EmailId,           
            CompanyName,
            MobileNumber,
            Location,
            IsActive




        }

    }
  

}
