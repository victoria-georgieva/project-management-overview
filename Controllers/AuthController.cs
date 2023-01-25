using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager
        {
            get;
        }
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> AddAdmin()
        {
           await CreateRoles();
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM signIn, string ReturnUrl)
        {
            IdentityUser user;
            if (signIn.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(signIn.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(signIn.UsernameOrEmail);
            }
            if (user == null)
            {
                ModelState.AddModelError("", "User Is Not Found!");
                return View(signIn);
            }
            var result = await
            _signInManager.PasswordSignInAsync(user, signIn.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is not correct!");
                return View(signIn);
            }
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }
      
        
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);

            IdentityUser newUser = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Username
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(register);
            }

            if (register.role==1)
            {
               await _userManager.AddToRoleAsync(newUser, "Developer");
            }
            else
            {

                await _userManager.AddToRoleAsync(newUser, "PM");

            }

            await _signInManager.PasswordSignInAsync(newUser, register.Password, true, true);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

        private async Task CreateRoles()
        {
            //initializing custom roles 
           // var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "CEO", "PM", "Developer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    try
                    {

                        roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                    catch(Exception e)
                    {
                        var p = e;
                    }
                   
                }
            }

            var poweruser = new IdentityUser
            {

                UserName = "CEO",
                Email = "ceo@yahoo.com",
                 
            };
           
            string userPWD = "4723688";
            try
            {
                //_userManager
                var createPowerUser = await _userManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                     _userManager.AddToRoleAsync(poweruser, "CEO");

                }
            }

            catch(Exception e)
            {

                var ee = e;
            }
             
                
           
        }



    }

}