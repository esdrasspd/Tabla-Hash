using System;

namespace TablaHash
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hashtable = new HashTable(8);

            hashtable.Insertar("Gato");
            hashtable.Insertar("Perro");
            hashtable.Insertar("Pato");
            hashtable.Insertar("Toro");
            hashtable.Insertar("Vaca");
            hashtable.Insertar("Serpiente");

            Console.WriteLine("Valores en la tabla hash:");
            hashtable.Mostrar();

            if (hashtable.Buscar("Perro"))
            {
                Console.WriteLine("Perro se encuentra en la tabla hash.");
            }
            else
            {
                Console.WriteLine("Perro no se encuentra en la tabla hash.");
            }

            hashtable.Eliminar("Perro");


            Console.WriteLine("Valores en la tabla hash después de eliminar: Perro...");
            hashtable.Mostrar();

            Console.ReadKey();
        }
    }

    class HashTable
    {
        private string[] tablaHash { get; set; }
        private int tamaño { get; set; }

        public HashTable(int tamaño)
        {
            this.tamaño = tamaño;
            tablaHash = new string[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tablaHash[i] = null;
            }
        }
        public void Insertar(string valor)
        {
            int indice = FuncionHash(valor);
            while (tablaHash[indice] != null && tablaHash[indice] != valor)
            {
                indice++;
                indice %= tamaño;
            }
            tablaHash[indice] = valor;
        }

        public bool Buscar(string valor)
        {
            int indice = FuncionHash(valor);
            while (tablaHash[indice] != null)
            {
                if (tablaHash[indice] == valor)
                {
                    return true;
                }
                indice++;
                indice %= tamaño;
            }
            return false;
        }

        public void Eliminar(string valor)
        {
            int indice = FuncionHash(valor);
            while (tablaHash[indice] != null)
            {
                if(tablaHash[indice] == valor)
                {
                    tablaHash[indice] = null;
                    return;
                }
                indice++;
                indice %= tamaño;
            }
        }

        public void Mostrar()
        {
            for (int i = 0; i < tamaño; i++)
            {
                if(tablaHash[i] != null)
                {
                    Console.WriteLine("Índice {0}: {1}", i, tablaHash[i]);
                }
                else
                {
                    Console.WriteLine("Índice {0}: Vacío", i);
                }
            }
        }

        private int FuncionHash(string clave)
        {
            int valorHash = 0;
            for(int i= 0; i < clave.Length; i++)
            {
                valorHash += (int)clave[i];
            }
            return valorHash % tamaño;
        }
    }
}