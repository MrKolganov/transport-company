using System;

namespace PPMenu
{
    public class DeleteMenuItem : MenuItem
    {
        private IRepository _repository; 

        public DeleteMenuItem(string title, string activationComand, IRepository repository) : base(title, activationComand)
        {
            _repository = repository;
        }

        public override void Action() 
        {
            _repository.Delete();     
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
