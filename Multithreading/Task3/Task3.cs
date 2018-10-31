using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        private static Random rnd = new Random();
        private const int MATRIX_SIZE = 250;
        private const int MATRIX_MAX_PRINT_SIZE = 6;
        static void Main(string[] args)
        {
            Console.Write("Enter Matrix (N*N) size N: ");
            var sizeString = Console.ReadLine();

            var sizeInt = MATRIX_SIZE;
            if (!int.TryParse(sizeString, out sizeInt) || sizeInt<=0) Console.WriteLine("Invalid Matrix size! Using default size: " + MATRIX_SIZE);

            if (sizeInt > MATRIX_MAX_PRINT_SIZE) Console.WriteLine("Matrix is too big for printing");

            var console = new StringBuilder();
            try
            {
                var matrixA = MatrixCreate(sizeInt, sizeInt);
                var matrixB = MatrixCreate(sizeInt, sizeInt);

                console.AppendLine("Matrix Fill.");
                var watch1 = Stopwatch.StartNew();
                MatrixFill(matrixA, FillNotParallel);
                MatrixFill(matrixB, FillNotParallel);
                watch1.Stop();
                
                var watch2 = Stopwatch.StartNew();
                MatrixFill(matrixA, FillParallel);
                MatrixFill(matrixB, FillParallel);
                watch2.Stop();

                if (sizeInt <= MATRIX_MAX_PRINT_SIZE)
                {
                    console.AppendLine("Matrix A:");
                    console.AppendLine(MatrixPrint(matrixA).ToString());
                    console.AppendLine("Matrix B:");
                    console.AppendLine(MatrixPrint(matrixB).ToString());
                }

                console.AppendFormat("Not Parallel time: {0} ms{1}", watch1.ElapsedMilliseconds, Environment.NewLine);
                console.AppendFormat("Parallel time: {0} ms{1}", watch2.ElapsedMilliseconds, Environment.NewLine);

                console.AppendLine();

                console.AppendLine("A*B:");
                watch1 = Stopwatch.StartNew();
                var result = MatrixMultiply(matrixA, matrixB, MultiplyNotParallel);
                watch1.Stop();

                watch2 = Stopwatch.StartNew();
                result = MatrixMultiply(matrixA, matrixB, MultiplyParallel);
                watch2.Stop();

                if (sizeInt <= MATRIX_MAX_PRINT_SIZE)
                {
                    console.AppendLine(MatrixPrint(result).ToString());
                }

                console.AppendFormat("Not Parallel time: {0} ms{1}", watch1.ElapsedMilliseconds, Environment.NewLine);
                console.AppendFormat("Parallel time: {0} ms{1}", watch2.ElapsedMilliseconds, Environment.NewLine);
                console.AppendLine();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Console.WriteLine(console.ToString());
            }
            
            Console.ReadLine();
        }


        private static double[][] MatrixCreate(int rows, int cols)
        {
            // do error checking here
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        private static StringBuilder MatrixPrint(double[][] matrix)
        {
            var result = new StringBuilder();
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            for (int row = 0; row < rows; row++)
                result.AppendLine(String.Join(" | ", matrix[row]));
            return result;
        }

        private static void MatrixFill(double[][] matrix, FillHandler FillHandler)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            FillHandler(matrix, rows, cols);
        }

        private static double[][] MatrixMultiply(double[][] matrixA, double[][] matrixB, MultiplicationHandler MultiplicationHandler)
        {
            // do error checking here
            var Arows = matrixA.Length;
            var Acols = matrixA[0].Length;

            var Brows = matrixB.Length;
            var Bcols = matrixB[0].Length;

            if (Acols != Brows) throw new Exception();

            double[][] result = MatrixCreate(Arows, Bcols);

            MultiplicationHandler(matrixA, matrixB, result, Arows, Acols, Bcols);
            return result;
        }

        private delegate void MultiplicationHandler(double[][] matrixA, double[][] matrixB, double[][] result, int Arows, int Acols, int Bcols);

        private static void MultiplyParallel(double[][] matrixA, double[][] matrixB, double[][] result, int Arows, int Acols, int Bcols)
        {
            Parallel.For(0, Arows, row =>
            {
                Multiply(matrixA, matrixB, result, Acols, Bcols, row);
            });
        }

        private static void MultiplyNotParallel(double[][] matrixA, double[][] matrixB, double[][] result, int Arows, int Acols, int Bcols)
        {
            for (int row = 0; row < Arows; row++)
                Multiply(matrixA, matrixB, result, Acols, Bcols, row);
        }

        private static void Multiply(double[][] matrixA, double[][] matrixB, double[][] result, int Acols, int Bcols, int row)
        {
            for (int col = 0; col < Bcols; col++)
                for (int newCol = 0; newCol < Acols; newCol++)
                    result[row][col] += matrixA[row][newCol] * matrixB[newCol][col];
        }

        private delegate void FillHandler(double[][] matrix, int rows, int cols);

        private static void FillParallel(double[][] matrix, int rows, int cols)
        {
            Parallel.For(0, rows, row =>
            {
                Fill(matrix, cols, row);
            });
        }

        private static void FillNotParallel(double[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
                Fill(matrix, cols, row);
        }


        private static void Fill(double[][] matrix, int cols, int row)
        {
            for (int col = 0; col < cols; col++)
                matrix[row][col] = rnd.NextDouble();
        }
    }
}
