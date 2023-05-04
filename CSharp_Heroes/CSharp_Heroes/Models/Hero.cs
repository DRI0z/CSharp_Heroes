namespace CSharp_Heroes.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public School School{ get; set; }

        public IList<HeroPower> Powers { get; set; }

    }
}
