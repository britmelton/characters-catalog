using Characters.Catalog.Domain;

namespace Characters.Catalog.Console;

internal class Program
{
    static void Main(string[] args)
    {
        var storeCharacter = new Character("brittany", "race", 679);
        storeCharacter.AddClass("className", 2, "n/a");

        var charactersStorage = new Dictionary<string, Character>
        {
            { "brittany", storeCharacter }
        };

        var action = Prompt("would you like to store or retrieve a character? Store/Retrieve").Trim().ToLower();
        if (action is "retrieve")
        {
            var characterName = Prompt("enter your characters name: ").ToLower();

            var retrieveCharacter = charactersStorage[characterName];
            Print(retrieveCharacter);
            var setSubclass = Prompt("now provide your subclass: ");
            retrieveCharacter.Classes[0].Subclass = setSubclass;
            Print(retrieveCharacter);
        }
        else
        {
            System.Console.WriteLine("begin Character creation: \n\n");

            var name = Prompt("enter your characters name: ");
            var age = uint.Parse(Prompt("enter your characters age: "));
            var race = Prompt("enter your race: ");

            var input = Prompt("will you have more than one class? Y/N").ToLower();
            if (input is "y")
            {
                var className1 = Prompt("enter your first class: ");
                var subclass1 = Prompt($"enter {className1}'s subclass: ");
                var level1 = uint.Parse(Prompt($"enter {className1}'s level: "));

                var className2 = Prompt("enter your second class: ");
                var subclass2 = Prompt($"enter {className2}'s subclass: ");
                var level2 = uint.Parse(Prompt($"enter {className2}'s level: "));

                var input2 = Prompt("do you have a third class? Y/N");
                switch (input2.ToLower())
                {
                    case "n":
                        {
                            var classes = new List<Class>
                            { new(className1, level1, subclass1), new(className2, level2, subclass2) };
                            var character = CreateCharacter(name, race, age, classes);

                            Print(character);
                            break;
                        }
                    case "y":
                        {
                            var className3 = Prompt("enter your final class: ");
                            var subclass3 = Prompt($"enter {className3}'s subclass: ");
                            var level3 = uint.Parse(Prompt($"enter {className3}'s level: "));

                            var classes = new List<Class>
                        {
                            new(className1, level1, subclass1),
                            new(className2, level2, subclass2),
                            new(className3, level3, subclass3)
                        };
                            var character = CreateCharacter(name, race, age, classes);

                            Print(character);
                            break;
                        }
                }
            }
            else
            {
                var className = Prompt("enter your class: ");
                var subclass = Prompt("enter your subclass: ");
                var level = uint.Parse(Prompt("enter your level: "));
                var classes = new List<Class> { new(className, level, subclass) };

                var character = CreateCharacter(name, race, age, classes);
                Print(character);


            }
        }

    }

    public static Character CreateCharacter(string name, string race, uint age, List<Class> classses)
    {
        var character = new Character(name, race, age);
        foreach (var @class in classses)
        {
            character.AddClass(@class);
        }

        return character;
    }

    public static void Print(Character character)
    {
        System.Console.WriteLine("\n\nhere's your character: ");
        System.Console.WriteLine(@$"
Name: {character.Name}
Age: {character.Age}
Race: {character.Race}");
        foreach (var @class in character.Classes)
        {
            System.Console.WriteLine($@"
       Class: {@class.ClassName}
       Subclass: {@class.Subclass}
       Level: {@class.Level}");
        }
    }

    public static string Prompt(string prompt)
    {
        System.Console.Write($"{prompt}>");
        return System.Console.ReadLine();
    }
}