using KolganovPS.Models.PetrovDB;
using PPMenu;
using System;
using System.Globalization;
using System.Linq;

namespace PP_KR_2023
{
    public class RouteRepository : Repository
    {
        public RouteRepository(PetrovDB db) : base(db)
        {
        }

        public override void Create()
        {
            Read();
            _db.Routes.Add(EnteringData());                       // Добавление к таблице учителей новой записи
            _db.SaveChanges();

            Console.WriteLine("*********************************************");
            Read();                                         
        }

        public override void Delete()
        {
            Read();
            Console.WriteLine("Введите ID маршрута для удаления:");
            int.TryParse(Console.ReadLine(), out int id);

            Route? routeToDelete = _db.Routes.FirstOrDefault(route => route.Id == id);
            while (routeToDelete == null)
            {
                Console.WriteLine("Такого маршрута нет");
                Console.WriteLine("Введите существующий маршрут:");
                int.TryParse(Console.ReadLine(), out id);
                routeToDelete = _db.Routes.FirstOrDefault(route => route.Id == id);
            }

            _db.Routes.Remove(routeToDelete);                                      
            _db.SaveChanges();                                                     

            Console.WriteLine("*********************************************");
            Read();                                                                 
        }

        public override void Read()
        {
            Console.WriteLine("Список маршрутов\n");
            Console.WriteLine("id\t| Name\t| Number days road \t| Range");
            Console.WriteLine("---------------------------------------------");

            foreach (Route route in _db.Routes)    
            {
                Console.WriteLine($"{route.Id}\t| {route.Name}\t| {route.NumberDaysRoad}\t| {route.Range}");
            }
            Console.WriteLine("---------------------------------------------");
        }

        public override void Update()
        {
            Read();
            Console.WriteLine("Введите ID маршрута для изменения:");
            int.TryParse(Console.ReadLine(), out int id);
            Route? routeToUpdate = _db.Routes.FirstOrDefault(route => route.Id == id);
            while (routeToUpdate == null)
            {
                Console.WriteLine("Такого маршрута нет");
                Console.WriteLine("Введите существующий маршрут:");
                int.TryParse(Console.ReadLine(), out id);
                routeToUpdate = _db.Routes.FirstOrDefault(route => route.Id == id);
            }   

            routeToUpdate = EnteringData();
            _db.Routes.Update(routeToUpdate);                                     
            _db.SaveChanges();                                                      

            Read(); 
        }

        public Route EnteringData()
        {
            Route routeToCreate = new Route();

            Console.WriteLine("Введите название маршрута:");
            routeToCreate.Name = Console.ReadLine();

            Console.WriteLine("Введите дальность маршрута");
            routeToCreate.Range = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите длительность маршрута");
            routeToCreate.NumberDaysRoad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите ID машины");
            routeToCreate.CarID = Convert.ToInt32(Console.ReadLine());

            return routeToCreate;
        }
    }
}
