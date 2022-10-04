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
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet("MyCards/{id}")]
        public async Task<ActionResult<List<Card>>> GetCards([FromRoute] string id)
        {
            var cards= await _cardService.GetCards(id);
            if (cards == null)
            {
                return NotFound();
            }
            return Ok(cards);
        }

    }
}
