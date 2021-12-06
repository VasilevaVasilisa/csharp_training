using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
   public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book"; //константа , название окна
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Addressbook\AddressBook.exe","", aux.SW_SHOW); //Запуск приложения,  запуск приложения в видимлм режиме SW_SHOW 
            aux.WinWait(WINTITLE); //Ожидание  открытия окна
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            groupHelper = new GroupHelper(this);
        }
        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d5"); //закрытие формы, третий параметр = уникальный идентификатор
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
