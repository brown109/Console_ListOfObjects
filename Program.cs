using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            // Add animals to the list you just created
            
            AddAnimals(animals);
                       
            // Display the list of animals you just added

            DisplayAnimals(animals);

            // Append all the newly added animals to the external file

            AppendAnimals(animals);

            // Analyze the list of animals you just made

            AnalyzeAnimals(animals);
        }

        public static void AddAnimals(List<Animal> animals)
        {
            Console.WriteLine("Lets Add some animals to a List");
            bool ValidInput;
            string ans;

            //
            // Loop to take user input to enter 1 or more animals
            //
            int done = 0;
            while (done == 0)
            {
                Animal animal = new Animal();

                // Get animal name from the user. It can't be null or empty 

                do
                {
                    ValidInput = true;
                    Console.Write("Enter Animal Name: ");
                    animal.Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(animal.Name) && (animal.Name[0] == ' '))
                    {
                        Console.WriteLine("Please enter something for name ");
                        ValidInput = false;
                    }
                }
                while (!ValidInput);

                //
                // IsReal is defaulted to true for any input other than 'y'
                // animal.IsReal = bool.Parse(Console.ReadLine());

                Console.Write("Is this animal real, Enter Y or N: ");
                ans = Console.ReadLine();
                animal.IsReal = true;
                if (ans.ToLower() == "n")
                {
                    animal.IsReal = false; 
                }
               
                do
                {
                    ValidInput = true;
                    Console.Write("How Many Legs?: ");
                    if (int.TryParse(Console.ReadLine(), out int legs))
                        {
                        animal.Legs = legs;
                        }
                    else
                        {
                        Console.WriteLine("Legs must be an integer value, try again");
                        ValidInput = false;
                        }
                }
                while (!ValidInput);


                // 
                // get a valid diet type from the user
                //
                do
                {
                    ValidInput = true;
                    Console.Write("What is the animal's diet type?: ");
                    if (Enum.TryParse(Console.ReadLine(), out Animal.DietType diet))
                    {
                        animal.Diet = diet;
                    }
                    else
                    {
                        Console.WriteLine("Diet Type must be valid. Here are your choices: ");
                        foreach (Animal.DietType disptype in Enum.GetValues(typeof(Animal.DietType)))
                        {
                            Console.Write(" || " + disptype);
                        }
                        Console.WriteLine();
                        ValidInput = false;
                    }
                }
                while (!ValidInput);
 
                animals.Add(animal);

                Console.Write("Add Another Animal, Y or N: ");
                string rudone = Console.ReadLine().ToLower();
                if (rudone != "y")
                {
                    done = 1;
                }
            }

        }
        // sample code to add an animal to the list without prompting the user
        //
        //static Animal MakeUnicorn()
        //{
        //    Animal unicorn = new Animal();
        //    unicorn.Name = "Unicorn";
        //    unicorn.IsReal = false;
        //    unicorn.Legs = 4;
        //    unicorn.Diet = Animal.DietType.carnivore; /* its a mean unicorn */

        //    return unicorn;
        
        //}

        static void DisplayAnimals(List<Animal> animals)
        {
            DisplayHeading();
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.Name.PadLeft(15) + animal.IsReal.ToString().PadLeft(15) + animal.Legs.ToString().PadLeft(10) + animal.Diet.ToString().PadLeft(15));
            }
        }

        static void DisplayHeading()
        {
            string h1 = "Name";
            string u1 = "----";
            string h2 = "Is it Real?";
            string u2 = "-----------";
            string h3 = "# of Legs";
            string u3 = "---------";
            string h4 = "Diet Type";
            string u4 = "---------";

            Console.WriteLine(h1.PadLeft(15) + h2.PadLeft(15) + h3.PadLeft(10) + h4.PadLeft(15));
            Console.WriteLine(u1.PadLeft(15) + u2.PadLeft(15) + u3.PadLeft(10) + u4.PadLeft(15));

        }
        private static void AppendAnimals(List<Animal> animals)
        {
            string filePath = @"Data\animals.txt";
            string animalRow;
            foreach (Animal animal in animals)
            {
                //   Console.WriteLine(animal.Name.PadLeft(15) + animal.IsReal.ToString().PadLeft(15) + animal.Legs.ToString().PadLeft(10) + animal.Diet.ToString().PadLeft(15));
                animalRow = animal.Name + ',' 
                    + animal.IsReal.ToString() + ',' 
                    + animal.Legs.ToString() + ',' 
                    + animal.Diet.ToString() + "\n";
                File.AppendAllText(filePath, animalRow);
             }
        }
        static void AnalyzeAnimals(List<Animal> animals)
        {
            Console.WriteLine();
            int nbrofAnimals = 0, totalLegs = 0;
            foreach (Animal animal in animals)
            {
                ++nbrofAnimals;
                totalLegs = totalLegs + animal.Legs;
            }
            if (totalLegs != 0)
            {
                Console.WriteLine($"Nbr of Animals = " + nbrofAnimals.ToString());
                Console.WriteLine($"Total Legs = " + totalLegs.ToString());
                decimal avgLegs = Decimal.Divide(totalLegs, nbrofAnimals);
                Console.WriteLine($"Average Legs = " + avgLegs.ToString("###.###"));
            }
        }

    }
}
