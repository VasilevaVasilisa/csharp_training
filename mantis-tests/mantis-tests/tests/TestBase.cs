using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests

{
   public class TestBase
    {
       
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();

        }

        public static Random rnd = new Random(); //генрация случайных чисел

        public static string GeneratorRandomString(int max) //метод для генерации случайных строк
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max); // генерация числа в диапозоне от 0 до max, с преобрахование в int
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i<l; i++) //генерация случайных символов
            {
               builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() + 65 + 32)));  // 223(65 только латинский, цифры, спец символы) , 32 коды символов в соответствии таблицей ASCII, символы меня 32 не печатные
                                                                                              //конвертируем сначала в целое число , потом в символ 
                                                                                             // Добавить в builder с помощью Append
            }
            return builder.ToString(); //
        }

    }
}
