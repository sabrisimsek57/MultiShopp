using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAddressByIdQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var valeus = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AdressId = valeus.AdressId,
                City = valeus.City,
                Detail = valeus.Detail1,
                District = valeus.District,
                UserId = valeus.UserId,
            };
        } 
    }
}
