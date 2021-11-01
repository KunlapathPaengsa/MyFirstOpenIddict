using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models.Configurations
{
    public class DatabaseSettings
    {
        public string ConnectionName { get; set; }
        public string DefaultSchema { get; set; }
    }
}
