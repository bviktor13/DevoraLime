using System.ComponentModel.DataAnnotations;

namespace HeroBattle.Domain.Models
{
    public  class Round
    {
        [Key]
        public int Id { get; set; }

        public string ArenaId { get; set; }

        public string Info { get; set; }
    }
}
