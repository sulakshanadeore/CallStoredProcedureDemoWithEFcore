using CallStoredProcedureDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CallStoredProcedureDemo.Repo
{

  public  interface IUserService
    {

        bool CheckForValidUser(string username, string password);       

    }
    public class UserUtility : IUserService
    {
        //private readonly IndigoAirlinesContext _context;
        IndigoAirlinesContext _context;
        public UserUtility(IndigoAirlinesContext context)
        {
            _context = context; 
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
    }
}
