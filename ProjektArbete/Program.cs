using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbete
{
    class Program
    {
        static Företag[] FöretagArr = new Företag[0]; // vektorn som vi kommer spara alla våra företag till
        static void Main(string[] args)
        {
            HämtaRegisteradeFöretag(); // hämtar alla förtagen som finns registerade från förra gågnen som programmet kördes
                                      // streamreader/writer  ser till att det som användaren angav sparas och skrivs med i registret
            bool HuvudLoop = true;
            while (HuvudLoop) 
            {
                int i = Meny();
                switch (i) // switch case for huvudmeny vart de valen som använderen kan välja ges
                {
                    case 1:
                        RegisteraFöretag();
                        break;
                    case 2:
                        HämtaAllaFöretag();
                        break;
                    case 3:
                        TaBortFöretag();
                        break;
                    case 4:
                        MenyFörSökning();
                        break;
                    case 5:
                        HuvudLoop = false;
                        break;
                    default: // fel sökning om anävnadren aner feläktigt input
                        Console.WriteLine("Opps!! Du måste ange ett av de valen som står överst, var vänlig och försök igen!");
                        break;

                   
                }
                
            }
            //Sorterar innan man skriver till fil
            SorteraArray();
            //Skriver till fil och sparar
            SparaFöretagTillFil();
        }
        //---------------------------------------------------------------------HUVUDMENY--------------------------------------------------------------
        static int Meny()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Vällkommen till Företagskund Register");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nTryck [1] för att Lägg till ett nytt företag");
            Console.WriteLine("Tryck [2]för att visa register på alla företag");
            Console.WriteLine("Tryck [3] för att ta bort ett företag");
            Console.WriteLine("Tryck [4] för att soretera företagen");
            Console.WriteLine("Tryck [5] för att avsluta program\n");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            int val = 0;
            try
            {
                val = int.Parse(Console.ReadLine());

            }
            catch (Exception ex) // fel sökning 
            {
                Console.WriteLine("Fel uppstod vid valet: " + ex.Message); // Message visar exakt de fel som anänvadren gjorde
            }
            return val;
        }
        //----------------------------------------------------------------LÄGGA TILL FÖRETAG TILL VEKTORN---------------------------------------------------------
        static void AddToArr(Företag längd)
        {
            Företag[] temp = new Företag[FöretagArr.Length + 1]; // vi initiera en ny instans av Företag (Klassen företag) som har Företag klassens variabler
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                temp[i] = FöretagArr[i];
            }
            temp[FöretagArr.Length] = längd;
            FöretagArr = temp;
        }
        //------------------------------------------------------------LÄSER FÖRETAG IFRÅN FIL-------------------------------------------------
        private static void FöretagFrånFil()
        {
            try
            {
                StreamReader fil = new StreamReader("Företag.txt");  // vi initiera en ny instans av StreamReader(klassen, inbyggd) som heter fil
                string läst;
                while ((läst = fil.ReadLine()) != null)
                {
                    string[] info = läst.Split('|');

                    Företag företag = new Företag();  // vi initiera en ny instans av Företag (Klassen företag) som har Företag klassens variabler

                    företag.Namn = info[0];
                    företag.Adress = info[1];
                    if (info.Length == 3)
                        företag.Sektor = info[2];

                    AddToArr(företag);
                }
                fil.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel uppstod! Låten finns inte i fil. " + ex.Message);
            }
        }

        //-----------------------------------------------------HÄMTAR DE REGISTERADE FÖRETAGEN-----------------------------------------------
        public static void HämtaRegisteradeFöretag()
        {
            if (File.Exists("Företag.txt")) // File.Exist om de sant att Företag.txt finns så går den vidare till metoden FöretagFile();
            {
                FöretagFrånFil();
            }
            else
            {
                File.Create("Företag.txt").Close();  /// File.Create skapar en txt fil i debug som används för stream reader och writer
            }
        }
        //----------------------------------------------------------SPARAR FÖRETAG TILL EN TEXTFIL----------------------------------------------
        public static void SparaFöretagTillFil()
        {
            StreamWriter fil = new StreamWriter("Företag.txt"); // vi initiera en ny instans av StreamWriter(klassen, inbyggd) som heter fil
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                Företag SparaFöretag = FöretagArr[i];
                fil.WriteLine("{0}|{1}|{2}", SparaFöretag.Namn, SparaFöretag.Adress, SparaFöretag.Sektor);
            }
            fil.Close();
        }
        //---------------------------------------------------------VISAR REGISTER PÅ ALLA FÖRETAG--------------------------------------------
        public static void HämtaAllaFöretag()
        {
            Console.WriteLine(" Namn:  |  Adress:  |  Sektor:  ");
            for (int i = 0; i < FöretagArr.Length; i++) // går igenom varje element i vektorn
            {
                Console.WriteLine(" {1}  |  {2}  |  {3}", i + 1, FöretagArr[i].Namn, FöretagArr[i].Adress, FöretagArr[i].Sektor);
            }
            Console.WriteLine();
        }
        //--------------------------------------------------------REGISTERING AV FÖRETAG--------------------------------------------------------
        public static void RegisteraFöretag()
        {
            Företag företag = new Företag(); // vi initerar en ny instans av klassen företag som heter företag
            bool FöretagFinnsEj = true;
            Console.WriteLine("Ange namn på företaget: ");
            företag.Namn = Console.ReadLine();

            Console.WriteLine("Ange adress på företaget: ");
            företag.Adress = Console.ReadLine();

            Console.WriteLine("Ange vilken sektor som företag arbetar inom:  \n1.Industri/Bygg \n2.It/Teknik \n3.Hälsa/Sjukvård \n4.Energi \n5.Fasigheter \n6.Ekonomi/Finans \n7.Övrigt");
            string val = Console.ReadLine();
            int valSökning = 0;
            bool loop = int.TryParse(val, out valSökning);
            if (loop == true)
            {
                switch (valSökning) // vi använder osss av ett switch case här för att ge användaren ett val av Sektorer som man kan registera företag till
                {
                    case 1:
                        företag.Sektor = "Industri/Bygg";
                        break;

                    case 2:
                        företag.Sektor = "It/Teknik";
                        break;
                    case 3:
                        företag.Sektor = " Hälsa/Sjukvård";
                        break;

                    case 4:
                        företag.Sektor = "Energi";
                        break;

                    case 5:
                        företag.Sektor = "Fasigheter";
                        break;

                    case 6:
                        företag.Sektor = "Ekonomi/Finans";
                        break;

                    case 7:
                        företag.Sektor = "Övrigt";
                        break;

                    default: // fel sökning 
                        Console.WriteLine("Opps!! Du måste ange ett av de valen som står överst, var vänlig och försök igen!");
                        break;
                }
                return; // fel sökning ser till att användren anger fel val att företaget inte registeras
                
            }
            // här kollar vi så att om de företaget som vi försöker registera redan finns i vektorn så kommer den inte läggas till i vektorn
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                if (företag.Namn == FöretagArr[i].Namn)
                {
                    FöretagFinnsEj = false;
                }
            }
            if (FöretagFinnsEj == true)
            {
                Console.WriteLine("\n Nu har " + företag.Namn + " blivit registerad!");
                AddToArr(företag);
                Console.WriteLine();
            }
        }

        //----------------------------------------------------------------------ANVÄNDARE MNEY FÖR SÖKNING------------------------------------------------------------
        public static void MenyFörSökning()
        {
            Console.WriteLine("Ange hur du vill sortera, \n1. Bokstavs Ordning \n2. Sektor: ");
            string val = Console.ReadLine();
            int valSökning;
            bool siffra = int.TryParse(val, out valSökning); // vi vill använda bool. try.Parse ändrar string till int 
            if (siffra == true)
            {
                switch (valSökning)
                {
                    case 1:
                        SorteraArrayEfterBokstav();
                        break;

                    case 2:
                        SökEfterSektor();
                        break;

                    default: //fel sökning
                        Console.WriteLine("Opps!! Du måste ange ett av de valen som står överst, var vänlig och försök igen!");
                        break;
                }
                return; 
            }
            
        }

        //----------------------------------------------------------------------SORTERAR EFTER SEKTOR------------------------------------------------------------
        public static void SökEfterSektor()
        {
            Console.WriteLine("Ange den sektorn som du vill söka efter:");
            string allSektor = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                if (allSektor.CompareTo(FöretagArr[i].Sektor) == 0)
                {
                    count++; // ränkar +1 varje gång som allsektor ComprareTo Vektorn hittar
                }
            }
            Console.WriteLine("Det finns " + count + " registerade företag inom sektorn " + allSektor);
        }


        //----------------------------------------------------------------------SORTERAR EFTER BOKSTAVSORDNING------------------------------------------------------------
        public static void SorteraArrayEfterBokstav()
        {
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                for (int j = 0; j < FöretagArr.Length - 1; j++)
                {
                    if (FöretagArr[j].Namn.ToLower().CompareTo(FöretagArr[j + 1].Namn.ToLower()) == 1) // gemför namn i vektorn med namn i vektorn 1+ plats till höger
                    {
                        //byter platsen på tal( detta fall namn) tills de är sorterade i rätt ordning
                        Företag temp = FöretagArr[j];
                        FöretagArr[j] = FöretagArr[j + 1];
                        FöretagArr[j + 1] = temp;
                    }
                   
                }
               
            }
            Console.WriteLine("Nu så har alla företag blivit sorterade i Bokstavs Ordning ");
        }



        //----------------------------------------------------------------------SORTERAR EFTER ARRAY------------------------------------------------------------


        //Denna sorteringsmetod visar alla registrerade låtar i bokstavsorning med hjälp av "Swap" och "Exchange Sort" 
         //metoden som sker efter att användaren har registrerat ett företag. 
        //Exchange sort algoritmen är smidigare gentemot Bubble Sort algoritmen då exchange har en skillnad. 
        //Exchange jämför det första elementet med varje element i arrayen som byter där det är nödvändigt. 
        //Denna kod är alltså kopplad till registereringsmetoden som automatiskt uppdateras efter att företaget är sparad.

        public static void SorteraArray()
        {
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                int minst = i;
                for (int j = i + 1; j < FöretagArr.Length; j++)
                {
                    if (0 < FöretagArr[minst].Namn.CompareTo(FöretagArr[j].Namn))
                    {
                        minst = j;
                    }
                }
                if (i < minst)
                {
                    Swap(minst, i);
                }
            }
        }
        public static void Swap(int minst, int i)
        {
            Företag temp = FöretagArr[i];
            FöretagArr[i] = FöretagArr[minst];
            FöretagArr[minst] = temp;
        }
        //---------------------------------------------------------TA BORT ETT FÖRETAG------------------------------------------------------------
        public static void TaBortFöretag()
        {
            HämtaAllaFöretag(); // hämtat de företagen som redan är registerade så att anävnadren kan se och sen välja ifrån listan

            Företag[] temp = new Företag[FöretagArr.Length - 1]; // vi initiera en ny instans av Företag (Klassen företag) vektron längd - 1 för vi vill ta bort ett element
            int grund = 0;
            Console.WriteLine("Ange namn på det företag som du vill ta bort:");
            string TaBortFöretag = Console.ReadLine();
            for (int i = 0; i < FöretagArr.Length; i++)
            {
                if (TaBortFöretag == FöretagArr[i].Namn)
                {
                    for (int j = 0; j < FöretagArr.Length; j++)
                    {
                        if (FöretagArr[j].Namn != TaBortFöretag) // om namnet inte finns i vektor
                        {
                            temp[grund] = FöretagArr[j]; //längd på vektorn ändras ej
                            grund++;
                        }
                    }
                    FöretagArr = temp; 
                    Console.WriteLine("\n{0} har blivit borttagen från Registret!", TaBortFöretag);
                    break;
                }
            }
        }
      
    }

}
