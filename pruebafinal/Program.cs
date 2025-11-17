using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebafinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" SISTEMA DE CONTROL DE ACCESO A RED");

            Console.WriteLine();


            Console.WriteLine("Roles disponibles:");

            Console.WriteLine("1. admin");

            Console.WriteLine("2. tecnico");

            Console.WriteLine("3. usuario");

            Console.WriteLine("4. invitado");

            Console.Write("\nIngrese el rol: ");

            string rol = Console.ReadLine().ToLower();


            Console.Write("Tiene 2FA activada? (si/no): ");

            string respuesta2FA = Console.ReadLine().ToLower();

            bool tiene2FA = (respuesta2FA == "si" || respuesta2FA == "s");


            Console.WriteLine("\nEstados de cuenta:");

            Console.WriteLine("1. activa");

            Console.WriteLine("2. suspendida");

            Console.WriteLine("3. bloqueada");

            Console.Write("\nIngrese el estado de la cuenta: ");

            string estadoCuenta = Console.ReadLine().ToLower();


            Console.WriteLine();

            Console.WriteLine("RESULTADO DEL CONTROL DE ACCESO:");


            string nivelAcceso = EvaluarAcceso(rol, tiene2FA, estadoCuenta);


            Console.WriteLine("Rol: " + rol);

            Console.WriteLine("2FA Activada: " + (tiene2FA ? "SI" : "NO"));

            Console.WriteLine("Estado de cuenta: " + estadoCuenta);

            Console.WriteLine();

            Console.WriteLine("NIVEL DE ACCESO: " + nivelAcceso);


            Console.WriteLine();

            Console.WriteLine("Presione cualquier tecla para salir...");

            Console.ReadKey();

        }


        static string EvaluarAcceso(string rol, bool tiene2FA, string estadoCuenta)

        {

            if (estadoCuenta == "bloqueada")

            {

                return "ACCESO DENEGADO - Cuenta bloqueada";

            }


            if (estadoCuenta == "suspendida")

            {

                if (rol == "admin" && tiene2FA)

                {

                    return "ACCESO CONCEDIDO - Lectura limitada (Admin con 2FA)";

                }

                else

                {

                    return "ACCESO DENEGADO - Cuenta suspendida";

                }

            }

            if (estadoCuenta == "activa")

            {

                if (rol == "admin")

                {

                    return "ACCESO TOTAL - Administrador";

                }


                if (rol == "tecnico")

                {

                    if (tiene2FA)

                    {

                        return "ACCESO TOTAL - Tecnico con 2FA";

                    }

                    else

                    {

                        return "ACCESO DE SOLO LECTURA - Tecnico sin 2FA";

                    }

                }


                if (rol == "usuario")

                {

                    if (tiene2FA)

                    {

                        return "ACCESO LIMITADO - Usuario con 2FA";

                    }

                    else

                    {

                        return "ACCESO DENEGADO - Usuario sin 2FA";

                    }

                }


                if (rol == "invitado")

                {

                    return "ACCESO DE SOLO LECTURA - Invitado";

                }

            }


            return "ERROR - Estado de cuenta no valido";

        }

    }

}