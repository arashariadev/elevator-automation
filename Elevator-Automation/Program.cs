
using Elevator_Automation.Logic;
using Elevator_Automation.Model;


{
    Console.WriteLine("Welcome to the Elevator Controller!");
    Console.WriteLine("How many floors does the building have?");

    int numberOfFloors;
    while (!int.TryParse(Console.ReadLine(), out numberOfFloors) || numberOfFloors <= 0)
    {
        Console.WriteLine("Invalid input. Please enter a positive integer.");
    }

    Elevator elevator = new Elevator(numberOfFloors);

    string input;
    do
    {
        Console.WriteLine("Please enter the target floor number or 'q' to quit:");

        input = Console.ReadLine();
        if (input == "q")
        {
            Console.WriteLine("Goodbye!");
            break;
        }

        if (int.TryParse(input, out int targetFloor))
        {
            elevator.FloorPress(targetFloor);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid floor number.");
        }

    } while (input != "q");

    Console.ReadLine();
}

   