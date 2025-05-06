class Ruleta{

    public static void IniciarRuleta() {

    validacionesExtras.AnimarTexto("\n                     ⌛⌛⌛  INICIANDO LA RULETA ⌛⌛⌛                   ", 0);
    Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");
              
        if (RegistrosHistoriales.alumno.Count < 2) {
            Console.WriteLine("⚠ No hay suficientes participantes. Debe haber al menos 2 participantes.");
            Console.WriteLine("⭕ Presiona 'R' para reiniciar o cualquier otra tecla para regresar al menú principal.");
            validacionesExtras.AnimarTexto("🎡Recordatorio: Puedes agregar más participantes desde el menú principal 🎡", 10);
            
            if ((Console.ReadLine() ?? "").ToUpper() == "R") {
                ReiniciarRuleta();
            }
            return;
        }
        
        int disponiblesAsignar = 0;
        
        for (int i = 0; i < RegistrosHistoriales.alumno.Count; i++) {
            if (!RegistrosHistoriales.asignadoDesarrollador[i] && !RegistrosHistoriales.asignadoFacilitador[i]) {
                disponiblesAsignar++;
            }
        }
        
        if (disponiblesAsignar < 2) {
            Console.WriteLine("⚠ No hay suficientes participantes disponibles para asignar roles.");
            Console.WriteLine("⭕ Presiona 'R' para reiniciar la ruleta o cualquier otra tecla para regresar al menú principal.");
            validacionesExtras.AnimarTexto("🎡Recordatorio: También puedes agregar más participantes si te quedaste sin giros 🎡", 10);
            
            if ((Console.ReadLine() ?? "").ToUpper() == "R") {
                ReiniciarRuleta();
            }
            return;
        }
        
        // Calcular giros totales y restantes
        int girosTotales = RegistrosHistoriales.alumno.Count / 2;
        int estudiantesAsignados = RegistrosHistoriales.alumno.Count - disponiblesAsignar;
        int girosCompletados = estudiantesAsignados / 2;
        int girosRestantes = girosTotales - girosCompletados;
        
        Console.WriteLine("🎉 ¡La ruleta ha comenzado! 🎉");
        
        Random aleatorio = new Random();
        int Desarrollador, Facilitador;
        
        // Buscar un desarrollador que no haya sido asignado a ningún rol
        do {
            Desarrollador = aleatorio.Next(RegistrosHistoriales.alumno.Count);
        } while (RegistrosHistoriales.asignadoDesarrollador[Desarrollador] || RegistrosHistoriales.asignadoFacilitador[Desarrollador]);
        
        // Buscar un facilitador que no haya sido asignado a ningún rol y que no sea el mismo que el desarrollador
        do {
            Facilitador = aleatorio.Next(RegistrosHistoriales.alumno.Count);
        } while (RegistrosHistoriales.asignadoDesarrollador[Facilitador] || RegistrosHistoriales.asignadoFacilitador[Facilitador] || Facilitador == Desarrollador);
        
        if (Desarrollador >= RegistrosHistoriales.alumno.Count || Facilitador >= RegistrosHistoriales.alumno.Count) {
            Console.WriteLine("⚠ Índice fuera de rango ⚠");
            return;
        }
        
        RegistrosHistoriales.rol[Desarrollador] = "Desarrollador en Vivo";
        RegistrosHistoriales.rol[Facilitador] = "Facilitador de Ejercicio a Desarrollar";
        RegistrosHistoriales.asignadoDesarrollador[Desarrollador] = true;
        RegistrosHistoriales.asignadoFacilitador[Facilitador] = true;
        
        validacionesExtras.AnimarTexto("🤸‍♂️Seleccionando Estudiantes🤸‍♀️", 0);
        
        Console.WriteLine($"👨‍💻 Estudiante 1: {RegistrosHistoriales.alumno[Desarrollador]}, Rol: Desarrollador en Vivo");
        Console.WriteLine($"👩‍🏫 Estudiante 2: {RegistrosHistoriales.alumno[Facilitador]}, Rol: Facilitador de Ejercicio a Desarrollar");
        
        
        RegistrosHistoriales.GuardarHistorial(RegistrosHistoriales.alumno[Desarrollador], RegistrosHistoriales.rol[Desarrollador]);
        RegistrosHistoriales.GuardarHistorial(RegistrosHistoriales.alumno[Facilitador], RegistrosHistoriales.rol[Facilitador]);
        
        // Guardar ambas selecciones en el archivo de "ÚltimaSeleccion.txt"
        RegistrosHistoriales.GuardarUltimaSeleccion(RegistrosHistoriales.alumno[Desarrollador], RegistrosHistoriales.rol[Desarrollador]);
        RegistrosHistoriales.GuardarUltimaSeleccion(RegistrosHistoriales.alumno[Facilitador], RegistrosHistoriales.rol[Facilitador]);
        
        if (disponiblesAsignar == 0) {
            Console.WriteLine("⚠ No hay suficientes participantes disponibles para asignar roles.");
            Console.WriteLine("⭕ Presiona 'R' para reiniciar la ruleta o cualquier otra tecla para regresar al menú principal.");
            validacionesExtras.AnimarTexto("🎡Recordatorio: También puedes agregar más participantes si te quedaste sin giros 🎡", 10);

            if ((Console.ReadLine() ?? "").ToUpper() == "R") {
                ReiniciarRuleta();
            }
        }
        
        return;
    }

    public static void ReiniciarRuleta() {
        // Asegurarnos de que los arrays tienen el mismo tamaño que la lista 'alumno'
        Array.Resize(ref RegistrosHistoriales.rol, RegistrosHistoriales.alumno.Count);
        Array.Resize(ref RegistrosHistoriales.asignadoDesarrollador, RegistrosHistoriales.alumno.Count);
        Array.Resize(ref RegistrosHistoriales.asignadoFacilitador, RegistrosHistoriales.alumno.Count);

        for (int i = 0; i < RegistrosHistoriales.alumno.Count; i++) {
            RegistrosHistoriales.rol[i] = null ?? "";  // Limpiar los roles asignados
            RegistrosHistoriales.asignadoDesarrollador[i] = false; 
            RegistrosHistoriales.asignadoFacilitador[i] = false;  
        }

        if (File.Exists(RegistrosHistoriales.Historial)) 
        {
            File.Delete(RegistrosHistoriales.Historial);  // Para limpiar el historial
        }

        //Para Crear un nuevo historial vacío
        try {
            using (StreamWriter writer = new StreamWriter(RegistrosHistoriales.Historial, false)) {
                
            }
        } catch (Exception ex) {
            Console.WriteLine("❌ Error al crear el nuevo historial: " + ex.Message);
        }

        validacionesExtras.AnimarTexto(" 🎡La ruleta ha sido reiniciada. Los roles ahora están disponibles para asignar nuevamente. 🎡", 10);
    }



}