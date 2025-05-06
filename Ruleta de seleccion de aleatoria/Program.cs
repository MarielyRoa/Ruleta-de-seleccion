using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading;

class Program {

    static void Main(string[] args){
        
        RegistrosHistoriales.CargarArhivoParticipantes();

        validacionesExtras.MostrarBienvenida();

        MenuPrincipalClase.MenuPrincipal();
        
    }

}


