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
    public class ItemPhotoService : IItemPhotosService
    {        
        private IRepository<ItemPhotosEntity> _itemPhotosEntityRepository;
        private readonly IMapper _mapper;

        public ItemPhotoService(IRepository<ItemPhotosEntity> itemPhotosEntityRepository, IMapper mapper)
        {
            _itemPhotosEntityRepository = itemPhotosEntityRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _itemPhotosEntityRepository.DeleteAsync(id);
        }

        public async Task<ItemPhotosDto> Get(int id)
        {
            var entity = await _itemPhotosEntityRepository.SelectAsync(id);
            var dto = _mapper.Map<ItemPhotosDto>(entity);
            return dto;
        }

        public async Task<IEnumerable<ItemPhotosDto>> GetAll()
        {
            var listEntity = await _itemPhotosEntityRepository.SelectAsync();

            var dto = _mapper.Map<IEnumerable<ItemPhotosDto>>(listEntity);

            return null;
        }

        public async Task<ItemPhotosDto> Post(ItemPhotosDto item)
        {
            var entity = _mapper.Map<ItemPhotosEntity>(item);

            if (entity != null && entity.ItemPhotoPropertySet != null &&
                entity.ItemPhotoPropertySet.Count > 0)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            var result = await _itemPhotosEntityRepository.InsertAsync(entity);
            
            return _mapper.Map<ItemPhotosDto>(result);
        }

        public async Task<ItemPhotosDto> Put(ItemPhotosDto item)
        {
            var entity = _mapper.Map<ItemPhotosEntity>(item);

            var entityFind = await _itemPhotosEntityRepository.SelectAsync(item.Id);

            if (entityFind != null)
            {
                entityFind.ItemPhotoPropertySet = new List<ItemPhotoPropertySetEntity>(entity.ItemPhotoPropertySet);
                entityFind.ModifiedAt = DateTime.UtcNow;
            }

            var result = await _itemPhotosEntityRepository.UpdateAsync(entityFind);
            
            return _mapper.Map<ItemPhotosDto>(result);
        }
    }
}