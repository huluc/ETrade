using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entity.Abstract;

namespace ETrade.Entity.Concrete
{
    public class Cart : IEntity
    {
        List<CartLine> _lines = new List<CartLine>();

        public void AddToCart(Product product, int quantity)
        {
            CartLine cartLine = _lines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(line => line.Product.ProductId == product.ProductId);
        }

        public decimal Total
        {
            get { return _lines.Sum(line => line.Product.UnitPrice * line.Quantity); }
        }

        public void Clear()
        {
            _lines.Clear();
        }

        public List<CartLine> Lines
        {
            get { return _lines; }
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
