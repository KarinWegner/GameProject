using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Extentions
{
    internal static class MapExtentions
    {
        public static IDrawable CreatureAtExtention(this List<Creature> creatures, IDrawable drawable)
        {
            //IDrawable result = drawable;

            //foreach (var creature in creatures)
            //{
            //    if (creature.Cell == drawable)
            //    {
            //        result = creature;
            //        break;
            //    }
            ////}
            //return result;

            return creatures.FirstOrDefault(d => d.Cell == drawable) ?? drawable as IDrawable;
        }
        public static IDrawable CreatureAtExtention2(this List<Creature> creatures, Cell drawable)
        {
            //IDrawable result = null;

            //foreach (var creature in creatures)
            //{
            //    if (creature.Cell == drawable)
            //    {
            //        result = creature;
            //        break;
            //    }
            //}
            //return result;
            return creatures.FirstOrDefault(d => d.Cell == drawable);
        }
        //public static int GetMapSizeFor(this IConfiguration config, string value)
        //{
        //    var section = config.GetSection("game:mapsettings");

        //    return int.TryParse(section[value], out int result) ? result : 0;
        //}

    }

    public static class ConfigExtension3
    {
        public static Func<IConfiguration, string, int> Implementation { private get; set; } =
            (config, value) =>
            {
                var section = config.GetSection("game:mapsettings");

                return int.TryParse(section[value], out int result) ? result : 0;
            };
        public static int GetMapSizeFor3(this IConfiguration config, string value)
        {
            return Implementation(config, value);
        }
    }

    public static class ConfigExtension2
    {
        public static IGetMapSize Implementation { private get; set; } = new GetMapSize();
        public static int GetMapSizeFor2(this IConfiguration config, string value)
        {
            var section = config.GetSection("game:mapsettings");

            return int.TryParse(section[value], out int result) ? result : 0;
        }
    }

    public class GetMapSize : IGetMapSize
    {
        public int GetMapSizeFor2(IConfiguration config, string value)
        {
            var section = config.GetSection("game:mapsettings");

            return int.TryParse(section[value], out int result) ? result : 0;
        }
    }

    public interface IGetMapSize
    {
        int GetMapSizeFor2(IConfiguration config, string value);
    }
}