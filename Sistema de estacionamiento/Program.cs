using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_estacionamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                                     SISTEMA DE ESTACIONAMIENTOS");
            Console.WriteLine("Puede ingresar o retirar vehículos de 2 pisos, cada uno con 5 estacionamientos");
            //Arreglo de estacionamientos, dos pisos y 5 espacios cada uno
            int[,] Estacionamientos = new int[2, 5];
            //Arreglo que almacena las horas de entrada, dos pisos y 5 espacios cada uno
            int[,] HorasEntrada = new int[2, 5];
            //Arreglo que almacena la placa, hora de entrada y hora de salida en ese orden
            int[] DatosFactura = new int[3];
            //Variable utilizada para determinar si se sale del sistema o no
            int Salir = 0;
            //Ciclo Do While principal, se ejecuta hasta que el usuario desea salir

            do
            {
                Console.WriteLine("");
                Console.WriteLine("¿Qué acción desea realizar?");
                Console.WriteLine("Digite 1 para ingresar un auto");
                Console.WriteLine("Digite 2 para retirar un auto");
                //Variable que almacena la decisión de operación a realizar en el switch
                int DecisionOperacion = Convert.ToInt32(Console.ReadLine());
                //Switch de operación a realizar
                switch (DecisionOperacion)
                {
                    //Caso 1, ingreso de placas
                    case 1:
                        //Variable que almacena la decisión de salir del módulo de ingreso de placas
                        int SalirIngreso = 0;
                        //Variable que almacena si ya no quedan estacionamientos disponibles o no
                        bool Lleno = false;
                        //Do while de ingreso de placas 
                        do
                        {
                            //Variable utilizada para almacenar la cantidad de espacios ocupados
                            int EspaciosOcupados = 0;
                            //Foreach que recorre todos los estacionamientos
                            foreach (int Posicion in Estacionamientos)
                            {
                                //Si la posicion nos es igual a 0, osea que está vacía, se aumenta la variable
                                //contadora de espacios ocupados
                                if (Posicion != 0)
                                {
                                    EspaciosOcupados++;
                                }
                            }
                            //Si los espacios ocupados con mas o igual a la cantidad de estacionamientos, devuelve
                            //un error y convierte a la variable Lleno en verdadera
                            if (EspaciosOcupados >= Estacionamientos.Length)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("No se puede ingresar el auto");
                                Lleno = true;
                            }
                            //Si los estacionamientos no estan llenos, se procede a leer los datos del ingreso
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese la placa del auto");
                                //Variable que almacena la placa a guardar 
                                int PlacaEntrada = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese la hora de entrada");
                                //Variable que almacena la hora de entrada
                                int HoraEntrada = Convert.ToInt32(Console.ReadLine());
                                //If que verifica que la hora de entrada este dentro del formato 24 horas y 
                                //presenta un error si no se cumple
                                if (HoraEntrada > 23 || HoraEntrada < 0)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Solo se permiten horas entre 00:00 y 23:00");
                                    break;
                                }
                                //Variable que se utiliza para verificar que la placa ya fue ingresada y evitar
                                //ingresarla en otros espacios vacíos
                                int Ingresado = 0;
                                //Variable que guarda la posicion actual dentro del arreglo
                                int PosicionColocado = 0;
                                //For que recorre las filas del arreglo de estacionamientos
                                for (int Fila = 0; Fila < Estacionamientos.GetLength(0); Fila++)
                                {
                                    //For que recorre las columnas dentro de cada fila
                                    for (int Columna = 0; Columna < Estacionamientos.GetLength(1); Columna++)
                                    {
                                        //If que verifica si el estacionamiento esta vacío y si no se ha ingresado la placa
                                        if (Estacionamientos[Fila, Columna] == 0 && Ingresado == 0)
                                        {
                                            //Se asigna la plaza al estacionamiento en posicion de la fila y columna vacía
                                            Estacionamientos[Fila, Columna] = PlacaEntrada;
                                            //Se utilizan estas mismas posiciones para guardar la hora ya que ambos arreglos
                                            //tienen el mismo formato
                                            HorasEntrada[Fila, Columna] = HoraEntrada;
                                            Console.WriteLine("");
                                            Console.WriteLine("Su auto ha sido asignado al estacionamiento #" + (PosicionColocado + 1));
                                            //Se aumenta la variable lo cual evita que la placa y hora se guarden mas de una vez
                                            Ingresado++;
                                            //Se sale de los ciclos for
                                            break;
                                        }
                                        //Variable que guarda la posición colocada es aumentada en caso tal no se de el break de los for
                                        PosicionColocado++;
                                    }
                                }
                            }
                            //Si los estacionamientos estan llenos, se sale del ciclo de Ingreso de placas aumentando la variable del Do while
                            if (Lleno == true)
                            {
                                SalirIngreso++;
                            }
                            //Si los estacionamientos nos estan llenos, se le pregunta al usuario si desea ingresar otro auto
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("¿Desea ingresar otro auto?");
                                Console.WriteLine("Digite 1 para SI ó 2 para NO");
                                //Variable que almacena la decision del usuario sobre otro ingreso de placa
                                int DecisionIngreso = Convert.ToInt32(Console.ReadLine());
                                //Si la decision es 2, osea cierta, se aumenta la variable del Do while
                                if (DecisionIngreso == 2)
                                {
                                    SalirIngreso++;
                                }
                            }
                        } while (SalirIngreso == 0);
                        //Break del caso de ingreso de placas
                        break;
                    //Caso 2 , retiro de placas
                    case 2:
                        //Variable que almacena la cantidad de espacios vacios
                        int EspaciosVacios = 0;
                        //Foreach que recorre todos los estacionamientos
                        foreach (int Posicion in Estacionamientos)
                        {
                            //Si la posicion es 0, osea que está vacía, se aumenta la variable de espacios vacíos
                            if (Posicion == 0)
                            {
                                EspaciosVacios++;
                            }
                        }
                        //Si los espacios vacios son mas o igual a la cantidad de estacionamientos, devuelve un error
                        if (EspaciosVacios >= Estacionamientos.Length)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No hay autos estacionados");
                        }
                        //Si los estacionamientos no están vacíos, se procede a leer los datos del retiro
                        else
                        {
                            //Variable que almacena si la placa existe en el sistema o no
                            bool PlacaExiste = false;
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese la placa del auto a retirar");
                            //Variable que almacena la placa a retirar
                            int PlacaSalida = Convert.ToInt32(Console.ReadLine());
                            //Variable que almacena el estacionamiento de la placa
                            int PosicionSalida = 0;
                            //foreach que recorre todos los estacionamientos
                            foreach (int BuscarPlaca in Estacionamientos)
                            {
                                //Si la posicion tiene como valor la placa que se desea retirar, se dice que la placa existe y se 
                                //indica el numero de estacionamiento
                                if (BuscarPlaca == PlacaSalida)
                                {
                                    PlacaExiste = true;
                                    Console.WriteLine("");
                                    Console.WriteLine("Su auto se encuentra en el estacionamiento #" + (PosicionSalida + 1));
                                }
                                //Se aumenta la posicion por cada recorrido del foreach
                                PosicionSalida++;
                            }
                            //Si los estacionamientos no están llenos, se procede a leer la hora y completar el procedimiento de 
                            //retiro
                            if (PlacaExiste != false)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese la hora de salida");
                                //Variable que almacena la hora de salida
                                int HoraSalida = Convert.ToInt32(Console.ReadLine());
                                //if que verifica que la hora de entrada este dentro del formato 24 horas y presenta un error si
                                //no se cumple
                                if (HoraSalida > 23 || HoraSalida < 0)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Solo se permiten horas entre 00:00 y 23:00");
                                    break;
                                }
                                //Variable que se utiliza para verificar que la placa ya fue retirada y evitar recorrer el resto
                                //del arreglo
                                int Retirado = 0;
                                //for que recorre las filas del arreglo de estacionamientos
                                for (int Fila = 0; Fila < Estacionamientos.GetLength(0); Fila++)
                                {
                                    //for que recorre las columnas dentro de cada fila
                                    for (int Columna = 0; Columna < Estacionamientos.GetLength(1); Columna++)
                                    {
                                        //If que verifica si el estacionamiento contiene la placa y la placa no ha sido retirada
                                        if (Estacionamientos[Fila, Columna] == PlacaSalida && Retirado == 0)
                                        {
                                            //if que verifica si la hora de salida es menor a la hora de entrada y devuelve un
                                            //error si se cumple
                                            if (HoraSalida < HorasEntrada[Fila, Columna])
                                            {
                                                Console.WriteLine("La hora de salida no puede ser menor a la hora de entrada");
                                                break;
                                            }
                                            //Si las horas estan bien, se procede con el proceso de retiro
                                            else
                                            {
                                                //Se guarda la placa en la primera posición del arreglo que almacena los datos de factura
                                                DatosFactura[0] = PlacaSalida;
                                                //Se guarda la hora de entrada en la segunda posicion del arreglo que almacena los datos
                                                //de factura
                                                DatosFactura[1] = HorasEntrada[Fila, Columna];
                                                //Se guarda la hora de salida en la tercera posicion del arreglo que almacena los datos
                                                //de factura
                                                DatosFactura[2] = HoraSalida;
                                                //Se vacía la posicion donde se encontraba la placa
                                                Estacionamientos[Fila, Columna] = 0;
                                                //Se vacía la posicion donde se encontraba la hora de la placa
                                                HorasEntrada[Fila, Columna] = 0;
                                                Console.WriteLine("");
                                                Console.WriteLine("****Auto Retirado****");
                                                //Se aumenta la variable lo cual evita que siga buscando la placa retirada
                                                Retirado++;
                                                //Se sale de los ciclos for
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            //Si no se encuentra la placa, se levanta un error
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Placa errada, intente de nuevo");
                            }
                        }
                        //Break del caso de retiro de placas
                        break;
                }
                //If que verifica la primera posicion de los datos de factura, si este valor no es 0, quiere decir que debe
                //procesar una facturación
                if (DatosFactura[0] > 0)
                {
                    //Variable que almacena la placa a facturar
                    int PlacaFactura = DatosFactura[0];
                    //Variable que almacena la hora de entrada
                    int InicioCobro = DatosFactura[1];
                    //Variable que almacena la hora de salida
                    int FinCobro = DatosFactura[2];
                    //Variable que almacena el total de horas a cobrar
                    int HorasPorFacturar = (FinCobro - InicioCobro);
                    //Variable que almacena el subtotal
                    decimal Subtotal = 0;
                    //Variable que almacena el total
                    decimal Total = 0;
                    //If que determina si fue una hora o menos y se pone un precio fijo
                    if (HorasPorFacturar <= 1)
                    {
                        Subtotal = 2.50m;
                    }
                    //Else que multiplica el total de horas por el precio por hora
                    else
                    {
                        Subtotal = HorasPorFacturar * 2.50m;
                    }
                    //Asignamos el total como el subtotal * 1.07m para incluir el 7% de impuesto
                    Total = Subtotal * 1.07m;
                    //Asignamos el total como el redondeo del total con dos decimales
                    Total = Decimal.Round(Total, 2);
                    Console.WriteLine("");
                    Console.WriteLine("Factura para placa: " + PlacaFactura);
                    Console.WriteLine("Horas estacionadas: " + HorasPorFacturar);
                    Console.WriteLine("El total a cancelar es: " + Total);
                    //Se vacía el arreglo de datos de factura para evitar facturar nuevamente la misma placa
                    DatosFactura[0] = 0;
                    DatosFactura[1] = 0;
                    DatosFactura[2] = 0;
                }
                Console.WriteLine("");
                Console.WriteLine("¿Desea salir del sistema?");
                Console.WriteLine("Digite 1 para SI ó 2 para NO");
                //Variable que almacena la decisión del usuario sobre salir del sistema
                int DecisionSalida = Convert.ToInt32(Console.ReadLine());
                //Si la decision es 1, se procede a aumentar la variable que controla el Do while lo cual nos saca del sistema
                if (DecisionSalida == 1)
                {
                    Salir++;
                }
            } while (Salir == 0);
        }   
    }
}
