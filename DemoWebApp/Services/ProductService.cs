using DemoWebApp.Models;
using Microsoft.Data.SqlClient; 
namespace DemoWebApp.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "sndberver001.database.windows.net";
        //private static string db_user = "snsqladmin";
        //private static string db_password = "5naspuri@1";
        //private static string db_database = "snAppDB001";
        private readonly IConfiguration _config;

        public ProductService(IConfiguration config)
        {
            _config = config;
        }
        private SqlConnection getdatabase()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;
            return new SqlConnection(_config.GetConnectionString("SQLConnection"));

        }
        public List<Product> GetProducts()
        {
            SqlConnection conn = getdatabase();
            List<Product> lstProducts = new List<Product>();
            string sqlStatment = "select ProductID,ProductName,Quantity from Products";
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand(sqlStatment, conn);
            using (SqlDataReader sqlReader = sqlcmd.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Product prod = new Product()
                    {
                        ProductId = sqlReader.GetInt32(0),
                        ProductName = sqlReader.GetString(1),
                        Quantity = sqlReader.GetInt32(2)
                    };
                    lstProducts.Add(prod);
                }
            }
            conn.Close();
            return lstProducts;
        }
    }
}
