namespace CSharp_Heroes.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Hero> Heroes { get; set; }

    }
}
