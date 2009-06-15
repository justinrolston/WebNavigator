using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    private int mID;
    private string mDescription;
    private decimal mTotal;

    public decimal Total
    {
        get { return mTotal; }
        set { mTotal = value; }
    }

    public string Description
    {
        get { return mDescription; }
        set { mDescription = value; }
    }

    public int ID
    {
        get { return mID; }
        set { mID = value; }
    }

	public Order()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public class OrderCollection : List<Order> 
{
    public static OrderCollection GetAllOrders()
    {
        OrderCollection orders;
        Order order;

        orders = new OrderCollection();
        for (int i = 0; i < 10; i++)
        {
            order = new Order();
            order.Description = "Order " + i.ToString();
            order.ID = i;
            order.Total = i;
            orders.Add(order);
        }

        return orders;
    }
}
