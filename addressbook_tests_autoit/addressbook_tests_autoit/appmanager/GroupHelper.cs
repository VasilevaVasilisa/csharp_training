using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }
        public static string GROUPWINTITLE = "Group editor"; // Константа, окно Group editor
        public static string GROUPDELETEWINTITLE = "Delete group";

        public List<GroupData> GetGroupList()
        {
          List<GroupData> list = new List<GroupData>();

          OpenGroupsDialogue();
          string  count =  aux.ControlTreeView("GROUPWINTITLE", "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount","#0",""); // метод для получения элемента из окна, GetItemCount - подсчет
         
            for(int i = 0; i < int.Parse(count); i++)
            {
             string item = aux.ControlTreeView("GROUPWINTITLE", "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, ""); //Берем текст элемента
             list.Add(new GroupData() { Name = item}); //Добавление группы в список групп
            }

          CloseGroupsDialogue();

          return list;

        }

        public void Remove(int index)
        {
            OpenGroupsDialogue();
            SelectGroup(index);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51"); //Delete
            aux.WinWait(GROUPWINTITLE);
            aux.ControlClick(GROUPDELETEWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53"); //Ok
            aux.WinWait(GROUPWINTITLE);
            CloseGroupsDialogue();
            aux.WinWait(WINTITLE);
        }

        public void SelectGroup(int index)
        {
           aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + index, ""); 
        }

        public void Add(GroupData newGroup)
        {
            // manager.Aux.ControlClick(WINTITLE, "", " WindowsForms10.BUTTON.app.0.2c908d512"); // Нажатие на кнопку Edit Groups
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");// Нажатие на кнопку New
            aux.Send(newGroup.Name);//Ввод названия группы
            aux.Send("{Enter}"); //Нажатие на клафишу Enter
            CloseGroupsDialogue();
            aux.WinWait(WINTITLE);
        }

      
        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");// Закрытие окна Group editor
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512"); // Нажатие на кнопку Edit Groups
            aux.WinWait(GROUPWINTITLE); // ожидание окна
        }
    }
}