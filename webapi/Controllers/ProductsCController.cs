using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsWebApiApplication.Controllers
{
    public class ProductsCController : ApiController
    {
        // GET: api/ProductsC
        public IEnumerable<Products1> Get()
        {
            List<Products1> list = new List<Products1>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;";
            con.Open();

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlCommand cmdlist = new SqlCommand();
            cmdlist.Connection = con;
            cmdlist.CommandType = System.Data.CommandType.Text;
            cmdlist.CommandText = "select * from Products1";

            // cmdlist.CommandText = "select ProductId=@ProductId, ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName from Products1";

            try
            {
                SqlDataReader dr = cmdlist.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Products1 {  C_ProductId= dr.GetInt32(0), ProductName = dr.GetString(1), Rate_ = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) });

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }



            return list;
           // return new string[] { "value1", "value2" };
        }

        // GET: api/ProductsC/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsC
        public void Post([FromBody]Products1 obj)
        {
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;";
            con.Open();

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlCommand cmdlist = new SqlCommand();
            cmdlist.Connection = con;
            cmdlist.CommandType = System.Data.CommandType.Text;
            cmdlist.CommandText = "Insert into Products1 values(@C_ProductId,@ProductName,@Rate_,@Description,@CategoryName)";

            cmdlist.Parameters.AddWithValue("@C_ProductId", obj.C_ProductId);
            cmdlist.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmdlist.Parameters.AddWithValue("@Rate_", obj.Rate_);
            cmdlist.Parameters.AddWithValue("@Description", obj.Description);
            cmdlist.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

           

            try
            {
                //SqlDataReader dr = cmdlist.ExecuteReader();
                //while (dr.Read())
                //{
                //    obj=(new Products1 { C_ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate_ = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) });

                //}
                cmdlist.ExecuteNonQuery();

               // dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }
            
        }

        // PUT: api/ProductsC/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductsC/5
        public void Delete(int id)
        {
        }
    }
}
