using System;

namespace VectorOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Программа умеет");
                Console.WriteLine("1. складывать два вектора");
                Console.WriteLine("2. умножать вектор на скаляр");
                Console.WriteLine("Введите номер операции или @ для выхода");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("> ");
                var operationNumber = Console.ReadLine();

                switch (operationNumber)
                {
                    case "@":
                        return;
                    case "1":
                        SumOfVectors();
                        break;
                    case "2":
                        MultiplicationOnScalar();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный номер операции");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        public static void SumOfVectors()
        {
            Console.WriteLine("Введите поочереди координаты x,y,z первого вектора");
            var vector1 = InputVectorCoordinates();
            Console.WriteLine("Введите поочереди координаты x,y,z второго вектора");
            var vector2 = InputVectorCoordinates();

            var resultVector = vector1 + vector2;

            Console.WriteLine($"Сумма двух векторов равна вектору с координатами {resultVector}");
        }

        public static Vector InputVectorCoordinates()
        {
            var coordinates = new double[3];
            var i = 0;
            while(i < 3)
            {
                Console.Write("> ");
                var coordinatesCandidate = Console.ReadLine();
                if (!double.TryParse(coordinatesCandidate, out coordinates[i]))
                {
                    InputErrorMessage();
                    continue;
                }

                i++;
            }
            
            return new Vector(coordinates[0], coordinates[1], coordinates[2]);
        }

        public static void InputErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Что-то пошло не так, повторите ввод!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MultiplicationOnScalar()
        {
            Console.WriteLine("Введите поочереди координаты x,y,z первого вектора");
            var vector1 = InputVectorCoordinates();

            Console.WriteLine("Введите значение, на которое необходимо перемножить вектор");
            double skalare;
            while (true)
            {
                Console.Write("> ");
                var skalarCandidate = Console.ReadLine();
                if (!double.TryParse(skalarCandidate, out skalare))
                {
                    InputErrorMessage();
                    continue;
                }
                break;
            }

            var resultVector = vector1 * skalare;
            Console.WriteLine($"Произведение вектора на скаляр в результате даст вектор с координатами {resultVector}");
        }
    }
}
