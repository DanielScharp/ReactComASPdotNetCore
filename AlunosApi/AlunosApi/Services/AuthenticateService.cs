using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AlunosApi.Services
{
    public class AuthenticateService :IAuthenticate
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticateService(SignInManager<IdentityUser> signInManager) 
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, 
                password, 
                false, //Define se o cookie de entrada deve persistir depois que o navegador for fechado
                lockoutOnFailure: false //Define que não quer que a conta do usuario seja bloqueada se a conexão falhar
            );
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
