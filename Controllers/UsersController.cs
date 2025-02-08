using CallStoredProcedureDemo.Models;
using CallStoredProcedureDemo.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallStoredProcedureDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _service;
        public UsersController(IUserService  service)
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult  Post([FromBody] User user)
        {
            bool ans=_service.CheckForValidUser(user.Userid, user.Password);

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

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
