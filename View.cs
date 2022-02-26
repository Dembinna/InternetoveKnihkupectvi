using System;
using System.Collections.Generic;
using System.Text;

namespace InternetoveKnihkupectvi
{
	class View
	{
		public void EndCommand()
        {
			Console.WriteLine("====");
        }
		public void EmptyCart(string name)
        {
			WriteHeader(name);
			WriteCostumerTable(0);
			Console.WriteLine("	Your shopping cart is EMPTY.");
			WriteFooter();
		}
		public void InvalidRequest()
        {
			Console.WriteLine("<!DOCTYPE html>");
			Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
			Console.WriteLine("<head>");
			Console.WriteLine("	<meta charset=\"utf-8\" />");
			Console.WriteLine("	<title>Nezarka.net: Online Shopping for Books</title>");
			Console.WriteLine("</head>");
			Console.WriteLine("<body>");
			Console.WriteLine("<p>Invalid request.</p>");
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
		}
		public void ShoppingCart(List<ExtendedShoppingItem> shopping_cart,string name, int count)
        {
			decimal total_price = 0;
			WriteHeader(name);
			WriteCostumerTable(count);
			Console.WriteLine("	Your shopping cart:");
			Console.WriteLine("	<table>");
			Console.WriteLine("		<tr>");
			Console.WriteLine("			<th>Title</th>");
			Console.WriteLine("			<th>Count</th>");
			Console.WriteLine("			<th>Price</th>");
			Console.WriteLine("			<th>Actions</th>");
			Console.WriteLine("		</tr>");
            //tabulka knih
			
            foreach (var s_item in shopping_cart)
            {
				Console.WriteLine("		<tr>");
				Console.WriteLine("			<td><a href=\"/Books/Detail/{0}\">{1}</a></td>", s_item.item.BookId,s_item.Detail.Title); ;
				Console.WriteLine("			<td>{0}</td>", s_item.item.Count);
                if (s_item.item.Count == 1)
                {
					Console.WriteLine("			<td>{0} EUR</td>",s_item.Detail.Price);
					total_price += s_item.Detail.Price; 
				}
                else
                {
					decimal price = s_item.item.Count * s_item.Detail.Price;
					Console.WriteLine("			<td>{0} * {1} = {2} EUR</td>",s_item.item.Count,s_item.Detail.Price,price);
					total_price += price;
				}
				Console.WriteLine("			<td>&lt;<a href=\"/ShoppingCart/Remove/{0}\">Remove</a>&gt;</td>",s_item.item.BookId);
				Console.WriteLine("		</tr>");
			}
			Console.WriteLine("	</table>");
			Console.WriteLine("	Total price of all items: {0} EUR",total_price);
			WriteFooter();
        }
		public void BookDetails(Book book,string name,int count)
        {
			WriteHeader(name);
			WriteCostumerTable(count);
			Console.WriteLine("	Book details:");
			Console.WriteLine("	<h2>{0}</h2>",book.Title);
			Console.WriteLine("	<p style=\"margin - left: 20px\">");
			Console.WriteLine("	Author: {0}<br />",book.Author);
			Console.WriteLine("	Price: {0} EUR<br />",book.Price);
			Console.WriteLine("	</p>");
			Console.WriteLine("	<h3>&lt;<a href=\"/ShoppingCart/Add/{0}\">Buy this book</a>&gt;</h3>",book.Id);
			WriteFooter();
		}
		public void Books(IList<Book> books,string name,int count)
		{
			int counter = 0;
			WriteHeader(name);
			WriteCostumerTable(count);
			Console.WriteLine("	Our books for you:");
			Console.WriteLine("	<table>");
            //cyklus
            foreach (var book in books)
            {
                if (counter==0)
                {
					Console.WriteLine("		<tr>");
				}
				Console.WriteLine("			<td style=\"padding: 10px;\">");
				Console.WriteLine("				<a href=\"/Books/Detail/{0}\">{1}</a><br />",book.Id,book.Title);
				Console.WriteLine("				Author: {0}<br />",book.Author);
				Console.WriteLine("				Price: {0} EUR &lt;<a href=\"/ShoppingCart/Add/{1}\">Buy</a>&gt;",book.Price,book.Id);
				Console.WriteLine("			</td>");
				++counter;
                if (counter==3)
                {
					counter = 0;
					Console.WriteLine("		</tr>");
				}
			}
			Console.WriteLine("	</table>");
			WriteFooter();
		}

		public void WriteFooter()
        {
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
		}
		public void WriteHeader(string name)
		{
			Console.WriteLine("<!DOCTYPE html>");
			Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
			Console.WriteLine("<head>");
			Console.WriteLine("	<meta charset=\"utf-8\" />");
			Console.WriteLine("	<title>Nezarka.net: Online Shopping for Books</title>");
			Console.WriteLine("</head>");
			Console.WriteLine("<body>");
			Console.WriteLine("	<style type=\"text/css\">");
			Console.WriteLine("		table, th, td {");
			Console.WriteLine("			border: 1px solid black;");
			Console.WriteLine("			border-collapse: collapse;");
			Console.WriteLine("		}");
			Console.WriteLine("		table {");
			Console.WriteLine("			margin-bottom: 10px;");
			Console.WriteLine("		}");
			Console.WriteLine("		pre {");
			Console.WriteLine("			line-height: 70%;");
			Console.WriteLine("		}");
			Console.WriteLine("	</style>");
			Console.WriteLine("	<h1><pre>  v,<br />Nezarka.NET: Online Shopping for Books</pre></h1>");
			Console.WriteLine("	{0}, here is your menu:", name);

		}
		public void WriteCostumerTable(int count)
        {
			Console.WriteLine("	<table>");
			Console.WriteLine("		<tr>");
			Console.WriteLine("			<td><a href=\"/Books\">Books</a></td>");
			Console.WriteLine("			<td><a href=\"/ShoppingCart\">Cart ({0})</a></td>", count);
			Console.WriteLine("		</tr>");
			Console.WriteLine("	</table>");
		}

    }
}
