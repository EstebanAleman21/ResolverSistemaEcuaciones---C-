using System;

namespace Act6
{
    class Program
    {
        static void Main()
        {
            double[,] coeficientes = new double[3, 4];

            // Solicitar los coeficientes al usuario
            Console.WriteLine("Ingrese los coeficientes de las tres ecuaciones separados por espacios:");
            for (int i = 0; i < 3; i++)
            {
                string[] entrada = Console.ReadLine().Split(' ');
                for (int j = 0; j < 4; j++)
                {                    coeficientes[i, j] = double.Parse(entrada[j]);
                }
            }

            // Resolver el sistema de ecuaciones
            double[] solucion = ResolverSistema(coeficientes);

            // Verificar si la matriz no tiene solución
            if (double.IsNaN(solucion[0]))
            {
                Console.WriteLine("La matriz no tiene solución.");
            }
            else
            {
                Console.WriteLine("Solución encontrada:");
                Console.WriteLine($"x = {solucion[0]}, y = {solucion[1]}, z = {solucion[2]}");
            }
        }

        static double[] ResolverSistema(double[,] coeficientes)
        {
            double[] solucion = new double[3];

            // Aplicar el método de Gauss
            for (int i = 0; i < 3; i++)
            {
                // Pivoteo parcial
                for (int k = i + 1; k < 3; k++)
                {
                    if (Math.Abs(coeficientes[i, i]) < Math.Abs(coeficientes[k, i]))
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            double temp = coeficientes[i, j];
                            coeficientes[i, j] = coeficientes[k, j];
                            coeficientes[k, j] = temp;
                        }
                    }
                }

                // Eliminación gaussiana
                for (int k = i + 1; k < 3; k++)
                {
                    double factor = coeficientes[k, i] / coeficientes[i, i];
                    for (int j = i; j <= 3; j++)
                    {
                        coeficientes[k, j] -= factor * coeficientes[i, j];
                    }
                }
            }

            // Sustitución hacia atrás
            for (int i = 2; i >= 0; i--)
            {
                solucion[i] = coeficientes[i, 3];
                for (int j = i + 1; j < 3; j++)
                {
                    solucion[i] -= coeficientes[i, j] * solucion[j];
                }
                solucion[i] /= coeficientes[i, i];
            }

            return solucion;
        }
    }
}
