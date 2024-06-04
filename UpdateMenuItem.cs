using System;

namespace PPMenu
{
    public class UpdateMenuItem : MenuItem 
    {
        private IRepository _repository;    
        public UpdateMenuItem(string title, string activationComand, IRepository repository) : base(title, activationComand)
        {
            _repository = repository;
        }

        public override void Action() 
        {
            try
            {
                _repository.Update(); 
            }
            catch (System.ApplicationException ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
