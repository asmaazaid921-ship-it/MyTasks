using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.ViewModelVM;

namespace Store.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class ProfileController : Controller
    {
       private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var  user= await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View();
            }
            var applicationUserVM = new ApplicationUserVM();

            applicationUserVM.Name = user.Name;
            applicationUserVM.Email = user.Email;
            applicationUserVM.Address = user.Address;
            applicationUserVM.phoneNumber = user.PhoneNumber;
            


            return View(applicationUserVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ApplicationUserVM applicationUserVM)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View();
            }
            user.Name = applicationUserVM.Name;
            user.Email = applicationUserVM.Email;
            user.Address = applicationUserVM.Address;
            user.PhoneNumber = applicationUserVM.phoneNumber;
           var result=await  _userManager.UpdateAsync(user);
           if (!result.Succeeded)
           {
               TempData["fail"] = "Profile updated fail!";
                return View(nameof (Index),applicationUserVM);
           }
           else
            
                TempData["succefull"] = "Profile updated succefull!";
            
           return RedirectToAction("Index");
        }
    }
}
