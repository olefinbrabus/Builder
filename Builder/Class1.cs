namespace Builder;

using System;

public class OrderForm
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string DeliveryAddress { get; set; }
    public bool ExpressDelivery { get; set; }

    public void Display()
    {
        Console.WriteLine($"Product: {ProductName}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Delivery Address: {DeliveryAddress}");
        Console.WriteLine($"Express Delivery: {(ExpressDelivery ? "Yes" : "No")}");
    }
}

public interface IOrderFormBuilder
{
    void BuildProduct(string productName);
    void BuildQuantity(int quantity);
    void BuildDeliveryAddress(string deliveryAddress);
    void BuildExpressDelivery(bool expressDelivery);
    OrderForm GetResult();
}

public class OrderFormBuilder : IOrderFormBuilder
{
    private OrderForm _orderForm = new OrderForm();

    public void BuildProduct(string productName)
    {
        _orderForm.ProductName = productName;
    }

    public void BuildQuantity(int quantity)
    {
        _orderForm.Quantity = quantity;
    }

    public void BuildDeliveryAddress(string deliveryAddress)
    {
        _orderForm.DeliveryAddress = deliveryAddress;
    }

    public void BuildExpressDelivery(bool expressDelivery)
    {
        _orderForm.ExpressDelivery = expressDelivery;
    }

    public OrderForm GetResult()
    {
        return _orderForm;
    }
}

public class OrderDirector
{
    private IOrderFormBuilder _builder;

    public OrderDirector(IOrderFormBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructOrder(string productName, int quantity, string deliveryAddress, bool expressDelivery)
    {
        _builder.BuildProduct(productName);
        _builder.BuildQuantity(quantity);
        _builder.BuildDeliveryAddress(deliveryAddress);
        _builder.BuildExpressDelivery(expressDelivery);
    }
}

class Program
{
    static void Main()
    {
        var builder = new OrderFormBuilder();
        
        var director = new OrderDirector(builder);

        director.ConstructOrder("Laptop", 2, "123 Main St", true);

        var orderForm = builder.GetResult();

        orderForm.Display();
    }
}
