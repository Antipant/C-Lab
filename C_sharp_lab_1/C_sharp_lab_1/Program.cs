using System;
using System.Collections.Generic;      //подключаем библиотеки
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_aircraft;

namespace C_sharp_lab_1                //пространство имен
{
    class Program                      //определяется класс
    {
        //определяется статическая(существует только один ее экземпляр, вызывается без создания объекта) функция
        static void Main(string[] args)           
        {
            //В информатике инкапсуляцией(лат.en capsula) называется упаковка данных и/ или функций в единый компонент.
            //шаг 2
            //создаем объект класса. объект не проинициализирован
            // Model_aircraft model_aircraft = null;

            //класс - объект - присваиваем - инициализируем, динамическое создание

            // Model_aircraft model_aircraft = new Model_aircraft();

            Model_aircraft model_aircraft = new Model_aircraft();
            string param;
            Console.WriteLine("первый цикл for начат");
            for (; ; ) //первый цикл for
            {
                Console.WriteLine("for(;;)");
                try
                {
                    Console.WriteLine("try");
                    Console.WriteLine("Insert Pitch");
                    param = Console.ReadLine();
                    model_aircraft.Pitch = Convert.ToSingle(param);//setmethod 
                    Console.WriteLine("break");
                    break;
                }
                catch (FormatException) { Console.WriteLine("catch (FormatException)"); Console.WriteLine("Неверный формат"); }
                catch (ArgumentOutOfRangeException) { Console.WriteLine("catch (ArgumentOutOfRangeException)"); Console.WriteLine("Не входит в допустимый диапазон"); }
            }//трассировка
            Console.WriteLine("первый цикл for завершен");
            Console.WriteLine("Pitch=" + model_aircraft.Pitch);//getmethod

            Console.WriteLine("втррой цикл for начат");
            for (; ; ) //второй цикл for
            {
                Console.WriteLine("for(;;)");
                try
                {
                    Console.WriteLine("try");
                    Console.WriteLine("Insert Speed");
                    param = Console.ReadLine();
                    model_aircraft.Speed = Convert.ToSingle(param);//setmethod
                    Console.WriteLine("break");
                    break;
                }
                catch (FormatException) { Console.WriteLine("catch (FormatException)"); Console.WriteLine("Неверный формат"); }
            }
            Console.WriteLine("Speed=" + model_aircraft.Speed);//getmethod
            Console.WriteLine("второй цикл for завершен");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
