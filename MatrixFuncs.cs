namespace Challenge_6 {
    internal class MatrixFuncs {

        public static void RotateClockwise(int[,] grid) {

            int size = grid.GetLength(0);

            for (int row = 0; row < size; row++) {
                for (int column = row + 1; column < size; column++) {

                    int hold = grid[row, column];
                    grid[row, column] = grid[column, row];
                    grid[column, row] = hold;

                }
            }

            for (int row = 0; row < size; row++) {

                int left = 0;
                int right = size - 1;

                while (left < right) {

                    int hold = grid[row, left];
                    grid[row, left] = grid[row, right];
                    grid[row, right] = hold;

                    left++;
                    right--;

                }
            }
        }

        public static void ShowGrid(int[,] grid) {

            int size = grid.GetLength(0);

            for (int row = 0; row < size; row++) {

                for (int column = 0; column < size; column++)
                    Console.Write($"{grid[row, column],5}");

                Console.WriteLine();

            }
        }
    }
}
