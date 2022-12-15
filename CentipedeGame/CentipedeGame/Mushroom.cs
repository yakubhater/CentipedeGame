using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentipedeGame
{
    public class Mushroom
    {
        public int health;
        public Rectangle rect;
        public Texture2D text;

        public Mushroom(Texture2D t, Rectangle r)
        {
            health = 4;
            text = t;
            rect = r;
        }
    }
}
