using System.ComponentModel.DataAnnotations;

namespace Store.ViewModelVM
{
    public class ResetPasswordVM
    {
public int Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare (nameof(Password))]
    public string ConfirmPassword { get; set; }
    }
}
