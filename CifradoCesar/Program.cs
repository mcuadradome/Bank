using System;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace CifradoCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string opt;
            do {
                Console.WriteLine("Escoga una opcion: \n 1.Encriptar \n 2.Desencriptar \n 3.Salir");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":

                        Console.WriteLine("Escriba mensaje");
                        string msg = Console.ReadLine().ToLower();

                        if (!msg.Equals(string.Empty))
                        {
                            string res = Commons.Encrypt(msg);
                            Console.WriteLine("Mensaje encriptado " + res);
                        }
                        break;
                    case "2":

                        Console.WriteLine("Ingrese mensaje encriptado");
                        string msgEncript = Console.ReadLine().ToLower();

                        if (!msgEncript.Equals(string.Empty))
                        {
                            string res = Commons.DesEncrypt(msgEncript);
                            Console.WriteLine("Mensaje desencriptado " + res);
                        }

                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("Desea continuar: \n 1.Si \n 2.No");
                opt = Console.ReadLine();

            } while (opt.Equals("1"));
        }
    }
}


