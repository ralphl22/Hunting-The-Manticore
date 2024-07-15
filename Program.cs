// Method loops everything in the game until HP of the ship or city reaches 0

LoopUntilHPZero();

void LoopUntilHPZero()
{
    // Initial variables and values for game start

    int manticoreHealthPoints = 10;
    int cityHealthPoints = 15;
    int roundCount = 1;

    do
    {
        // Method prints game's state to the console

        void GameState()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Round: {roundCount} | City HP: {cityHealthPoints}/15 | Manticore HP: {manticoreHealthPoints}/10");
            Console.ResetColor();
        }

        // Method allows Player 1 to choose Manticore's distance from the city, clearing the console when done 

        int number;

        AskForNumber("Player 1, choose the Manticore's distance from the city (0 to 100): ");

        void AskForNumber(string text)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(text);
                Console.ResetColor ();
                number = Convert.ToInt32(Console.ReadLine());
            }
            while (number < 0 || number > 100); // loops if the number is not in range
        }

        Console.Clear();

        // Method that displays how much damage the cannon does

        void CannonDamageDisplay()
        {
            if (roundCount % 3 == 0 && roundCount % 5 == 0)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The cannon will deal 10 DMG this round.");
                Console.ResetColor();

            }
            else if (roundCount % 3 == 0 || roundCount % 5 == 0)
            {
                if (manticoreHealthPoints <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The cannon will deal 3 DMG this round.");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The cannon will deal 3 DMG this round.");
                Console.ResetColor();

            }
            else
            {
                if (manticoreHealthPoints <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The cannon will deal 1 DMG this round.");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The cannon will deal 1 DMG this round.");
            }
        }

        // Method for determining the range of the cannon by Player 2: if the number is a miss, the city takes 1 DMG. If it's a direct hit, the CannonDamage method
        // is called. Program ends if the city's HP is 0.

       CannonRange();


        void CannonRange()   
        {
            int guessedNumber;

            do
            {
                GameState();
                CannonDamageDisplay();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Player 2, how far do you want to shoot the cannon? (0 to 100)");
                Console.ResetColor();

                guessedNumber = Convert.ToInt32(Console.ReadLine());

                if (guessedNumber > number) // number too far
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The cannon OVERSHOT the target!");
                    roundCount++;
                    cityHealthPoints--;
                    Console.WriteLine("The Manticore has done 1 DMG to City!");
                    Console.ResetColor();
                }
                else if (guessedNumber < number) // number not close enough 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The cannon FELL SHORT of the target!");
                    roundCount++;
                    cityHealthPoints--;
                    Console.WriteLine("The Manticore has done 1 DMG to City!");
                    Console.ResetColor();
                }
                else if (guessedNumber == number) // a direct hit: calls CannonDamage method and loops until Manticore HP is 0.
                {
                    CannonDamage();
                    break;
                }
                if (cityHealthPoints == 0) // City is destroyed if HP is 0
                {
                    GameState();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("City has been destroyed!");
                    Console.ResetColor();
                    break;
                }
            }
            while (true);
        }

        // Method that calculates how much damage the cannon does to the Manticore based on the round number. Program ends if Manticore's HP is 0.

        void CannonDamage()
        {
            while (true)
            {
                if (roundCount % 3 == 0 && roundCount % 5 == 0)
                {
                    manticoreHealthPoints -= 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("DIRECT HIT on the Manticore!");
                    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                    Console.ResetColor();
                    break;
                }
                else if (roundCount % 3 == 0 || roundCount % 5 == 0)
                {
                    manticoreHealthPoints -= 3;
                    if (manticoreHealthPoints <= 0)
                    {
                        GameState();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                        Console.ResetColor();
                        break;
                    }
                    roundCount++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("DIRECT HIT on the Manticore!");
                    CannonRange();
                    break;
                }
                else
                {
                    manticoreHealthPoints--;
                    if (manticoreHealthPoints <= 0)
                    {
                        GameState();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                        Console.ResetColor();
                        break;
                    }
                    roundCount++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("DIRECT HIT on the Manticore!");
                    CannonRange();
                    break;
                }
            }
        }
    }
    while (manticoreHealthPoints > 0 && cityHealthPoints > 0);
}