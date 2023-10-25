using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSofftek.DTOs;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Services;

namespace PruebaTecnicaSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CurrencyInformationService _currencyInfoService;
        public AccountController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAccount()
        {
            IEnumerable<Account> accountList = await _unitOfWork.AccountRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accountList));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AccountDto>> PostTrabajo([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (accountDto == null)
            {
                return BadRequest(accountDto);
            }

            Account accountModel = _mapper.Map<Account>(accountDto);
            await _unitOfWork.AccountRepository.Insert(accountModel);

            // Devolver una respuesta HTTP 201 (Created) sin especificar una ruta
            return StatusCode(StatusCodes.Status201Created, accountDto);
        }
        /*
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutJob(int id, [FromBody] JobDTO jobDto)
        {
            if (jobDto == null || id != jobDto.JobId)
            {
                return BadRequest();
            }

            Job trabajoModel = _mapper.Map<Job>(jobDto);
            await _unitOfWork.JobRepository.Update(trabajoModel);

            return NoContent();
        }*/

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAccount(int AccountId)
        {
            if (AccountId == 0)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.AccountRepository.Delete(AccountId);
                return NoContent();
            }
        }
        [HttpGet("ConsultarSaldo/{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> ConsultarSaldo(int AccountId)
        {
            var account = await _unitOfWork.AccountRepository.GetById(AccountId);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account.Balance);
        }
        [HttpPost("Depositar/{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> Depositar(int AccountId, [FromBody] decimal amount)
        {
            var account = await _unitOfWork.AccountRepository.GetById(AccountId);

            if (account == null)
            {
                return BadRequest("Cuenta no encontrada");
            }

            account.Balance += amount;
            await _unitOfWork.AccountRepository.Update(account);

            return Ok(account.Balance);
        }

        [HttpPost("Retirar/{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> Retirar(int AccountId, [FromBody] decimal amount)
        {          
            var account = await _unitOfWork.AccountRepository.GetById(AccountId);

            if (account == null)
            {
                return BadRequest("Cuenta no encontrada");
            }

            if (account.Balance < amount)
            {
                return BadRequest("Fondos insuficientes");
            }

            account.Balance -= amount;
            await _unitOfWork.AccountRepository.Update(account);

            return Ok(account.Balance);
        }

        /*
         Para poder comprar cripto
         de Pesos, a Dolares y ultimamente a Crypto.
         chequear qué tipo de cuenta es (En pesos o en dolares)
         Convertirlo a lo que sea necesario
         y enviarlo a la cuenta en cryptos
         */
        [HttpPost("CompraCrypto/{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> CompraCrypto(int AccountId, [FromBody] decimal amount)
        {
            var account = await _unitOfWork.AccountRepository.GetById(AccountId);
            if (account == null)
            {
                return BadRequest("Cuenta no encontrada");
            }
            var bankAccount = await _unitOfWork.BankAccountRepository.GetById(AccountId);
            if (account.Balance < amount)
            {
                return BadRequest("Fondos insuficientes");
            }
            if((int)bankAccount.Type == 1)
            {
                var dolarPrice = _currencyInfoService.getDolarInformation();
                return Ok(dolarPrice);
                //account.Balance = account.Balance / _currencyInfoService.getDolarValue();
                //account.Balance /= _currencyDataService.getDolarValue();
            }
            

            

            account.Balance -= amount;
            await _unitOfWork.AccountRepository.Update(account);

            return Ok(account.Balance);
        }
    }
}
