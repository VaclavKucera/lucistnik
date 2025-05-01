class Program
{
    static void Main(string[] args)
    {
        Lucistnik lucistnik = new Lucistnik("Albrecht", 10);
        lucistnik.ZobrazStav();
        lucistnik.Vystrel();
        lucistnik.ZobrazStav();
        lucistnik.PridejSipy(5);
        lucistnik.ZobrazStav();

        while (true)
        {
            Console.WriteLine("Chceš: \n 1. Vystřelit šíp \n 2. Přidat šíp \n 3. Ukončit");
            
            string vstup = Console.ReadLine();

            bool jeCislo = int.TryParse(vstup, out int volba);
            if (!jeCislo)
            {
                Console.WriteLine("Zadej číslo 1, 2, 3.");
                continue;
            }

            switch (volba)
            {
                case 1:
                    lucistnik.Vystrel();
                    break;
                case 2:
                    int pocet = NactiCeleCisloZKonzole("Kolik šípů přidáváš?");
                    lucistnik.PridejSipy(pocet);
                    break;
                case 3:
                    Console.WriteLine("Ukončuji program.");
                    return;
                default:
                    Console.WriteLine("Zkuste znovu.");
                    break;
            }
        }
    }

    public static int NactiCeleCisloZKonzole(string vyzva)
    {
        Console.WriteLine(vyzva);
        string vstup = Console.ReadLine();
        bool jeCislo = int.TryParse(vstup, out int vysledek);
        if (jeCislo)
        {
            return vysledek;
        }
        else
        {
            Console.WriteLine("Zadejte platné číslo.");
            return NactiCeleCisloZKonzole(vyzva); 
    }
}
public class Lucistnik
{
    string jmeno;
    int pocetSipu;

    public Lucistnik(string jmeno, int pocetSipu)
    {
        this.jmeno = jmeno;
        this.pocetSipu = pocetSipu;
    }

    public void Vystrel()
    {
        if (pocetSipu > 0)
        {
            Console.WriteLine($"{jmeno} úspěšně vystřelil.");
            pocetSipu--;
        }
        else
        {
            Console.WriteLine($"{jmeno} už nemá žádné další šípy.");
        }
    }

    public void PridejSipy(int pocet)
    {
        pocetSipu += pocet;
        Console.WriteLine($"{jmeno} přidal {pocet} šípů.");
    }

    public void ZobrazStav()
    {
        Console.WriteLine($"{jmeno} má {pocetSipu} šípů.");
    }
}}
