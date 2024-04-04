using System;
using System.ComponentModel.DataAnnotations;


namespace WebApplication10.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Поле Ім'я прізвище є обов'язковим")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Введіть коректну адресу електронної пошти")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Бажана дата консультації є обов'язковим")]
        [FutureDate(ErrorMessage = "Дата консультації має бути в майбутньому")]
        [NotOnWeekend(ErrorMessage = "Консультація не може бути проведена у вихідний день")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Поле Продукт є обов'язковим")]
        public string SelectedProduct { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date.Date > DateTime.Now.Date;
        }
    }

    public class NotOnWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
