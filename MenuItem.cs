using System;

// ТЕОРИЯ: поле - это переменная внутри класса.
// Любой класс, наследуемый от интерфейса, ОБЯЗАН реализовывать объявленные в этом интерфейсе методы и свойства

namespace PPMenu
{
    public class MenuItem : IMenuItem                           // Класс "Элемент меню", который наследуется от интерфейса IMenuItem
    {
        // ПРАВИЛО ИМЕНОВАНИЯ: private поля класса МОЖНО называть, начиная с нижнего подчеркивания
        // (для того, чтобы не использовать лишний раз ключевое слово this)

        private string _activationComand;                       // private поле _activationComand (т.е. та клавиша, которую необходимо нажать пользователю)
        private string _title;                                  // private поле _title (т.е. описания пункта меню)

        public MenuItem(string title, string activationComand)  // Конструктор (принимает 2 параметра: string title и string activationComand)
        {
            _title = title;                                     // Присвоение полю _activationComand значения, полученного в качестве параметра конструктора
            _activationComand = activationComand;               // Присвоение полю _title значения, полученного в качестве параметра конструктора
        }

        public string GetActivationComand()                     // Метод для возвращения команды активации пункта меню (т.е. той клавиши, которую необходимо нажать пользователю)
        {
            return _activationComand;
        }

        public string GetTitle()                                // Метод для возвращения описания пункта меню
        {
            return _title;
        }

        // ТЕОРИЯ: метод, помеченный в классе-родителе как virtual, может быть переопределен в его наследниках

        // ИДЕЯ: класс MenuItem - сам не реализует никакого Action(), реализация будет прописана в наследниках этого класса
        // поэтому ниже метод Action() помечен как virtual. Выводит данный метод в данном классе лишь отладочную информацию в консоль

        public virtual void Action()
        {
            Console.WriteLine($"(MenuItem) Пользователь вызвал действие {_activationComand} - {_title}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}