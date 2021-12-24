using CardFile.Models;
using CardFileBLL.DTO;
using CardFileBLL.Infrastructure;
using CardFileBLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CardFile.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                if (model.Password==model.ConfirmPassword)
                {
                    UserDTO userDto = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.Name,
                        Surname = model.Surname,
                        TextCounter = 0,
                        Role = "Registered"
                    };
                    OperationDetails operationDetails = await UserService.Create(userDto);
                    if (operationDetails.Succedeed)
                        return RedirectToAction("Index", "Home");
                    else
                        ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Password mismatch");
                }
                
            }
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "oleh@gmail.com",
                UserName = "oleh@gmail.com",
                Password = "qwer1234",
                Name = "Oleh",
                Surname="Bazarbaiev",
                TextCounter=0,
                Role = "Admin",
            }, new List<string> { "Registered", "Admin" });
        }
    }
}