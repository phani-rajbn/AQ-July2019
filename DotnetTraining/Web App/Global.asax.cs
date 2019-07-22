using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        static string filename = @"B:\Programs\AQJul2019\DotnetTraining\SampleWebApp\Products.csv";
        protected void Application_Start(object sender, EventArgs e)
        {
            var products = getAllProducts();
            Application["AllItems"] = products;//Add to App State......
            //Response.Write("Application is started");
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            HashSet<Product> cart = new HashSet<Product>();
            Session["myCart"] = cart;
            Session.Add("MyMeanings", new Dictionary<string, string>());
        }
        private List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var words = line.Split(',');
                    var p = new Product
                    {
                        ProductCost = double.Parse(words[2]),
                        ProductID = int.Parse(words[0]),
                        ProductName = words[1]
                    };
                    products.Add(p);
                }
            }
            return products;
        }
    }
}