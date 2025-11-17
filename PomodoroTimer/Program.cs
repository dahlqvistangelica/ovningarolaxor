using System.Globalization;
using System.Text.Json;

namespace PomodoroTimer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Timer> timers = new List<Timer>();
            string path = @"C:\Repos\ovningarolaxor\PomodoroTimer\timers.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            Timer timer = Timer.GetTimer();
            timers.Add(timer);
            if (File.Exists(path))
            {
                var jsonfile = File.ReadAllText(path);
                timers.AddRange(JsonSerializer.Deserialize<List<Timer>>(jsonfile));
            }
            string json = JsonSerializer.Serialize(timers, options);
            File.WriteAllText(path, json);
                

            timer.ShowTimer();
            Console.ReadLine();
            
            
        }

    public class Timer
        {
            public string Subject { get; set; }
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
            public TimeSpan totalTime { get; set; }

            public Timer(string subject, TimeSpan span)
            {
                Subject = subject;
                startTime = DateTime.Now;
                totalTime = span;
                endTime = startTime + span;
            }
            public Timer()
            { }

            public static Timer GetTimer()
            {
                Console.WriteLine("Vad är det du vill sätta en timer på?");
                string subject = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(subject))
                {
                    Console.WriteLine("Ämne kan inte vara tomt.");
                }
                Console.WriteLine("Ange tid för timer: ");
                string timer = Console.ReadLine();
                string format = "hh\\:mm\\:ss";
                if (TimeSpan.TryParseExact(timer, format, CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan result))
                {
                    return new Timer(subject, result);
                }
                Console.WriteLine("Felaktig inmatning av tidsangivelse. Försök igen");
                timer = Console.ReadLine();
                return new Timer(subject, result);
            }

            public void ShowTimer()
            {
                
                while(this.totalTime.TotalSeconds >= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Nedräkning till {this.Subject}");
                    Console.WriteLine($"{this.totalTime:hh\\:mm\\:ss}");
                    Thread.Sleep(1000);
                    TimeSpan second = new TimeSpan(0, 0, 1);
                    this.totalTime = this.totalTime.Subtract(second);
                }
                if (this.totalTime.Seconds == 0)
                {
                    Console.Beep();
                    Console.WriteLine("Nedräkningen avslutad!");
                }
            }
        }
    }
}
