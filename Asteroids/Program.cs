using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids  // by Aleksandr K.

 /* ДЗ к вебинару №1.

    - Добавил класс Comet. Решил  поменять местами и наследовать его от Asteroid - все же классификация схожа.
    - Star хотел делать статичным, все же звезды визуально неподвижны, но блин там придется довольно много переделывать похоже и не очень понятно как. Оставил как отдельный класс :(
    - Поменял расположение планеты и начальные точки небесных тел.
    - Картинки вставил свои - пришлось повозиться с вырезанием.. Планета Арракис, если знакома вселенная Dune :D */

{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new Form()  // Экземпляр формы создаем
            {
                MinimumSize = new System.Drawing.Size(800, 600),  // Свойства. Ограничение размера формы мин и макс
                MaximumSize = new System.Drawing.Size(800, 600),
                MaximizeBox = false,  // Нельзя расширить или спрятать (ниже) размер формы.
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,   
                Text = "Asteroids"
            };

            Game.Init(form);  // Обращаемся к Init и передаем экземпляр формы.
            form.Show();     // Для отрисовки вызываем метод Show
            Game.Draw();    // Отрисовка через метод Draw
            Application.Run(form);  // Запускаем форму.
        }
    }
}
