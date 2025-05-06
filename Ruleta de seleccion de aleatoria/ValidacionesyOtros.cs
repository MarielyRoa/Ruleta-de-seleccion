class validacionesExtras{

    public static void AnimarTexto(string texto, int velocidad) {

        foreach (char c in texto) {
            Console.Write(c);
            Thread.Sleep(velocidad);
        }
            Console.WriteLine();
            Thread.Sleep(0);
    }

    public static void MostrarBienvenida(){
    
        Console.Write(@"
                    🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲
                    🎲           ____    _    _   _     _____ _____  ___                    🎲
                    🎲          |  _ \  | |  | | | |   | ____|_   _|/ \ \                   🎲
                    🎲          | |_) | | |  | | | |   |   |   | | / _ \ \                  🎲
                    🎲          |  _ <  | |  | | | |___| |___  | |/ ___ \ \                 🎲
                    🎲          |_| \_\ \_\__/ / | |___|_____| |_/_/   \_\ \                🎲
                    🎲          ============================================                🎲
                    🎲          _    _     _____    _  _____ ___  ____  ___    _            🎲
                    🎲         / \  | |   | ____|  / \|_   _/ _ \|  _ \|_ _|  / \\          🎲
                    🎲        / _ \ | |   |  _|   / _ \ | || | | | |_) || |  / _ \\         🎲
                    🎲       / ___ \| |___| |___ / ___ \| || |_| |  _ < | | / ___ \\        🎲
                    🎲      /_/   \_\_____|_____/_/   \_\_| \___/|_| \_\___/_/   \_\\       🎲
                    🎲                                                                      🎲
                    🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲 ");
        

        }

    public static bool validaciones(){

        string confirmacion = Console.ReadLine()?.ToLower() ?? "";

        if (confirmacion == "s") {
        return true; // Confirmación para borrar

        } else if (confirmacion == "n") {
        return false; // Cancelación de la acción
        
        } else {
        Console.WriteLine("❌ Opción inválida, por favor ingrese 'S' para sí o 'N' para no. ❌");
        return false; 
        }
    }

}