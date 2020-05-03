namespace RentItEasy.Areas.User.ViewModels.Appointment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentInputModel
    {
        public int AdId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }
    }
}
