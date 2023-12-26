namespace FirstWebApi.Logger
{
    public class MyLogger : IMyLogger
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.WriteLine("Error - " + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
