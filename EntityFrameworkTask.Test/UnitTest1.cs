using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkTask.Models;

namespace EntityFrameworkTask.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var context = new NorthwindDb())
			{
				Category category = context.Categories.FirstOrDefault();

				var result = context.Orders
					.Join(
						context.Order_Details,
						order => order.OrderID,
						details => details.OrderID,
						(order, details) => new { Order = order, Customer = order.Customer, ProductID = details.ProductID })
					.Join(
						category.Products,
						orderDet => orderDet.ProductID,
						product => product.ProductID,
						(orderDet, product) => new { Order = orderDet.Order, Product = product, Customer = orderDet.Customer })
					.GroupBy(order => order.Order.OrderID);

				Console.WriteLine($"Category: {category.CategoryName}");
				foreach (var order in result)
				{
					Console.WriteLine($"Order name: {order.Key}");
					foreach (var details in order)
					{
						Console.WriteLine("-----------------------------------------");
						Console.WriteLine($"Customer: {details.Customer.CompanyName} | Product: {details.Product.ProductName}");
					}
				}
			}
		}
	}
}
