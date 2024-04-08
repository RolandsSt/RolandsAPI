namespace RolandsAPI.Models
{
    public class Iedzivotajs
    {
        public int Id { get; set; }
        public string? Vards { get; set; }
        public string? Uzvards { get; set; }
        public string? PersonasKods { get; set; }
        public DateTime DzimsanasDatums { get; set; }
        public int Telefons { get; set; }
        public string? Email { get; set; }
        public int DzivoklisId { get; set; }
        public bool IsOwner { get; set; }
        public string? Secret { get; set; }
    }
}
