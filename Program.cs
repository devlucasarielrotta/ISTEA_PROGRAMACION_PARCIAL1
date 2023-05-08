
    internal class Program
{
    static void Main(string[] args)
    {   
        int[] cancionesSegundosArray = { 110, 120, 130, 105, 115 };
        int[] cancionesSegundosArray2 = { 0, 0, 0, 0, 0 }; // Esto se declara asi porque son 5 canciones por disco. 

        int maximo = cancionesSegundosArray[0];
        int cancionesAceptadas = 0;
        int cancionesRechazadas = 0;
        const int PRECIOPORCANCION = 500;
        int abonoTotal = 0;
        int duracionDisco1 = 0;
        int duracionDisco2 = 0;
        int segundosUsados = 0;
        const int SEGUNDOSMAXPORDISCO = 360;
        String salida = "";

        // TODO esto se debe ejecutar antes de ingresar a cualquier opcion del switch menu
        // ya que asi ya tenemos todo ordenado para poder mostrar la info solicitada


        // Recorremos las canciones para verificar cual excede el tiempo de 120s y validamos al mismo tiempo cuantas fueron aceptadas y rechazadas
        for (int i = 0; i < cancionesSegundosArray.Length; i++)
        {

            if (cancionesSegundosArray[i] > 120)
            {

                cancionesSegundosArray[i] = 0;
                cancionesRechazadas++;

            }
            else
            {
                cancionesAceptadas++;
            }
        }
        // Recorremos las canciones para obtener la de mayor duración 
        for (int i = 1; i < cancionesSegundosArray.Length; i++)
        {

            if (cancionesSegundosArray[i] > maximo)
            {
                maximo = cancionesSegundosArray[i];
            }
        }

        // Recorremos el primer array para saber cuando excedemos el limite de segundos y asi guardamos la cancion en el array2
        for (int i = 0; i < cancionesSegundosArray.Length; i++)
        {
            segundosUsados += cancionesSegundosArray[i];

            if (segundosUsados > SEGUNDOSMAXPORDISCO)
            {
                cancionesSegundosArray2[i] = cancionesSegundosArray[i];
                cancionesSegundosArray[i] = 0;
            }

        }
        abonoTotal = PRECIOPORCANCION * cancionesAceptadas;
        int opcion;

        do {
            Console.WriteLine("1.Ver canción más larga, canciones aceptadas/rechazadas y el abono total.\n" +
                "2.Ver la duración de las canciones y a cuales discos pertenecen.\n" +
                "3.Ver el top 3 de canciones más largas.\n" +
                "0.Salir");
            opcion = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcion) {
                case 1:
                    
                    // OPCION 1 
                    Console.WriteLine("La duracion de la canción mas larga es: " + maximo + " segundos.");
                    Console.WriteLine("Canciones Aceptadas: " + cancionesAceptadas + " y canciones rechazadas: " + cancionesRechazadas);
                    Console.WriteLine("El abono total es de $" + abonoTotal + ".");
                    Console.WriteLine("\nPresione enter para continuar....");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    
                    // OPCION 2
                    // recorremos los arrays para obtener su informacion
                    for (int i = 0; i < cancionesSegundosArray.Length; i++)
                    {
                        salida += $"Posicion: {i}, Duracion en segundos: {cancionesSegundosArray[i]}, Disco 1.\n";
                        duracionDisco1 += cancionesSegundosArray[i];
                    }
                    for (int i = 0; i < cancionesSegundosArray2.Length; i++)
                    {
                        salida += $"Posicion: {i}, Duracion en segundos: {cancionesSegundosArray2[i]}, Disco 2.\n";
                        duracionDisco2 += cancionesSegundosArray2[i];
                    }

                    Console.WriteLine("Canciones:" + salida);
                    Console.WriteLine("Duracion de los discos: \n" + "Disco 1: " + duracionDisco1 + " segundos " + "\nDisco 2: " + duracionDisco2 + " segundos " + "\n");

                    Console.WriteLine("\nPresione enter para continuar....");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:

                    // OPCION 3
                    // declaramos el merge de arrays
                    int[] cancionesSegundosArray3 = new int[cancionesSegundosArray.Length + cancionesSegundosArray2.Length];

                    // llenamos el array3
                    for (int i = 0, j = cancionesSegundosArray2.Length; i < cancionesSegundosArray.Length; i++)
                    {
                        cancionesSegundosArray3[i] = cancionesSegundosArray[i];

                        cancionesSegundosArray3[j + i] = cancionesSegundosArray2[i];

                    }


                    // lo ordenamos con metodo de ordenamiento burbuja
                    for (int i = 0; i < cancionesSegundosArray3.Length; i++)
                    {

                        for (int j = 0; j < cancionesSegundosArray3.Length - 1; j++)
                        {
                            if (cancionesSegundosArray3[j] < cancionesSegundosArray3[j + 1])
                            {
                                int aux = cancionesSegundosArray3[j];
                                cancionesSegundosArray3[j] = cancionesSegundosArray3[j + 1];
                                cancionesSegundosArray3[j + 1] = aux;

                            }


                        }

                    }

                    salida = "";

                    for (int i = 0; i < 3; i++)
                    {
                        salida += "\n" + cancionesSegundosArray3[i];
                    }
                    Console.WriteLine("Canciones con mas duración (expresado en segundos): " + salida);
                    Console.WriteLine("\nPresione enter para continuar....");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 0:
                    Console.WriteLine("Hasta luego");

                    
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta, vuelva a intentar por favor\nPresione enter para continuar....");
                    Console.ReadLine();
                    Console.Clear();
                    break;

            }
            
        } while (opcion != 0);

        


  


    }
}
