using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using System.Data; 
using MySql.Data.MySqlClient;  
using System.Configuration; 
using System.Net; 


namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        string myConnection = "Server=localhost;Database=BookStore;Uid=root;Pwd='';";
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(ILogger<PublisherController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
         [HttpGet]
        public IActionResult getPublisher(){
            MySqlConnection conn = new MySqlConnection(myConnection); 
            List<Publisher> list = new List<Publisher>();
            try{
                string query = "select * from publisher"; 
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = conn; 
                conn.Open(); 
                MySqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read()){
                    list.Add(new Publisher{
                        Code = (int)reader["code"],
                        Phone_1 = (int)reader["phone_1"],
                        Phone_2 = (int)reader["phone_2"],
                        Name = reader["name"].ToString(),
                        City = reader["city"].ToString(),
                    });
                } 
            }catch(Exception){throw;}
            finally{
                conn.Clone(); 
            }
            

            return View(list); 
        }

        


        [HttpPost] 
        [ActionName("Index")]

        public IActionResult PostIndex(string name, string city, int phone_1, int phone_2){ 
            if(name == null && city == null) {
                Response.StatusCode = 404;
                return Content("Not Found");
            }

            else{
                MySqlConnection conn = new MySqlConnection(myConnection);
                MySqlCommand command; 
                conn.Open();
                try{
                    command = conn.CreateCommand();
                    command.CommandText = "insert into publisher(name,city,phone_1,phone_2) values('"+name+"','"+city+"','"+phone_1+"','"+phone_2+"')";
                    command.ExecuteNonQuery();
                }catch(Exception){throw;}
                finally{
                    if(conn.State == ConnectionState.Open){
                        conn.Close();
                    }
                }
            Response.StatusCode = 200;
            return View();
            }

        }

        public IActionResult UpdatePage(){
           return View(); 
        }
        
        public IActionResult Update(int code, int phone_1, int phone_2){
            if(code == 0 && phone_1 == 0 && phone_2 == 0)
            { 
                Response.StatusCode = 404;
                return Content("Not Found");
         
            }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "UPDATE publisher SET phone_1='"+phone_1+"', phone_2='"+phone_2+"' WHERE code='"+code+"';"; 
                    MySqlCommand command = new MySqlCommand(query);
                    command.Connection = conn; 
                    command.ExecuteNonQuery();
                }catch(Exception){throw;}
                finally{
                    conn.Clone(); 
                }
                Response.StatusCode = 200;
                return View();
                }
                
        }

        public IActionResult DeletePage(){
            return View(); 
        }

        public IActionResult Delete(int code){
            if(code == 0){ 

                Response.StatusCode = 404;
                return Content("Not Found");
             }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "DELETE FROM publisher WHERE code='"+code+"'"; 
                    MySqlCommand command = new MySqlCommand(query);
                    command.Connection = conn; 
                    command.ExecuteNonQuery();
                }catch(Exception){throw;}
                finally{
                    conn.Clone(); 
                }
            Response.StatusCode = 200;
            return View(); 


            }
            

        }


    }

}
