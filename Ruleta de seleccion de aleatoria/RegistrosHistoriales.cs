class RegistrosHistoriales{

    public static List<string> alumno = new List<string>(); 
    public static string Historial = @"HISTORIAL.txt";
    public static string ArchivoParticipantes = @"ArchivoParticipantes.txt";
    public static string archivoUltimaSeleccion = @"UltimaSeleccion.txt";
    public static string[] rol = new string[alumno.Count];  
    public static bool[] asignadoDesarrollador = new bool[alumno.Count]; 
    public static bool[] asignadoFacilitador = new bool[alumno.Count];
    public static bool continuar = true;


    public static void CargarArhivoParticipantes(){

        if (!File.Exists(ArchivoParticipantes)) {
        using (StreamWriter sw = File.CreateText(ArchivoParticipantes)) {
        }
        }

        var participantesFromFile = File.ReadAllLines(ArchivoParticipantes);
        alumno.Clear(); 

        foreach (var participante in participantesFromFile) {
            if (!string.IsNullOrEmpty(participante)) {
                alumno.Add(participante.Trim().ToLower());
            }
        }
        Array.Resize(ref rol, alumno.Count);
        Array.Resize(ref asignadoDesarrollador, alumno.Count);
        Array.Resize(ref asignadoFacilitador, alumno.Count);
    }

    
    public static void HistorialDeSeleccion(){

        if (File.Exists(archivoUltimaSeleccion) && new FileInfo(archivoUltimaSeleccion).Length > 0)
        {
            Console.WriteLine("\n 📖 Historial de selecciones: 📖");
            Console.WriteLine("═════════════════════════════════════");
            string[] UltimaSeleccion = File.ReadAllLines(archivoUltimaSeleccion);

            Array.Sort(UltimaSeleccion);
                for (int i = 0; i < UltimaSeleccion.Length; i++){
                string linea_por_linea = UltimaSeleccion[i];

                Console.WriteLine($"{i + 1}: {linea_por_linea}");
            }
            Console.WriteLine("═════════════════════════════════════");
        }
        else
        {
            validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
            Console.WriteLine("❌ No hay historial registrado o el archivo está vacío.");
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.Read();
        return;
    }

    public static void EliminarHistorialUltimaSeleccion(){

        if (File.Exists(archivoUltimaSeleccion))
        {
            // Eliminar el archivo completo
            File.Delete(archivoUltimaSeleccion);

            validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine("✅ Historial de la última selección eliminado.");
        }else{
            Console.WriteLine("❌ El archivo 'UltimaSeleccion.txt' no existe.");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.Read();
    }



    public static void GuardarHistorial(string estudiante, string rol){
       
        try
        {

            using (StreamWriter writer = new StreamWriter(Historial, true))
            {
                writer.WriteLine($"{DateTime.Now} - {estudiante} - {rol}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al guardar el historial: " + ex.Message);
        }
    }

    public static void GuardarUltimaSeleccion(string estudiante, string rol) {
        try {
            using (StreamWriter writer = new StreamWriter(@"UltimaSeleccion.txt", true)) 
            {
                writer.WriteLine($"{DateTime.Now} - {estudiante} - {rol}");
            }
        } catch (Exception ex) 
        {
            Console.WriteLine("❌ Error al guardar la última selección: " + ex.Message);
        }
    }

}