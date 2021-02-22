using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ITMatching.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace ITMatching.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExpertRegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public ExpertRegisterModel(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "Please enter your First name", MinimumLength = 2)]
            [Display(Name = "First Name")]
            [RegularExpression(@"^[a-zA-Z]*", ErrorMessage = "Name should not contain digits")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Please enter your Last name", MinimumLength = 2)]
            [Display(Name = "Last Name")]
            [RegularExpression(@"^[a-zA-Z]*", ErrorMessage = "Name should not contain digits")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Please enter your primary phone number", MinimumLength = 6)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            //[RegularExpression(@"^[0-9]{10-13}", ErrorMessage = "Phone number should not contain letters")]

            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Work Schedule Start Time")]
            public string StartTime { get; set; }

            [Required]
            [Display(Name = "Work Schedule End Time")]
            public string EndTime { get; set; }

            [Required]
            [Display(Name = "Work Schedule [From]")]
            public string FromDay { get; set; }

            [Required]
            [Display(Name = "Work Schedule [To]")]
            public string ToDay { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        ITMatchingAppContext context = new ITMatchingAppContext();
                        Itmuser Ituser = new Itmuser()
                        {
                            Username = Input.Email,
                            FirstName = Input.FirstName,
                            LastName = Input.LastName,
                            PhoneNumber = Input.PhoneNumber,
                            Email = Input.Email,
                            AspnetUserId = user.Id
                        };
                        context.Itmusers.Add(Ituser);
                        context.SaveChanges();
                        Itmuser use = context.Itmusers.FirstOrDefault(item => item.Email == Ituser.Email);
                        Expert exp = new Expert()
                        {
                            WorkSchedule = Input.StartTime + " - " + Input.EndTime + " " + Input.FromDay + " to " + Input.ToDay,
                            ItmuserId = use.Id
                        };
                        context.Experts.Add(exp);
                        context.SaveChanges();
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}