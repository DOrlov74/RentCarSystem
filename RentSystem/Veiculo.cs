using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace RentSystem
{
    abstract class Veiculo
    {
        #region construtores
        public Veiculo()
        {
            Id = ++_nextId;
        }
        #endregion
        private static int _nextId;
        private int _id;
        public int Id 
        {
            get {return _id; }
            private set {_id=value; } 
        }
        public string Model { get; set; }
        public string Cor { get; set; }
        public string Localidade { get; set; }
        public bool Disponibilidade { get; set; }
        public decimal Preco { get; set; }
        public virtual void PedirDados()
        {
            Console.WriteLine("Model?");
            do { Model = Console.ReadLine(); }
            while (!ValidarModel(Model));

            Console.WriteLine("Cor?");
            do { Cor = Console.ReadLine(); }
            while (!ValidarCor(Cor));

            Console.WriteLine("Localide?");
            do { Localidade = Console.ReadLine(); }
            while (!ValidarLocalidade(Localidade));

            Console.WriteLine("Preço?");
            string s;
            do { s = Console.ReadLine(); }
            while (!validarPreco(s));
            Preco = decimal.Parse(s);

            do
            {
                Console.WriteLine("Está disponivel? (Y/N)");
                s = Console.ReadLine();
            }
            while (String.Compare(s.ToLower(), "y")!=0 && String.Compare(s.ToLower(), "n")!=0);
            if (String.Compare(s.ToLower(), "y") == 0) { Disponibilidade = true; }
            else { Disponibilidade = false; }
        }
        public virtual void MostrarDados()
        {
            Console.WriteLine("id: "+ Id);
            Console.WriteLine("Model: "+ Model);
            Console.WriteLine("Cor: "+ Cor);
            Console.WriteLine("Localidade: "+ Localidade);
            Console.WriteLine("Preço: "+ Preco);
            Console.WriteLine((Disponibilidade?"E":"Não e")+"stá disponivel");
        }
        bool ValidarModel(string s)
        {
            Regex regex = new Regex(@"(\w+){3}\s?\w*");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Model deve conter no mínimo 3 caracteres");
            }
            return false;
        }
        bool ValidarCor(string s)
        {
            Regex regex = new Regex(@"(\w+){3}");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Cor deve conter no mínimo 3 caracteres");
            }
            return false;
        }
        bool ValidarLocalidade(string s)
        {
            Regex regex = new Regex(@"(\w+){3}\s?\w*");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Localidade deve conter no mínimo 3 caracteres");
            }
            return false;
        }
        public bool validarPreco(string s)
        {
            Regex regex = new Regex(@"\d{1,8}(\.\d{1,4})?");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Insira a Preço em formato xxxx.xx");
            }
            return false;
        }
    }
}
