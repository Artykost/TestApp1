using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp1.Domain.Entity
{
    public class UserStatistic
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "identity_user")]
        public Guid IdentityUser { get; set; }

        [Display(Name = "period_from")]
        public DateTime PeriodFrom { get; set; }

        [Display(Name = "period_to")]
        public DateTime PeriodTo { get; set; }
    }
}
