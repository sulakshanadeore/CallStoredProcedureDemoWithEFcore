using CallStoredProcedureDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CallStoredProcedureDemo.Repo
{

  public  interface IUserService
    {

        bool CheckForValidUser(string username, string password); 
        
         void SignUp(string username, string password);

        bool ChangePassword(int id, string newpass);

    }
    public class UserUtility : IUserService
    {
        //private readonly IndigoAirlinesContext _context;
        IndigoAirlinesContext _context;
        public UserUtility(IndigoAirlinesContext context)
        {
            _context = context; 
        }

        public bool ChangePassword(int id, string newpass)
        {
            bool status = false;
            try
            {

            
            _context.Database.ExecuteSqlRaw("exec sp_updateUser @p_id, @p_newpassword",
                new[]
                {
                  new SqlParameter("@p_id",id),
                  new SqlParameter("@p_newpassword",newpass)
                 
                });
                status = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;

        }

        public bool CheckForValidUser(string username, string password)
        {
            SqlParameter p_output=new SqlParameter("@p_status", System.Data.SqlDbType.Bit);
            p_output.Direction = System.Data.ParameterDirection.Output;
            //var isValid = p_output;

            //SqlParameter p1= new SqlParameter("@p_userid", username);

            //  throw new NotImplementedException();
             _context.Database.ExecuteSqlRaw("Execute sp_ValidateUser @p_userid, @p_password, @p_status output",
                new[]
                {
                  new SqlParameter("@p_userid",username),
                  new SqlParameter("@p_password",password),
                  p_output
                });

           bool output=Convert.ToBoolean(p_output.Value); ;

         //  return Convert.ToBoolean(p_output.Value)


            return output;  

        }

        public void SignUp(string username, string password)
        {
            User user=new User();
            user.id = 1;
            user.Userid = username;
            user.Password = password;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
