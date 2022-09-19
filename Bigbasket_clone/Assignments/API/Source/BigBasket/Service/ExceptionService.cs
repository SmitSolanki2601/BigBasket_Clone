using Bigbasket.IService;
using BigBasket.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.Service
{
    public class ExceptionService : IExceptionService
    {
     
            private string config { get; set; }
            public ExceptionService(IConfiguration Configuration)
            {
                config = Configuration.GetConnectionString("DBconnection");
            }
            public void _LogError(string data)
            {

                //config.AddDbContext<C_EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBconnection")))
                using (SqlConnection connection = new SqlConnection(config))
                {

                    connection.Open();


                    SqlCommand command = new SqlCommand("SPErrorDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@error", data);
                    command.ExecuteNonQuery();

                    connection.Close();




           
            }
        }
    }
}
