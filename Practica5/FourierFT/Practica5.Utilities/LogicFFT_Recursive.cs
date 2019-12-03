using System;
using System.Numerics;

namespace FourierFT.Practica5.Utilities
{
    public static class LogicFFT_Recursive
    {
        public static Complex[] fft(Complex[] x)
        {
            int N = x.Length;
            if (N == 1)
            {
                return new Complex[] { x[0] };
            }
            else if (N % 2 != 0)
            {
                Console.WriteLine("ERROR");
                return null;
            }
            else
            {
                Complex[] even = new Complex[N / 2];
                for (int k = 0; k < N / 2; k++)
                {
                    even[k] = x[2 * k];
                }
                Complex[] q = fft(even);
                Complex[] odd = even; 
                for (int k = 0; k < N / 2; k++)
                {
                    odd[k] = x[2 * k + 1];
                }
                Complex[] r = fft(odd);
                Complex[] y = new Complex[N];
                for (int k = 0; k < N / 2; k++)
                {
                    double kth = -2 * k * Math.PI / N;
                    Complex wk = new Complex(Math.Cos(kth), Math.Sin(kth));
                    
                    y[k] = plus(q[k], times(wk, r[k]));
                    y[k + N / 2] = minus(q[k], times(wk, r[k]));
                }
                return y;
            }

        }

        private static Complex times(Complex a, Complex b)
        {
            //Complex a = this;
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imag = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imag);
        }
        private static Complex plus(Complex a, Complex b)
        {
            double real = a.Real + b.Real;
            double imag = a.Imaginary + b.Imaginary;
            return new Complex(real, imag);
        }

        private static Complex minus(Complex a, Complex b)
        {
            double real = a.Real - b.Real;
            double imag = a.Imaginary - b.Imaginary;
            return new Complex(real, imag);
        }
    }
}
    

    