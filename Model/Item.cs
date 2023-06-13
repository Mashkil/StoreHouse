using StoreHouse.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public Status Status { get; set; }

        public int Amount { get; set; }

        public DateTimeOffset TimestampCreated { get; set; }

        public List<Transaction>? Transactions { get; set; }

        public List<ChangeStatus> ChangeStatuses { get; set; }
    }
}
