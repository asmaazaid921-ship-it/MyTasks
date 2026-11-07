using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Packaging.Core;
using Store.Models;
using Store.Repository;

using Store.ViewModelVM;
using Store.Utilisite;
using Store.Migrations;
using Store.Utilisite.DbSeeding;



namespace Store.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;

         private readonly  IEmailSender _emailSender;

        IRepository<ApplicationUserOTP> _applicationUserOTP;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepository<ApplicationUserOTP> applicationUserOTP, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _applicationUserOTP = applicationUserOTP;
         
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }


            ApplicationUser user = new ApplicationUser();

            user.Name = registerVM.Name;
            user.Email = registerVM.Email;
            user.UserName = registerVM.UserName;
            user.Address = registerVM.Address;

            var result = await _userManager.CreateAsync(user, registerVM.Password);


            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}\n";
                }
                ModelState.AddModelError("", errors);
                return View(registerVM);

            } 
                var Token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var link = Url.Action(nameof(ConfirmEmail), "Account", new { area = "Identity", userId = user.Id, Token });
                await _emailSender.SendEmailAsync(registerVM.Email, "Confirm your email", $"Please confirm your email by clicking on this link: <a href='{link}'>Confirm Email</a>");

            

            

            return RedirectToAction("Login", "Account", new { area = "Identity" });
        }
        [HttpGet]


        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost ]
        public async Task<IActionResult> ConfirmEmail(string UserId  ,string Token)
        {
            var user =await _userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                return NotFound();
                TempData["Error"] = "User not found!";
                return RedirectToAction("Login", "Account", new { area = "Identity" });

            }
           // var Token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var Result= await _userManager.ConfirmEmailAsync(user, Token);
            if (!Result.Succeeded)
            {
                TempData["Error"] = "Email confirmation failed!";
            }
               TempData["Success"] = "Email confirmed successfully!";

                return RedirectToAction("Login", "Account", new { area = "Identity" });
            
           
        }
        

        [HttpGet]
        public IActionResult ResendEmailConfirmition()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> ResendEmailConfirmitionAsync(ResendEmailConfirmitionVM resendEmailConfirmitionVM)
        {
            var user = await _userManager.FindByEmailAsync(resendEmailConfirmitionVM.UserNameOrEmail);
            await _userManager.FindByNameAsync(resendEmailConfirmitionVM.UserNameOrEmail);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email");
                return View(resendEmailConfirmitionVM);
            }

            if (user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email is already confirmed");
                return View(resendEmailConfirmitionVM);

                var Token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var link = Url.Action(nameof(ConfirmEmail), "Account", new { area = "Identity", userId = user.Id, Token });
                await _emailSender.SendEmailAsync(user.Email, "Confirm your email", $"Please confirm your email by clicking on this link: <a href='{link}'>Confirm Email</a>");



            }

            return RedirectToAction("Login", "Account", new { area = "Identity" });


           
        }



        [HttpGet]
        public IActionResult Login()
        {
           



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {


            var user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
            await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
            if (!result.Succeeded)
            {

                ModelState.AddModelError("", "Invalid password");
                return View(loginVM);
            }
            TempData["Success"] = "Login successful!";
            return RedirectToAction("Index","Home",new { area = "Customer" });
            
        }
        [HttpGet]


        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ForgetPassword( ForgetPasswordVM forgetPasswordVM)
        {

            var user = await _userManager.FindByEmailAsync(forgetPasswordVM.UserNameOrEmail);
            await _userManager.FindByNameAsync(forgetPasswordVM.UserNameOrEmail);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email");
                return View(forgetPasswordVM);
            }

            var otp = new Random().Next(1000, 9999) .ToString();
            var applicationUserOtp = new ApplicationUserOTP(otp,user.Id);
            await _applicationUserOTP.AddAsync(applicationUserOtp);
            await _applicationUserOTP.SaveChangesAsync();
            await _emailSender.SendEmailAsync(user.Email, "Reset your password", $"<h1> use this <span style =\"color: red \">{otp}</span> to Rest your Password</a>");

       
            return RedirectToAction(nameof(VerifyOTP), new {userId=user.Id});
        }

        [HttpGet]


        public IActionResult VerifyOTP(String userId)
        {
            return View(new VerifyOTPVM() { UserId=userId});
        }

        [HttpPost]
        public async  Task<IActionResult>VerifyOTP(VerifyOTPVM verifyOTPVM)
        { 

            var user= await _userManager.FindByIdAsync(verifyOTPVM.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email");
                return View(verifyOTPVM);
            }
            var otp = await _applicationUserOTP.GetAsync(
                e => e.ApplicationUserId == user.Id &&
                e.IsValid == true &&
                DateTime.UtcNow < e.Validto && e.OTP == verifyOTPVM.OTP);

            if (otp == null || otp.OTP != verifyOTPVM.OTP)
            {
                ModelState.AddModelError("", "Invalid OTP");
                return View(verifyOTPVM);
            }
            otp.IsValid = false;
            

            return RedirectToAction( nameof(ResetPassword) , new { userId = user.Id });
        }
        [HttpGet]


        public IActionResult ResetPassword( string userId)
        {
            return View(new ResetPasswordVM() { UserId = userId });
        }

        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var user = await _userManager.FindByIdAsync(resetPasswordVM.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or email");
                return View(resetPasswordVM);
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordVM.Password);
            await _applicationUserOTP.SaveChangesAsync();
            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}\n";
                }
                ModelState.AddModelError("", errors);
                return View(resetPasswordVM);
            }
             TempData["Success"] = "Password reset successful!";

            return RedirectToAction("Login", "Account");
        }



        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
            RedirectToAction("Login", "Account");

        }
    }
}
