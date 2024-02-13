using System;
using System.Linq;

int[] factura = new int[15];
string[] placa = new string[15];
DateTime[] fecha = new DateTime[15];
int[] tipoVehiculo = new int[15];
string[] caseta = new string[15];
int[] montoaPagar = new int[15];
int[] pago = new int[15];
int[] vuelto = new int[15];
int indice = 0;
int total = 0;
Main();
void InicializarVectores()
{

    Console.WriteLine("-----Inicializando Vectores-----");
    factura = Enumerable.Repeat(0, 15).ToArray<int>();
    placa = Enumerable.Repeat("", 15).ToArray<string>();
    fecha = Enumerable.Repeat(DateTime.MinValue, 15).ToArray<DateTime>();    
    tipoVehiculo = Enumerable.Repeat(0, 15).ToArray<int>();
    caseta = Enumerable.Repeat("", 15).ToArray<string>();
    pago = Enumerable.Repeat(0, 15).ToArray<int>();
    montoaPagar = Enumerable.Repeat(0, 15).ToArray<int>();
    vuelto = Enumerable.Repeat(0, 15).ToArray<int>();


}

void IngresarPasoVehicular()
{
    int faltante = 0;
    int respuesta = 0;
    do
    {
        if (indice >= 10)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("No se puede ingresar mas datos");
            return;
        }
        
        factura[indice] = indice + 1;
        Console.WriteLine("Ingrese el numero de placa"); placa[indice] = Console.ReadLine();
        Console.WriteLine("Ingrese la fecha(dd/mm/aaaa): "); fecha[indice] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.WriteLine("Ingrese la hora(hh:mm): "); fecha[indice] = fecha[indice].Add(TimeSpan.Parse(Console.ReadLine()));
        Console.WriteLine("Ingrese el tipo de vehiculo;\n 1-Moto, 2-Vehiculo Liviano, 3-Camion, 4-Autobus"); tipoVehiculo[indice] = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite el numero de caseta: del 1 al 3"); caseta[indice] = Console.ReadLine();
        switch (tipoVehiculo[indice])
        {
            case 1:
                montoaPagar[indice] = 500; break;
            case 2:
                montoaPagar[indice] = 700; break;
            case 3:
                montoaPagar[indice] = 2700; break;
            case 4:
                montoaPagar[indice] = 3700; break;
            default:
                Console.WriteLine("No existe ese tipo de vehiculo");
                
                break;
        }
        
        Console.WriteLine("Digite el monto pagado por el cliente: "); pago[indice] = int.Parse(Console.ReadLine());
        if (montoaPagar[indice] > pago[indice])
        {
            Console.BackgroundColor = ConsoleColor.Red;
            faltante = montoaPagar[indice] - pago[indice];
            Console.WriteLine($"Le faltan {faltante} para poder completar su pago.");
            return;
        }
        else {
            vuelto[indice] = pago[indice] - montoaPagar[indice];
                }
        total = total + montoaPagar[indice];
        indice++;
        Console.WriteLine("Desea agregar mas: 1-Si 2-No");
        respuesta = int.Parse(Console.ReadLine());
    } while (respuesta == 1);
}

void ConsultarVehiculo()
{
    bool encontrado = false;
    Console.WriteLine("Digite la placa a buscar");
    string pla = Console.ReadLine();

    for (int i = 0; i < placa.Length; i++)
    {
        if (pla.Equals(placa[i]))
        {
            Console.WriteLine($"La placa numero {placa[i]} tiene la factura {factura[i]}\nTipo de vehiculo: {tipoVehiculo[i]}\nCaseta: {caseta[i]}\nMonto a Pagar: {montoaPagar[i]}\nPago con: {pago[i]}\nY el vuelto fue de: {vuelto[i]} ");
            encontrado = true;
            break;
        }
    }
    if (encontrado == false)
    {
        Console.WriteLine($"La placa{pla} no se encuentra");
    }
    Console.Clear();
}

void ModificarDatos()
{
    bool encontrado = false;
    Console.WriteLine("Digite la placa a buscar");
    string pla = Console.ReadLine();

    for (int i = 0; i < placa.Length; i++)
    {
        if (pla.Equals(placa[i]))
        {
            Console.WriteLine($"La placa numero {placa[i]} tiene la factura {factura[i]}\nTipo de vehiculo{tipoVehiculo[i]}\nCaseta: {caseta[i]}\nMonto a Pagar: {montoaPagar[i]}\nPago con: {pago[i]}\nY el vuelto fue de: {vuelto[i]} ");
            encontrado = true;
            Console.WriteLine("¿Qué dato desea modificar?");
            Console.WriteLine("1. Fecha y Hora");
            Console.WriteLine("2. Tipo de Vehiculo");
            Console.WriteLine("3. Placa");
            Console.WriteLine("4. Número de Caseta");
            Console.WriteLine("5. Monto Paga Cliente");
            Console.WriteLine("Ingrese el número de opción que desea modificar:");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la nueva fecha y hora (dd/mm/aaaa hh:mm): ");
                    fecha[i] = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);
                    break;
                case 2:
                    Console.Write("Ingrese el tipo de vehiculo;\n 1-Moto, 2-Vehiculo Liviano, 3-Camion, 4-Autobus"); tipoVehiculo[indice] = int.Parse(Console.ReadLine());
                    switch (tipoVehiculo[indice])
                    {
                        case 1:
                            montoaPagar[indice] = 500; break;
                        case 2:
                            montoaPagar[indice] = 700; break;
                        case 3:
                            montoaPagar[indice] = 2700; break;
                        case 4:
                            montoaPagar[indice] = 3700; break;
                        default:
                            Console.WriteLine("No existe ese tipo de vehiculo");
                            break;
                    }
                    break;
                case 3:
                    Console.Write("Ingrese la nueva placa: ");
                    placa[i] = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Ingrese el nuevo numero de caseta ");
                    caseta[i] = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Ingrese el nuevo monto que paga el cliente ");
                    pago[i] = int.Parse(Console.ReadLine());
                    if (montoaPagar[indice] > pago[indice])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Pago incompleto");
                        return;
                    }
                    else
                    {
                        vuelto[indice] = pago[indice] - montoaPagar[indice];
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
    if (encontrado == false)
    {
        Console.WriteLine($"La placa{pla} no se encuentra");
    }
    Console.Clear();
}
void Reporte()
{
   
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Factura          Placa         Tipo de Vehiculo      Caseta         Monto a pagar      Paga con       Vuelto");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        for (int i = 0; i < indice; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{factura[i]}                 {placa[i]}               {tipoVehiculo[i]}                {caseta[i]}               {montoaPagar[i]}               {pago[i]}                {vuelto[i]}");
        
        }
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"Cantidad de vehiculos: {indice}                                                          total: {total}");
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
    Console.Clear();
}
void Main()
        
   
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Datos");
            Console.WriteLine("3. Consultar Vehiculo");
            Console.WriteLine("4. Modificar Datos");
            Console.WriteLine("5. Reporte");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    IngresarPasoVehicular();
                    break;
                case 3:
                    ConsultarVehiculo();
                    break;
                case 4:
                    ModificarDatos();
                    break;
                case 5:
                    Reporte();
                    break;
                
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 6);
}

    