using CallStoredProcedureDemo.Models;
using CallStoredProcedureDemo.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallStoredProcedureDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _service;
        public UsersController(IUserService service)
        {

            _service = service;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string str = "Hello";
            if (str == "Hello" && id == 1)
            {
                return RedirectToAction("Get", "WeatherForecast");
            }
            else
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }


        [HttpPost("/CreateUser")]
       public  HttpResponseMessage Post([FromBody] User user) 
            {
                _service.SignUp(user.Userid, user.Password);
                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.OK;

                response.Content = new StringContent("User created...");
         
           
                return response;


            }



            // POST api/<UsersController>

            [HttpPost]
        public IActionResult CheckUserValidataion([FromBody] User user)
            {
                bool ans = _service.CheckForValidUser(user.Userid, user.Password);

                if (ans)
                {
                    return Ok("Success....");


                    // return Content("Login Successful....");//Content Result


                    //HttpResponseMessage
                    //var msg = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    //msg.Content = new StringContent("Login Successful");
                    //return msg;



                }
                else
                {

                    return BadRequest("Not allowed in.....");
                    //  return Content("Login UnSuccessful...."); //Content Result

                    //HttpResponseMessage
                    //var msg = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                    //msg.Content = new StringContent("Login UnSuccessful");
                    //return msg;
                }

            }

        //PUT api/<UsersController>/5
            [HttpPut("{id}")]
        public ContentResult Put(int id, [FromBody] string password)
        {
            bool ans=_service.ChangePassword(id, password);
            string msg="No change in  pwd";
            if (ans)
            {
                msg = "Password changed successfully...";
            }
            return Content(msg);



        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    
    }
}
