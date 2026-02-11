using System.ComponentModel.DataAnnotations;

namespace TeamNaGuara.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string DocumentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Position { get; set; }
        public string PhotoPath { get; set; }
        public string DocumentImagePath { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
