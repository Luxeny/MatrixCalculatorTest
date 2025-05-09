using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            MathMatrix firstMatrix = new MathMatrix(3);
            MathMatrix secondMatrix = new MathMatrix(3);

            Console.WriteLine("Первая матрица:");
            Console.WriteLine(firstMatrix);

            Console.WriteLine("Вторая матрица:");
            Console.WriteLine(secondMatrix);

            MathMatrix sum = firstMatrix + secondMatrix;
            Console.WriteLine("Сумма матриц:");
            Console.WriteLine(sum);

            MathMatrix product = firstMatrix * secondMatrix;
            Console.WriteLine("Произведение матриц:");
            Console.WriteLine(product);

            Console.WriteLine("Детерминант первой матрицы: " + firstMatrix.Determinant());
            Console.WriteLine("Детерминант второй матрицы: " + secondMatrix.Determinant());

            Console.WriteLine("След первой матрицы: " + firstMatrix.Trace());
            Console.WriteLine("Первая матрица " + (firstMatrix.IsSymmetric() ? "симметрична" : "не симметрична"));

            if (firstMatrix > secondMatrix)
            {
                Console.WriteLine("Детерминант первой матрицы больше.");
            }
            else if (firstMatrix < secondMatrix)
            {
                Console.WriteLine("Детерминант второй матрицы меньше.");
            }
            else
            {
                Console.WriteLine("Детерминанты равны.");
            }

            MathMatrix inverseMatrix1 = firstMatrix.Inverse();
            Console.WriteLine("Обратная первая матрица:");
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