using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Linq;

namespace RubricaConClassi;

public static class Rubrica
{
    static List<Contatto> contatti = new();
    const string percorsoFile = @"C:\Users\dpace\Desktop\rub2.csv";
    public static List<Contatto> CaricaRubrica()
    {

        using (var reader = new StreamReader(percorsoFile))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null, HasHeaderRecord = false}))

        { 
            contatti = csv.GetRecords<Contatto>().ToList();

        }
        return contatti;

    }
    public static void SalvaRubrica(List<Contatto> contatti)
    {
        using (var writer = new StreamWriter(percorsoFile, append: false))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(contatti);
        }


    }
    public static void AggiungiContatto()
    {
        

        Console.WriteLine("Inserisci nome:");
        string? nome = Console.ReadLine();
        Console.WriteLine("Inserisci cognome:");
        string? cognome = Console.ReadLine();
        Console.WriteLine("Inserisci email:");
        string? email = Console.ReadLine();
        Console.WriteLine("Inserisci telefono:");
        string? telefono = Console.ReadLine();

        foreach (var riga in contatti)
        {
            if (riga.GetEmail() == email)
            {
                Console.WriteLine("Contatto già esistente!");
                return;
            }
        }

        Contatto nuovoContatto = new Contatto(nome, cognome, email, telefono);
        contatti.Add(nuovoContatto);

        SalvaRubrica(contatti);

        Console.WriteLine("Contatto aggiunto con successo!");
    }
    public static void ModificaContatto()
    {
        bool emailTrovata = false;
        Console.Write("Inserisci email dell'utente da modificare: ");
        string? ricercaEmail = Console.ReadLine();

        List<Contatto> contattiEsistenti = CaricaRubrica();

        foreach (var riga in contattiEsistenti)
        {
            if (riga.GetEmail() == ricercaEmail)
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

                if (string.IsNullOrEmpty(nuovoNome)) nuovoNome = riga.Nome;
                if (string.IsNullOrEmpty(nuovoCognome)) nuovoCognome = riga.Cognome;
                if (string.IsNullOrEmpty(nuovaEmail)) nuovaEmail = riga.Email;
                if (string.IsNullOrEmpty(nuovoTelefono)) nuovoTelefono = riga.Telefono;

                riga.Nome = nuovoNome;
                riga.Cognome = nuovoCognome;
                riga.Email = nuovaEmail;
                riga.Telefono = nuovoTelefono;

                SalvaRubrica(contattiEsistenti);
                Console.WriteLine("Contatto modificato con successo!");
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
        Console.Write("Inserisci email dell'utente da eliminare: ");
        string? ricercaEmail = Console.ReadLine();

        List<Contatto> contattiEsistenti = CaricaRubrica();

        foreach (var riga in contattiEsistenti)
        {
            if (riga.GetEmail() == ricercaEmail)
            {
                contattiEsistenti.Remove(riga);

                SalvaRubrica(contattiEsistenti);
                Console.WriteLine("Contatto eliminato con successo!");
                break;
            } else
            {
                Console.WriteLine("Email non trovata");
                break;
            }
        }
    }
    public static void EliminaRubrica()
    {        
        Console.WriteLine("Sei sicuro di voler eliminare la rubrica? (s/n)");
        string? EliminazioneRubrica = Console.ReadLine();
        if (EliminazioneRubrica.ToLower() == "s")
        {
            Console.WriteLine("\nRubrica eliminata correttamente");
            contatti.Clear();
            SalvaRubrica(contatti);

        }
        else
        {
            Console.WriteLine("Risposta non valida. Operazione annullata");
        }
    }
    public static void EsportaRubrica()
    {
        string ricercaFileDaEsportare = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Console.WriteLine("Inserisci nome del nuovo file");
        string? nomeRegistro = Console.ReadLine() + ".csv";
        string fileEsportato = Path.Combine(ricercaFileDaEsportare, nomeRegistro);
        
        using (var writer = new StreamWriter(fileEsportato, append: false)) 
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true }))
        {
            csv.WriteRecords(contatti);
        }

        Console.WriteLine($"Rubrica esportata in {fileEsportato}");
    }
    public static void ImportaRubrica()
    {
        Console.WriteLine("Inserisci nome della rubrica da importare");
        string ricercaFileDaImportare = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + Console.ReadLine() + ".csv";

        if (File.Exists(ricercaFileDaImportare))
        {
            List<Contatto> nuoviContatti;
            using (var reader = new StreamReader(ricercaFileDaImportare))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null, HasHeaderRecord = false }))

            {
                nuoviContatti = csv.GetRecords<Contatto>().ToList();

            }
            foreach (var contattoImportato in nuoviContatti)
            {

                var contattoEsistente = contatti.FirstOrDefault(c => c.Email == contattoImportato.Email);
                if (contattoEsistente != null)
                {
                    Console.WriteLine($"Contatto duplicato trovato: {contattoEsistente.Nome} {contattoEsistente.Cognome}. Vuoi mantenere (1) il contatto esistente o (2) il nuovo contatto? (1/2)");
                    string scelta = Console.ReadLine() ?? "";
                    if (scelta == "2")
                    {
                        contatti.Remove(contattoEsistente);
                        contatti.Add(contattoImportato);
                    }
                }
                else
                {
                    contatti.Add(contattoImportato);
                }

                
                SalvaRubrica(contatti);
                

            }
            Console.WriteLine("Rubrica importata con successo! (forse)");
        }
    }
    public static void VisualizzaContatti()
    {

        if (contatti.Count == 0)
        {
            Console.WriteLine("Non ci sono contatti nella rubrica.");
        }
        else
        {
            foreach (var contatto in contatti)
            {
                Console.WriteLine($"{contatto.Nome}, {contatto.Cognome}, {contatto.Email}, {contatto.Telefono}");
            }
        }

    }
}

