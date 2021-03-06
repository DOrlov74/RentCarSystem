﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace RentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo no sistema Rent-a-car");
            MainMenu();
        }
        static void MainMenu()
        {
            string resposta;
            bool success;
            int opcao;
            do {
                Console.WriteLine("1 - Criar veiculo");
                Console.WriteLine("2 - Listar veiculos");
                Console.WriteLine("3 - Arrendar veiculos");
                Console.WriteLine("0 - Sair");
                do {
                    resposta = Console.ReadLine();
                    success = Int32.TryParse(resposta, out opcao);
                    if (!success && opcao < 4 && opcao >= 0)
                    {
                        Console.WriteLine("A resposta não é válida. Tente novamente");
                        success = false;
                    }
                }
                while (!success);
                switch (opcao)
                {
                    case 1:
                        CriarVeiculoMenu();
                        break;
                    case 2:
                        ListarVeiculoMenu();
                        break;
                    case 3:
                        ArrendarVeiculoMenu();
                        break;
                    default:
                        Console.WriteLine("Até logo");
                        break;
                }
            } while (opcao!=0);
        }

        
        private static void CriarVeiculoMenu()
        {
            bool success;
            int opcao;
            Console.WriteLine("1 - Criar um Moto");
            Console.WriteLine("2 - Criar um ligeiro");
            Console.WriteLine("3 - Criar um pesado");
            Console.WriteLine("4 - Criar um barco");
            Console.WriteLine("5 - Menu anterior");
            Console.WriteLine("0 - Sair");
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out opcao);
                if (!success && opcao < 6 && opcao >= 0)
                {
                    Console.WriteLine("A resposta não é válida. Tente novamente");
                    success = false;
                }
            }
            while (!success);
            switch (opcao)
            {
                case 1:
                    CriarMoto();
                    break;
                case 2:
                    CriarLigeiro();
                    break;
                case 3:
                    CriarPesado();
                    break;
                case 4:
                    CriarBarco();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Até logo");
                    break;
            }
        }
        private static void CriarMoto()
        {
            Moto novo=new Moto();
            novo.PedirDados();
            Moto.listaDeMotos.Add(novo);
        }
        private static void CriarLigeiro()
        {
            Ligeiro novo = new Ligeiro();
            novo.PedirDados();
            Ligeiro.listaDeLigeiros.Add(novo);
        }
        private static void CriarPesado()
        {
            Pesado novo = new Pesado();
            novo.PedirDados();
            Pesado.listaDePesados.Add(novo);
        }
        private static void CriarBarco()
        {
            Barco novo = new Barco();
            novo.PedirDados();
            Barco.listaDeBarcos.Add(novo);
        }

        private static void ListarVeiculoMenu()
        {
            bool success;
            int opcao;
            Console.WriteLine("1 - Listar Motos");
            Console.WriteLine("2 - Listar Ligeiros");
            Console.WriteLine("3 - Listar Pesados");
            Console.WriteLine("4 - Listar Barcos");
            Console.WriteLine("5 - Menu anterior");
            Console.WriteLine("0 - Sair");
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out opcao);
                if (!success && opcao<6 && opcao>=0)
                {
                    Console.WriteLine("A resposta não é válida. Tente novamente");
                    success = false;
                }
            }
            while (!success);
            switch (opcao)
            {
                case 1:
                    ListarMotos();
                    break;
                case 2:
                    ListarLigeiros();
                    break;
                case 3:
                    ListarPesados();
                    break;
                case 4:
                    ListarBarcos();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Até logo");
                    break;
            }
        }
        private static void EliminarMenu(Func<int, bool> validator, Func<int, bool> eliminator)
        {
            bool success;
            int id;

            Console.WriteLine("Para eliminar veiculo insira o id");
            Console.WriteLine("0 - Menu anterior");
            do
            {
                success = int.TryParse(Console.ReadLine(), out id);
                if (id!=0 && !validator(id))
                {
                    Console.WriteLine("A resposta não é válida. Tente novamente");
                    success = false;
                }
            } while
                 (!success);
            if (id == 0) ListarVeiculoMenu();
            else eliminator(id);
        }

        private static void ListarMotos()
        {
            if (Moto.listaDeMotos.Count > 0)
            {
                foreach (Moto moto in Moto.listaDeMotos)
                {
                    moto.MostrarDados();
                }
                EliminarMenu(Moto.ValidarId, Moto.Eliminar);
            }
            else
            {
                Console.WriteLine("não há nenhum moto");
            }
        }

        private static void ListarLigeiros()
        {
            if (Ligeiro.listaDeLigeiros.Count > 0)
            {
                foreach (Ligeiro ligeiro in Ligeiro.listaDeLigeiros)
                {
                    ligeiro.MostrarDados();
                }
                EliminarMenu(Ligeiro.ValidarId, Ligeiro.Eliminar);
            }
            else
            {
                Console.WriteLine("não há nenhum ligeiro");
            }
        }
        private static void ListarPesados()
        {
            if (Pesado.listaDePesados.Count > 0)
            {
                foreach (Pesado pesado in Pesado.listaDePesados)
                {
                    pesado.MostrarDados();
                }
                EliminarMenu(Pesado.ValidarId, Pesado.Eliminar);
            }
            else
            {
                Console.WriteLine("não há nenhum pesado");
            }
        }
        private static void ListarBarcos()
        {
            if (Barco.listaDeBarcos.Count > 0)
            {
                foreach (Barco barco in Barco.listaDeBarcos)
                {
                    barco.MostrarDados();
                }
                EliminarMenu(Barco.ValidarId, Barco.Eliminar);
            }
            else
            {
                Console.WriteLine("não há nenhum barco");
            }
        }
        private static void ArrendarVeiculoMenu()
        {
            bool success;
            int opcao;
            Console.WriteLine("1 - Arrendar Moto");
            Console.WriteLine("2 - Arrendar Ligeiro");
            Console.WriteLine("3 - Arrendar Pesado");
            Console.WriteLine("4 - Arrendar Barco");
            Console.WriteLine("5 - Menu anterior");
            Console.WriteLine("0 - Sair");
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out opcao);
                if (!success && opcao < 6 && opcao >= 0)
                {
                    Console.WriteLine("A resposta não é válida. Tente novamente");
                    success = false;
                }
            }
            while (!success);
            switch (opcao)
            {
                case 1:
                    ArrendarMoto();
                    break;
                case 2:
                    ArrendarLigeiro();
                    break;
                case 3:
                    ArrendarPesado();
                    break;
                case 4:
                    ArrendarBarco();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Até logo");
                    break;
            }
        }

        private static void ArrendarBarco()
        {
            if (Barco.listaDeBarcos.Count > 0)
            {
                IEnumerable<Barco> disponiveis =
                    from barco in Barco.listaDeBarcos
                    where barco.Disponibilidade
                    select barco;
                if (disponiveis.Count() > 0)
                {
                    foreach (Barco barco in disponiveis)
                    {
                        barco.MostrarDados();
                    }
                    ArrendarMenu(Barco.ValidarDisponivel, Barco.Arrendar);
                }
            }
            else
            {
                Console.WriteLine("não há nenhum ligeiro");
            }
        }

        private static void ArrendarPesado()
        {
            if (Pesado.listaDePesados.Count > 0)
            {
                IEnumerable<Pesado> disponiveis =
                    from pesado in Pesado.listaDePesados
                    where pesado.Disponibilidade
                    select pesado;
                if (disponiveis.Count() > 0)
                {
                    foreach (Pesado pesado in disponiveis)
                    {
                        pesado.MostrarDados();
                    }
                    ArrendarMenu(Pesado.ValidarDisponivel, Pesado.Arrendar);
                }
            }
            else
            {
                Console.WriteLine("não há nenhum ligeiro");
            }
        }

        private static void ArrendarLigeiro()
        {
            if (Ligeiro.listaDeLigeiros.Count > 0)
            {
                IEnumerable<Ligeiro> disponiveis =
                    from ligeiro in Ligeiro.listaDeLigeiros
                    where ligeiro.Disponibilidade
                    select ligeiro;
                if (disponiveis.Count() > 0)
                {
                    foreach (Ligeiro ligeiro in disponiveis)
                    {
                        ligeiro.MostrarDados();
                    }
                    ArrendarMenu(Ligeiro.ValidarDisponivel, Ligeiro.Arrendar);
                }
            }
            else
            {
                Console.WriteLine("não há nenhum ligeiro");
            }
        }

        private static void ArrendarMoto()
        {
            if (Moto.listaDeMotos.Count > 0)
            {
                IEnumerable<Moto> disponiveis =
                    from moto in Moto.listaDeMotos
                    where moto.Disponibilidade
                    select moto;
                if (disponiveis.Count() > 0)
                {
                    foreach (Moto moto in disponiveis)
                    {
                        moto.MostrarDados();
                    }
                    ArrendarMenu(Moto.ValidarDisponivel, Moto.Arrendar);
                }
                else
                {
                    Console.WriteLine("não há nenhum moto disponivel");
                }
            }
            else
            {
                Console.WriteLine("não há nenhum moto");
            }
        }

        private static void ArrendarMenu(Func<int, bool> validator, Func<int, bool> arrendator)
        {
            bool success;
            int id;

            Console.WriteLine("Para arrendar veiculo insira o id");
            Console.WriteLine("0 - Menu anterior");
            do
            {
                success = int.TryParse(Console.ReadLine(), out id);
                if (id != 0 && !validator(id))
                {
                    Console.WriteLine("A resposta não é válida. Tente novamente");
                    success = false;
                }
            } while
                 (!success);
            if (id == 0) ArrendarVeiculoMenu();
            else arrendator(id);
        }
    }
}
