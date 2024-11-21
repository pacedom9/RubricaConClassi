using CsvHelper.Configuration.Attributes;

public class Contatto
{
   
    public string Nome { get; set; } 
    public string Cognome { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Contatto(string nome, string cognome, string email, string telefono)
    {
        Nome = nome;
        Cognome = cognome;
        Email = email;
        Telefono = telefono;
    }

}







