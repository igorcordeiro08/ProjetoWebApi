using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class AuthRequest
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}