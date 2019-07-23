using Microsoft.Extensions.Configuration;
using OrderProcessing.Database.Source;
using OrderProcessingCore.Utilities.Configurations;
using System.Data;
using System.Data.SqlClient;

namespace OrderProcessing.Database
{
    /**
     *Should be an abstract class that implements the methods from the DAO interface 
     * using SQL and annotated entities 
        */
    public abstract class SqlDAO
    {
        //TODO: Create a connection accessor and use it here
        protected SqlConnection Con=new SqlConnection();
        protected SqlCommand Com=new SqlCommand();
        protected SqlDataAdapter DataAdapter=new SqlDataAdapter();
        protected SqlDataReader Reader;
        protected string Query;
        private IConfiguration Configuration = AppConfigurations.GetConfigurations();

        public SqlDAO()
        {
            
        }

        private bool Connected()
        {
            return Con.State == ConnectionState.Open;
        }


        protected SqlConnection CreateConnection()
        {
            Con = new SqlConnection(Configuration.GetConnectionString("kataledatabase"));

            if (Connected())
            {
                Com.Dispose();
                Con.Close();
            }

            Con.Open();

            return Con;
        }
        
    }
}
