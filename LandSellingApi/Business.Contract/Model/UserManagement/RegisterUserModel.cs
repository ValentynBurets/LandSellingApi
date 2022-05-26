
namespace Business.Contract.Model
{
    public class RegisterUserModel : LoginUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
