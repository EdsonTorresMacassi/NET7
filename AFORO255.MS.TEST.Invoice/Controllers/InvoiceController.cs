using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.etm.DTOs;
using AFORO255.MS.TEST.Invoice.etm.Models;
using AFORO255.MS.TEST.Invoice.etm.Services;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Invoice.etm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        //private readonly IEventBus _eventBus;

        //public InvoiceController(IInvoiceService invoiceService, IEventBus eventBus)
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
            //_eventBus = eventBus;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_invoiceService.GetAll());
        }

        [HttpPost]
        public IActionResult Invoice([FromBody] InvoiceRequest request)
        {
            InvoiceModel transaction = new InvoiceModel(request.Amount, request.State);
            transaction = _invoiceService.Invoice(transaction);
            return Ok(transaction);
        }
    }
}
