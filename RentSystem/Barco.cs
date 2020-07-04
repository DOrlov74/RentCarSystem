using System;
using System.Collections.Generic;
using System.Text;

namespace RentSystem
{
    class Barco:Maritimo
    {
        public static List<Barco> listaDeBarcos = new List<Barco>();
        public static bool ValidarId(int id)
        {
            if (listaDeBarcos.Count > 0)
            {
                foreach (Barco f in listaDeBarcos)
                { if (f.Id == id) return true; }
            }
            Console.WriteLine("Barco com id: " + id + " não encontrado");
            return false;
        }
        public static bool Eliminar(int id)
        {
            foreach (Barco item in listaDeBarcos)
            {
                if (item.Id == id)
                {
                    listaDeBarcos.Remove(item);
                    Console.WriteLine("Barco com id: " + id + " foi eliminado");
                    return true;
                }
            }
            return false;
        }
    }
}
