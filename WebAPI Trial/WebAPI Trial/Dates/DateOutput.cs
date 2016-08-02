using WebAPI_Trial.Interfaces;

namespace WebAPI_Trial.Misc_Classes
{
    public sealed class DateOutput : IOutput
    {
        public string Write(string content)
        {
            //method to fetch the date and can be invoked by those classes who interface with IOutput
            return content;
        }
    }
}