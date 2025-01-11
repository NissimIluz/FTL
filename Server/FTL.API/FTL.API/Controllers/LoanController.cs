using FLT.Loan.Application.Abstractions.Services;
using FTL.User.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace FTL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoanInterestsService _loanInterestsService;

        public LoanController(IUserService userService, ILoanInterestsService loanInterestsService)
        {
            _userService = userService;
            _loanInterestsService = loanInterestsService;
        }

        [HttpGet("CalculateLoanInterests/{userId}")]
        public async Task<IActionResult> CalculateLoanInterests(string userId, [FromQuery] decimal amount, [FromQuery] int periodInMonth)
        {
            var user = await _userService.GetUserAsync(userId);
            var interest = _loanInterestsService.CalculateInterest(user, amount, periodInMonth);
            return Ok(interest);

        }
    }
}
