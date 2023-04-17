
using System;

class Program
{
    // Calculates the n-th Bernoulli number
    static double BernoulliNumber(int n)
    {
        // B(0) is defined as 1
        if (n == 0) return 1;

        // Initialize array A with A[m] = 1 / (m + 1) for m = 0, 1, ..., n
        double[] A = new double[n + 1];
        for (int m = 0; m <= n; m++)
            A[m] = 1.0 / (m + 1);

        // Compute the remaining elements of array A using the backward recursion formula
        for (int j = 1; j <= n; j++)
            for (int m = n; m >= j; m--)
                A[m - 1] = m * (A[m - 1] - A[m]);

        // The Bernoulli number is A[0]
        return A[0];
    }

    // Calculates the integral of a function using the Euler-Maclaurin formula
    static double EulerMaclaurin(double a, double b, int n)
    {
        // Calculate the step size
        double h = (b - a) / n;

        // Calculate the first sum in the formula
        double sum1 = 0;
        for (int k = 1; k <= n - 1; k++)
        {
            double x = a + k * h;
            sum1 += BernoulliNumber(2 * k) * Math.Pow(h, 2 * k) / (2 * k);
        }

        // Calculate the second sum in the formula
        double sum2 = 0;
        for (int k = 0; k <= n; k++)
        {
            double x = a + k * h;
            sum2 += Math.Pow(-1, k) * BernoulliNumber(2 * k + 1) * Math.Pow(h, 2 * k + 1) / (2 * k + 1);
        }

        // The final result is the sum of the two sums
        return sum1 + sum2;
    }

    static void Main()
    {
        // Calculate and print the first 11 Bernoulli numbers
        for (int n = 0; n <= 10; n++)
        {
            double b = BernoulliNumber(n);
            Console.WriteLine("B({0}) = {1}", n, b);
        }

        // Calculate and print the integral of x^3 from 0 to 1 using the Euler-Maclaurin formula
        double result = EulerMaclaurin(0, 1, 10);
        Console.WriteLine("Result of Euler-Maclaurin formula: {0}", result);

        Console.ReadLine();
    }
}
