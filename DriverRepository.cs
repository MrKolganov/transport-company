using KolganovPS.Models.PetrovDB;
using PPMenu;
using System;
using System.Globalization;
using System.Linq;

namespace PP_KR_2023
{

    public class DriverRepository : Repository  
    {

        public DriverRepository(PetrovDB db) : base(db)
        {
        }


        public override void Create()
        {
            Driver teacherToCreate = new Driver();

            Console.WriteLine("Введите ФИО водителя:");
            teacherToCreate.FIO = Console.ReadLine();

            Console.WriteLine("Введите дату начала работы водителя (формат дд.мм.гг чч:мм):");
            DateOnly.TryParseExact(Console.ReadLine(), "d.M.yy H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dateTime);
            teacherToCreate.StartDate = dateTime;

            Console.WriteLine("Введите id машины водителя:");
            teacherToCreate.CarsID = Convert.ToInt32(Console.ReadLine());

            _db.Drivers.Add(teacherToCreate);
            _db.SaveChanges();

            Console.WriteLine("*********************************************");
            Read();
        }
        public override void Delete()      
        {
            Console.WriteLine("Введите ID водителя для удаления:");
            int.TryParse(Console.ReadLine(), out int id);                               

            Driver? driverToDelete = _db.Drivers.FirstOrDefault(driver => driver.Id == id);  
            while (driverToDelete == null)
            {
                Console.WriteLine("Такго водителя нет");
                Console.WriteLine("Введите существующего водителя:");
                int.TryParse(Console.ReadLine(), out id);
                driverToDelete = _db.Drivers.FirstOrDefault(driver => driver.Id == id);
            }
            _db.Drivers.Remove(driverToDelete);                                        
            _db.SaveChanges();                                                          

            Console.WriteLine("*********************************************");
            Read();                                                                     
        }

        public override void Read()        
        {
            Console.WriteLine("Список водителй\n");
            Console.WriteLine("id\t| fio");
            Console.WriteLine("---------------------------------------------");

            foreach (Driver teacher in _db.Drivers)                                                
            {
                Console.WriteLine($"{teacher.Id}\t| {teacher.FIO}");    
            }
            Console.WriteLine("---------------------------------------------");
        }

        public override void Update()       
        {
            Console.WriteLine("Введите ID водителя для изменения:");
            int.TryParse(Console.ReadLine(), out int id);                               

            Driver? driverToUpdate = _db.Drivers.FirstOrDefault(driver => driver.Id == id); 
            while (driverToUpdate == null)
            {
                Console.WriteLine("Такого водителя нет");
                Console.WriteLine("Введите существующего водителя:");
                int.TryParse(Console.ReadLine(), out id);
                driverToUpdate = _db.Drivers.FirstOrDefault(driver => driver.Id == id);
            }
            _db.Drivers.Remove(driverToUpdate);                                        
            _db.SaveChanges();                                                         

            Create();                                                                   
        }
    }
}
