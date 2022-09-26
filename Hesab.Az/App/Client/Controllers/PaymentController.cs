using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hesab.Az.App.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IPaymentService _paymentService;
        public static string invitationToken;
        private static int reservationId;
        private static string orderId;
        private static string sessionId;
        private static decimal amount;
        public PaymentController(ICategoryService categoryService, IPaymentService paymentService)
        {
            _categoryService = categoryService;
            _paymentService = paymentService;
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            return Ok(await _categoryService.GetCategoriesWithAttributes());
        }
        [HttpPost("Details")]
        public async Task<IActionResult> Details([FromForm]int? id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
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
                        CreatedAt = DateTime.Now
                    };
                    await _paymentService.AddAsync(transaction);
                }
                return Ok();
            }
            return BadRequest();
        }

    }
}
