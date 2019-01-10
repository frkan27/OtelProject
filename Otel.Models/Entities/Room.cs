using Otel.Models.Abstracts;
using Otel.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Models.Entities
{
    [Table("Rooms")]
    public class Room : BaseEntity<int>
    {
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        public RoomTypes RoomType { get; set; }
        public decimal Price { get; set; }
        public bool IsEmpty { get; set; } = true;
        public bool IsUseable { get; set; } = true;
        public int RoomCategoryId { get; set; }


        [ForeignKey("RoomCategoryId")]
        public virtual RoomCategory RoomCategory { get; set; }
       public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new HashSet<ReservationDetail>();

    }
}
