using Microsoft.AspNetCore.Mvc;

namespace ThrApi.Service.CustonException
{
    public class ExceptionService : Exception
    {
        public ExceptionService(string message) : base(message){}



    }
}
