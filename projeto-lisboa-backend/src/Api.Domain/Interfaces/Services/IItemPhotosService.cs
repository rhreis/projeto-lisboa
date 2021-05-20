using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Items
{
    public interface IItemPhotosService
    {
        Task<ItemPhotosDto> Get(int id);

        Task<IEnumerable<ItemPhotosDto>> GetAll();

        Task<ItemPhotosDto> Post(ItemPhotosDto items);

        Task<ItemPhotosDto> Put(ItemPhotosDto items);

        Task<bool> Delete(int id);
    }
}

