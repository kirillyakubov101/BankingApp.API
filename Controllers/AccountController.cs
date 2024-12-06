using Banking.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AccountController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            var accounts = _context.Account.ToList();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var account = _context.Account.Find(id);

            if(account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
