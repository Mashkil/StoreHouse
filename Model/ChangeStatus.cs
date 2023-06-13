using StoreHouse.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Model
{
    public class ChangeStatus
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset TimeOfChange { get; set; }

        public int ItemId { get; set; }

        public Status From { get; set; }

        public Status To { get; set; }

        public Item Item { get; set; }
    }
}
