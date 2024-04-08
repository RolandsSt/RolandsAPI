namespace RolandsAPI.Models
{
    public class Dzivoklis
    {
        public int Id { get; set; }
        public int Numurs { get; set; }
        public int Stavs { get; set; }
        public int IstabuSkaits { get; set; }
        public int IedzivotajuSkaits { get; set; }
        public float PilnaPlatiba { get; set; }
        public float DzivojamaPlatiba { get; set; }
        public int MajaId { get; set; }
        public string? Secret { get; set; }
    }
}
