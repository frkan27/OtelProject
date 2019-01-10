using Otel.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Models.Entities
{
    [Table("RoomCategories")]
    public class RoomCategory : BaseEntity<int>
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    }
}
