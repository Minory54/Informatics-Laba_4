using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1._2
{
    internal class Program
    {
        static sbyte readSByte() // Проверка введенной строки на тип sbyte (для задания 1)
        {
            sbyte sNum;

            while (!(sbyte.TryParse(Console.ReadLine(), out sNum)))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Неверный диапозон или тип данных!");
                Console.ResetColor();
                Console.Write("Задание 1. Введите число в диапозоне от -128 до 127: ");
            }
            return sNum;
        }

        static int readInt() // Проверка введенной строки на тип int (для задания 3)
        {
            int intNum;

            while (!(int.TryParse(Console.ReadLine(), out intNum)))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Неверный диапозон или тип данных!");
                Console.ResetColor();
                Console.Write("Задание 3. Введите число в диапозоне от -128 до 127: ");
            }
            return intNum;
        }

        static int[] readIntArray() // Проверка на тип int[] (для задания 4)
        {

            double doubleNum; // используется этот тип потому что 

            while (!(double.TryParse(Console.ReadLine(), out doubleNum)) || (Convert.ToString(doubleNum)).Length > 8)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Неверный тип данных или число больше 8 бит!");
                Console.ResetColor();
                Console.Write("Задание 4. Введите 8 бит число: ");
            }

            string strNum = Convert.ToString(doubleNum);


            if (strNum.Length < 8)
            {
                while (strNum.Length < 8)
                {
                    strNum = "0" + strNum;
                }
            }

            int[] array = new int[8];
            for (int i = 0; i < strNum.Length; i++)
            {
                array[i] = (int)char.GetNumericValue(strNum[i]);
            }

            return array;
        }

        static int[] sbyteToBin(sbyte n) // Перевод числа в двоичную систему (для задания 1)
        {
            int[] array = new int[8];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (n >> (7 - i)) & 1;
            }

            return array;
        }

        static sbyte binToSByte(int[] n) // Перевод двоичного кода в число типа sbyte (для задания 2) 
        {
            sbyte result = 0;

            for (int i = 0; i < n.Length; i++)
            {
                // Сдвигаем бит влево и выполняем побитовое И с массивом
                if (n[i] == 1)
                {
                    result = (sbyte)(result | (1 << (7 - i)));
                }
            }

            return result;
        }

        static int[] intToBin(int n) // Перевод числа в двоичную систему (для задания 3)
        {
            int absNum = Math.Abs(n);
            int[] array = new int[8];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = absNum % 2;
                absNum = Convert.ToSByte(absNum / 2);
            }

            int temp;
            for (int i = 0; i < array.Length / 2; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            if (n < 0) // Условие если изначальное число отрицательное
            {
                array = addOne(invers(array));
            }

            return array;
        }

        static int binToInt(int[] n) // Перевод строки в чило int (для задания 4) 
        {
            int[] array = new int[8];
            array = n;
            int result = 0;

            if (n[0] == 1) // Условие если изначальное число отрицательное
            {
                array = addOne(invers(n));
            }

            for (int i = 0, j = 7; i < 8 && j >= 0; i++, j--)
            {
                result = result + array[i] * Convert.ToInt32(Math.Pow(2, j));
            }
            if (n[0] == 1)
            {
                result = Convert.ToInt32(result * (-1));
            }

            return result;
        }

        static int[] invers(int[] array) // Инверсия двоичного кода для отрицательных чисел
        {

            int[] invArray = new int[8];
            for (int i = 0; i < invArray.Length; i++)
            {
                if (array[i] == 0)
                {
                    invArray[i] = 1;
                }
                else
                {
                    invArray[i] = 0;
                }
            }

            return invArray;
        }

        static int[] addOne(int[] n) // Добаление единицы к двоичному коду
        {
            int[] unit = { 0, 0, 0, 0, 0, 0, 0, 1 };
            int[] resArray = new int[8];

            int temp = 0;

            for (int i = resArray.Length - 1; i >= 0; i--)
            {
                if (n[i] + unit[i] + temp >= 2)
                {
                    resArray[i] = n[i] + unit[i] + temp - 2;
                    temp = 1;
                }
                else
                {
                    resArray[i] = n[i] + unit[i] + temp;
                    temp = 0;
                }
            }

            return resArray;
        }

        static void print(int[] m)
        {
            Console.Write("Число в двоичном виде: ");
            for (int i = 0; i < m.Length; i++)
            {
                if (i == 4)
                {
                    Console.Write(" " + m[i]);
                }
                else
                {
                    Console.Write(m[i]);
                }

            }
        }

        static void Main(string[] args)
        {
            Console.Write("Номер задания (1-4): ");
            string numExercise = Console.ReadLine();

            switch (numExercise)
            {
                case ("1"):
                    Console.Write("Задание 1. Введите число в диапозоне от -128 до 127: ");
                    sbyte sbyteNum = readSByte();

                    print(sbyteToBin(sbyteNum));
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;

                case ("2"):
                    Console.Write("Задание 2. Введите 8 бит число: ");
                    int[] intNumArray = readIntArray();

                    sbyte resultSByte = binToSByte(intNumArray);
                    Console.Write("Число в десятичном виде: " + resultSByte);
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;

                case ("3"):
                    Console.Write("Задание 3. Введите целое число в диапозоне от -128 до 127: ");
                    int intNum = readInt();

                    print(intToBin(intNum));
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;

                case ("4"):
                    Console.Write("Задание 4. Введите 8 бит число: ");
                    int[] intNumArray2 = readIntArray();
                    int resultInt = binToInt(intNumArray2);

                    Console.Write("Число в десятичном виде: " + resultInt);
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;

                default:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Неверный номер задания!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Main(null);
                    break;
            }
        }
    }
}
