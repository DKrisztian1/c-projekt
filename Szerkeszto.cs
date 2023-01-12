namespace Projekt
{
    class Szerkeszto
    {
        private static bool futasVege = false;
        private static byte x, y, nyelv;
        private static char[,] matrix;
        private static Dictionary<string, string[]> szoveg = new()
        {
            { "BekérHossz", new string[] {"Adja meg a pálya hosszát: ", "Enter the length of the track: " } },
            { "BekérMagasság", new string[] {"Adja meg a pálya magasságát: ", "Enter the height of the track: " } },
            { "BekérKoordX", new string[]{ "Adja meg az x koordinátát: ", "Enter the x coordinate: " } },
            { "BekérKoordY", new string[]{ "Adja meg az y koordinátát: ", "Enter the y coordinate: " } },
            { "Kilépés", new string[]{ "Kilépés", "Exit" } },
            { "BekérElérésiÚt", new string[]{ "Adja meg a pálya elérési útját: ", "Enter the path to the track: " } },
            { "Módosítás", new string[]{ "Meglévő pálya módosítása: ", "Modifying an existing track: " } },
            { "Generálás", new string[]{ "Új pálya generálása: ", "Generate a new track: " } },
            { "Mentés", new string[]{ "Pálya mentése: ", "Save the track: " } },
        };
        static void Main()
        {
            string nyelvBeallitas;
            do
            {
                Console.Write("Milyen nyelvű legyen a program? / Which language should the programme be in? (magyar/angol): ");
                nyelvBeallitas = Console.ReadLine();
                Console.Clear();
            }while (!(nyelvBeallitas == "angol" || nyelvBeallitas == "magyar"));
            if(nyelvBeallitas == "magyar")
                nyelv = 0;
            else
                nyelv = 1;

            Menu:
            switch (ValasztMenubol(1))
            {
                case 'm':
                    Console.Write(szoveg["BekérElérésiÚt"][nyelv]);
                    matrix = BetoltTerkepet(Console.ReadLine());
                    break;
                case 'g':
                    matrix = GeneralTerkep();
                    Console.Clear();
                    break;
                case 'k':
                    return;
            }
            while (!futasVege)
            {
                switch (ValasztMenubol(2))
                {
                    case '0':
                        Berak(0);
                        break;
                    case '1':
                        Berak(1);
                        break;
                    case '2':
                        Berak(2);
                        break;
                    case '3':
                        Berak(3);
                        break;
                    case '4':
                        Berak(4);
                        break;
                    case '5':
                        Berak(5);
                        break;
                    case '6':
                        Berak(6);
                        break;
                    case '7':
                        Berak(7);
                        break;
                    case '8':
                        Berak(8);
                        break;
                    case '9':
                        Berak(9);
                        break;
                    case 'ö':
                        Berak(10);
                        break;
                    case 'ü':
                        Berak(11);
                        break;
                    case 'ó':
                        Berak(12);
                        break;
                    case 'm':
                        Console.Write(szoveg["BekérElérésiÚt"][nyelv]);
                        MentTerkepet(Console.ReadLine());
                        goto Menu;
                    case 'k':
                        goto Menu;
                }
            }
        }

        static void MegjelenitPalya()
        {
            for(byte sor = 0; sor < matrix.GetLength(0); sor++)
            {
                for (byte oszlop = 0; oszlop < matrix.GetLength(1); oszlop++)
                    Console.Write(matrix[sor, oszlop]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static char ValasztMenubol(byte i)
        {
            char valasz;
            do
            {
                if(i==1)
                {
                    Console.Clear();
                    Console.WriteLine($"[m] ==> {szoveg["Módosítás"][nyelv]}");
                    Console.WriteLine($"[g] ==> {szoveg["Generálás"][nyelv]}");
                    Console.WriteLine($"[k] ==> {szoveg["Kilépés"][nyelv]}");
                    valasz = Console.ReadKey(true).KeyChar;
                    if (valasz == 'm' || valasz == 'g' || valasz == 'k')
                        break;
                }
                else
                {
                    Console.Clear();
                    MegjelenitPalya();
                    Console.WriteLine("[0] ==> ╬");
                    Console.WriteLine("[1] ==> ═");
                    Console.WriteLine("[2] ==> ╦");
                    Console.WriteLine("[3] ==> ╩");
                    Console.WriteLine("[4] ==> ║");
                    Console.WriteLine("[5] ==> ╣");
                    Console.WriteLine("[6] ==> ╠");
                    Console.WriteLine("[7] ==> ╗");
                    Console.WriteLine("[8] ==> ╝");
                    Console.WriteLine("[9] ==> ╚");
                    Console.WriteLine("[ö] ==> ╔");
                    Console.WriteLine("[ü] ==> █");
                    Console.WriteLine("[ó] ==> .");
                    Console.WriteLine($"[m] ==> {szoveg["Mentés"][nyelv]}");
                    Console.WriteLine($"[k] ==> {szoveg["Kilépés"][nyelv]}");
                    valasz = Console.ReadKey(true).KeyChar;
                    if (valasz == '0' || valasz == '1' || valasz == '2' || valasz == '3' || valasz == '4' || valasz == '5' || valasz == '6' || valasz == '7' || valasz == '8' || valasz == '9' || valasz == 'ö' || valasz == 'ü' || valasz == 'ó' || valasz == 'm' || valasz == 'k')
                        break;
                }
            } while (true);
            Console.WriteLine();
            return valasz;
        }

        static char[,] BetoltTerkepet(string palyaNeve)
        {
            string[] sorok = File.ReadAllLines(palyaNeve);
            char[,] palya = new char[sorok.Length, sorok[0].Length];
            for (int sorIndex = 0; sorIndex < palya.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < palya.GetLength(1); oszlopIndexe++)
                {
                    palya[sorIndex, oszlopIndexe] = sorok[sorIndex][oszlopIndexe];
                }
            }
            return palya;
        }

        static void MentTerkepet(string palyaNeve)
        {
            string[] sorok = new string[matrix.GetLength(0)];
            for (byte sor = 0; sor < sorok.Length; sor++)
                for (byte oszlop = 0; oszlop < sorok.Length; oszlop++)
                    sorok[sor] += matrix[sor, oszlop];
            File.WriteAllLines(palyaNeve, sorok);
        }

        static char[,] GeneralTerkep()
        {
            Console.Write(szoveg["BekérHossz"][nyelv]);
            byte hossz = Convert.ToByte(Console.ReadLine());
            Console.Write(szoveg["BekérMagasság"][nyelv]);
            byte magassag = Convert.ToByte(Console.ReadLine());

            matrix = new char[hossz, magassag];

            for (byte sor = 0; sor < hossz; sor++)
                for (byte oszlop = 0; oszlop < magassag; oszlop++)
                    matrix[sor, oszlop] = '.';
            
            return matrix;
        }

        static void Berak(byte index)
        {
            Console.Clear();
            MegjelenitPalya();

            Console.Write(szoveg["BekérKoordX"][nyelv]);
            x = Convert.ToByte(Console.ReadLine());
            Console.Write(szoveg["BekérKoordY"][nyelv]);
            y = Convert.ToByte(Console.ReadLine());
            
            matrix[x, y] = "╬═╦╩║╣╠╗╝╚╔█."[index];
        }
    }
}