using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Model
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int ManagerWhoSoldId { get; set; }

        public DateTimeOffset TimestampCreated { get; set; }

        public Manager ManageWhoSold { get; set; }

        public Item Item { get; set; }
    }
}
