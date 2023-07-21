using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; } // kiralama tarihi
        public DateTime? ReturnDate { get; set; } // teslim tarihi
        //  Araba teslim edilmemişse ReturnDate null'dır.

    }
}
