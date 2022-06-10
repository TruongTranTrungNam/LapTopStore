using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapTopStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Laptop laptop, int quantity)
        {
            CartLine line = Lines
            .Where(l => l.Laptop.LaptopID == laptop.LaptopID)
            .FirstOrDefault(); if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Laptop = laptop,
                    Quantity = quantity,
                    

                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Laptop laptop) =>
        Lines.RemoveAll(l => l.Laptop.LaptopID == laptop.LaptopID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Laptop.GiaTien * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Laptop Laptop { get; set; }
        public int Quantity { get; set; }
        
    }
}
