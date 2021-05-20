using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ItemPhotoPropertySetEntity : BaseEntity
    {
        public int ItemPhotoId { get; set; }
        public virtual ItemPhotosEntity ItemPhotos { get; set; }
        public int PropertyId { get; set; }
        public virtual PropertiesEntity Properties { get; set; }
        public string Value { get; set; }

    }
}