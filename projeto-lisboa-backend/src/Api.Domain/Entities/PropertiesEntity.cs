using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class PropertiesEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<ItemPhotoPropertySetEntity> ItemPhotoPropertySet { get; set; }
    }
}