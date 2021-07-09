using EsercizationeFinale.Week1.OriellaVullo.Models.Chain;
using EsercizationeFinale.Week1.OriellaVullo.Models.Factory;
using System;
using System.IO;

namespace EsercizationeFinale.Week1.OriellaVullo
{
    class Program
    {
        private const string _cartella = @"C:\Saves";

        static void Main(string[] args)
        {
            /* MONITORAGGIO CARTELLA */
            MonitoraggioCartella();

            /* CHAIN OF RESPONSAIBILITY */
            var manager = new ManagerHandler();
            var operationMan = new OperationalManagerHandler();
            var ceo = new CeoHandler();
            // configurazione la concatenazione
            manager.SetNext(operationMan).SetNext(ceo);

            /* RICHIESTA CIFRA */
            Console.WriteLine("Inserire importo del spesa");
            decimal.TryParse(Console.ReadLine(), out decimal spesa);
            // controllo la spesa 
            var result = manager.Handle(spesa);

            /* RICHIESTA TIPO DI RIMBORSO */
            Console.WriteLine("Inserire Categoria del rimborso");
            Console.WriteLine("1 x Viaggio \n2 x Alloggio \n3 x Vitto \n4 x Altro");
            // TODO : inserire controllo numeri e do-while
            string nbrScelto = Console.ReadLine();
            int.TryParse(nbrScelto, out int nbrCategoria);

            /* FACTORY */
            // instanziare la categoria
            ICategoria categoria;
            // creo la categoria tramite la factory
            categoria = CategoriaFactory.GetCategoria(nbrCategoria);

            // richiesta descrizione
            Console.WriteLine("Inserire descrizione");
            categoria.Descrizione = Console.ReadLine();

            if (result != null)
            {
                Console.WriteLine("=== SPESA APPROVATA ===\n\n");
                // salvo su file 
                SaveToFile("spese_elaborate.txt", categoria, spesa, result);
            }
            else
            {
                Console.WriteLine("=== SPESA NON APPROVATA ===");
                Console.WriteLine("Nessuna spesa sopra i 2500 euro è approvata");
                // salvo su file
                SaveToFile("spese_elaborate.txt", categoria, spesa, result);
            }
        }

        private static void SaveToFile(string fileName, ICategoria categoria, decimal spesa, string result)
        {
            try
            {
                if (!Directory.Exists(_cartella))
                {
                    Directory.CreateDirectory(_cartella);
                }

                StreamWriter writer = File.AppendText(Path.Combine(_cartella, fileName));
               
                if (String.IsNullOrEmpty(result))
                {
                    //Data;categoria,descrizione;RESPINTA;-;-
                    writer.WriteLine($"{DateTime.Now.ToShortDateString()}; {categoria.GetType().Name}; {categoria.Descrizione}; RESPINTA; -; -");
               
                }
                else
                {
                    // Data; Categoria; Descrizione; APPROVATA; LvApprov; ImportoRimborsato
                    writer.WriteLine($"{DateTime.Now.ToShortDateString()}; {categoria.GetType().Name}; {categoria.Descrizione}; APPROVATA; {categoria.importoRimborsato(spesa)}; {result}");
                }
                
                writer.Flush();
                writer.Close();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O Error: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore Generico: {ex.Message}");
            }
        }

        private static void MonitoraggioCartella()
        {
            FileSystemWatcher fsw = new();
            // controlla solo questo file
            fsw.Filter = "*.txt";
            // percorso da monitorare
            fsw.Path = @"C:\watch";

            // cosa deve controllare
            fsw.NotifyFilter = NotifyFilters.LastWrite
                | NotifyFilters.LastAccess
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            // abilito gli eventi
            fsw.EnableRaisingEvents = true;

            // creo il file 
            fsw.Created += Fsw_Created;
        }

        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"= CREATED: {e.Name} =");
            var reader = File.OpenText(e.FullPath);
            string line;
            while ((line = reader.ReadLine()) != null)
                Console.WriteLine(line);
        }
    }
}
