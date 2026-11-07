using System.ComponentModel.DataAnnotations;

namespace Shefaa.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }

        [MaxLength(255)]
        public string? ProfileImg { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        

       
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }

       
        //public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
      //  public ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; } = new List<UserPhoneNumber>();

        
       // public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
    

