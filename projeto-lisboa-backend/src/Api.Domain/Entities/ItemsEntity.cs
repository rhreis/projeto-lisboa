using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ItemsEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<ItemPhotosEntity> ItemPhotos { get; set; }
    }
}