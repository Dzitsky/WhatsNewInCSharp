using System;
using System.Runtime.CompilerServices;

namespace ModuleInitializers
{
    class Program
    {
        /*
		 * Способ единой инициализации при запуске приложения.
		 * Static-конструкторы не очень, т.к. во время исполнения кода необходимо понять используется ли класс с таким конструктором = расходы.
		 * Где применять? - Генераторы кода, которые должны иметь какую-то логику инициализации, но которую теперь не надо явно вызывать.
		 */

        /*
		 * Как работает:
		 *
		 * Компилятор находит все методы, которые помечены [ModuleInitializer] и вызывает их.
		 * Порядок вызова указать нельзя, но он одинаков при каждом вызове.
		 */

        /*
		 * Ограничения:
		 *
		 * Должен быть static
		 * Должен быть void
		 * Не должен иметь параметров
		 * Не должен работать с generics
		 * Не должен быть локальным методом
		 * Должен быть доступен (internal или public)
		 */

        [ModuleInitializer]
        public static void InitializerMethod1()
        {
            Console.WriteLine(value: "InitializerMethod1");
        }


        [ModuleInitializer]
        public static void InitializerMethod2()
        {
            Console.WriteLine(value: "InitializerMethod2");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(value: "Main");
            Console.ReadLine();
        }
    }
}
