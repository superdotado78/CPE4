using System;
using System.Collections.Generic;
using System.Linq;

class Vuelo
{
    public string Origen { get; set; }
    public string Destino { get; set; }
    public decimal Precio { get; set; }
    public string Aerolinea { get; set; }

    public Vuelo(string origen, string destino, decimal precio, string aerolinea)
    {
        Origen = origen;
        Destino = destino;
        Precio = precio;
        Aerolinea = aerolinea;
    }

    public override string ToString()
    {
        return $"Origen: {Origen}, Destino: {Destino}, Precio: ${Precio}, Aerolínea: {Aerolinea}";
    }
}

class Program
{
    static void Main()
    {
        // Base de datos extendida de vuelos
        List<Vuelo> vuelos = new List<Vuelo>
        {
            // Nacionales
            new Vuelo("Quito", "Guayaquil", 75, "LATAM"),
            new Vuelo("Quito", "Cuenca", 60, "Avianca"),
            new Vuelo("Quito", "Loja", 65, "TAME"),
            new Vuelo("Guayaquil", "Cuenca", 58, "EquAir"),
            new Vuelo("Loja", "Quito", 68, "LATAM"),
            new Vuelo("Quito", "Manta", 50, "Avianca"),
            new Vuelo("Manta", "Guayaquil", 40, "TAME"),

            // Internacionales
            new Vuelo("Quito", "Bogotá", 220, "Avianca"),
            new Vuelo("Quito", "Lima", 310, "LATAM"),
            new Vuelo("Quito", "Miami", 480, "American"),
            new Vuelo("Guayaquil", "Madrid", 820, "Iberia"),
            new Vuelo("Quito", "Panamá", 270, "Copa"),
            new Vuelo("Quito", "Buenos Aires", 640, "Aerolineas Argentinas"),
            new Vuelo("Guayaquil", "Nueva York", 510, "JetBlue"),
            new Vuelo("Cuenca", "Bogotá", 250, "Avianca"),
            new Vuelo("Manta", "Lima", 300, "LATAM"),
            new Vuelo("Quito", "Santiago", 590, "Sky Airline"),
            new Vuelo("Guayaquil", "Miami", 470, "American"),
            new Vuelo("Quito", "Madrid", 790, "Iberia"),
            new Vuelo("Guayaquil", "Londres", 890, "British Airways"),
            new Vuelo("Quito", "Ciudad de México", 410, "Aeroméxico")
        };

        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE CONSULTA DE VUELOS ===");
            Console.WriteLine("Jorge Diaz, Fernado Corrales, Nataly Anchundia\n");
            Console.WriteLine("1. Consultar vuelos");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese ciudad de origen: ");
                    string origen = Console.ReadLine() ?? "";
                    Console.Write("Ingrese ciudad de destino: ");
                    string destino = Console.ReadLine() ?? "";

                    var vuelosFiltrados = vuelos
                        .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase)
                                 && v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(v => v.Precio)
                        .ToList();

                    if (vuelosFiltrados.Count == 0)
                    {
                        Console.WriteLine($"No se encontraron vuelos desde {origen} a {destino}.");
                    }
                    else
                    {
                        Console.WriteLine($"\nVuelos encontrados desde {origen} a {destino}:");
                        foreach (var vuelo in vuelosFiltrados)
                        {
                            Console.WriteLine(vuelo);
                        }
                        Console.WriteLine($"\nEl vuelo más barato cuesta: ${vuelosFiltrados.First().Precio}");
                    }
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 2);
    }
}
