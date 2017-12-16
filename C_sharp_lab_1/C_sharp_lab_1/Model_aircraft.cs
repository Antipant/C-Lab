using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace model_aircraft
{
    //плюсы
    //контролируемый доступ к единственному экземпляру.
    //минусы
    //глобальные объекты могут быть вредны для объектного программирования, в некоторых случаях приводят к созданию немасштабируемого проекта;  усложняет написание модульных тестов и следование tdd.
    //применение
    //должен быть ровно один экземпляр некоторого класса, легко доступный всем клиентам;
    //единственный экземпляр должен расширяться путем порождения подклассов, и клиентам нужно иметь возможность работать с расширенным экземпляром без модификации своего кода.

    //sealed - от класса нельзя ничего пронаследовать, нельзя использовать protected

    //EventHandler - Представляет метод, который будет обрабатывать событие, не имеющее данных.


    public class Singleton
    {
        public Singleton() { Console.WriteLine("Model_aircraft"); }

        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                instance = new Singleton();
                return instance;
            }
        }
    }

    public class Model_aircraft
    {
        public float pitch = 0.0f;
        public float hight = 0.0f;//угол тангажа
        public float roll = 0.0f;   //угол крена
        public float yaw = 0.0f;    //угол рысканья

        //синглтон
        //1) закрыть конструктор, нельзя создать объект
        //2) внутри класса создается статический объект
        //3) функция доступа

        //или атрибут доступа:
        public float Pitch
        {
            set
            {
                /*  if ((value >= 10) || (value <= -10))
                  {
                      Console.WriteLine("throw new ArgumentOutOfRangeException()");
                      throw new ArgumentOutOfRangeException();
                  }*/
                Console.WriteLine("set");
                pitch = value;
                Console.WriteLine("pitch = value");
            }
            get
            {
                Console.WriteLine("get");
                Console.WriteLine("return pitch");
                return pitch;
            }
        }
        public float Speed
        {
            set
            {
                Console.WriteLine("set");
                hight = value;
                Console.WriteLine("hight = value");
            }
            get
            {
                Console.WriteLine("get");
                Console.WriteLine("return hight");
                return hight;
            }
        }
        public float Hight
        {
            set;
            get;
        }

    }

}
