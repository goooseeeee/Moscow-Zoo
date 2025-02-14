using System;
using System.Collections.Generic;

public interface IAlive
{
    int Food { get; }
}

public interface IInventory
{
    int Number { get; }
}

public abstract class Animal : IAlive, IInventory
{
    public string Name { get; set; }
    public int Food { get; set; }
    public int Number { get; set; }
    public bool IsHealthy { get; set; }
    public abstract void Feed();
}

public class Herbo : Animal
{
    public int KindnessLevel { get; set; }

    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Predator : Animal
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Monkey : Herbo
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Rabbit : Herbo
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Tiger : Predator
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Wolf : Predator
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} is being fed {Food} kg of food.");
    }
}

public class Thing : IInventory
{
    public string Name { get; set; }
    public int Number { get; set; }
}

public class Table : Thing { }
public class Computer : Thing { }

public class Zoo
{
    private List<Animal> animals = new List<Animal>();
    private List<Thing> things = new List<Thing>();
    private VeterinaryClinic veterinaryClinic;

    public Zoo(VeterinaryClinic veterinaryClinic)
    {
        this.veterinaryClinic = veterinaryClinic;
    }

    public void AddAnimal(Animal animal)
    {
        if (veterinaryClinic.CheckHealth(animal))
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} added to the zoo.");
        }
        else
        {
            Console.WriteLine($"{animal.Name} was not accepted to the zoo due to health issues.");
        }
    }

    public void FeedAnimals()
    {
        foreach (var animal in animals)
        {
            animal.Feed();
        }
    }

    public void ListContactZooAnimals()
    {
        foreach (var animal in animals)
        {
            if (animal is Herbo herbo && herbo.KindnessLevel > 5)
            {
                Console.WriteLine($"{animal.Name} can go to the contact zoo.");
            }
        }
    }

    public void ShowInventory()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine($"Animal: {animal.Name}, Inventory Number: {animal.Number}");
        }

        foreach (var thing in things)
        {
            Console.WriteLine($"Thing: {thing.Name}, Inventory Number: {thing.Number}");
        }
    }

    public void AddThing(Thing thing)
    {
        things.Add(thing);
    }
}

public class VeterinaryClinic
{
    public bool CheckHealth(Animal animal)
    {
        return animal.IsHealthy;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var veterinaryClinic = new VeterinaryClinic();
        var zoo = new Zoo(veterinaryClinic);

        var tiger = new Tiger { Name = "Tiger", Food = 10, Number = 1, IsHealthy = true };
        var monkey = new Monkey { Name = "Monkey", Food = 5, Number = 2, IsHealthy = true, KindnessLevel = 8 };

        zoo.AddAnimal(tiger);
        zoo.AddAnimal(monkey);

        zoo.FeedAnimals();
        zoo.ListContactZooAnimals();
        zoo.ShowInventory();
    }
}

