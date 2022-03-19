using System.ComponentModel.DataAnnotations;

namespace Business.Contract.Model
{
    public class UpdatePasswordModel
    {
        [Required]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}:;<>,.?~_+-=|]).{10,25}$")]
        public string CurrentPassword { get; set; }

        [Required]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}:;<>,.?~_+-=|]).{10,25}$")]
        public string NewPassword { get; set; }
    }
}
