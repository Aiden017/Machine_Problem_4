using System;
using System.Collections.Generic;

public class CharacterGenerator
{
    public static string Archetype;
    public static string Gender;
    public static string Strength;
    public static string Class;
    public static string Weapon;
    public static string Gear;
    public static string Skill;
    public static string Spell;
    public static int Life;
    public static int Energy;
    public static int Power;
    public static int Mana;

    public static List<string> characterList = new List<string>();

    public static string ManualTrim(string input)
    {
        int start = 0;
        while (start < input.Length && input[start] == ' ')
        {
            start++;
        }

        int end = input.Length - 1;
        while (end >= 0 && input[end] == ' ')
        {
            end--;
        }

        if (start > end)
            return "";

        return input.Substring(start, end - start + 1);
    }

    public static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Character Creator");
        Console.WriteLine("1) Add Details");
        Console.WriteLine("2) Generate Character");
        Console.WriteLine("3) Exit");

        string input = Console.ReadLine();
        input = ManualTrim(input);

        if (input == "1")
        {
            MakeChar();
            return true;
        }
        else if (input == "2")
        {
            GChar();
            return true;
        }
        else if (input == "3")
        {
            return false;
        }
        return true;
    }

    public static void MakeChar()
{
    try
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Enter Archetype (Hero/Villain):");
            Archetype = ManualTrim(Console.ReadLine()).ToLowerInvariant();
            if (Archetype == "hero" || Archetype == "villain")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Archetype. Please enter 'Hero' or 'Villain'.\n");
            }
        }

        while (true)
        {
            Console.WriteLine("Enter Gender (M/F):");
            Gender = ManualTrim(Console.ReadLine()).ToLowerInvariant();
            if (Gender == "m" || Gender == "f")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Gender. Please enter 'M' or 'F'.\n");
            }
        }

        Console.WriteLine("Enter Strength Type (Physical/Agility/Constitution/Magic):");
        Strength = ManualTrim(Console.ReadLine()).ToLowerInvariant();

        Console.WriteLine("Details saved. Press Enter to continue...");
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error occurred: " + ex.Message);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}


    public static void GChar()
    {
        try
        {
            Console.Clear();
            Random rand = new Random();

            string[] physClass = { "Warrior", "Dark Slayer", "Sword Master" };
            string[] agiClass = { "Rogue", "Ranger", "Striker" };
            string[] conClass = { "Tank", "Defender", "Royal Guard" };
            string[] magClass = { "Mage", "Wizard", "Invoker" };

            string[] physWep = { "Rebellion (Greatsword)", "Leviathan Axe", "Charge Blade" };
            string[] agiWep = { "Daggers", "Yamato (Katana)", "Whip" };
            string[] conGear = { "Shield", "Heavy Armor", "Chain Mail" };
            string[] magSkill = { "Wisdom", "Silence", "Foresight" };
            string[] magSpell = { "Fireball", "Meteor Shower", "Electric Bolt" };

            Class = "";
            Weapon = "";
            Gear = "";
            Skill = "";
            Spell = "";
            Life = 0;
            Energy = 0;
            Power = 0;
            Mana = 0;

            string str = Strength.ToLowerInvariant();

            if (str == "physical")
            {
                Class = physClass[rand.Next(physClass.Length)];
                Weapon = physWep[rand.Next(physWep.Length)];
                Power = rand.Next(75, 91);
                Life = rand.Next(60, 76);
                Energy = rand.Next(40, 61);
            }
            else if (str == "agility")
            {
                Class = agiClass[rand.Next(agiClass.Length)];
                Weapon = agiWep[rand.Next(agiWep.Length)];
                Energy = rand.Next(75, 91);
                Power = rand.Next(60, 76);
                Life = rand.Next(40, 61);
            }
            else if (str == "constitution")
            {
                Class = conClass[rand.Next(conClass.Length)];
                Gear = conGear[rand.Next(conGear.Length)];
                Life = rand.Next(75, 91);
                Energy = rand.Next(60, 76);
                Power = rand.Next(40, 61);
            }
            else if (str == "magic")
            {
                Class = magClass[rand.Next(magClass.Length)];
                Skill = magSkill[rand.Next(magSkill.Length)];
                Spell = magSpell[rand.Next(magSpell.Length)];
                Mana = rand.Next(75, 91);
                Life = rand.Next(60, 76);
            }
            else
            {
                Console.WriteLine("Invalid strength type. Please add details first.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

           string capArchetype = (Archetype.Length > 0) 
           ? Archetype.Substring(0, 1).ToUpper() + Archetype.Substring(1).ToLower() 
           : Archetype;
           string capGender = (Gender.Length > 0) 
           ? Gender.Substring(0, 1).ToUpper() 
           : Gender;
           string capStrength = (Strength.Length > 0)
           ? Strength.Substring(0, 1).ToUpper() + Strength.Substring(1).ToLower()
           : Strength;

           string output = "Generated Character:\n";
           output += "Archetype: " + capArchetype + "\n";
           output += "Gender: " + capGender + "\n";
           output += "Strength: " + capStrength + "\n";



            if (str == "physical" || str == "agility")
            {
                output += "Weapon: " + Weapon + "\n";
                output += "Power: " + Power + "\n";
                output += "Life: " + Life + "\n";
                output += "Energy: " + Energy + "\n";
            }
            else if (str == "constitution")
            {
                output += "Gear: " + Gear + "\n";
                output += "Life: " + Life + "\n";
                output += "Energy: " + Energy + "\n";
                output += "Power: " + Power + "\n";
            }
            else if (str == "magic")
            {
                output += "Skill: " + Skill + "\n";
                output += "Spell: " + Spell + "\n";
                output += "Mana: " + Mana + "\n";
                output += "Life: " + Life + "\n";
            }

            characterList.Add(output);
            Console.WriteLine(output);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during generation: " + ex.Message);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

public class test
{
    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            running = CharacterGenerator.MainMenu();
        }
        Console.WriteLine("Exiting Character Creator. Goodbye!");
    }
}
