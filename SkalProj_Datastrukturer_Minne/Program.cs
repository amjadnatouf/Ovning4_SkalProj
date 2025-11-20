using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application\n");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    Console.Write("Välj en åtgärd: ");
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> testList = new List<string>();
            string? userInput;

            Console.WriteLine("\n---- Listmeny  ----");
            Console.WriteLine("+[string] : Lägg till sträng i listant.");
            Console.WriteLine("-[string] : Ta bort sträng från listan.");
            Console.WriteLine("0         : Återgå till huvudmenyn.");
            Console.WriteLine();

            do
            {
                Console.WriteLine($"Count: {testList.Count}, Capacity: {testList.Capacity}");
                Console.Write("Välj en åtgärd: ");
                userInput = "";
                char nav = ' ';
                string value = "";
                try
                {
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Du måste ange något!");
                        return;
                    }

                    nav = userInput[0];
                    value = userInput.Length > 1 ? userInput.Substring(1) : "";
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input får inte vara tom {e.Message}!");
                }
                switch (nav)
                {
                    case '+':
                        testList.Add(value);
                        Console.WriteLine($"Lägg till {value} i listan");
                        Console.WriteLine($"Count: {testList.Count}, Capacity: {testList.Capacity}");
                        break;
                    case '-':
                        if (testList.Remove(value))
                        {
                            Console.WriteLine($"Ta bort {value} från listan");
                            Console.WriteLine($"Count: {testList.Count}, Capacity: {testList.Capacity}");
                        }
                        else
                        {
                            Console.WriteLine($"{value} hittades inte i listan");
                        }
                        break;
                    case '0':
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                            + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)");
                        break;
                }
                Console.WriteLine();
            }
            while (userInput[0] != '0');

            /*
             * Svar på frågorna - Ovning 1:
             * 
             * 2. När ökar listans kapacitet?
             * kapaciteten ökar när vi försöker lägga till elementer i listan och Counter == Capacity
             * 
             * 3. Med hur mycket ökar kapaciteten?
             * Kapaciteten när listan skapas är 0. När man lägger till det första elementet ökarkapaciteten
             * med 4 som standard i C#. Därefter fördubblas kapaciteten varje gång listan behöver växa.
             * 0 -> 4 -> 8 -> 16 -> 32 ...
             * 
             * 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
             * Listans kapacitet ökar exponentiellt av prestandaskäl: att kopiera arrayen för varje nytt 
             * element vore dyrt, medan exponentiell ökning balanserar minnesanvändning och effektivitet.
             * 
             * 5. Minskar kapaciteten när element tas bort ur listan?
             * Nej, kapaciteten minskar inte automatiskt när element tas bort ur listan endast Count förändras.
             * men kapaciteten förblir samma. 
             * 
             * 6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             * Använd en array när storleken är känd och konstant, och när maximal prestanda med minimal 
             * overhead behövs. Använd istället en lista när storleken är okänd eller dynamisk, och när du ofta 
             * behöver lägga till eller ta bort element.
             */
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> testQueue = new Queue<string>();
            string? userInput;

            Console.WriteLine("\n---- Queuemeny  ----");
            Console.WriteLine("+[string] : Enqueue sträng i queue.");
            Console.WriteLine("-[string] : Dequeue första sträng från queue.");
            Console.WriteLine("0         : Återgå till huvudmenyn.");
            Console.WriteLine();

            do
            {
                // Check the queue
                Console.WriteLine(string.Join(", ", testQueue.Select(x => x.ToString())));
                Console.Write("Välj en åtgärd: ");
                userInput = "";
                char nav = ' ';
                string value = "";
                try
                {
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Du måste ange något!");
                        return;
                    }

                    nav = userInput[0];
                    value = userInput.Length > 1 ? userInput.Substring(1) : "";
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input får inte vara tom {e.Message}!");
                }
                switch (nav)
                {
                    case '+':
                        testQueue.Enqueue(value);
                        Console.WriteLine($"{value} gick med i queue");
                        Console.WriteLine($"Queue count: {testQueue.Count}");
                        break;
                    case '-':
                        if (testQueue.Count > 0)
                        {
                            string served = testQueue.Dequeue();
                            Console.WriteLine($"{value} expedierad och lämnade queue");
                            Console.WriteLine($"Queue count: {testQueue.Count}");
                        }
                        else
                        {
                            Console.WriteLine("Queue är tom!");
                        }
                        break;
                    case '0':
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                            + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)");
                        break;
                }
                Console.WriteLine();
            }
            while (userInput[0] != '0');

            /*
            * Svar på frågorna - Ovning 2:
            * 
            * 1. Simulera följande kö på papper:
            * a. ICA öppnar och kön till kassan är       -> []
            * b. Kalle ställer sig i                     -> [Kalle]
            * c. Greta ställer sig i                     -> [Kalle, Greta]
            * d. Kalle blir expedierad och lämnar        -> [Greta]
            * e. Stina ställer sig i                     -> [Greta, Stina]
            * f. Greta blir expedierad och lämnar        -> [Stina]
            * g. Olle ställer sig i                      -> [Stina, Olle]
            * h.      … Queue-klassen fungerar enligt Först In Först (FIFO) principen
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> testStack = new Stack<string>();
            string? userInput;

            Console.WriteLine("\n---- Stackmeny  ----");
            Console.WriteLine("+[string] : Lägg till sträng i stacken.");
            Console.WriteLine("-[string] : Ta bort sträng från stacken.");
            Console.WriteLine("r         : Omvänd text");
            Console.WriteLine("0         : Återgå till huvudmenyn.");
            Console.WriteLine();

            do
            {
                // Check the stack
                Console.WriteLine(string.Join(", ", testStack.Select(x => x.ToString())));
                Console.Write("Välj en åtgärd: ");
                userInput = "";
                char nav = ' ';
                string value = "";
                try
                {
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Du måste ange något!");
                        return;
                    }

                    nav = userInput.ToUpper()[0];
                    value = userInput.Substring(1);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input får inte vara tom {e.Message}!");
                }
                switch (nav)
                {
                    case '+':
                        testStack.Push(value);
                        Console.WriteLine($"{value} trycktes på stacken");
                        Console.WriteLine($"Stack count: {testStack.Count}");
                        break;
                    case '-':
                        if (testStack.Count > 0)
                        {
                            string removed = testStack.Pop();
                            Console.WriteLine($"{removed} togs bort från stacken");
                            Console.WriteLine($"Stack count: {testStack.Count}");
                        }
                        else
                        {
                            Console.WriteLine("Stacken är tom!");
                        }
                        break;
                    case 'R':
                        ReverseText();
                        break;
                    case '0':
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                            + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)");
                        break;
                }
                Console.WriteLine();
            }
            while (userInput.ToUpper()[0] != '0');
            /*
            * Svar på frågorna - Ovning 3:
            * 
            * 1. Simulera följande kö på papper:
            * a. ICA öppnar och kön till kassan är       -> []
            * b. Kalle ställer sig i                     -> [Kalle]
            * c. Greta ställer sig i                     -> [Kalle, Greta]
            * d. Kalle blir expedierad och lämnar        -> [Kalle]
            * e. Stina ställer sig i                     -> [Kalle, Stina]
            * f. Greta blir expedierad och lämnar        -> [Kalle]
            * g. Olle ställer sig i                      -> [Kalle, Olle]
            * h.      … Stack-klassen fungerar enligt Först In Sist ut (FILO) principen
            * vilket betyder att det sista elementet som läggs till tas bort först. Därför
            * fungerar stacken inte för att simulera en kö som i exemplet med ICA.
            * Förklaring med exemplet:
            * I kön: [Kalle, Greta] står Kalle först. När Kalle ska expedieras tas han bort först,
            * vilket fungerar korrekt med en kö (FIFO).
            * Om vi istället använde en stack, skulle det senaste tillsatta elementet (Greta) tas bort först,
            * vilket bryter ordningen. Felet uppstår alltså redan vid första expedieringen och fortsätter för
            * varje person som ska expedieras, eftersom stacken alltid tar bort det översta elementet,
            * inte den som stått längst i kön. 
            */
        }

        /// <summary>
        /// Reversed a text string method using stack
        /// </summary>
        static void ReverseText()
        {
            Console.WriteLine("---- Omvänd text ----");
            Console.WriteLine("Ange texten som ska vändas: ");

            string? userString = Console.ReadLine();

            if (string.IsNullOrEmpty(userString) || string.IsNullOrWhiteSpace(userString))
            {
                Console.WriteLine("Ingen text hittades!");
                return;
            }

            Stack<char> sc = new Stack<char>();

            foreach (var c in userString)
            {
                sc.Push(c);
            }

            string reversedString = "";
            while (sc.Count > 0)
            {
                reversedString += sc.Pop();
            }

            Console.WriteLine($"Originalsträngen är: {userString}");
            Console.WriteLine($"Den omvända strängen är: {reversedString}");
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("\n---- Kontrollera parentesmeny  ----");
            Console.WriteLine("1. Kontrollera om en sträng har korrekt formaterade parenteser.");
            Console.WriteLine("2. Giltiga parenteser: (), {}, []");
            Console.WriteLine();
            Console.Write("Ange en sträng för att kontrollera: ");

            string userInput = "";
            try
            {
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Du måste ange något!");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input får inte vara tom!");
            }

            bool isWellFormed = hasCorrectParanthesis(userInput);
            Console.WriteLine($"Result: {(isWellFormed ? "Well formed" : "Not well formed")}");
            Console.WriteLine();

            /*
            * Svar på frågorna - Ovning 4:
            * 
            * 1. Vilken datastruktur använder du
            * Stack användes för att implementera CheckParanthesis-metoden eftersom den använder FILO, vilket
            * passar perfekt när vi kollar efter öppnings- och stängningsparenteser
            */
        }

        /// <summary>
        /// Check if paranthesis in a string are well formed or not
        /// </summary>
        /// <param name="userInput">Sting to check</param>
        /// <returns>True if well formed, false if not</returns>
        static bool hasCorrectParanthesis(string str)
        {
            Stack<char> bs = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };
            foreach (char c in str)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    bs.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (bs.Count == 0)
                        return false;

                    char top = bs.Pop();

                    if (top != bracketPairs[c])
                        return false;
                }
            }
            return bs.Count == 0;
        }
    }
}

