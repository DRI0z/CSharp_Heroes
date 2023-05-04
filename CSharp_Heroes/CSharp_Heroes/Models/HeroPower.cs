namespace CSharp_Heroes.Models
{
    public class HeroPower
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        public int PowerId { get; set; }
        public Power Power { get; set; }
    }
}
