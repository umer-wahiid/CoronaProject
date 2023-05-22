namespace ECProject.Models
{
    public class CartItem
    {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public double Total
            {
                get { return Quantity * Price; }
            }
            public string Image { get; set; }
            public CartItem() { }
            public CartItem(Product product)
            {
                ProductId = product.ProductId;
                ProductName = product.ProductName;
                Price = product.Price;
                Quantity = 1;
                Image = product.PImage;
            }
    }
}