using Serilog;
namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Konfigurera Serilog för att logga till konsolen
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate:"[{Timestamp:yyyy-MM-dd HH:mm} {Level: u3}] {Message:lj}{NewLine}{Exception}")
                
                .WriteTo.File("övning2.log", outputTemplate:"[{Timestamp: yyyy-MM-dd HH:mm} {Level: u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
                

            Console.WriteLine("=== Övning 1: Grundläggande konsolloggning ===");

            // TODO: Logga meddelanden på olika nivåer
            Log.Information("Application started");
            Log.Warning("This is a warning.");
            
            try
            {
                Log.Debug("About to do something.");
                
                Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                Console.ReadKey();
                int nämnare = 0;
                int resultat = 10 / nämnare;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred.");
            }
            Log.Information("Application closing.");
            // Glöm inte att spola loggarna!
            Log.CloseAndFlush();

        }
    }
}
