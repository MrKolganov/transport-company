using KolganovPS.Models.PetrovDB;

namespace PPMenu
{

    public abstract class Repository : IRepository
    {
        protected PetrovDB _db;

        protected Repository(PetrovDB db)
        {
            _db = db;
        }

        public abstract void Create(); 

        public abstract void Delete();  

        public abstract void Read();  

        public abstract void Update();  
    }
}
