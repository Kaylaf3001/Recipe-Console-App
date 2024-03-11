using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE
{
    internal class Receipe
    {
        private string receipeName = "";
        private string[] ingredientNames = { };
        private string[] stepDescriptions = { };
        private int[] ingredQuantity = { };
        private int[] originalQuantities = { }; // Array to store original quantities
        private int scaleNumber = 0;
        private string[] unitOfMeasurement = { };
        private int repSteps = 0;
        private int ingreNo = 0;

        /// Prompts the user for the information required
        public void userInput()
        {
            Console.WriteLine("What is the name of the recipe?");
            receipeName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("How many Ingredients does your recipe have?");
            int ingreNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            ///Arrays to store the data
            ingredientNames = new string[ingreNo];
            ingredQuantity = new int[ingreNo];
            originalQuantities = new int[ingreNo];
            unitOfMeasurement = new string[ingreNo];

            Console.WriteLine("Name and Quantity of your ingredients:");
            nameQuanUnit();

            Console.WriteLine();
            Console.WriteLine("How many steps are there?");
            int repSteps = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("******************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter a description for each step: ");
            steps();
            Console.WriteLine("******************************************************************************");
            Console.WriteLine();

            Console.WriteLine("Would you like to view the recipe? (1 - Yes and 0 - No)");
            int response = Convert.ToInt32(Console.ReadLine());

            if (response == 1)
            {
                displayReceipe();
            }
            else if (response == 0)
            {
                Console.WriteLine("IDK");
            }

            Console.WriteLine("Would you like to change the scale of your recipe? (1 - Yes, 0 - No)");
            int response2 = Convert.ToInt32(Console.ReadLine());

            if (response2 == 1)
            {
                Console.WriteLine("What would you like to scale down to?");
                scaleNumber = Convert.ToInt32(Console.ReadLine());
                scale();
            }
            else if (response2 == 0)
            {
                Console.WriteLine("IDK");
            }

            Console.WriteLine("Would you like to revert back to the orginal quantities? (1 - Yes, 0 - No)");
            int response3 = Convert.ToInt32(Console.ReadLine());

            if (response3 == 1)
            {
                resetQuantities();
            }
            else if (response3 == 0)
            {
                Console.WriteLine("IDK");
            }

            Console.WriteLine("Would you like to clear the data for a new receipe?(1 - Yes, 0 - No)");
            int response4 = Convert.ToInt32(Console.ReadLine());

            if (response2 == 1)
            {
                clearData();
            }
            else if (response4 == 0)
            {
                Console.WriteLine("IDK");
            }
        }

        ///========================================================================================================
        public void displayReceipe()
        {
            Console.WriteLine("******************************************************************************");
            Console.WriteLine("Receipe name: " + receipeName);
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredientNames[i]}: {ingredQuantity[i]} {unitOfMeasurement[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Steps:");
            for (int i = 0; i < stepDescriptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]} ");
            }
            Console.WriteLine("******************************************************************************");
        }
        ///========================================================================================================
        public void steps()
        {
            stepDescriptions = new string[repSteps];
            for (int i = 0; i < repSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}: ");
                stepDescriptions[i] = Console.ReadLine();
                Console.WriteLine();
            }
        }
        ///========================================================================================================
        public void scale()
        {
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                int newQuantity = originalQuantities[i] / scaleNumber;
                Console.WriteLine("Old: " + ingredQuantity[i] + " New: " + newQuantity);
                ingredQuantity[i] = newQuantity;
            }
            displayReceipe(); // Display recipe after scaling
        }
        ///========================================================================================================
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                ingredQuantity[i] = originalQuantities[i];
            }
            Console.WriteLine("Quantities reverted to original values.");
            displayReceipe();
        }
        ///========================================================================================================
        public void clearData()
        {
            receipeName = "";
            ingredientNames = new string[] { };
            stepDescriptions = new string[] { };
            ingredQuantity = new int[] { };
            originalQuantities = new int[] { };
            scaleNumber = 0;
            unitOfMeasurement = new string[] { };

            userInput();
        }
        ///========================================================================================================4
        public void nameQuanUnit()
        {
            for (int i = 0; i < ingreNo; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                ingredientNames[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                ingredQuantity[i] = Convert.ToInt32(Console.ReadLine());
                originalQuantities[i] = ingredQuantity[i]; // Store original quantity
                Console.WriteLine("Is there a unit of measurement? (1 - Yes and 0 - No)");
                int resp = Convert.ToInt32(Console.ReadLine());
                if (resp == 1)
                {
                    Console.WriteLine("What is the unit of measurement?");
                    unitOfMeasurement[i] = Console.ReadLine();
                }
                else if (resp == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        ///========================================================================================================
    }
}
