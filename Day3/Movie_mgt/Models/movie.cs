namespace Movie_mgt.Models
{
    public class movie
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Director { get; set; }
        public string Genre { get; set; } 
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
