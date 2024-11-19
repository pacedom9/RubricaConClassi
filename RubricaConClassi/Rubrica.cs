

using System.Xml.Linq;

namespace RubricaConClassi;

public class Rubrica
{


    public static void AggiungiContatto()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        bool emailTrovata = false;
        Console.Write("Inserisci email dell'utente da modificare: ");
        var ricercaEmail = Console.ReadLine();

        List<string> righe = new List<string>(File.ReadAllLines(percorsoFile));
        List<Contatto> contatti = new List<Contatto>();

        foreach (var riga in righe)
        {
            var colonne = riga.Split(',');
            var contatto = new Contatto(colonne[0], colonne[1], colonne[2], colonne[3]);
            contatti.Add(contatto);
        }

        for (int i = 0; i < contatti.Count; i++)
        {
            var contatto = contatti[i];

            if (contatto.GetEmail() == ricercaEmail)
            {
                emailTrovata = true;
                Console.Write("Inserisci nuovo nome: ");
                string? nuovoNome = Console.ReadLine();
                Console.Write("Inserisci nuovo cognome: ");
                string? nuovoCognome = Console.ReadLine();
                Console.Write("Inserisci nuova email: ");
                string? nuovaEmail = Console.ReadLine();
                Console.Write("Inserisci nuovo numero di telefono: ");
                string? nuovoTelefono = Console.ReadLine();

                contatti[i] = new Contatto(nuovoNome, nuovoCognome, nuovaEmail, nuovoTelefono);

                var nuoveRighe = contatti.Select(c => c.Get()).ToList();  // Usa Get() per ottenere la rappresentazione del contatto in formato CSV
                File.WriteAllLines(percorsoFile, nuoveRighe);

                Console.WriteLine("\nContatto modificato correttamente");
                break;
            }
        }

        if (!emailTrovata)
        {
            Console.WriteLine("Email non trovata");
        }
    }
    public static void ModificaContatto()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        bool emailTrovata = false;
        Console.Write("Inserisci email dell'utente da modificare: ");
        var ricercaEmail = Console.ReadLine();

        List<string> righe = new List<string>(File.ReadAllLines(percorsoFile));
        List<Contatto> contatti = new List<Contatto>();
        foreach (var riga in righe)
        {
            var colonne = riga.Split(',');
            var contatto = new Contatto(colonne[0], colonne[1], colonne[2], colonne[3]);
            contatti.Add(contatto);
        }

        for (int i = 0; i < contatti.Count; i++)
        {
            var contatto = contatti[i];

            if (contatto.GetEmail() == ricercaEmail)
            {
                emailTrovata = true;
                Console.Write("Inserisci nuovo nome: ");
                string? nuovoNome = Console.ReadLine();
                Console.Write("Inserisci nuovo cognome: ");
                string? nuovoCognome = Console.ReadLine();
                Console.Write("Inserisci nuova email: ");
                string? nuovaEmail = Console.ReadLine();
                Console.Write("Inserisci nuovo numero di telefono: ");
                string? nuovoTelefono = Console.ReadLine();

                contatti[i] = new Contatto(nuovoNome, nuovoCognome, nuovaEmail, nuovoTelefono);

                var nuovoContatto = contatti.Select(c => c.Get()).ToList();
                File.WriteAllLines(percorsoFile, nuovoContatto);

                Console.WriteLine("\nContatto modificato correttamente");
                break;
            }
        }

        if (!emailTrovata)
        {
            Console.WriteLine("Email non trovata");
        }
    }
    public static void EliminaContatto()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        bool emailTrovata = false;
        Console.Write("Inserisci email dell'utente da eliminare: ");
        string? ricercaEmail = Console.ReadLine();

        List<string> righe = new List<string>(File.ReadAllLines(percorsoFile));

        List<Contatto> contatti = new List<Contatto>();

        foreach (var riga in righe)
        {
            var colonne = riga.Split(',');
            var contatto = new Contatto(colonne[0], colonne[1], colonne[2], colonne[3]);
            contatti.Add(contatto);
        }
        for (int i = 0; i < contatti.Count; i++)
        {
            var contatto = contatti[i];

            if (contatto.GetEmail() == ricercaEmail)
            {
                emailTrovata = true;
                Console.WriteLine($"Sei sicuro di voler eliminare l'utente {ricercaEmail}? (s/n)");

                string? risposta = Console.ReadLine();

                if (risposta.ToLower() == "s")
                {
                    
                    contatti.RemoveAt(i);
                    var nuoveRighe = contatti.Select(c => c.Get()).ToList();  // Usa il metodo Get per ottenere la rappresentazione CSV
                    File.WriteAllLines(percorsoFile, nuoveRighe);
                    Console.WriteLine("\nContatto eliminato correttamente");
                    break;
                }
            }
        }

        if (!emailTrovata)
        {
            Console.WriteLine("Email non trovata");
        }
    }
    public static void EliminaRubrica()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        Console.WriteLine("Sei sicuro di voler eliminare la rubrica? (s/n)");
        string? EliminazioneRubrica = Console.ReadLine();
        if (EliminazioneRubrica.ToLower() == "s")
        {
            Console.WriteLine("\nRubrica eliminata correttamente");
            File.Delete(percorsoFile);

        }
        else
        {
            Console.WriteLine("Operazione annullata");
        }
    }
    public static void EsportaRubrica()
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        string copyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\";
        Console.WriteLine("Inserisci nome nuovo registro");
        var fileCopy = Console.ReadLine();
        File.Copy(folderPath, copyPath + fileCopy + ".csv");

    }
    public static void ImportaRubrica()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        bool emailTrovata = false;
        var ricercaFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\";
        Console.Write("Inserisci nome file da importare: ");
        var fileImportato = ricercaFile + Console.ReadLine() + ".csv";


        List<string> righe = new List<string>(File.ReadAllLines(percorsoFile));
        var righeNuove = File.ReadAllLines(fileImportato).ToList();

        for (int y = 0; y < righeNuove.Count; y++)
        {
            var colonne = righeNuove[y].Split(',');
            bool emailDuplicata = false;

            for (int i = 0; i < righe.Count; i++)
            {
                var colonne2 = righe[i].Split(',');


                if (colonne2[2].Trim() == colonne[2].Trim())
                {
                    emailDuplicata = true;
                    Console.WriteLine($"{colonne[2].Trim()} esiste già. Vuoi sostituirlo con {colonne2[0]},{colonne2[1]} ? (s/n)");
                    var rispostaUtente = Console.ReadLine();
                    if (rispostaUtente.ToLower() == "s")
                    {
                        righe.Remove(colonne[0] + colonne[1] + colonne[2] + colonne[3]);
                        righeNuove.Add(colonne[0] + colonne[1] + colonne[2] + colonne[3]);
                        File.WriteAllLines(percorsoFile, righeNuove);
                        break;
                    }
                    else if (rispostaUtente.ToLower() == "n")
                    {
                        Console.WriteLine("Okay.");
                        break;
                    }
                    else if (!emailDuplicata)
                    {
                        File.AppendAllLines(percorsoFile, righeNuove);
                        break;
                    }

                }
            }
        }

    }
    public static void VisualizzaContatti()
    {
        string percorsoFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\diecimila.csv";
        Console.WriteLine("\n" + File.ReadAllText(percorsoFile));
    }
}

