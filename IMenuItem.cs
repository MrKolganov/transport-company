namespace PPMenu
{

    public interface IMenuItem         
    {
        string GetActivationComand();   
        string GetTitle();              
        void Action();               
    }
}