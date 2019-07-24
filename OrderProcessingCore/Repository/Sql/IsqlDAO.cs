using OrderProcessingCore.DAO.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingCore.Database
{
    interface ISqlDAO<T> 
    {
        //void CreateQuery(string Query);
        //T GetFromQuery(string Query);    
        List<T> GetByQuery(string Query);
        
    }
}
