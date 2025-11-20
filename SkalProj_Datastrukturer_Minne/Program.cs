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
                Console.WriteLine("Choose an option by entering its number (0–9), or press 'q' to exit:"
                    + "\n0. Examine a List"
                    + "\n1. Examine a Queue"
                    + "\n2. Examine a Stack"
                    + "\n3. CheckParenthesis"
                    + "\n4. CheckRecursiveOdd"
                    + "\n5. CheckRecursiveEven"
                    + "\n6. CheckFibonacciRecursive"
                    + "\n7. CheckIterativeOdd"
                    + "\n8. CheckIterativeEven"
                    + "\n9. CheckFibonacciIterative"
                    + "\nq. Exit the application\n");
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
                    case '0':
                        ExamineList();
                        break;
                    case '1':
                        ExamineQueue();
                        break;
                    case '2':
                        ExamineStack();
                        break;
                    case '3':
                        CheckParanthesis();
                        break;
                    case '4':
                        ExamineRecursiveOdd();
                        break;
                    case '5':
                        ExamineRecursiveEven();
                        break;
                    case '6':
                        ExamineFibonacciRecursive();
                        break;
                    case '7':
                        ExamineIterativeOdd();
                        break;
                    case '8':
                        ExamineIterativeEven();
                        break;
                    case '9':
                        ExamineFibonacciIterative();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case 'q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choose an option by entering its number (0-9), or press 'q' to exit:");
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
                userInput = Console.ReadLine()!;
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("\nDu måste ange något input!\n");
                    return;
                }

                char nav = userInput[0];
                string value = userInput.Length > 1 ? userInput.Substring(1) : "";
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
                userInput = Console.ReadLine()!;
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("\nDu måste ange något input!\n");
                    return;
                }

                char nav = userInput[0];
                string value = userInput.Length > 1 ? userInput.Substring(1) : "";
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
                userInput = Console.ReadLine()!;
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("\nDu måste ange något!\n");
                    return;
                }

                char nav = userInput.ToUpper()[0];
                string value = userInput.Length > 1 ? userInput.Substring(1) : "";
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

        /// <summary>
        /// Reads a string from the user and checks whether its parentheses are well-formed
        /// </summary>
        static void CheckParanthesis()
        {
            Console.WriteLine("\n---- Kontrollera parentesmeny  ----");
            Console.WriteLine("1. Kontrollera om en sträng har korrekt formaterade parenteser.");
            Console.WriteLine("2. Giltiga parenteser: (), {}, []");
            Console.WriteLine();
            Console.Write("Ange en sträng för att kontrollera: ");

            string userInput = Console.ReadLine()!;
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("\nDu måste ange något input!\n");
                return;
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

        /// <summary>
        /// Tests RecursiveOdd by reading n from the user and printing the n-th odd number and its sequence
        /// </summary>
        static void ExamineRecursiveOdd()
        {
            Console.WriteLine("\n--- Examine RecursiveOdd ---");
            Console.Write("Ange n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int result = RecursiveOdd(n);
                Console.WriteLine($"\nDet {n}:e udda talet är: {result}");

                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{RecursiveOdd(i)}{(i < n ? ", " : "")}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Recursively calculates the n-th odd number
        /// </summary>
        /// <param name="n">The position (n) of the odd number to compute</param>
        /// <returns>The n-th odd number</returns>
        static int RecursiveOdd(int n)
        {
            // Base case: the first odd number is 1
            if (n == 1)
            {
                return 1;
            }
            // Recursive case: nth odd = (n-1)th odd + 2
            return RecursiveOdd(n - 1) + 2;

            /*
            * Svar på frågorna - Ovning 5:
            * 
            * 1. Illustrera förloppen för RecursiveOdd(5) 
            * - RecursiveOdd(5) bygger upp ett anropsstack:
            * - n = 5 och n != 1; metoden anropar då RecursiveOdd(5 - 1) + 2.
            * - n = 4 och n != 1; metoden anropar då RecursiveOdd(4 - 1) + 2.
            * - detta fortsätter tills n == 1; då returneras värdet 1.
            * - När basfallet har nåtts börjar varje tidigare anrop lägga på +2 och returnera resultatet uppåt i stacken.
            * 
            * Förklaring:
            * 1. RecursiveOdd(5) → RecursiveOdd(4) + 2
            * 2. RecursiveOdd(4) → RecursiveOdd(3) + 2
            * 3. RecursiveOdd(3) → RecursiveOdd(2) + 2
            * 4. RecursiveOdd(2) → RecursiveOdd(1) + 2
            * 5. RecursiveOdd(1) → return 1 (base)
            * 6. Så: 1 → 3 → 5 → 7 → 9
            * 
            * Result: 9
            * Stack depth: 5
            */
        }

        /// <summary>
        /// Tests RecursiveEven by reading n from the user and printing the n-th even number and its sequence
        /// </summary>
        static void ExamineRecursiveEven()
        {
            Console.WriteLine("\n--- Examine RecursiveEven ---");
            Console.Write("Ange n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int result = RecursiveEven(n);
                Console.WriteLine($"\nDet {n}:e jämnt talet är: {result}");


                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{RecursiveEven(i)}{(i < n ? ", " : "")}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Recursively calculates the n-th even number
        /// </summary>
        /// <param name="n">The position (n) of the even number to compute</param>
        /// <returns>The n-th even number</returns>
        static int RecursiveEven(int n)
        {
            // Base case: the first even number is 2
            if (n == 1)
            {
                return 2;
            }
            // Recursive case: nth even = (n-1)th even + 2
            return RecursiveEven(n - 1) + 2;
        }

        /// <summary>
        /// Examines FibonacciRecursive by reading n from the user and printing the n-th Fibonacci number and its sequence
        /// </summary>
        static void ExamineFibonacciRecursive()
        {
            Console.WriteLine("\n--- Examine Fibonacci Recursive ---");
            Console.Write("Ange n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int result = FibonacciRecursive(n);
                Console.WriteLine($"Fibonacci({n}) = {result}");

                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 0; i <= Math.Min(n, 15); i++)
                {
                    Console.Write($"{FibonacciRecursive(i)}{(i < n && i < 15 ? ", " : "")}");
                }
                if (n > 15)
                {
                    // showing first 16 only due to recursion depth
                    Console.Write(" ...");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Recursively calculates the n-th Fibonacci number
        /// </summary>
        /// <param name="n">The position (n) in the Fibonacci sequence</param>
        /// <returns>The n-th Fibonacci number</returns>
        static int FibonacciRecursive(int n)
        {
            // Base cases
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            // Recursive case: f(n) = f(n-1) + f(n-2)
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }


        /// <summary>
        /// Examine IterativeOdd by reading n from the user and printing the n-th odd number and its sequence
        /// </summary>
        static void ExamineIterativeOdd()
        {
            Console.WriteLine("\n--- Examine IterativeOdd ---");
            Console.Write("Ange n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int result = IterativeOdd(n);
                Console.WriteLine($"\nDet {n}:e udda talet är: {result}");

                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{IterativeOdd(i)}{(i < n ? ", " : "")}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Iteratively calculates the n-th odd number
        /// </summary>
        /// <param name="n">The position (n) of the odd number to compute</param>
        /// <returns>The n-th odd number</returns>
        static int IterativeOdd(int n)
        {
            int result = 1;

            // Start from 1 and add 2 for each step until we reach n
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
            /*
            * Svar på frågorna - Ovning 6:
            * 
            * 1. Illustrera förloppen för IterativeOdd(5) 
            * - IterativeOdd(5) börjar med: result = 1.
            * - i startar på 0 och loopen kör tills i = n - 1.
            * - Vid varje iteration adderas 2 till det tidigare resultatet och det nya värdet lagras i variabeln result.
            * - När iterationen avslutas returneras det slutliga värdet av result.
            * 
            * Förklaring:
            * Loop iteration 1 (i=0): result = 1 + 2 = 3
            * Loop iteration 2 (i=1): result = 3 + 2 = 5
            * Loop iteration 3 (i=2): result = 5 + 2 = 7
            * Loop iteration 4 (i=3): result = 7 + 2 = 9
            * 
            * Loop slutar (i=4, villkor i < 4 är falskt)
            * Return: 9
            * 
            * Resultat: 9
            */
        }

        /// <summary>
        /// Examine IterativeEven by reading n from the user and printing the n-th even number and its sequence
        /// </summary>
        static void ExamineIterativeEven()
        {
            Console.WriteLine("\n--- Examine IterativeEven ---");
            Console.Write("Ange n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int result = IterativeEven(n);
                Console.WriteLine($"\nDet {n}:e jämnt talet är: {result}");


                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{IterativeEven(i)}{(i < n ? ", " : "")}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Iteratively calculates the n-th even number
        /// </summary>
        /// <param name="n">The position (n) of the even number to compute</param>
        /// <returns>The n-th even number</returns>
        static int IterativeEven(int n)
        {
            int result = 2;

            // Start from 2 and add 2 for each step until we reach n
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        /// <summary>
        /// Examines FibonacciIterative by reading n from the user and printing the n-th Fibonacci number and its sequence
        /// </summary>
        static void ExamineFibonacciIterative()
        {
            Console.WriteLine("\n--- Testing Fibonacci (Iterative) ---");
            Console.Write("Enter n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int result = FibonacciIterative(n);
                Console.WriteLine($"Fibonacci({n}) = {result}");

                // Show sequence
                Console.Write("Sekvens: ");
                for (int i = 0; i <= Math.Min(n, 30); i++)
                {
                    Console.Write($"{FibonacciIterative(i)}{(i < n && i < 15 ? ", " : "")}");
                }
                if (n > 15)
                {
                    // showing first 16 only due to recursion depth
                    Console.Write(" ...");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Ogiltig input!\n");
            }
        }

        /// <summary>
        /// Iteratively calculates the n-th Fibonacci number
        /// </summary>
        /// <param name="n">The position (n) in the Fibonacci sequence</param>
        /// <returns>The n-th Fibonacci number</returns>
        static int FibonacciIterative(int n)
        {
            // Base cases
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Keep track of the two previous Fibonacci numbers
            int prev2 = 0; // f(0)
            int prev1 = 1; // f(1)
            int current = 0;

            // Calculate iteratively from f(2) to f(n)
            for (int i = 2; i <= n; i++)
            {
                current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }
            return current;
        }
    }

    /*
     * Fråga: Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering.
     * Vilken av ovanstående funktioner är mest minnesvänlig och varför? 
     * 
     * Den iterativa funktionen är mest minnesvänlig, eftersom iteration använder ett fast minnesutrymme, 
     * medan rekursion skapar ett nytt stack-anrop för varje nivå. 
     * Rekursionen använder alltså mer stackminne och riskerar stack overflow vid stora n,
     * medan iteration gör samma arbete utan att bygga upp en anropsstack.
     */
}
