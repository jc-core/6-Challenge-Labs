namespace Challenge_6 {
    internal class Program {

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Rotate Image");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        RotateImage();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void RotateImage() {

            Console.WriteLine();
            Console.WriteLine("The image is a square grid of numbers. It turns 90 degrees clockwise in place.");

            int[,] grid = ReadGrid();

            Console.WriteLine();
            Console.WriteLine("Before:");
            MatrixFuncs.ShowGrid(grid);

            MatrixFuncs.RotateClockwise(grid);

            Console.WriteLine();
            Console.WriteLine("After:");
            MatrixFuncs.ShowGrid(grid);

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int[,] ReadGrid() {

            int size;

            while (true) {

                Console.Write("Grid size: ");

                if (int.TryParse(Console.ReadLine(), out size) && size >= 1 && size <= 10)
                    break;

                Console.WriteLine("Whole numbers from 1 to 10 only, try again.");

            }

            int[,] grid = new int[size, size];

            for (int row = 0; row < size; row++) {

                while (true) {

                    Console.Write($"Row {row + 1}, {size} numbers separated by spaces: ");
                    string[] numInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (numInputs.Length != size) {
                        Console.WriteLine($"Each row needs exactly {size} numbers, try again.");
                        continue;
                    }

                    bool parsed = true;

                    for (int column = 0; column < size; column++) {
                        if (!int.TryParse(numInputs[column], out int value)) {
                            parsed = false;
                            break;
                        }
                        grid[row, column] = value;
                    }

                    if (parsed)
                        break;

                    Console.WriteLine("Whole numbers only, with a space between each one.");

                }

            }

            return grid;

        }
    }
}
