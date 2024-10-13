using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public UpdateAddressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand Command)
        {
            var values = await _repository.GetByIdAsync(Command.AdressId);
            values.Detail1 = Command.Detail;
            values.District = Command.District;
            values.City = Command.City;
            values.UserId = Command.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
