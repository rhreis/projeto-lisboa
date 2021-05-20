using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class TypePropertySetEntity : BaseEntity
    {
        public int MediaTypeId { get; set; }
        public TypesEntity Types { get; set; }
        public int PropertyId { get; set; }
        public PropertiesEntity Properties { get; set; }
    }
}