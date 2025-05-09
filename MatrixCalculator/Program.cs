using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            MathMatrix firstMatrix = new MathMatrix(3);
            MathMatrix secondMatrix = new MathMatrix(3);

            Console.WriteLine("=== Матрица A ===");
            Console.WriteLine(firstMatrix);

            Console.WriteLine("\n=== Матрица B ===");
            Console.WriteLine(secondMatrix);

            MathMatrix sum = firstMatrix + secondMatrix;
            Console.WriteLine("\n=== A + B ===");
            Console.WriteLine(sum);

            MathMatrix product = firstMatrix * secondMatrix;
            Console.WriteLine("\n=== A * B ===");
            Console.WriteLine(product);

            Console.WriteLine("Детерминант матрицы A: " + firstMatrix.Determinant());
            Console.WriteLine("Детерминант матрицы B: " + secondMatrix.Determinant());

            Console.WriteLine("След матрицы  A: " + firstMatrix.Trace());
            Console.WriteLine("Симметричность A: " + (firstMatrix.IsSymmetric() ? "Да" : "Нет"));

            if (firstMatrix > secondMatrix)
            {
                Console.WriteLine("Детерминант матрицы A больше.");
            }
            else if (firstMatrix < secondMatrix)
            {
                Console.WriteLine("Детерминант матрицы B меньше.");
            }
            else
            {
                Console.WriteLine("Детерминанты равны.");
            }

            MathMatrix inverseMatrix1 = firstMatrix.Inverse();
            Console.WriteLine("Обратная матрица A:");
            Console.WriteLine(inverseMatrix1);
        }
        catch (Exception ex) when (ex is MatrixOperationException || ex is MatrixSizeMismatchException)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неожиданная ошибка: " + ex.Message);
        }
    }
}