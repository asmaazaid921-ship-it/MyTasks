using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Utilisite.DbSeeding
{
    public class DbInitilizer : IDbInitilizer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DbInitilizer> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public DbInitilizer(ApplicationDbContext context, ILogger<DbInitilizer> logger = null, UserManager<ApplicationUser> userManager = null, RoleManager<IdentityRole> roleManager = null)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();

                }
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole(CD.SUPER_ADMIN_ROLE));
                    await _roleManager.CreateAsync(new IdentityRole(CD.ADMIN_ROLE));
                    await _roleManager.CreateAsync(new IdentityRole(CD.CUSTOMER_ROLE));
                    await _roleManager.CreateAsync(new IdentityRole(CD.EMPLOYEE_ROLE));
                }
                    await _userManager.CreateAsync(new ApplicationUser()
                    {
                        Name = "ASMAA",
                        UserName = "Asmaa@gmail.com",
                        Email = "Asmaa@gmail.com",
                        EmailConfirmed = true,
                    }, "Aa@123");

                    var user = await _userManager.FindByEmailAsync("superadmin@example.com");
                    await _userManager.AddToRoleAsync(user, CD.SUPER_ADMIN_ROLE);

                

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

        }
    }
}
