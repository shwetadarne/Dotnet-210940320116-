using ProductWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductWebApplication.Controllers
{
    public class ProductCController : Controller
    {
        // GET: ProductC
        public ActionResult Index()
        {
            List<ProductM> list = new List<ProductM>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;";
            con.Open();

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlCommand cmdlist = new SqlCommand();
            cmdlist.Connection = con;
            cmdlist.CommandType = System.Data.CommandType.Text;
             cmdlist.CommandText = "select * from Products1";

            try
            {
                SqlDataReader dr = cmdlist.ExecuteReader();
                while(dr.Read())
                {
                    list.Add(new ProductM { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) });

                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }
            
            
            
            return View(list);
        }

        // GET: ProductC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        


        


        // GET: ProductC/Edit/5
        public ActionResult Edit(int id = 101)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;";
            con.Open();

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlCommand cmdlist = new SqlCommand();
            cmdlist.Connection = con;
            cmdlist.CommandType = System.Data.CommandType.Text;
            cmdlist.CommandText = "select * from Products1 where ProductId=@ProductId ";

            cmdlist.Parameters.AddWithValue("@ProductId", id);

            SqlDataReader dr = cmdlist.ExecuteReader();
            ProductM obj = null;
            if (dr.Read())
                obj = new ProductM { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };



            return View(obj);





        }


        // POST: ProductC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductM obj=null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;";
            con.Open();

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=BookDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlCommand cmdlist = new SqlCommand();
            cmdlist.Connection = con;
            cmdlist.CommandType = System.Data.CommandType.Text;
            cmdlist.CommandText = "update Products1 set  ProductName=@ProductName, Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId  ";
            
            cmdlist.Parameters.AddWithValue("@ProductId",(Int32) id);
            cmdlist.Parameters.AddWithValue("@ProductName",obj.ProductName);
            cmdlist.Parameters.AddWithValue("@Rate", obj.Rate);
            cmdlist.Parameters.AddWithValue("@Description", obj.Description);
            cmdlist.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

           // SqlDataReader dr = cmdlist.ExecuteReader();
           //// ProductM obj = null;
           // if (dr.Read())
           //     obj = new ProductM { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };



            try
            {
                cmdlist.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            finally
            {
                con.Close();
            }
            
            
        }

        // GET: ProductC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
