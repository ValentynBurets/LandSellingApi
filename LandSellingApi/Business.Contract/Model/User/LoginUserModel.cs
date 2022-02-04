using System.ComponentModel.DataAnnotations;


namespace Business.Contract.Model
{
    public class LoginUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        //[StringLength(25, ErrorMessage = "Password is limited to {2} to {1} characters", MinimumLength = 10)]
        public string Password { get; set; }
    }
}
