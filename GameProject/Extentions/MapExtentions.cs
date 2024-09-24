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
            IDrawable result = drawable;

            foreach (var creature in creatures)
            {
                if (creature.Cell == drawable)
                {
                    result = creature;
                    break;
                }
            }
            return result;
        }
        public static IDrawable CreatureAtExtention2(this List<Creature> creatures, Cell drawable)
        {
            IDrawable result = null;

            foreach (var creature in creatures)
            {
                if (creature.Cell == drawable)
                {
                    result = creature;
                    break;
                }
            }
            return result;
        }
    }
}
