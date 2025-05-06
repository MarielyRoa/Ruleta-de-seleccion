class MenuParticipantes{

    public static void Participantes(){

        while(RegistrosHistoriales.continuar){
        Console.WriteLine("\n                       🎡🎡🎡Bienvenido a la seccion de participantes🎡🎡🎡");
        
        Console.WriteLine("  🔁══════════════════════════════════🔁 ");
        Console.WriteLine(" ‖    🎡⭕OPCIONES⭕🎡                  ‖");
        Console.WriteLine(" ‖ 1. Ver lista de participantes 📃      ‖");
        Console.WriteLine(" ‖ 2. Agregar participante 📖🖋          ‖");
        Console.WriteLine(" ‖ 3. Editar Nombre de participante 📖🖋 ‖");
        Console.WriteLine(" ‖ 4. Eliminar Participante ❌📃         ‖");
        Console.WriteLine(" ‖ 5. Editar Rol  📝                     ‖");
        Console.WriteLine(" ‖ 6. Volver al menu principal 🏠        ‖");
        Console.WriteLine(" ‖ 7. Salir 🔚                           ‖");
        Console.WriteLine("  🔁══════════════════════════════════🔁 ");


        Console.WriteLine("🔠 Seleccione una opción: ");
        string input2 = Console.ReadLine()?.Trim() ?? ""; // Captura la entrada y elimina espacios en blanco

        if (!int.TryParse(input2, out int opcion2)) // Intenta convertir a número
        {
            Console.WriteLine("❌ Opción inválida. Debe ingresar un número entre 1 y 7.");
            continue; // Vuelve a mostrar el menú si la conversión falla
        }

            switch(opcion2){

                case 1:
                    validacionesExtras.AnimarTexto("📋 Cargando lista de participantes... 📃", 10);
                    Verparticipantes(); 
                break;
                    
                case 2:
                    validacionesExtras.AnimarTexto("➕ Agregando nuevo participante... 📝", 10);
                    AgregarParticipante();
                break;

                case 3:
                    validacionesExtras.AnimarTexto("📝 Editando el nombre del participante... 📝", 10);
                    EditarNombre();
                break;

                case 4:
                    EliminarParticipante();
                break;

                case 5:
                    validacionesExtras.AnimarTexto("🔄 Editando rol de participante... 📝", 10);
                    Roles.EditarRol();
                break;

                case 6:
                    validacionesExtras.MostrarBienvenida();
                    MenuPrincipalClase.MenuPrincipal();
                break;

                case 7:
                    Console.WriteLine("¿Está seguro que desea salir de la aplicación? (S/N)");
                    if(validacionesExtras.validaciones()){
                        validacionesExtras.AnimarTexto("😊 Gracias por usar la Ruleta de Selección. ¡Te espero pronto! 🚪", 10);
                        RegistrosHistoriales.continuar = false;
                    }else{

                        Console.WriteLine("❌Accion cancelada❌");
                    }
                break;

                default:
                    Console.WriteLine("❌ Opcion invalida");
                break;
            }
        }

    }

    public static void Verparticipantes(){
        
        Console.WriteLine("\n                     📋📋📋 LISTA DE PARTICIPANTES 📋📋📋               ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        
        for (int i = 0; i < RegistrosHistoriales.alumno.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {RegistrosHistoriales.alumno[i]}");
        }
        
        return;
    }

   public static void EditarNombre(){
    Console.WriteLine("\n                     📝📝📝  EDITAR NOMBRE 📝📝📝                   ");
    Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

    RegistrosHistoriales.CargarArhivoParticipantes();

    Verparticipantes();

    int indice = -1;
    bool indiceValido = false;

    while (!indiceValido) {
        Console.WriteLine("👩‍💻 Ingrese el número del participante a editar, O presione '0' para regresar al Menu:");
        string numeroParticipante = Console.ReadLine() ?? "";

        if (numeroParticipante == "0") {
            Console.WriteLine("🔙 Regresando al menú principal...");
            return; 
        }

        // Intentar convertir la entrada a un número entero
        if (int.TryParse(numeroParticipante, out indice)) {
            // Restamos 1 para ajustar el índice
            indice--; 
            if (indice >= 0 && indice < RegistrosHistoriales.alumno.Count) {
                indiceValido = true;
            } else {
                Console.WriteLine("⚠ Índice fuera de rango.");
            }
        } else {
            Console.WriteLine("⚠ Entrada no válida. Por favor, ingrese un número entero.");
        }
    }

    
    Console.WriteLine($"👩‍💻 Ingrese el nombre actualizado del participante {RegistrosHistoriales.alumno[indice]}:");
    string nombreNuevo = Console.ReadLine() ?? "";
    RegistrosHistoriales.alumno[indice] = nombreNuevo; 

    // Actualizar el archivo con los nuevos nombres
    File.WriteAllLines(RegistrosHistoriales.ArchivoParticipantes, RegistrosHistoriales.alumno);

    Console.WriteLine($"✅Nombre actualizado con éxito, ahora el participante se llama {nombreNuevo}");
}


    public static void AgregarParticipante(){
    Console.WriteLine("\n                     ➕➕➕  AGREGAR PARTICIPANTES ➕➕➕                ");
    Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");
    
    string nuevoParticipante = "";
    bool nombreValido = false;

    while (!nombreValido){
        Console.WriteLine("Ingrese el nombre del nuevo participante, O presione '0' para volver al menu:");
        nuevoParticipante = Console.ReadLine()?.ToLower().Trim() ?? "";

        if (nuevoParticipante == "0") {
            Console.WriteLine("🔙 Regresando al menú principal...");
            return; 
        }

        if (string.IsNullOrWhiteSpace(nuevoParticipante)) {
            Console.WriteLine("❌ Nombre inválido. No puede estar vacío.");
        }
        else if (!nuevoParticipante.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))) {
            Console.WriteLine("❌ Nombre inválido. Solo se permiten letras y espacios.");
        }
        else if (RegistrosHistoriales.alumno.Any(p => p.Equals(nuevoParticipante, StringComparison.OrdinalIgnoreCase))) {
            validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
            Console.WriteLine($"⚠️ El participante '{nuevoParticipante}' ya está en la lista.");
        }
        else {
            nombreValido = true; // El nombre es valido, se sale del bucle
        }
    }

    // Agregar el nuevo participante
    RegistrosHistoriales.alumno.Add(nuevoParticipante);

    Array.Resize(ref RegistrosHistoriales.rol, RegistrosHistoriales.alumno.Count);
    Array.Resize(ref RegistrosHistoriales.asignadoDesarrollador, RegistrosHistoriales.alumno.Count);
    Array.Resize(ref RegistrosHistoriales.asignadoFacilitador, RegistrosHistoriales.alumno.Count);

    try {
        
        using (StreamWriter writer = File.AppendText(RegistrosHistoriales.ArchivoParticipantes)) {
            writer.WriteLine(nuevoParticipante);
        }
        
        validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
        Console.WriteLine($"✅ {nuevoParticipante} ha sido agregado correctamente.");
    }
    catch (Exception ex) {
        Console.WriteLine($"❌ Error al guardar en el archivo: {ex.Message}");
    }

    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    Console.Read();

    }

    public static void EliminarParticipante(){
    Console.WriteLine("\n                     ❌❌❌ ELIMINAR PARTICIPANTES ❌❌❌            ");
    Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

    Verparticipantes();
    Console.WriteLine("👩‍🏫Escriba el nombre del participante para eliminar, O presione '0' para volver al menu: ");
    string nombre = Console.ReadLine()?.ToLower().Trim() ?? "";

    if (nombre == "0") {
            Console.WriteLine("🔙 Regresando al menú principal...");
            return; 
        }

    bool encontrar = false;
    int indiceparaeliminar = -1;

    for (int i = 0; i < RegistrosHistoriales.alumno.Count; i++) {
        if (RegistrosHistoriales.alumno[i].Equals(nombre, StringComparison.OrdinalIgnoreCase)) {
            encontrar = true;
            indiceparaeliminar = i;
            break;
        } 
    }

    if (encontrar && indiceparaeliminar >= 0) {

        Console.WriteLine($"¿Está seguro que desea eliminar a {nombre}? (S/N)");
        string confirmacion = Console.ReadLine()?.ToUpper() ?? "";
        
        if (confirmacion == "S") {
            RegistrosHistoriales.alumno.RemoveAt(indiceparaeliminar);

            Array.Resize(ref RegistrosHistoriales.rol, RegistrosHistoriales.alumno.Count);
            Array.Resize(ref RegistrosHistoriales.asignadoDesarrollador, RegistrosHistoriales.alumno.Count);
            Array.Resize(ref RegistrosHistoriales.asignadoFacilitador, RegistrosHistoriales.alumno.Count);

            try {
                File.WriteAllLines(RegistrosHistoriales.ArchivoParticipantes, RegistrosHistoriales.alumno);

                validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
                validacionesExtras.AnimarTexto("❌ Eliminando participante... 🗑️", 10);
                Console.WriteLine($"✅ {nombre} ha sido eliminado correctamente.");

            } catch (Exception ex) {
                Console.WriteLine($"❌ Error al actualizar el archivo: {ex.Message}");
            }
        } else {
            Console.WriteLine($"❌ Eliminación de {nombre} cancelada.");
        }
    } else {
        validacionesExtras.AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
        Console.WriteLine("❌ No se encontró el participante.");
    }
    
    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    Console.Read();
}

    
 
}