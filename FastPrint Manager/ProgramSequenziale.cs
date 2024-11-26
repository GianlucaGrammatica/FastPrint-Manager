using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Simulazione stampa in corso...");
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Avvio dei task concorrenti
        Task<int> stampante1 = SimulaStampante("Stampante 1");
        Task<int> stampante2 = SimulaStampante("Stampante 2");
        Task<int> stampante3 = SimulaStampante("Stampante 3");

        // Aspetta che tutti i task siano completati
        int[] risultati = await Task.WhenAll(stampante1, stampante2, stampante3);

        stopwatch.Stop();
        Console.WriteLine("\n--- Risultati ---");
        Console.WriteLine($"Stampante 1 ha stampato {risultati[0]} documenti.");
        Console.WriteLine($"Stampante 2 ha stampato {risultati[1]} documenti.");
        Console.WriteLine($"Stampante 3 ha stampato {risultati[2]} documenti.");
        Console.WriteLine($"Tempo totale impiegato: {stopwatch.ElapsedMilliseconds} ms");

        Console.ReadKey();
    }

    static async Task<int> SimulaStampante(string nomeStampante)
    {
        Random random = new Random();
        int numeroDocumenti = random.Next(5, 16);

        Console.WriteLine($"{nomeStampante} inizia a stampare {numeroDocumenti} documenti...");

        for (int i = 0; i < numeroDocumenti; i++)
        {
            int tempoStampa = random.Next(100, 501);
            await Task.Delay(tempoStampa); // Simula il tempo di stampa per un documento
            Console.WriteLine($"{nomeStampante} ha stampato il documento {i + 1}/{numeroDocumenti}.");
        }

        return numeroDocumenti;
    }
}
