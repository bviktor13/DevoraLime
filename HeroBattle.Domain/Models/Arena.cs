using System.ComponentModel.DataAnnotations;

namespace HeroBattle.Domain.Models
{
    public class Arena
    {
        [Key]
        public string Id { get; set; }

        public int NumberOfHeroes { get; set; }

        public bool IsFinished { get; set; }

        public List<Round> History { get; set; } = new List<Round>();
    }
}
