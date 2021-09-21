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



namespace BookStore.Controllers
{    public class AuthorController : Controller
    {
        string myConnection = "Server=localhost;Database=BookStore;Uid=root;Pwd='';";       
         private readonly ILogger<AuthorController> _logger;
        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getAuthor(){
            MySqlConnection conn = new MySqlConnection(myConnection); 
            List<Author> list = new List<Author>();
            try{
                string query = "select * from author"; 
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = conn; 
                conn.Open(); 
                MySqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read()){
                    list.Add(new Author{
                        Id = (int)reader["id"],
                        Fname = reader["fname"].ToString(),
                        Lname = reader["lname"].ToString(),

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

        public IActionResult PostIndex(string firstname, string lastname){ 
            if(firstname == null && lastname == null){
                Response.StatusCode = 404;
                return Content("Not Found");
            }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection);
                MySqlCommand command; 
                conn.Open();
                try{
                    command = conn.CreateCommand();
                    command.CommandText = "insert into author(fname,lname) values('"+firstname+"','"+lastname+"')";
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

        public IActionResult Update(int id, string fname, string lname){
            if(id == 0 && fname == null && lname == null){
                 Response.StatusCode = 404;
                return Content("Not Found");
            }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "UPDATE author SET fname='"+fname+"', lname='"+lname+"' WHERE id='"+id+"';"; 
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

        public IActionResult Delete(int id){
            if(id == 0){
                Response.StatusCode = 404;
                return Content("Not Found");
            }
            else{

                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "DELETE FROM author WHERE id='"+id+"'"; 
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
