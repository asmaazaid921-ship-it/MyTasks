namespace Store.ViewModelVM
{
    public class LoginVM
    {
       public int Id { get; set; }
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
