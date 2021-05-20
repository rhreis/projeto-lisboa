using System;
using System.Collections.Generic;

namespace Api.Domain.Dtos
{
    public class ItemPhotosDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int TypeId { get; set; }
        public string FileName { get; set; }
        public int Position { get; set; }
        public string Alt { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public List<ItemPhotoPropertySetDto> ItemPhotoPropertySet { get; set; }
    }
}