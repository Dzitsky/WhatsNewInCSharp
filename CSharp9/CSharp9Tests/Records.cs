using NUnit.Framework;
using System;

namespace CSharp9Tests
{
    /// <summary>
    /// Records
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record"></see>
    /// </summary>
    public class Records
    {
        /*
		 * Записи упрощают создание неизменяемых ссылочных типов.
		 * Записи занимают промежуточное место межу классами и структурами.
		 * Удобны для создания DTO.
		 * На уровне IL кода это классы, но оптимизированные для многопоточной среды.
		 */

        #region Full syntax

        private record Product
        {
            public int Id { get; }
            public string Description { get; init; }

            public Product(int id, string description)
            {
                (Id, Description) = (id, description);
            }
        }

        private record Vehicle : Product
        {
            public int MaxSpeed { get; }

            public Vehicle(int id, string description, int speed)
                : base(id: id, description: description)
            {
                MaxSpeed = speed;
            }
        }

        #endregion

        #region Short syntax

        /*
		 * Компилятор сам создаст конструктор и свойства
		 */

        private record Car(int Id, string Description, int MaxSpeed);


        /*
		 * К сокращенной записи можно добавлять методы
		 */

        private record Bus(int Id, string Description, int MaxSpeed)
            : Vehicle(id: Id, description: Description, speed: MaxSpeed)
        {
            public override string ToString()
            {
                return "New result";
            }
        }

        #endregion

        [Test]
        public void Demo1()
        {
            Product product1 = new Product(id: 1, description: "Some description");
            Product product2 = new Product(id: 1, description: "Some description");

            /*
			 * Сравнение в record происходит по значением всех полей (включая приватные), а не по ссылкам как в классах
			 * Переопределено сравнение.
			 */

            Console.WriteLine(value: product1 == product2); // true
        }

        [Test]
        public void Demo2()
        {
            Product product = new Product(id: 1, description: "Some description");
            Vehicle vehicle = new Vehicle(id: 1, description: "Some description", speed: 120);

            /*
			 * Сравнение происходит не только по всем полям, но и по типу.
			 */
             
            Console.WriteLine(value: product == vehicle); // false
        }

        [Test]
        public void Demo3()
        {
            Product product = new Product(id: 1, description: "Some description");
            MyRecord record = new MyRecord(name: "Some name");

            /*
			 * Сравнение разных типов записей вообще недопустимо
			 */

            //Console.WriteLine(product == record); // ERROR
        }

        [Test]
        public void Demo4()
        {
            Product product = new Product(id: 1, description: "Some description");

            /*
			 * Переопределен ToString()
			 */

            Console.WriteLine(value: product); // Product { Id = 1, Description = Some description }
        }

        [Test]
        public void Demo5()
        {
            Product? product1 = new Product(id: 1, description: "Some description");

            /*
			 * Создание модификации записи с помощью with
			 */

            Product? product2 = product1 with
            {
                Description = "New description"
            };

            Console.WriteLine(value: product2); // Product { Id = 1, Description = New description }
        }

        [Test]
        public void Demo6()
        {
            Bus bus = new Bus(Id: 1, Description: "Some description", MaxSpeed: 90);

            /*
			 * При сокращенном определении записей также создается и деконструктор
			 */

            (int id, string? description, _) = bus;

            Console.WriteLine(value: id); // 1
            Console.WriteLine(value: description); // Some description
            //Console.WriteLine(value: maxSpeed); // 90
        }

        #region Types

        private record MyRecord
        {
            public string Name { get; }

            public MyRecord(string name) => Name = name;
        }

        #endregion
    }
}
