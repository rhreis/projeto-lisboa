namespace Api.Domain.Dtos
{
    public class ItemPhotoPropertySetDto
    {
        public int Id { get; set; }
        public int ItemPhotoId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }
    }
}