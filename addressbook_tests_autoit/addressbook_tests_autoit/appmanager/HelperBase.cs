using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE; //чтобы видно было из Helper
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux; //чтобы запись в Helper была короче
            WINTITLE = ApplicationManager.WINTITLE; 
            
        }
    }
}