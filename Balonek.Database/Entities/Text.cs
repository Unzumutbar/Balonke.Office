namespace Balonek.Database.Entities
{
    public class Text : BaseEntity
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id.ToString(), Value);
        }
    }
}
