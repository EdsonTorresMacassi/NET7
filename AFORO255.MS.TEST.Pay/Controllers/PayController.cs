using Microsoft.AspNetCore.Mvc;

using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.etm.DTOs;
using AFORO255.MS.TEST.Pay.etm.Messages.Commands;
using AFORO255.MS.TEST.Pay.etm.Models;
using AFORO255.MS.TEST.Pay.etm.Services;

namespace AFORO255.MS.TEST.Pay.etm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;
        private readonly IEventBus _eventBus;

        public PayController(IPayService payService, IEventBus eventBus)
        {
            _payService = payService;
            _eventBus = eventBus;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_payService.GetAll());
        }

        [HttpPost]
        public IActionResult Pay([FromBody] PayRequest request)
        {
            PayModel transaction = new PayModel(request.IdInvoice, request.Amount);
            transaction = _payService.Pay(transaction);

            _eventBus.SendCommand(new TransactionCreateCommand(transaction.Id, transaction.IdInvoice, transaction.Amount, transaction.Date));
            _eventBus.SendCommand(new InvoiceCreateCommand(transaction.IdInvoice, transaction.Amount, transaction.Date));
            return Ok(transaction);
        }
    }
}
