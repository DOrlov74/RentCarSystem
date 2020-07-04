using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RentSystem
{
    class Ligeiro:QuatroRodas
    {
        public static List<Ligeiro> listaDeLigeiros = new List<Ligeiro>();
        public int Capacidade { get; set; }
        public override void PedirDados()
        {
            base.PedirDados();
            Console.WriteLine("Capacidade?");
            string s;
            do { s = Console.ReadLine(); }
            while (!ValidarCapacidade(s));
            Capacidade = int.Parse(s);
        }
        public override void MostrarDados()
        {
            base.MostrarDados();
            Console.WriteLine("Capacidade: "+Capacidade+" pessoas");
        }
        private bool ValidarCapacidade(string s)
        {
            Regex regex = new Regex(@"(\d+){1,3}");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Capacidade deve ser o numero de pessoas");
            }
            return false;
        }
        public static bool ValidarId(int id)
        {
            if (listaDeLigeiros.Count > 0)
            {
                foreach (Ligeiro f in listaDeLigeiros)
                { if (f.Id == id) return true; }
            }
            Console.WriteLine("Ligeiro com id: " + id + " não encontrado");
            return false;
        }
        public static bool Eliminar(int id)
        {
            foreach (Ligeiro item in listaDeLigeiros)
            {
                if (item.Id == id)
                {
                    listaDeLigeiros.Remove(item);
                    Console.WriteLine("Ligeiro com id: " + id + " foi eliminado");
                    return true;
                }
            }
            return false;
        }
    }
}
