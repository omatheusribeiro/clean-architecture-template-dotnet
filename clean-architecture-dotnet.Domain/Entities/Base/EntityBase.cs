namespace clean_architecture_dotnet.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
