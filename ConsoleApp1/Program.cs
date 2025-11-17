using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace ConsoleApp1
{
   public class ListHandler
    {
        Random random = new Random();
        List<FlashCard> cards;
        Dictionary<int, string> playerAnswers;
        private string filePath = @"C:\Repos\ovningarolaxor\ConsoleApp1\flashcards.json";

        public ListHandler()
        {
            cards = new List<FlashCard>();
            playerAnswers = new Dictionary<int, string>();
        }

        private void SerializeList()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(cards, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void LoadFromFile()
        {
            if(File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(jsonString))
                { cards.AddRange(JsonSerializer.Deserialize<List<FlashCard>>(jsonString)); }
            }
            else
            {
                SerializeList();
            }
        }
        
        private int ShowQuestion(int counter)
        {
            int questionNumber = random.Next(1, cards.Count);
            Console.Write($"Fråga {counter}: ");
            Console.WriteLine(cards[questionNumber]);
            return questionNumber;
        }
        private string GetAnswer()
        {
            Console.WriteLine("Svar: ");
            string answer = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("Skriv ett svar");
                answer = Console.ReadLine();
            }
            return answer;
        }
        public void Round(int counter)
        {
            playerAnswers.Add(ShowQuestion(counter), GetAnswer());
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ListHandler handler = new ListHandler();
            handler.LoadFromFile();
            
        }
    }


}
