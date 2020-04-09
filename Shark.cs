using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class Shark : Animal
{
    public Shark(Level level, Point gridPosition)
        : base(level, gridPosition, "Sprites/LevelObjects/spr_shark")
    {
    }
}