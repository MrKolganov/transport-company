using KolganovPS.Models.PetrovDB;
using PP_KR_2023;
using System;

namespace PPMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetrovDB db = new PetrovDB();
            Menu menu = new Menu();

            CarRepository carRepository = new CarRepository(db);
            HierarchicalMenuItem carHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей машины", "1");

            carHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка машин", "1", carRepository));                
            carHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление новой машины в список", "2", carRepository));    
            carHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование данных машины", "3", carRepository));         
            carHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаление машины из списка", "4", carRepository));           

            DriverRepository driverRepository = new DriverRepository(db);                                                
            HierarchicalMenuItem driverHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей водители", "2");  

            driverHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка водителей", "1", driverRepository));  
            driverHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление нового водителя в список", "2", driverRepository));
            driverHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование данных водителя", "3", driverRepository));   
            driverHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаление водителя из списка", "4", driverRepository));

            RouteRepository routeRepository = new RouteRepository(db);                                                   
            HierarchicalMenuItem routeHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей маршруты", "3");   

            routeHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка маршрутов", "1", routeRepository));                   
            routeHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление нового маршрута в список", "2", routeRepository));      
            routeHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование маршрута", "3", routeRepository));       
            routeHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаление маршрута из списка", "4", routeRepository));     

            menu.MenuItems.Add(carHierarchicalMenuItem);
            menu.MenuItems.Add(driverHierarchicalMenuItem);
            menu.MenuItems.Add(routeHierarchicalMenuItem);
            menu.StartMenuHandle(); 
        }
    }
}
