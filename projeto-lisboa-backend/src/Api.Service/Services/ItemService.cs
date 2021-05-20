using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Items;
using AutoMapper;

namespace Api.Service.Services
{
    public class ItemService : IItemService
    {        
        private IRepository<ItemsEntity> _repositoryItemsEntity;
        private IRepository<ItemPhotosEntity> _repositoryItemPhotosEntity;
        private readonly IMapper _mapper;

        public ItemService(IRepository<ItemsEntity> repositoryItemsEntity, IRepository<ItemPhotosEntity> repositoryItemPhotosEntity, IMapper mapper)
        {
            _repositoryItemsEntity = repositoryItemsEntity;
            _repositoryItemPhotosEntity = repositoryItemPhotosEntity;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repositoryItemsEntity.DeleteAsync(id);
        }

        public async Task<ItemDto> Get(int id)
        {
            var entity = await _repositoryItemsEntity.SelectAsync(id);
            var dto = _mapper.Map<ItemDto>(entity);
            return dto;
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var listItemsEntity = await _repositoryItemsEntity.SelectFillAsync();

            //var listItemsEntity = await _repositoryItemsEntity.SelectAsync();

            //var listItemPhotosEntity = await _repositoryItemPhotosEntity.SelectAsync();

            var dto = _mapper.Map<IEnumerable<ItemDto>>(listItemsEntity);

            return dto;
        }

        public async Task<ItemDto> Post(ItemDto item)
        {
            var entity = _mapper.Map<ItemsEntity>(item);

            var result = await _repositoryItemsEntity.InsertAsync(entity);
            
            return _mapper.Map<ItemDto>(result);
        }

        public async Task<ItemDto> Put(ItemDto item)
        {
            var entity = _mapper.Map<ItemsEntity>(item);
            
            var result = await _repositoryItemsEntity.UpdateAsync(entity);
            
            return _mapper.Map<ItemDto>(result);
        }
    }
}