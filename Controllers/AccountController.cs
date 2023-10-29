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
        public AccountController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtiene un listado de todas las Cuentas.
        /// </summary>
        /// <returns>Devuelve todas las cuentas cargadas en la DB.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAccount()
        {
            IEnumerable<Account> accountList = await _unitOfWork.AccountRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<AccountDto>>(accountList));
        }

        /// <summary>
        /// Crea una nueva Cuenta.
        /// </summary>
        /// <param name="accountDto">Los datos de la cuenta que se van a crear.</param>
        /// <returns>Devuelve un 201 = Se creo la cuenta.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AccountDto>> PostAccount([FromBody] AccountDto accountDto)
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
        public async Task<IActionResult> PutAccount(int id, [FromBody] JobDTO jobDto)
        {
            if (jobDto == null || id != jobDto.JobId)
            {
                return BadRequest();
            }

            Job trabajoModel = _mapper.Map<Job>(jobDto);
            await _unitOfWork.JobRepository.Update(trabajoModel);

            return NoContent();
        }*/
        /// <summary>
        /// Elimina una Cuenta por su ID.
        /// </summary>
        /// <param name="AccountId">Recibe el parametro AccountId para eliminar por id.</param>
        /// <returns>Devuelve un 204 para saber que la cuenta se elimino.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAccount(int AccountId)
        {
            // validacion para que exista la cuenta
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

        /// <summary>
        /// Consulta el Saldo por el Id de la cuenta.
        /// </summary>
        /// <param name="AccountId">Recibe el parametro AccountId para eliminar por id.</param>
        /// <returns>Devuelve un Ok con el balance de la cuenta pedida.</returns>
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

        /// <summary>
        /// Realiza un deposito a una cuenta por su Id y devuelve el saldo actualizado.
        /// </summary>
        /// <param name="AccountId">El Id de la cuenta donde va a ir el deposito.</param>
        /// <param name="amount">La cantidad a depositar.</param>
        /// <returns>Devuelve un Ok y el saldo actualizado.</returns>
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

        /// <summary>
        /// Realiza un retiro de una cuenta por su Id.
        /// </summary>
        /// <param name="AccountId">El id de la cuenta para buscar.</param>
        /// <param name="amount">Cantidad a retirar.</param>
        /// <returns>Devuelve un ok y el saldo/balance actualizado.</returns>
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
        /// <summary>
        /// Compra de Crypto.
        /// </summary>
        /// <param name="AccountId">Id de la cuenta para comprar crypto.</param>
        /// <param name="amount">Cantidad de plata(pesos) para comprar crypto</param>
        /// <param name="_currencyInformation">Proporciona informacion sobre el cambio de moneda y criptomonedas.</param>
        /// <returns>Devuelve un Ok mostrando el nuevo saldo y la cantidad de BTC comprada</returns>
        [HttpPost("CompraCrypto/{AccountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> CompraCrypto(int AccountId, [FromBody] decimal amount, [FromServices] CurrencyInformationService _currencyInformation)
        {
            // Esto nose si esta bien pero no encontre otra manera de hacerlo
             CryptoAccountDto cryptoDto = new CryptoAccountDto();
             CryptoAccount cryptoAccount = _mapper.Map<CryptoAccount>(cryptoDto);
            
            var account = await _unitOfWork.AccountRepository.GetById(AccountId);
            // Condicion para ver si existe la cuenta
            if (account == null)
            {
                return BadRequest("Cuenta no encontrada");
            }
            var bankAccount = await _unitOfWork.BankAccountRepository.GetById(AccountId);
            // Condicion que compara si el balance de la cuenta es menor al ingresado
            if (account.Balance < amount)
            {
                return BadRequest("Fondos insuficientes");
            }
            // Condicion para saber si es de tipo de cuenta ARS
            if ((int)bankAccount.Type == 1)
            {
                account.Balance -= amount;
                // Hace la division del balance con el Precio del Dolar y lo mismo con Crypto
                var convertedArsToUsd = amount / _currencyInformation.getDolarInformation();
                var convertedBTC = convertedArsToUsd / _currencyInformation.getCryptoInformation();
                cryptoAccount.CryptoBalance = convertedBTC;
            }
            //Condicion para saber si es de tipo de cuenta USD
            else if ((int)bankAccount.Type == 2)
            {                
                account.Balance -= amount;                
                // Hace la division del balance con el Precio de Crypto
                cryptoAccount.CryptoBalance = amount / _currencyInformation.getCryptoInformation();
            }
            cryptoAccount.AccountId = account.AccountId;
            cryptoAccount.CustomerId = bankAccount.CustomerId;

            await _unitOfWork.CryptoAccountRepository.Insert(cryptoAccount);
            await _unitOfWork.AccountRepository.Update(account);

            return Ok("Se compró BTC exitosamente, nuevo saldo: " + cryptoAccount.CryptoBalance);
        }
    }
}
