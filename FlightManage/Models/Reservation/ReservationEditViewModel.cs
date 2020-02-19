using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Models.Reservation
{
    public class ReservationEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = " FirstName cannot be longer than 40 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = " MiddleName cannot be longer than 40 characters")]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = " LastName cannot be longer than 40 characters")]
        public string LastName { get; set; }
        [Required]
        [Range(10, int.MaxValue, ErrorMessage = "PersonalNumber cannot be longer or shorter than 10 characters")]
        public int PersonalNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TelephoneNumber cannot be longer or shorter than 10 characters")]
        public int TelephoneNumber { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = " Nationality cannot be longer than 40 characters")]
        public string Nationality { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TicketNumber cannot be longer than 10 characters")]
        public int TicketNumber { get; set; }

    }
}
