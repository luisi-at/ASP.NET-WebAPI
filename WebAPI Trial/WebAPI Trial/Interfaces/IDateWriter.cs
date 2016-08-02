namespace WebAPI_Trial.Interfaces
{
    public interface IDateWriter
    {
        //method to give the final output that can be invoked by those classes who interface with IDateWriter
        string WriteDate();
    }
}