using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ItemPhotosEntity : BaseEntity
    {        
        public int ItemId { get; set; }
        public virtual ItemsEntity Item { get; set; }
        public int TypeId { get; set; }
        public virtual TypesEntity Type { get; set; }
        public string FileName { get; set; }
        public int Position { get; set; }
        public string Alt { get; set; }        
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public List<ItemPhotoPropertySetEntity> ItemPhotoPropertySet { get; set; }
    }
}