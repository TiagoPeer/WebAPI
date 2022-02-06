using AutoMapper;
using WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    [AutoMap(typeof(Form))]
    public class FormDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Message { get; set; }
    }
}
