using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System;
using System.Data;

namespace OrderManagementSystem.Controllers
{
    [ApiController]
    public class Order : ControllerBase
    {
        [Route("Order")]
        [HttpPost]
        public void createorder([FromBody] OrderMS orderMS)
        {

            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=OrderManagement;User ID=sa;Password=123");
            SqlCommand cmd = new SqlCommand("sp_name", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BuyerName", orderMS.BuyerInfo.BuyerName);
                cmd.Parameters.AddWithValue("@Mobile", orderMS.BuyerInfo.Mobile);
                cmd.Parameters.AddWithValue("@Email", orderMS.product);
                cmd.Parameters.AddWithValue("@Street", orderMS.Address.Street);
                cmd.Parameters.AddWithValue("@State", orderMS.Address.State);
                cmd.Parameters.AddWithValue("@OrderStatus", orderMS.OrderStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            
        }

        [Route("Order")]
        [HttpPut]
        public void updateOrder([FromBody] OrderMS orderMS)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=OrderManagement;User ID=sa;Password=123");
            SqlCommand cmd = new SqlCommand("sp_name", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", orderMS.OrderID); ;
            cmd.Parameters.AddWithValue("@BuyerName", orderMS.BuyerInfo.BuyerName);
            cmd.Parameters.AddWithValue("@Mobile", orderMS.BuyerInfo.Mobile);
            cmd.Parameters.AddWithValue("@product", orderMS.product);
            cmd.Parameters.AddWithValue("@Street", orderMS.Address.Street);
            cmd.Parameters.AddWithValue("@State", orderMS.Address.State);
            cmd.Parameters.AddWithValue("@OrderStatus", orderMS.OrderStatus);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [Route("Order")]
        [HttpGet]
        public OrderMS GetOrderData(int? id)
        {
            OrderMS order = new OrderMS();

            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=OrderManagement;User ID=sa;Password=123");
                SqlCommand cmd = new SqlCommand("sp_name", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.OrderID = Convert.ToInt32(rdr["OrderID"]);
                    order.BuyerInfo.BuyerName = rdr["BuyerName"].ToString();
                    order.BuyerInfo.Mobile = rdr["Mobile"].ToString();
                    //order.product = ;
                    order.Address.Street = rdr["Street"].ToString();
                    order.Address.State = rdr["State"].ToString();
                }
            
            return order;
        }

        public void DeleteOrder(int? id)
        {
                SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=OrderManagement;User ID=sa;Password=123");
                SqlCommand cmd = new SqlCommand("sp_name", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }





    }
}
