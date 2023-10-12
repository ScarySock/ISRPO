using System;

namespace Rectangle
{
    class Rectangle
    {
        //Простейший класс "Прямоугольник" со сторонами, параллельными осям
        //координат, заданный координатами левого верхнего угла, шириной и высотой
        private double left = 0, top = 0, width = 0, height = 0;
        public Rectangle(double left, double top, double width, double height)
        {
            //корректируем данные и пишем из аргументов конструктора в объект this
            if (width < 0) { left += width; width = -width; }
            if (height < 0) { top += height; height = -height; }
            this.left = left; this.top = top; this.width = width; this.height = height;
        }
        public void Print(string header = null)
        {
            //Вывод заголовка header и координат 2 углов в консоль
            if (!String.IsNullOrEmpty(header))
            {
                if (header.Trim().Length > 0) Console.Write(header + " ");
            }
            Console.WriteLine($"({left:F2},{top:F2}) - " +
             $"({(left + width):F2},{(top + height):F2})");
        }
        public double Area()
        { //Площадь
            return width * height;
        }
        public double Perimeter()
        { //Периметр
            return 2 * (width + height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(-3, -5, -10, 6); //Создали прямоугольник
            r.Print(); //Вывели координаты 2 углов
            Console.WriteLine($"Area={r.Area():F2}, Perimeter={r.Perimeter():F2}");
            //Вывели площадь и периметр
            Console.ReadKey();
        }
    }
}
