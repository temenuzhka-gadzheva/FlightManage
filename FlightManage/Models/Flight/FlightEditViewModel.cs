using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Models.Flight
{
    public class FlightEditViewModel
    {

        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Location name cannot be longer than 40 characters")]
        public string LocationFrom { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Location name cannot be longer than 40 characters")]
        public string LocationTo { get; set; }

        [Required]
        public DateTime TakeOffTime { get; set; }

        [Required]
        public DateTime LandingTime { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Location name cannot be longer than 50 characters")]
        public string AircraftType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Negative values or 0 are not accepted")]
        public int AircraftNumber { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Pilot name cannot be longer than 50 characters")]
        public string PilotName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Negative values or 0 are not accepted")]
        public int PassengerCapacity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Negative values or 0 are not accepted")]
        public int BusinessPassengerCapacity { get; set; }
    }
}
