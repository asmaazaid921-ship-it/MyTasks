using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using System.Diagnostics.Metrics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using Store.ViewModelVM;

namespace Store.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubImage> ProductSubImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ApplicationUserOTP> ApplicationUserOTPs { get; set; }
        public DbSet<Store.ViewModelVM.VerifyOTPVM> VerifyOTPVM { get; set; } = default!;
        public DbSet<Store.ViewModelVM.ResetPasswordVM> ResetPasswordVM { get; set; } = default!;

        //  public DbSet<Store.ViewModelVM.LoginVM> LoginVM { get; set; } = default!;
        // public DbSet<Store.ViewModelVM.ResendEmailConfirmitionVM> ResendEmailConfirmitionVM { get; set; } = default!;
        // public DbSet<Store.ViewModelVM.ForgetPasswordVM> ForgetPasswordVM { get; set; } = default!;
        //  public DbSet<Store.ViewModelVM.RegisterVM> RegisterVM { get; set; } = default!;
        // public DbSet<Store.ViewModelVM.LoginVM> LoginVM { get; set; } = default!;

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //   base.OnConfiguring(optionsBuilder);

        //   optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30 ");
        //  }
    }
}
