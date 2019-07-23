using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Utilities.Configurations
{
    public interface IConfig
    {
        string GetConnectionString();
        void LoadConfigurations();

    }
}
