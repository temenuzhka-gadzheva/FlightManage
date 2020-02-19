using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Models.User
{
    public class UserEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }


        [Required]
        [MaxLength(25, ErrorMessage = "Username cannot be longer than 25 characters")]
        public string Username { get; set; }


        [Required]
        [MaxLength(8, ErrorMessage = "Password cannot be longer than 8 characters")]
        public string Password { get; set; }


        [Required]
        [MaxLength(25, ErrorMessage = "Email cannot be longer than 25 characters")]
        public string Email { get; set; }


        [Required]
        [MaxLength(25, ErrorMessage = "FirstName cannot be longer than 25 characters")]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(25, ErrorMessage = "LastName cannot be longer than 25 characters")]
        public string LastName { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Negative values or 0 are not accepted")]
        public int PersonalNo { get; set; }


        [Required]
        [MaxLength(30, ErrorMessage = "Address cannot be longer than 30 characters")]
        public string Address { get; set; }


        [Required]
        [MaxLength(10, ErrorMessage = "Telephone cannot be longer than 10 characters")]
        public string Telephone { get; set; }


        [Required]
        [MaxLength(15, ErrorMessage = "Role cannot be longer than 15 characters")]
        public string Role { get; set; }
    }
}
