namespace CSharp_Heroes.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<HeroPower> Heroes { get; set; }

    }
}
