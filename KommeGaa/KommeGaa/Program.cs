using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace KommeGaa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, string> /* Et liste system som indeholder alle brugerne. Lidt ligesom arrays, dog lettere at have med at gøre.
                                                          Man kan oprette så mange brugere som man har lyst til. Dog husk at opret dem med små bogstaver. /**/
            {
                { "admin", "1234" },
                { "rene", "12345" },
                { "daniel", "4321" },
                { "danielr", "123456" },
                { "kasper", "qwer" },
                { "jesper", "pass4" }
            };

            // Herfra
            Random random = new Random();
            bool gætteLoop;
            bool programGætteLoop;
            bool loop;
            int antalForsøg = 0;
            char jaNej;
            string userInputString;
            // Til her er GætteLeg orienteret. Menupunkt [2].


            string stringUser = "";
            bool loginLoop = false;
            bool programLoop = false;


            //Method.Center er en metode i Class1 som centrerer tekst som man skriver ind i den. Det er derfor at teksten står i midten øverst.
            Method.Center("HYDAC KommeGåSystem");
            Console.WriteLine("");

            while (!loginLoop == true) //While loopet er lavet så brugeren kan indtaste oplysninger igen hvis det blev indtastet forkert.
            {

                Console.WriteLine("Indtast Brugernavn: ");
                stringUser = Console.ReadLine();
                Console.WriteLine("Indtast Password: ");
                string stringPass = Console.ReadLine();


                /* Hvis TryGetValue finder en værdi (adgangskoden) for det givne brugernavn, 
                   gemmes denne værdi i variablen password. out betyder, at password vil blive 
                   initialiseret med værdien fra listen med users, hvis brugernavnet findes. /**/
                if (users.TryGetValue(stringUser.ToLower(), out string password) && stringPass.ToLower() == password)
                {

                    // det er loginLoop = true; der gør at den ikke looper mere.
                    loginLoop = true;
                    Console.Clear();
                    Method.Center("HYDAC KommeGåSystem");
                    Method.Center("Login Vellykket!");

                }

                else // Her looper den tilbage til while() hvis koderne ikke stemmer overens.

                {

                    Console.Clear();
                    Method.Center("HYDAC KommeGåSystem");
                    Method.Center("Forkert brugernavn eller password. Prøv igen");

                }

            }

            while (programLoop != true) //Opretter endnu et while loop så vi kan gå tilbage hertil hvis der bliver givet et bogstav eller forkert tal.
            {
                gætteLoop = true;
                programGætteLoop = true;
                loop = true;

                // En lille menu. Plads til forbedringer.
                Console.WriteLine("Hvad vil du?");
                Console.WriteLine("[1] Registrere gæst");
                Console.WriteLine("[2] Spille Gætteleg");
                Console.WriteLine("[3] Luk program ned");

                string inputKeyUser = Console.ReadKey().KeyChar.ToString(); //Den her linje bruger ReadKey som er det samme som ReadLine. Ved Readkey behøves man bare ikke trykke ENTER.

                Console.Clear(); //sletter al tekst på skærmen.

                Method.Center("HYDAC KommeGåSystem"); //Printer Hydac KommeGåSystem ud øverst centreret igen da det bliver slettet lige overfor.


                try // Try catch som hjælper på hvis der bliver tastet et bogstav istedet for tal.

                {

                    if (int.Parse(inputKeyUser) == 1) //If else der fortæller hvad den skal gøre hvis der bliver tastet 1 eller 2.

                    {

                        Method.Center("Registrering af gæst valgt."); //Printer teksten til midten af konsollen.

                        Console.WriteLine("Indtast fulde navn på gæst: ");
                        string guestName = Console.ReadLine();

                        Console.WriteLine("Indtast firma navn gæst besøger fra: ");
                        string guestCompany = Console.ReadLine();

                        /* 
                        Evt. her kan vi lave noget med en sikkerhedsfolder??
                        /**/

                        string dateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"); // Henter klokken og datoen fra computeren og gemmer det i en string.


                        // Kombinerer tiden, firmaet og navnet på gæsten i én string der hedder guestInfo. De små \n er for at lave en ny linje i en txt fil.
                        string guestInfo = "Navn på gæst: " + guestName + "\n" +
                                           "Firma: " + guestCompany + "\n" +
                                           "Registreringstidspunkt: " + dateTime + "\n" +
                                           "Registreringen er lavet af følgende ansvarshavende: " + stringUser + "\n\n";


                        File.AppendAllText("GæsteInformation.txt", guestInfo); /* Gemmer gæsteinfoen i en Txt fil i \KommeGaa\KommeGaa\bin\Debug\net8.0.
                                                                                  Hvis i kan få det til at gemme i main mappen istedet så man ikke skal ind i så mange undermapper, så
                                                                                  prøv jer endelig an med det. /**/

                        Console.WriteLine("Registreringen er blevet gemt med dato og klokkeslæt! Tryk en tast for at gå til Menu.");
                        Console.ReadKey(); // Ligesom ReadLine, bare uden man skal trykke ENTER.
                        Console.Clear();
                        Method.Center("HYDAC KommeGåSystem");
                        //break; skal være her hvis i vil have koden til at fortsætte nederst i programmet efter registreringen.

                    }

                    else if (int.Parse(inputKeyUser) == 2)

                    {

                        Console.Clear();

                        /* !!!OBS ALT HERFRA TIL NÆSTE GRØN TEKST ER GÆTTELEGSKODE!!! Jeg kedede mig og lavede det her program for sig selv i et andet projekt. 
                                                                                      Synes det ville være sjovt hvis jeg kunne tilføje den hertil.        /**/
                        while (programGætteLoop == true)
                        {

                            Method.Center("HYDAC GætteLegsSpil");
                            Method.Center("For at starte, indtast tal 0 - 100 og tryk ENTER");
                            Method.Center("Tryk ESC for at gå tilbage");
                            int tilfældigtTal = random.Next(0, 100);

                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.Escape)

                            {
                                Console.Clear();
                                Method.Center("HYDAC KommeGåSystem");
                                break;

                            }

                            else

                            {
                                Console.Clear();
                                Method.Center("HYDAC GætteLegsSpil");
                                Method.Center("For at starte, indtast tal 0 - 100 og tryk ENTER");

                                while (gætteLoop == true)

                                {

                                    try
                                    {
                                        userInputString = Console.ReadLine();
                                        int userInput = int.Parse(userInputString);

                                        if (userInput < tilfældigtTal)
                                        {
                                            Console.WriteLine("Højere ->");
                                            antalForsøg++;
                                        }
                                        else if (userInput > tilfældigtTal)
                                        {
                                            Console.WriteLine("<- Lavere");
                                            antalForsøg++;
                                        }
                                        else if (userInput == tilfældigtTal)
                                        {
                                            Console.WriteLine($"Du gættede rigtigt! Tallet var {tilfældigtTal}");
                                            antalForsøg++;
                                            break;
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Method.Center("HYDAC GætteLegsSpil");
                                        Console.WriteLine("Du skal skrive et tal, ikke bogstav.");
                                    }
                                }
                            }

                            Console.WriteLine($"Det tog dig {antalForsøg} forsøg at gætte mit tal! Prøv igen? y/n");


                            while (loop == true)
                            {

                                jaNej = Console.ReadKey().KeyChar;

                                if (jaNej == 'y')
                                {
                                    Console.Clear();
                                    antalForsøg = 0;
                                    break;
                                }
                                else if (jaNej == 'n')
                                {
                                    Console.Clear();
                                    programGætteLoop = false;
                                    loop = false;
                                    gætteLoop = false;
                                    Method.WaitTime("Loading");
                                    Console.Clear();
                                    Method.Center("HYDAC KommeGåSystem");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Det forstår jeg ikke. Tryk på y eller n tasten.");
                                    Console.WriteLine();
                                    Console.WriteLine($"'y' = Ja, 'n' = Nej");
                                }
                            }

                        }
                        /* !!!HER SLUTTER GÆTTELEGSKODEN!!! /**/

                    }

                    else if (int.Parse(inputKeyUser) == 3) // lukker programmet ned hvis der bliver trykket på '3'.

                    {
                        Console.Clear();
                        Method.WaitTime("Lukker ned");  // En metode der bare tilføjer 4 gange prikker på stringet samt rydder skærmen for tekst.
                        break;

                    }

                    else // Hvis der bliver tastet et tal der ikke er 1 eller 2.

                    {

                        Method.Center("Det forstår jeg ikke. Prøv igen.");

                    }
                }

                catch (Exception ex) // Hvis der bliver tastet et bogstav istedet for et tal.

                {

                    Method.Center("Det forstår jeg ikke. Prøv igen.");

                }
            }

            /*
             Det er her programmet hopper hen til efter registreringen hvis break; tilføjes på linje 134. 
             Så det er her ny kode skal laves hvis der skal tilføjes noget efterfølgende
            /**/
        }

    }
}
