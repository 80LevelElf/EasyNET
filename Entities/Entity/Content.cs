namespace EN.Core.Entity
{
    public class Content : EntityBase
    {
        public string ContentTitle { get; set; }
        public string ContentBody { get; set; }
        public int ContentTypeId { get; set; }
    }
}
