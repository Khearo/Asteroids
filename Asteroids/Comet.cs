using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Comet : Asteroid  
    {
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)  // Базовый констроктор. Перетягиваем параметры из Астероид
        {
        }

        public override void Draw() // Переопределение базового метода Draw. Рисуем звезы плюсиком (:
        {
            //base.Draw();
            //Game.Buffer.Graphics.DrawEllipse(Pens.CornflowerBlue, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(Resources.Comet33, Pos.X, Pos.Y, Size.Width, Size.Height);

        }

        public override void Update() //Переопределение базового метода Update
        {
            //base.Update();

            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }

    }
    
}
