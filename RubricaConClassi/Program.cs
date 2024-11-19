
using RubricaConClassi;


Console.WriteLine("1 - Aggiungi contatto");
Console.WriteLine("2 - Modifica contatto");
Console.WriteLine("3 - Elimina contatto");
Console.WriteLine("4 - Elimina rubrica");
Console.WriteLine("5 - Esporta rubrica");
Console.WriteLine("6 - Importa rubrica");
Console.WriteLine("7 - Visualizza contatti\n");
string? sceltaString = Console.ReadLine();
int sceltaInt;
int.TryParse(sceltaString, out sceltaInt);
while (sceltaInt > 7 || sceltaInt < 1)
{
    sceltaString = Console.ReadLine();
    int.TryParse(sceltaString, out sceltaInt);
}
switch (sceltaInt)
{
    case 1:
        Rubrica.AggiungiContatto();
        break;
    case 2:
        Rubrica.ModificaContatto();
        break;
    case 3:
        Rubrica.EliminaContatto();
        break;
    case 4:
        Rubrica.EliminaRubrica();
        break;
    case 5:
        Rubrica.EsportaRubrica();
        break;
    case 6:
        Rubrica.ImportaRubrica();
        break;
    case 7:
        Rubrica.VisualizzaContatti();
        break;
}






