using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region EntitytoDto
            CreateMap<ItemsEntity, ItemDto>();
            CreateMap<ItemPhotosEntity, ItemPhotosDto>();
            CreateMap<ItemPhotoPropertySetEntity, ItemPhotoPropertySetDto>();
            #endregion

            #region DtoToEntity
            CreateMap<ItemDto, ItemsEntity>();
            CreateMap<ItemPhotosDto, ItemPhotosEntity>();
            CreateMap<ItemPhotoPropertySetDto, ItemPhotoPropertySetEntity>();
            #endregion

        }
    }
}
