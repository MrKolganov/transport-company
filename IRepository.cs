using KolganovPS.Models.PetrovDB;

namespace PPMenu
{
    public interface IRepository
    { 
        void Create();
        
        void Read();

        void Update();

        void Delete();
    }
}
