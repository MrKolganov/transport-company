using System;

namespace PPMenu
{
    public class ReadMenuItem : MenuItem
    {
        private IRepository _repository;   

        public ReadMenuItem(string title, string activationComand, IRepository repository) : base(title, activationComand)
        {
            _repository = repository;
        }

        public override void Action()      
        {
            _repository.Read();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
