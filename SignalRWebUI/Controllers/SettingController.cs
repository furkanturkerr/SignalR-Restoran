using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers;

public class SettingController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    
    public SettingController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        UserEditDto userEditDto = new UserEditDto();
        userEditDto.Surname = value.Surname;
        userEditDto.Name = value.Name;
        userEditDto.UserName = value.UserName;
        userEditDto.Mail = value.Email;
        return View(userEditDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(UserEditDto userEditDto)
    {
        if (userEditDto.Password == userEditDto.ConfirmPassword)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Surname = userEditDto.Surname;
            user.Name = userEditDto.Name;
            user.UserName = userEditDto.UserName;
            user.Email = userEditDto.Mail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Setting");
        }
        return View(userEditDto);
    }
}