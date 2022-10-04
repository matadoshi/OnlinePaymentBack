using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IAttributeService _attributeService;
        private readonly IPaymentService _paymentService;
        public static string invitationToken;
        private static int reservationId;
        private static string orderId;
        private static string sessionId;
        private static decimal amount;
        public PaymentController(ICategoryService categoryService, IPaymentService paymentService, IAttributeService attributeService)
        {
            _categoryService = categoryService;
            _paymentService = paymentService;
            _attributeService = attributeService;
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            return Ok(await _categoryService.GetCategoriesWithAttributes());
        }
        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromForm]decimal amount, [FromForm] int attributeId)
        {
            var attribute = await _attributeService.GetDataForAttributes(attributeId);
            if (attribute == null) return NotFound();

            var data = await _paymentService.CreatePayment(new CreatePaymentRequest
            {
                Amount = amount * 100,
                LanguageCode = "AZ",
                Description = "Payment",
                Platform = attribute.Name
            });
            var returnUrl = data.Response.Order.Url + "?ORDERID=" + data.Response.Order.OrderId + "&SESSIONID=" + data.Response.Order.SessionId;

            return Ok(returnUrl);
        }
        [HttpPost("Approve")]
        public async Task<IActionResult> Approve()
        {
            if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(sessionId))
            {
                var request = new PaymentStatusRequest
                {
                    LanguageCode = "AZ",
                    PaymentOrderId = orderId,
                    PaymentSessionId = sessionId
                };

                var data = await _paymentService.GetPaymentStatus(request);
                if (data.Response.Order.OrderStatus == "APPROVED")
                {
                    Transaction transaction = new Transaction
                    {
                        OrderId = orderId,
                        Amount = amount,
                        StatusId = data.Response.Status,
                        Status = data.Response.Order.OrderStatus,
                        CreatedDate = DateTime.Now
                    };
                    await _paymentService.AddAsync(transaction);
                }
                return Ok();
            }
            return BadRequest();
        }

    }
}
