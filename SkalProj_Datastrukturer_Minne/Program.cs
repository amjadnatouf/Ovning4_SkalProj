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
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
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
            string userInput;

            do
            {
                Console.WriteLine($"Count: {testList.Count}, Capacity: {testList.Capacity}");
                Console.WriteLine("Välj en åtgärd: ");
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
                    continue;

                char nav = userInput[0];
                string value = input.substring(1);

                switch (nav) {
                    case '+':
                        testList.Add(value);
                        Console.WriteLine($"Lägg till {value} i listan");
                        Console.WriteLine($"Count: {testList.Count}, Capacity: {testList.Capacity}");
                        break;
                    case '-':
                        if(testList.Remove(value))
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
                        return;
                    default:
                        Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                            + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)"); 
                        break;
                }
                Console.WriteLine();
                while (userInput[0] !='0');

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
                string userInput;

                do
                {
                    // Check the queue
                    Console.WriteLine(string.Join(", ", testQueue.Select(x => x.ToString())));
                    Console.WriteLine("Välj en åtgärd: ");
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
                        continue;

                    char nav = userInput[0];
                    string value = input.substring(1);

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
                            return;
                        default:
                            Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                                + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)");
                            break;
                    }
                    Console.WriteLine();
                    while (userInput[0] != '0') ;

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
                    /*
                     * Loop this method until the user inputs something to exit to main menue.
                     * Create a switch with cases to push or pop items
                     * Make sure to look at the stack after pushing and and poping to see how it behaves
                    */
                    Stack<string> testStack = new Stack<string>();
                    string userInput;

                    do
                    {
                        // Check the stack
                        Console.WriteLine(string.Join(", ", testStack.Select(x => x.ToString())));
                        Console.WriteLine("Välj en åtgärd: ");
                        userInput = Console.ReadLine();
                        if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
                            continue;

                        char nav = userInput.ToUpper()[0];
                        string value = input.substring(1);

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
                                    Console.WriteLine($"Stack count: {testQueue.Count}");
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
                                return;
                            default:
                                Console.WriteLine("Vänligen välj en åtgärd: '+' (lägg till objekt),"
                                    + " '-' (ta bort objekt) eller '0' (återgå till huvudmenyn)");
                                break;
                        }
                        Console.WriteLine();
                        while (userInput.ToUpper()[0] != '0');
                    }

                    /// <summary>
                    /// Reversed a text string method using stack
                    /// </summary>
                    static void ReverseText() {
                        Console.WriteLine("---- Omvänd text ----");
                        Console.WriteLine("Ange texten som ska vändas: ");

                        string userString = Console.ReadLine();

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
                        while (sc.Count>0)
                        {
                            reversedString += sc.Pop();
                        }

                        Console.WriteLine($"Originalsträngen är: {userString}");
                        Console.WriteLine($"Den omvända strängen är: {reversedString}");
                    }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

