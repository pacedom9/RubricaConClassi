using CsvHelper.Configuration.Attributes;

public class Contatto
{
    [Index(0)]
    public string Nome { get; set; }

    [Index(1)]
    public string Cognome { get; set; }

    [Index(2)]
    public string Email { get; set; }

    [Index(3)]
    public string Telefono { get; set; }

    public Contatto(string nome, string cognome, string email, string telefono)
    {
        Nome = nome;
        Cognome = cognome;
        Email = email;
        Telefono = telefono;
    }

    public string Get()
    {
        return $"{Nome}, {Cognome}, {Email}, {Telefono}";
    }

    public string GetEmail()
    {
        return $"{Email}";
    }
}