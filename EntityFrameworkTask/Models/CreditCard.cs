using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTask.Models
{
	public class CreditCard
	{
		public int CreditCardID { get; set; }

		public string CardNumber { get; set; }

		public DateTime ExpirationDate { get; set; }

		public virtual Employee Employee { get; set; }
	}
}
