using Otel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL.Repository
{
    public class RoomRepo : RepositoryBase<Room, int>
    {
        public override List<Room> GetAll()
        {
            return base.GetAll(x => x.IsUseable);//tüm odaları istediğimde her zaman useable olanlar gelsin.
        }
    }
}
