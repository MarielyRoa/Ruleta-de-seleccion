class Roles{

    public static void EditarRol(){

        Console.WriteLine("\n                     📝📝📝 EDITAR ROLES 📝📝📝                      ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        
        MenuParticipantes.Verparticipantes();
        Console.WriteLine("👩‍🏫Escriba el nombre del participante para editar su rol, O presione '0' para volver al menu: ");
        string nombre = Console.ReadLine() ?? "";

        if (nombre == "0") {
            Console.WriteLine("🔙 Regresando al menú principal...");
            return; 
        }

        if(string.IsNullOrWhiteSpace(nombre)){
            Console.WriteLine("Dato invalido");
            return;
        }
        if (int.TryParse(nombre, out _)) {
            Console.WriteLine("Dato inválido. El nombre no puede ser un número.");
            return;
        }

        for (int i = 0; i < RegistrosHistoriales.alumno.Count; i++)
        {
            if (RegistrosHistoriales.alumno[i].Equals(nombre, StringComparison.OrdinalIgnoreCase)){

                if (string.IsNullOrEmpty(RegistrosHistoriales.rol[i])) {
                    Console.WriteLine($"El participante {nombre} no tiene rol asignado aún.");
                }else{
                    Console.WriteLine($"El rol actual de {nombre} es: {RegistrosHistoriales.rol[i]}");
                }

        Console.WriteLine("Ingrese el nuevo rol: (Desarrollador en vivo) o (Facilitador de ejercicio) ");

        validacionesExtras.AnimarTexto("OJO, 👩‍🏫 Tambien puede ser un Rol personalizado 👨‍🎓",10);

        Console.WriteLine("Si desea regresar al menu puede presionar '0' ");
        
        string nuevoRol = Console.ReadLine() ?? "";

        if (nuevoRol == "0") {
            Console.WriteLine("🔙 Regresando al menú principal...");
            return; 
        }

        if (!string.IsNullOrEmpty(nuevoRol)) {
                    // Asignar el nuevo rol
            RegistrosHistoriales.rol[i] = nuevoRol;
            RegistrosHistoriales.GuardarHistorial(RegistrosHistoriales.alumno[i], nuevoRol);
            RegistrosHistoriales.GuardarUltimaSeleccion(RegistrosHistoriales.alumno[i], nuevoRol);

            validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine($"✅ {nombre} ha sido actualizado con el nuevo rol: {nuevoRol}");
        } else {
            Console.WriteLine("❌Rol inválido. No se realizó ningún cambio.");
            }
            break;
            }
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.Read();
   
    }
   
    public static void RolesAsignados(){
    

        Console.WriteLine("\n                     📝📝📝 ROLES ASIGNADOS 📝📝📝                   ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");


        // Verificar si el archivo existe y tiene contenido
        if (File.Exists(RegistrosHistoriales.Historial) && new FileInfo(RegistrosHistoriales.Historial).Length > 0)
        {
            Console.WriteLine("\n 📑Historial de Roles Asignados: 📘");
            Console.WriteLine("═════════════════════════════════════");
            string[] historial = File.ReadAllLines(RegistrosHistoriales.Historial);

            Array.Sort(historial);
                for (int i = 0; i < historial.Length; i++){
                string linea_por_linea = historial[i];

                Console.WriteLine($"{i + 1}: {linea_por_linea}");
            }
            Console.WriteLine("═════════════════════════════════════");
        }
        else
        {
            validacionesExtras.AnimarTexto("❌ No hay historial registrado o el archivo está vacío.",10);
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        return;
    }
}