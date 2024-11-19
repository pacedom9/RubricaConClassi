public class Contatto
{
    private string Nome;
    private string Cognome;
    private string Email;
    private string Telefono;

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
