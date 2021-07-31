using System;

Console.Title = "The Battle for Consolonar";
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

// Initial Variables
int cityLife = 15;
int manticoreLife = 10;
int manticorePosition;
int round;

// Player 1 Input

Console.Write("Welcome Player 1! ");
manticorePosition = RangePromptIntegerInputLine("Please enter the distance to the Manticore, as a full number between 0 and 100", 0, 100);
Console.WriteLine("Excellent. Let the Battle begin by pressing any Button!");
Console.ReadKey(true);
Console.Clear();

//Player 2 playing the Game

Console.WriteLine("Welcome Player 2. Let's begin the hunt!");

for (round = 1; cityLife > 0; round++)
{
    Console.ForegroundColor = ConsoleColor.Black;
    Status(round);
    int guess = RangePromptIntegerInputLine("Which Range between 0 and 100 will the Cannon Shoot?", 0, 100);
    HitConfirm(manticorePosition, guess);
    if (manticoreLife > 0) //Surviving ship deals Damage!
        Damage("City", 1);
    if (manticoreLife <= 0) //Win condition
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("You have defeated the Manticore!! Congratulations");
        break;
    }
    if (cityLife <= 0) //Loss Condition
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.WriteLine("You took too long and the city has been Destroyed by the Uncoded one. Too bad");
        break;
    }
    else
        continue;
}

//Methodspace

int RangePromptIntegerInputLine(string message, int min, int max) //Prompts the user to input an integer between min and max
{
    Console.WriteLine(message);
    int number = Convert.ToInt32(Console.ReadLine());
    if (number > min && number < max)
        return number;
    Console.WriteLine("Please stay within the set parameter!");
    return RangePromptIntegerInputLine(message, min, max);
}
void Status(int roundNumber) //Shortcut for Start of Round Information for the Player
{
    Console.WriteLine("----------------------------");
    Console.WriteLine($"Round {roundNumber}:   City Life: {cityLife}/15   Manticore Life: {manticoreLife}/10");
    Console.WriteLine($"The Cannon is expected to deal {damageValue(round)} points of Damage!");
}
int damageValue(int roundNumber) //Calculates the damage based on the Round we're on.
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
        return 10;
    if (roundNumber % 3 == 0 || roundNumber % 5 == 0)
        return 3;
    else
        return 1;
}
void HitConfirm(int manticorePosition, int guess) //Checking wether the guess hit or not
{
    if (manticorePosition == guess)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Damage("Manticore", damageValue(round));
        Console.WriteLine("You've landed a DIRECT HIT!");
    }
    if (manticorePosition > guess)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You FELL SHORT of the Manticore!");
    }
    if (manticorePosition < guess)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You OVERSHOT the Manticore!");
    }
}
void Damage(string target, int value) //Shortcut to assign Damage
{
    if (target == "City")
        cityLife -= value;
    if (target == "Manticore")
        manticoreLife -= value;
    else
        return;
}