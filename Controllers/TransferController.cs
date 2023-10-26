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
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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

            var transfer = _mapper.Map<Transfer>(transferDto);
            transfer.TransferType = "Transferencia";
            transfer.Date = DateTime.Now;

            // Verificar que las cuentas de origen y destino existan 
            //var transfer = await _unitOfWork.TransferRepository.GetById(transferId);

            var originAccount = await _unitOfWork.AccountRepository.GetByOrigin(transfer.Origin);
            var destinationAccount = await _unitOfWork.AccountRepository.GetByDestination(transfer.Destination);

            if (originAccount == null || destinationAccount == null)
            {
                return BadRequest("Cuentas de origen o destino no válidas");
            }

            // Realizar la transferencia (restar del origen y sumar al destino)
            //Esto falta corregir ------------------------------------------
            if ((originAccount.Balance -= transfer.Amount) > 0)
            {
                destinationAccount.Balance += transfer.Amount;
                // Guardar las actualizaciones en las cuentas y la transferencia
                await _unitOfWork.AccountRepository.Update(originAccount);
                await _unitOfWork.AccountRepository.Update(destinationAccount);
                await _unitOfWork.TransferRepository.Insert(transfer);

                return StatusCode(StatusCodes.Status201Created, _mapper.Map<TransferDto>(transfer));
            }
            else { return BadRequest(); }
            
        }
    }
}
