using System;
using System.Collections.Generic;
using System.Text;

namespace RentSystem
{
    class Moto:DuasRodas
    {
        public static List<Moto> listaDeMotos = new List<Moto>();
        public static bool ValidarId(int id)
        {
            if (listaDeMotos.Count > 0)
            {
                foreach (Moto f in listaDeMotos)
                { if (f.Id == id) return true; }
            }
            Console.WriteLine("Moto com id: " + id + " não encontrado");
            return false;
        }
        public static bool Eliminar(int id)
        {
            foreach (Moto item in listaDeMotos)
            {
                if (item.Id == id)
                {
                    listaDeMotos.Remove(item);
                    Console.WriteLine("Moto com id: " + id + " foi eliminado");
                    return true;
                }
            }
            return false;
        }
    }
}
