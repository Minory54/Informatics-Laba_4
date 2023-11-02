using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1
{
    internal class Program
    {
        static sbyte readSByte() // Проверка введенной строки (для задания 1)
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

        static string readString() // Проверка введенной строки (для задания 2)
        {
            double doubleNum;

            while (!(double.TryParse(Console.ReadLine(), out doubleNum)) || (Convert.ToString(doubleNum)).Length > 8)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Неверный тип данных или число больше 8 бит!");
                Console.ResetColor();
                Console.Write("Задание 2. Введите 8 бит число: ");
            }

            string strNum = Convert.ToString(doubleNum);

            if (strNum.Length < 8)
            {
                while (strNum.Length < 8)
                {
                    strNum = "0" + strNum;
                }
            }
            return strNum;
        }

        static int[] sbyteToBin(sbyte n) // Перевод числа в двоичную систему
        {

            sbyte absNum = Math.Abs(n);
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

        static int[] strToBin(string n) // Перевод строки в массив
        {
            int[] array = new int[8];

            for (int i = 0; i < n.Length; i++)
            {
                array[i] = (int)char.GetNumericValue(n[i]);
            }

            return array;
        }

        static string binToStr(int[] n) // Перевод массива в строку
        {
            string result = "";
            for (int i = 0; i < n.Length; i++)
            { 
                if (i == 4) 
                { 
                    result = result + " " + Convert.ToString(n[i]);
                }
                else
                {
                    result = result + Convert.ToString(n[i]);
                }
                
            }
            return result;
        }

        static sbyte binToSByte(int[] n) // Перевод строки в байты 
        {
            int[] array = new int[8];
            array = n;
            sbyte result = 0;

            if (n[0] == 1) // Условие если изначальное число отрицательное
            {              
               array = addOne(invers(n));
            }

            for (int i = 0, j = 7; i < 8 && j >= 0; i++, j--)
            {
                //Console.WriteLine(array[i] + " " + i + " " + j + " " + (Math.Pow(array[i] * 2, j)));
                result += (sbyte)(array[i] * Convert.ToSByte(Math.Pow(2, j)));
            }          
            if (n[0] == 1)
            {
                result = Convert.ToSByte(result * (-1));
            }

            //result = Convert.ToSByte(intResult);

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

            for(int i = resArray.Length-1; i >= 0; i--)
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
                    string resultStr = binToStr(sbyteToBin(sbyteNum));
                    
                    Console.Write("Число в двоичном виде: " + resultStr);
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;
                
                case ("2"):
                    Console.Write("Задание 2. Введите 8 бит число: ");
                    string strNum = readString();
                    sbyte resultSByte = binToSByte(strToBin(strNum));

                    Console.Write("Число в десятичном виде: " + resultSByte);
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;
                
                case ("3"):
                    Console.Write("Задание 3. Введите целое число в диапозоне от -128 до 127: ");

                    Console.Write("Число в двоичном виде: ");
                    Console.WriteLine();
                    Console.WriteLine();

                    Main(null);
                    break;
                
                case ("4"):
                    Console.Write("Задание 4. Введите 8 бит число: ");

                    Console.Write("Число в десятичном виде: ");
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

            //Console.Write("Введите число в диапозоне от -128 до 127: ");
            //sbyte num = readSByte();
            //int[] result = sbyteToBin(num);

            //print(result);
            //Console.ReadKey();
            
        }
    }
}
