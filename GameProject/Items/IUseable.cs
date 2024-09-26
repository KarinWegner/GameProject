using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Items
{
    internal interface IUseable
    {
        void Use(Creature creature);
        void Use(Creature creature, Action<Creature> action);
    }
}
