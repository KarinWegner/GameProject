using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Services
{
    public class MapService : IMapService
    {
        private readonly IConfiguration config;

        public MapService(IConfiguration config)
        {
            this.config = config;
        }

        public (int width, int height) GetMap()
        {
            return (width: config.GetMapSizeFor2("x"), height: config.GetMapSizeFor2("y"));
        }
    }
}
