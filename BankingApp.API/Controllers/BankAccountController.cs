using BankingApp.API.Models;
using BankingApp.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(WithdrawRequest request)
        {
            try
            {
                var result = await _bankAccountService.WithdrawAsync(request.AccountAccount, request.Amount);

                if (!result.IsSuccessful)
                    return BadRequest(result.Message);

                return Ok(result);
            }
            catch
            {
               return Problem();
            }
        }
    }

}
