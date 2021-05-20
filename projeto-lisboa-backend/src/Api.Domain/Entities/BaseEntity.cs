using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}