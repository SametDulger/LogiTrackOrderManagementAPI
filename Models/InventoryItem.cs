using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiTrackAPI.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public string? Location { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
