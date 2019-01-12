using Otel.Models.Entities;
using Otel.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL.Repository
{
    public class ReservationRepo : RepositoryBase<Reservation, Guid>
    {
        public Guid MakeReservation(MakeReservationModel model)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var reservation = new Reservation()
                    {
                        ReservationDate=model.ReservationDate,
                        CheckOutDate=model.CheckOutDate,
                        RoomId = model.RoomId

                    };
                    db.Reservations.Add(reservation);
                    db.SaveChanges();

                    foreach (var registerViewModel in model.RegisterViewModels)
                    {
                        db.ReservationDetails.Add(new ReservationDetail()
                        {
                            FirstName = registerViewModel.FirstName,
                            LastName = registerViewModel.Surname,
                            ReservationId = reservation.Id,
                            TelephoneNumber = registerViewModel.Telephone

                        });

                        db.SaveChanges();
                    }
             
                    //Odanın boş olup olmadığını göstermek için.
                    var room = db.Rooms.Find(model.RoomId);
                    room.IsEmpty = false;
                    db.SaveChanges();


                    tran.Commit();
                    return reservation.Id;

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
