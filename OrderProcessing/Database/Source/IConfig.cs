using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Database.Source
{
    public interface IConfig
    {
        string GetConnectionString();
        void LoadConfigurations();

    }
}
