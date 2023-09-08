namespace ShopTARge22.Models.SpaceShips
{
    public class SpaceshipCreateViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BuildDate { get; set; }
        public int Passengers { get; set; }
        public int CargoWeight { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
