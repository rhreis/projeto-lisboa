using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Items
{
    public interface IItemService
    {
        Task<ItemDto> Get(int id);

        Task<IEnumerable<ItemDto>> GetAll();

        Task<ItemDto> Post(ItemDto items);

        Task<ItemDto> Put(ItemDto items);

        Task<bool> Delete(int id);
    }
}

