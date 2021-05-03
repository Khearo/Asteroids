using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids 
{
    
    static class Game
    {
        private static BufferedGraphicsContext _context; // графический контекст.
        public static BufferedGraphics Buffer;  // граффический буфер для отрисовки графики.
        static Asteroid[] _asteroids;   // Массив астероидов
        static Star[] _stars;       // Массив звезд
        static Asteroid[] _comets;

        public static int Width { get; set; }   //св-во для отрисовки границы по ширине  
        public static int Height { get; set; }  // св-во для отрисовки границе по высоте

        public static void Init(Form form)  //метод инициализации игры. В параметры передается экземпляр формы.  
        {
            Graphics g = form.CreateGraphics();  // Вывод графики. Создаем и сразу возвращаем форму.
            _context = BufferedGraphicsManager.Current; // Инициализация графического контекста.
            Width = form.ClientSize.Width;  // Граница отрисовки по ширине и высоте (ниже) = границе формы
            Height = form.ClientSize.Height;    
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));  // Инициализируем буффер.

            Load();  

            Timer timer = new Timer();  // Класс таймер
            timer.Interval = 60;    // Каждые 60 милисекунд отрабатывает метод OnTime
            timer.Tick += OnTime;   
            timer.Start();  
        }

        private static void OnTime(object sender, EventArgs e)
        {
            Draw(); //отрисовка объектов
            Update(); // обновление объектов
        }

        public static void Draw()   // Метод для отрисовки графики (постоянно)
        {
            //Buffer.Graphics.Clear(Color.Black);  // Очищаем фон и заполняем его черным.
            Buffer.Graphics.DrawImage(Resources.Space2, new Rectangle(0, 0, 800, 600));

            Buffer.Graphics.DrawImage(Resources.ArrakisR, new Rectangle(440, 320, 200, 200));
           // Buffer.Graphics.FillEllipse(Brushes.MediumSeaGreen, new Rectangle(440, 320, 200, 200));  // Рисуем элипс (круг), через 4х угольник, в который вписан элипс



            foreach (Asteroid asteroid in _asteroids)  //Проходимся по астероидам и рисуем.
                asteroid.Draw();

            foreach (Star star in _stars)
                star.Draw();

            foreach (Asteroid comet in _comets)
            {
                comet.Draw();
            }


            Buffer.Render();  // Для отрисовки ( рендера ) всего выше сделанного.
        }

        public static void Load()   // Инициализирует(заргужает) все объекты сцены. Отрабатывает 1 раз.
        {
            var random = new Random();

            _asteroids = new Asteroid[10];  // массив астороидов из 15 шт.
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 30);  // Размер астероида от 10 до 50 пкс
                _asteroids[i] = new Asteroid(new Point(i * 25 + 30, 500 ), new Point(-i , -i), new Size(size, size));
            }

            _stars = new Star[35];
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(470, i * 15 + 10), new Point(-i - 1, i ), new Size(10, 15));
            }

            _comets = new Comet[3];  
            for (int i = 0; i < _comets.Length; i++)
            {
                var size = random.Next(50, 65);
                _comets[i] = new Comet(new Point(i * 250 + 15, i * 100 + 25), new Point(-i - 1, -i - 1), new Size(size, size));
            }
        }

        public static void Update()     // Отрабатывает постоянно
        {
            foreach (Asteroid asteroid in _asteroids)  // обновляем
                asteroid.Update();

            foreach (Star star in _stars)
                star.Update();

            foreach (Asteroid comet in _comets)
            {
                comet.Update();
            }
        }

    }
}
