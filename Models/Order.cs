using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiTrackAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();

        public void AddItem(InventoryItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(InventoryItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
    }
}
