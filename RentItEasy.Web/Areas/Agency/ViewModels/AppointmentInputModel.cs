using System;
using System.ComponentModel.DataAnnotations;

namespace RentItEasy.Areas.User.ViewModels
{
    public class AppointmentInputModel
    {
        public int AdId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }
    }
}
