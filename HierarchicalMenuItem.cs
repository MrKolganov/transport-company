namespace PPMenu
{
    public class HierarchicalMenuItem : Menu, IMenuItem                    
    {

        private string _activationComand;                                   
        private string _title;                                              

        public HierarchicalMenuItem(string title, string activationComand)  
        {
            _title = title;                         
            _activationComand = activationComand;   
        }

        public string GetActivationComand()         // Метод для возвращения команды активации пункта меню (т.е. той клавиши, которую необходимо нажать пользователю)
        {
            return _activationComand;
        }

        public string GetTitle()                    // Метод для возвращения описания пункта меню
        {
            return _title;
        }

        // ИДЕЯ: когда главное меню передаст управление выбранному пользователем подменю, обработка запросов пользователя ляжет уже на подменю

        public void Action()                        // Метод, вызываемый при передаче управления от Menu к HierarchicalMenuItem
        {
            StartMenuHandle();                      // Запуск обработки запросов пользователя
        }
    }
}