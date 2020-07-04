using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RentSystem
{
    class Pesado:QuatroRodas
    {
        public static List<Pesado> listaDePesados = new List<Pesado>();
        public decimal CapacidadeDeCargo { get; set; }
        public override void PedirDados()
        {
            base.PedirDados();
            Console.WriteLine("Capacidade de cargo?");
            string s;
            do { s = Console.ReadLine(); }
            while (!ValidarCapacidade(s));
            CapacidadeDeCargo = decimal.Parse(s);
        }
        public override void MostrarDados()
        {
            base.MostrarDados();
            Console.WriteLine("Capacidade de cargo: "+ CapacidadeDeCargo);
        }
        private bool ValidarCapacidade(string s)
        {
            Regex regex = new Regex(@"\d{1,8}(\.\d{1,4})?");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Insira a capacidade de cargo em formato xxxx.xx");
            }
            return false;
        }
        public static bool ValidarId(int id)
        {
            if (listaDePesados.Count > 0)
            {
                foreach (Pesado f in listaDePesados)
                { if (f.Id == id) return true; }
            }
            Console.WriteLine("Pesado com id: " + id + " não encontrado");
            return false;
        }
        public static bool Eliminar(int id)
        {
            foreach (Pesado item in listaDePesados)
            {
                if (item.Id == id)
                {
                    listaDePesados.Remove(item);
                    Console.WriteLine("Pesado com id: " + id + " foi eliminado");
                    return true;
                }
            }
            return false;
        }
    }
}
