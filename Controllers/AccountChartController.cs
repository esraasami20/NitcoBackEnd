using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NitcoBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NitcoBackEnd.Model;

namespace NitcoBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountChartController : ControllerBase
    {
        private AccountChartService _accountChartService;

        public AccountChartController(AccountChartService accountChartService)
        {
            _accountChartService = accountChartService;
        }

        //get all account
        [HttpGet]
        public ActionResult<List<AccountsChart>> GettAll()
        {
            return Ok(_accountChartService.GetAccounts());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountsChart>> GetAccountsChart(Guid id)
        {
            AccountsChart accounts = _accountChartService.GetAccountById(id);
            if (accounts == null)
                return NotFound();
            return Ok(accounts);
        }

        [HttpPut("{id}")]
        public ActionResult EditAccountAsync(Guid id, [FromBody] AccountsChart accounts)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(accounts);
            }
            else
            {
                accounts.Id = id;
                var result = _accountChartService.EditAccountData(id,accounts);
                if (result != null)
                    return NoContent();
                return NotFound();
            }

        }
    
        [HttpPost]
        public async Task<ActionResult<AccountsChart>> AddAccount(AccountsChart accounts)
        {
            if (ModelState.IsValid)
            {
                var result =  _accountChartService.addAccount(accounts);
                if (result != null)
                    return Ok(accounts);
                return StatusCode(StatusCodes.Status500InternalServerError, "Try again");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public ActionResult<AccountsChart> DeleteAccount(Guid id)
        {
            var result = _accountChartService.deleteAccounr(id);
            if (result!=null)
                return NoContent();
            else
                return NotFound();
        }
    }
}
