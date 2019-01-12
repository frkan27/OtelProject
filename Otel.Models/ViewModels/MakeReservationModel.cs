using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Models.ViewModels
{
  public class MakeReservationModel
    {
        public List<ReservationRegisterViewModel> RegisterViewModels  { get; set; }

        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? CheckOutDate { get; set; }



    }
}
