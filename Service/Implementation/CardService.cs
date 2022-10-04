using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repo;

        public CardService(ICardRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Card>> GetCards(string id)
        {
            return _repo.GetCards(id);
        }
    }
}
