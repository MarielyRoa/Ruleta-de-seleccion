class MenuPrincipalClase{

    public static void MenuPrincipal(){

        while(RegistrosHistoriales.continuar){

        Console.WriteLine("\n                       🎡🎡🎡Bienvenidos a la ruleta de seleccion aleatoria🎡🎡🎡");
        Console.WriteLine("  🔁══════════════════════════════════════🔁 ");
        Console.WriteLine(" ‖                                           ‖");
        Console.WriteLine(" ‖    🎡⭕OPCIONES⭕🎡                     ‖"); 
        Console.WriteLine(" ‖ 1. Iniciar la Ruleta 🎡🟢                ‖"); 
        Console.WriteLine(" ‖ 2. Participantes 🤸‍♀️🤸‍♂️                    ‖");
        Console.WriteLine(" ‖ 3. Roles ya asignados 👩‍💻👨‍💻               ‖"); 
        Console.WriteLine(" ‖ 4. Reiniciar la ruleta 🎡♻               ‖"); 
        Console.WriteLine(" ‖ 5. Ver Historial Seleccion 📑            ‖"); 
        Console.WriteLine(" ‖ 6. Eliminar Historial de Seleccion ❌📑  ‖"); 
        Console.WriteLine(" ‖ 7. Salir 🔚                              ‖");  
        Console.WriteLine("  🔁══════════════════════════════════════🔁 ");
        
        Console.Write("🔠 Seleccione una opción: ");
        string input = Console.ReadLine()?.Trim() ?? ""; // Captura la entrada y elimina espacios en blanco

        if (!int.TryParse(input, out int opcion)) // Intenta convertir a número
        {
            Console.WriteLine("❌ Opción inválida. Debe ingresar un número entre 1 y 7.");
            continue; // Vuelve a mostrar el menú si la conversión falla
        }

            switch(opcion){

                case 1:
                    validacionesExtras.AnimarTexto("🎡 Iniciando la ruleta... 🎲", 10);
                    Ruleta.IniciarRuleta();
                break;

                case 2:
                
                    validacionesExtras.AnimarTexto("🤸‍♀️🤸‍♂️ Cargando participantes... 🤸‍♀️🤸‍♂️", 10);
                    MenuParticipantes.Participantes();
                break;

                case 3:
                    validacionesExtras.AnimarTexto("👩‍💻 Cargando roles asignados... 👨‍💻", 10);
                    Roles.RolesAsignados();
                break;

                case 4:
                    validacionesExtras.AnimarTexto("♻️ Reiniciando la ruleta... 🔄", 10);
                    Console.WriteLine("¿Está seguro que desea Reiniciar la ruleta? (S/N)");
                    if(validacionesExtras.validaciones()){
                        Ruleta.ReiniciarRuleta();
                    }else{

                        Console.WriteLine("❌Accion cancelada❌");
                    }
                   
                break;

                case 5:
                    validacionesExtras.AnimarTexto("📋 Cargando historial de selección... 📑", 10);
                    RegistrosHistoriales.HistorialDeSeleccion();
                break;

                case 6:
                    validacionesExtras.AnimarTexto("🗑️ Eliminando historial... ❌", 10);
                    Console.WriteLine("¿Está seguro que desea borrar todo el historial de registros? (S/N)");
                    if(validacionesExtras.validaciones()){
                        RegistrosHistoriales.EliminarHistorialUltimaSeleccion();
                    }else{

                        Console.WriteLine("❌Accion cancelada❌");
                    }
                    
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
                    Console.WriteLine("⚠ Opcion invalida, numero fuera de rango de (1 y 7)");
                continue;
                }
        }
    }

    
}