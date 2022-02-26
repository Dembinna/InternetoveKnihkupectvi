using System;
using System.Collections.Generic;
using System.Text;

namespace InternetoveKnihkupectvi
{
    class Controller
    {
        ModelStore model;
        View view;
        public Controller(ModelStore m, View v)
        {
            model = m;
            view = v;
        }
        public void HandleEx(string line)
        {
            try
            {
                string[] input = line.Split(' ', '/');
                
                if (input[0] == "GET")
                {
                    HandleInput(input);
                }
                else
                {
                    view.InvalidRequest();
                }
                view.EndCommand();
            }
            catch (Exception)
            {

                view.InvalidRequest();
            }
        }

            public void HandleInput(string[] commands)
            {
                int costumer_id;
                costumer_id = Convert.ToInt32(commands[1]);
                int pocet = model.books.Count;
                int count = commands.Length;
                var costumer = model.GetCustomer(costumer_id);
                if(costumer == null) { view.InvalidRequest(); return; }
                switch (commands[5])
                {
                    case "Books":
                        if (count > 6)
                        {
                        try
                        {
                            int BookId = Convert.ToInt32(commands[7]);
                            var book = model.GetBook(BookId);
                            if (book ==null)
                            {
                                view.InvalidRequest();
                            }
                            else
                            {
                                view.BookDetails(model.GetBook(BookId), costumer.FirstName, costumer.ShoppingCart.Items.Count);
                            }
                            
                        }
                        catch(Exception ex)
                        {
                            if (ex is FormatException)
                            {
                                view.InvalidRequest();
                            }
                                
                        }
                        }
                        else
                        {
                            view.Books(model.GetBooks(), costumer.FirstName, costumer.ShoppingCart.Items.Count);
                        }

                        break;
                case "ShoppingCart":

                    if (count > 6)
                    {
                        try {

                        int BookId = Convert.ToInt32(commands[7]);
                        if (BookId > pocet || BookId < 1) break;
                        if (commands[6] == "Add")
                        {
                            model.Add(costumer_id, BookId);
                            view.ShoppingCart(model.GetExtendeShoppingCart(costumer_id), costumer.FirstName, costumer.ShoppingCart.Items.Count);
                        }
                        if (commands[6] == "Remove")
                        {
                            if (model.Remove(costumer_id, BookId) == false)
                            {
                                view.ShoppingCart(model.GetExtendeShoppingCart(costumer_id), costumer.FirstName, costumer.ShoppingCart.Items.Count);
                            }
                            else
                            {

                                view.InvalidRequest();
                            }

                        }
                        }
                        catch (Exception ex)
                        {
                            if (ex is FormatException)
                            {
                                view.InvalidRequest();
                                break;
                            }
                        }

                    }
                    else
                    {
                        if (costumer.ShoppingCart.Items.Count > 0)
                        {
                            view.ShoppingCart(model.GetExtendeShoppingCart(costumer_id), costumer.FirstName, costumer.ShoppingCart.Items.Count);
                        }
                        else
                        {
                            view.EmptyCart(costumer.FirstName);
                        }

                    }
                    break;

                default:
                    view.InvalidRequest();
                    return;
                }
                
            }
    }
}
