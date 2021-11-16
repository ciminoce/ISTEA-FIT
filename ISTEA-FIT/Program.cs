using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTEA_FIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("ISTEA-FIT");
            Console.Write("Ingrese la cantidad de días a cargar:");
            var cantidadDias = int.Parse(Console.ReadLine());
            if (cantidadDias<=0)
            {
                Console.WriteLine("Debe ingresar una cantidad superior a 0");
                Console.ReadLine();
                return;
            }
            var PasosPorDia = new int[cantidadDias];
            for (int i = 0; i < cantidadDias; i++)
            {
                //Console.Write($"Pasos del día {i+1}:");
                Console.Write($"Pasos del día {i}:");
                PasosPorDia[i] = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            do
            {
                MostrarVector(PasosPorDia);//esto lo podés anular
                CrearMenu();
                Console.Write("Ingrese la opción de menú:");
                var opcionMenu = int.Parse(Console.ReadLine());
                switch (opcionMenu)
                {
                    case 0:
                        return;
                    case 1:
                        var totalPasos = SumarPasos(PasosPorDia);
                        Console.WriteLine($"Se dieron {totalPasos} pasos en el período");
                        break;
                    case 2:
                        var caloriasPerdidas = CalcularCaloriasPerdidas(SumarPasos(PasosPorDia));
                        Console.WriteLine($"Calorías perdidas en el período: {caloriasPerdidas}");
                        break;
                    case 3:
                        var promedioCalorias = PromedioCaloriasQuemadas(PasosPorDia);
                        Console.WriteLine($"Calorías perdidas promedio en el período: {promedioCalorias}");
                        break;

                    case 4:
                        var maximaActividad = BuscarDiaMayorActividad(PasosPorDia);
                        Console.WriteLine($"Día de mayor actividad:{maximaActividad}");
                        break;
                    case 5:
                        var menorActividad = BuscarDiaMenorActividad(PasosPorDia);
                        Console.WriteLine($"Día de menor actividad:{menorActividad}");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Presione tecla para continuar");
                Console.ReadLine();
            } while (true); 
        }

        private static void MostrarVector(int[] pasosPorDia)
        {
            foreach (var i in pasosPorDia )
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        private static int PromedioCaloriasQuemadas(int[] pasosPorDia)
        {
            //var promedio = 0;
            //foreach (var i in pasosPorDia)
            //{
            //    var caloriasDia = CalcularCaloriasPerdidas(i);
            //    promedio += caloriasDia;
            //}

            //return promedio / pasosPorDia.Length;
            return CalcularCaloriasPerdidas(SumarPasos(pasosPorDia)) / pasosPorDia.Length;
        }

        private static int BuscarDiaMenorActividad(int[] pasosPorDia)
        {
            var menor = int.MaxValue;
            var menorDia = -1;
            for (int dia = 0; dia < pasosPorDia.Length; dia++)
            {
                if (pasosPorDia[dia] < menor)
                {
                    menor = pasosPorDia[dia];
                    menorDia = dia;
                }
                
            }

            return menorDia;
        }

        private static int BuscarDiaMayorActividad(int[] pasosPorDia)
        {
            var mayor = 0;
            var mayorDia = -1;
            for (int dia = 0; dia < pasosPorDia.Length; dia++)
            {
                if (pasosPorDia[dia]>mayor)
                {
                    mayor = pasosPorDia[dia];
                    mayorDia = dia;
                }

            }

            return mayorDia;
        }

        private static int CalcularCaloriasPerdidas(int sumarPasos)
        {
            return sumarPasos * 30 / 1000;
        }

        private static int SumarPasos(int[] pasosPorDia)
        {
            var cantidadPasos = 0;
            foreach (var i in pasosPorDia)
            {
                cantidadPasos += i;
            }

            //return pasosPorDia.Sum();
            return cantidadPasos;
        }

        private static void CrearMenu()
        {
            Console.WriteLine("Menú para Obtener Información");
            Console.WriteLine("0-Salir");
            Console.WriteLine("1-Total de pasos");
            Console.WriteLine("2-Ver calorias perdidas totales");
            Console.WriteLine("3-Calcular cantidad promedio de calorías quemadas");
            Console.WriteLine("4-Determinar dia de mayor actividad");
            Console.WriteLine("5-Determinar dia de menor actividad");
        }
    }
}
