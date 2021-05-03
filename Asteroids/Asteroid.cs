using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Properties;

namespace Asteroids
{
    class Asteroid  // Объект характеризуется состоянием и поведением.
    {
        protected Point Pos; // Позиция(расположение) текущая
        protected Point Dir; // Направление, изменение координат (ось х,у) 
        protected Size Size; // Размер

       
        public Asteroid(Point pos, Point dir, Size size)    // Конструктор (метод класса), вызываем(инициализируем) поля
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()  // Метод отрисовки астероида
        {
            Game.Buffer.Graphics.DrawImage(Resources.Asteroid2, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.(Pens.Brown, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public virtual void Update()  // Метод изменения позиции астероида
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }


    }
}
