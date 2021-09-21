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
{
    public class BookController : Controller
    {

        string myConnection = "Server=localhost;Database=BookStore;Uid=root;Pwd='';";
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult getBook(){
            MySqlConnection conn = new MySqlConnection(myConnection); 
            List<Book> list = new List<Book>();
            conn.Open(); 
            try{
                string query = "select * from books"; 
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = conn; 
                MySqlDataReader reader = command.ExecuteReader(); 
                while(reader.Read()){
                    list.Add(new Book{
                        Isbn = (int)reader["isbn"],
                        Title = reader["title"].ToString(),
                        Price = reader["price"].ToString(),
                        PageCount = (int)reader["page"],
                        Type = reader["type"].ToString(),

                    });
                } 
            }catch(Exception){throw;}
            finally{
                conn.Clone(); 
            }

            return View(list); 
        }


        
        public IActionResult UpdatePage(){
            return View(); 
        }

        public IActionResult Update(int isbn, string price){
            if(isbn == 0 && price == null){
                Response.StatusCode = 404;
                return Content("Not Found");
            }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "UPDATE books SET price='"+price+"' WHERE isbn='"+isbn+"';"; 
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

        
        [HttpPost] 
        [ActionName("Index")]

        public IActionResult PostIndex(string title, string price, int page, string type){ 
            if(title == null && 
               price == null && page == 0 && type == null)

            { Response.StatusCode = 404;
              return Content("Not Found");
            }

            else{
                MySqlConnection conn = new MySqlConnection(myConnection);
                MySqlCommand command; 
                conn.Open();
                try{
                    command = conn.CreateCommand();
                    command.CommandText = "insert into books(title,price,page,type) values('"+title+"','"+price+"','"+page+"','"+type+"')";
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

        public IActionResult DeletePage(){
            return View(); 
        }

        public IActionResult Delete(int isbn){
            if(isbn == 0){  
                Response.StatusCode = 404;
                return Content("Not Found"); 
            }
            else{
                MySqlConnection conn = new MySqlConnection(myConnection); 
                conn.Open(); 
                try{
                    string query = "DELETE FROM books WHERE isbn='"+isbn+"'"; 
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
