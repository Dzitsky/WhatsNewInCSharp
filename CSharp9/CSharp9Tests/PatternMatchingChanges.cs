using NUnit.Framework;
using System;

namespace CSharp9Tests
{
    public class PatternMatchingChanges
    {
        /// <summary>
        /// Pattern-matching changes for C# 9.0
        /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/patterns3"></see>
        /// </summary>
        [Test]
        public void Demo1()
        {
            // Проверка на тип
            Square square = new Square();
            if (square is not Shape)
            {
                // some code
            }

            // Проверки свойств
            if (square is { IsColored: true, Area: > 0 })
            {
                // some code
            }
            // Раньше было
            if (square.IsColored && square.Area > 0)
            {
                // some code
            }

            if (square is { Area: > 0 and (< 100 or 5) })
            {
                // some code
            }

        }

        /// <summary>
        /// Switch Expression 1
        /// </summary>
        [Test]
        public void Demo2()
        {
            static decimal CalculateToll(object shape) =>
                shape switch
                {
                    Square sq => 2.00m,
                    Circle _ => 3.00m, // В C# 8.0 переменную можно не объявлять (discard pattern)
                    Triangle => 5.00m, // В C# 9.0 можно вообще ничего не указывать
                                       // Хоть что не равное null
                    { } => throw new ArgumentException(message: "Unknown shape type", paramName: nameof(shape)),
                    // Если пришло null
                    null => throw new ArgumentNullException(paramName: nameof(shape))
                };

            Console.WriteLine(value: CalculateToll(shape: new Triangle())); // 5.00
        }

        /// <summary>
        /// Switch Expression 2
        /// </summary>
        [Test]
        public void Demo3()
        {
            static decimal CalculateToll(object shape) =>
                shape switch
                {
                    // Тут можно не боятся NullreferenceException,
                    // т.к. свойства будут проверятся если shape не null и экземпляр Square
                    Square { Area: > 200 } => 2.00m + 1.00m,
                    Square => 2.00m,

                    // Можно писать выражения
                    Triangle triangle when (triangle.Area + 5 == 120) => 6.00m,
                    Triangle => 5.00m,

                    // Вложенные Switch Expression
                    Circle circle => circle.Area switch
                    {
                        80 => 1.00m,
                        90 => 2.00m,
                        _ => 3.00m
                    }
                };

            Console.WriteLine(value: CalculateToll(shape: new Square() { Area = 240 })); // 3.00
            Console.WriteLine(value: CalculateToll(shape: new Triangle() { Area = 115 })); // 6.00
            Console.WriteLine(value: CalculateToll(shape: new Circle() { Area = 90 })); // 2.00
            Console.WriteLine(value: CalculateToll(shape: new Circle())); // 3.00
        }

        /// <summary>
        /// Switch Expression 3
        /// </summary>
        [Test]
        public void Demo4()
        {
            // Проверка дня недели
            static bool IsWeekDay(DateTime date) =>
                date.DayOfWeek switch
                {
                    DayOfWeek.Saturday => false,
                    DayOfWeek.Sunday => false,
                    _ => true
                };

            // Определение времени суток
            static TimeOfTheDay GetTimeBand(DateTime date) =>
                date.Hour switch
                {
                    < 6 or > 19 => TimeOfTheDay.Night,
                    < 10 => TimeOfTheDay.Morning,
                    < 16 => TimeOfTheDay.Afternoon,
                    _ => TimeOfTheDay.Evening,
                };

            // Расчет коэффициента в зависимости от дня недели и времени суток 
            static decimal PeakTimePremiumFull(DateTime date) =>
                (IsWeekDay(date: date), GetTimeBand(date: date)) /* кортеж */ switch
                {
                    // Сопоставление идет по-порядку и будет закончено как только будет найден подходящий вариант
                    (true, TimeOfTheDay.Morning) => 2.00m,
                    (true, TimeOfTheDay.Afternoon) => 1.50m,
                    (true, TimeOfTheDay.Night) => 0.75m,
                    (false, _) => 1.75m, // Можно применять discard pattern
                    _ => 1.0m
                };

            Console.WriteLine(value: PeakTimePremiumFull(date: new DateTime(year: 2021, month: 2, day: 8, hour: 9, minute: 0, second: 0))); // 2.00
        }

        #region Types

        private class Shape
        {
            public decimal Area { get; set; }
            public bool IsColored { get; set; }
        }

        private class Square : Shape
        {

        }

        private class Triangle : Shape
        {

        }

        private class Circle : Shape
        {

        }

        private enum TimeOfTheDay
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }

        #endregion
    }
}
