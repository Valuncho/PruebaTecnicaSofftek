using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSofftek.DTOs;
using PruebaTecnicaSofftek.Models;
using PruebaTecnicaSofftek.Services;
using PruebaTecnicaSofftek.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaSofftek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransferController(IMapper mapper, IUnitOfWork unitOfWork)
        {   // proporciona acceso a varios repositorios y operaciones relacionadas con la base de datos
            _unitOfWork = unitOfWork;            
            _mapper = mapper;
        }

        /// <summary>
        /// Crea una transferencia entre cuentas.
        /// </summary>
        /// <param name="transferDto">Trae los atributos de la clase TransferController.</param>
        /// <returns>Devuelve un 201 con las cuentas actualizadas y una transferencia creada en la db.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TransferDto>> CreateTransfer([FromBody] TransferDto transferDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // mapea un objeto (transfer dto) a Transfer y el resultado se asigna a transfer
            var transfer = _mapper.Map<Transfer>(transferDto);
            // Esto falto corregir
            transfer.TransferType = "Transferencia";
            // Asigna la fecha 
            transfer.Date = DateTime.Now;

            // Verificar que las cuentas de origen y destino existan 
            var originAccount = await _unitOfWork.AccountRepository.GetByOrigin(transfer.Origin);
            var destinationAccount = await _unitOfWork.AccountRepository.GetByDestination(transfer.Destination);
            
            if (originAccount == null || destinationAccount == null)
            {
                return BadRequest("Cuentas de origen o destino no válidas");
            }            
            // Realizar la transferencia (restar del origen y sumar al destino)
            if ((originAccount.Balance -= transfer.Amount) > 0)
            {
                destinationAccount.Balance += transfer.Amount;
                // Guardar las actualizaciones en las cuentas y la transferencia
                await _unitOfWork.AccountRepository.Update(originAccount);
                await _unitOfWork.AccountRepository.Update(destinationAccount);
                await _unitOfWork.TransferRepository.Insert(transfer);

                return StatusCode(StatusCodes.Status201Created, _mapper.Map<TransferDto>(transfer));
            }
            else 
            { 
                return BadRequest(); 
            }            
        }
    }
}
