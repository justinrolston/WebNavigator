using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for WebNavigator
/// </summary>
public class WebNavigator
{
    private static WebNavigator mInstance;
    private OrderNavigator mOrderNav;

    public OrderNavigator Orders
    {
        get { return this.mOrderNav; }
    }

    public static WebNavigator URLFor
    {
        get { return mInstance; }
        set { mInstance = value; }
    }

    static WebNavigator()
    {
        mInstance = new WebNavigator();
    }

    public static string Resolve(string url)
    {
        string result;

        if (url.StartsWith("~"))
        {
            result = (HttpContext.Current.Request.ApplicationPath + url.Substring(1)).Replace("//", "/");
        }
        else
        {
            result = url;
        }

        return result;
    }

	public WebNavigator()
	{
        this.mOrderNav = new OrderNavigator();
	}

    public string Home()
    {
        return Resolve("~");
    }

    public string Checkout(string emailAddress)
    {
        return WebNavigator.Resolve("~/Checkout.aspx?email=" + emailAddress);
    }

    public static void GoTo(string url)
    {
        HttpContext.Current.Response.Redirect(url, false);
    }
}

public class OrderNavigator
{
    public string OrderSummary(OrderCollection orders)
    {
        HttpContext.Current.Session.Add("Orders", orders);
        return WebNavigator.Resolve("~/Orders.aspx");
    }
}
