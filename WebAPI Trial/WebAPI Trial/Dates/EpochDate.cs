using System;
using WebAPI_Trial.Interfaces;

namespace WebAPI_Trial.Misc_Classes
{
    public sealed class EpochDate : IDateWriter
    {
        private IOutput _output;

        public EpochDate(IOutput output)
        {
            // set the variable to hold the value
            _output = output;
        }
        public string WriteDate()
        {
            // get the value to return up the call path
            return DateTime.UtcNow.ToString();
        }
    }
}