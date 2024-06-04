using KolganovPS.Models.PetrovDB;

namespace PPMenu
{

    public class CarRepository : Repository 
    {
        public CarRepository(PetrovDB db) : base(db)
        {
        }

        private static CarRepository _carForCRUD;

        public static CarRepository carForCRUD
        {
            get { return _carForCRUD; }
        }

        public override void Create()
        {
            Car cargoToCreate = new Car();

            Console.WriteLine("Введите номер машины:");
            cargoToCreate.NumberCar = Console.ReadLine();

            _db.Cars.Add(cargoToCreate);   
            _db.SaveChanges();                              

            Console.WriteLine("*********************************************");
            Read();                                         
        }

        public override void Delete()       
        {
            Console.WriteLine("Введите ID машины для удаления:");
            int.TryParse(Console.ReadLine(), out int id);                               

            Car? carToDelete = _db.Cars.FirstOrDefault(car => car.Id == id);  

            while (carToDelete == null)
            {
                Console.WriteLine("Такой машины нет");
                Console.WriteLine("Введите существующую машину:");
                int.TryParse(Console.ReadLine(), out id);
                carToDelete = _db.Cars.FirstOrDefault(car => car.Id == id);
            }
            try
            {
                _db.Cars.Remove(carToDelete);                                        
                _db.SaveChanges();                                                        
            }
            catch
            {
                Console.WriteLine("Для удаления машины необходимо удалить её во всех таблицах");
            }

            Console.WriteLine("*********************************************");
            Read();                                                                    
        }

        public override void Read()        
        {
            Console.WriteLine("Список машин\n");
            Console.WriteLine("id\t| Number");
            Console.WriteLine("---------------------------------------------");

            foreach (Car car in _db.Cars)                    
            {
                Console.WriteLine($"{car.Id}\t| {car.NumberCar}");  
            }
            Console.WriteLine("---------------------------------------------");
        }

        public override void Update()      
        {
            Console.WriteLine("Введите ID машины для изменения:");
            int.TryParse(Console.ReadLine(), out int id);                              


            Car? carToUpdate = _db.Cars.FirstOrDefault(car => car.Id == id); 
            while(carToUpdate == null)
            {
                Console.WriteLine("Такой машины нет");
                Console.WriteLine("Введите существующую машину:");
                int.TryParse(Console.ReadLine(), out id);
                carToUpdate = _db.Cars.FirstOrDefault(car => car.Id == id);
            }

            Console.WriteLine("Введите новый номер машины:");
            carToUpdate.NumberCar = Console.ReadLine();

            _db.Cars.Update(carToUpdate);                                        
            _db.SaveChanges();                                                          

            Read();
        }
    }
}
