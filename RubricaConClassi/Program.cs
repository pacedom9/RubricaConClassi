
using static RubricaConClassi.Rubrica;
CaricaRubrica();

while (true)
{

    Console.WriteLine("1 - Aggiungi contatto");
    Console.WriteLine("2 - Modifica contatto");
    Console.WriteLine("3 - Elimina contatto");
    Console.WriteLine("4 - Elimina rubrica");
    Console.WriteLine("5 - Esporta rubrica");
    Console.WriteLine("6 - Importa rubrica");
    Console.WriteLine("7 - Visualizza contatti");
    Console.WriteLine("8 - Esci dalla rubrica");
    string? sceltaString = Console.ReadLine();
    int sceltaInt;
    int.TryParse(sceltaString, out sceltaInt);
    while (sceltaInt > 8 || sceltaInt < 1)
    {
        sceltaString = Console.ReadLine();
        int.TryParse(sceltaString, out sceltaInt);
    }
    switch (sceltaInt)
    {
        case 1:
            AggiungiContatto();
            break;
        case 2:
            ModificaContatto();
            break;
        case 3:
            EliminaContatto();
            break;
        case 4:
            EliminaRubrica();
            break;
        case 5:
            EsportaRubrica();
            break;
        case 6:
            ImportaRubrica();
            break;
        case 7:
            VisualizzaContatti();
            break;
        case 8:
            return;
    }
}



