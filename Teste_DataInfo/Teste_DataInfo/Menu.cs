﻿using static Teste_DataInfo.ManipuladorTarefas;

namespace Teste_DataInfo
{
    public class Menu
    {
        public enum Opcoes : int
        {
            AdicionarTarefa = 1,
            ListarTarefas = 2,
            EditarTarefa = 3,
            ExcluirTarefa = 4,
            MarcarDesmarcarConcluida = 5,
            FiltrarTarefas = 6,
            Sair = 0,
        }

        private int MostraMenu()
        {
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Listar Tarefas");
            Console.WriteLine("3 - Editar Tarefa");
            Console.WriteLine("4 - Excluir Tarefa");
            Console.WriteLine("5 - Marcar / Desmarcar como concluída");
            Console.WriteLine("6 - Filtrar Tarefas");
            Console.WriteLine("0 - Sair");

            return Convert.ToInt32(Console.ReadLine());
        }

        public void Comecar()
        {
            Opcoes opcao = (Opcoes)MostraMenu();

            ManipuladorTarefas manipuladorTarefas = new ManipuladorTarefas();

            while (opcao != 0)
            {
                switch (opcao)
                {
                    case Opcoes.AdicionarTarefa:
                    {
                        Console.Clear();

                        Console.WriteLine("Campos sinalizados com '*' são obrigatórios.\n");

                        Tarefa tarefa = new Tarefa();

                        Console.WriteLine("Digite o título da tarefa:*");
                        tarefa.Titulo = Console.ReadLine();

                        Console.WriteLine("Digite a descrição da tarefa:");
                        tarefa.Descricao = Console.ReadLine();

                        Console.WriteLine(manipuladorTarefas.AdicionaTarefa(tarefa));
                    }
                    break;

                    case Opcoes.ListarTarefas:
                    {
                        Console.Clear();

                        Console.WriteLine(manipuladorTarefas.ListaTarefas());
                    }
                    break;

                    case Opcoes.EditarTarefa:
                    {
                        Console.Clear();

                        Console.WriteLine(manipuladorTarefas.ListaTarefas());

                        Console.WriteLine("Selecione o ID da tarefa que deseja editar:");
                        int indexTarefa = Convert.ToInt32(Console.ReadLine());

                        Tarefa tarefa = new Tarefa();

                        Console.WriteLine("Novo título:*");
                        tarefa.Titulo = Console.ReadLine();

                        Console.WriteLine("Nova descrição:");
                        tarefa.Descricao = Console.ReadLine();

                        Console.WriteLine(manipuladorTarefas.EditaTarefa(indexTarefa, tarefa));
                    }
                    break;

                    case Opcoes.ExcluirTarefa:
                    {
                        Console.Clear();

                        Console.WriteLine(manipuladorTarefas.ListaTarefas());

                        Console.WriteLine("Selecione o ID da tarefa que deseja excluir:");
                        int indexTarefa = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(manipuladorTarefas.ExcluiTarefa(indexTarefa));
                    }
                    break;

                    case Opcoes.MarcarDesmarcarConcluida:
                    {
                        Console.Clear();

                        Console.WriteLine(manipuladorTarefas.ListaTarefas());

                        Console.WriteLine("Selecione o ID da tarefa que deseja marcar/desmarcar:");
                        int indexTarefa = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(manipuladorTarefas.AlteraStatusTarefa(indexTarefa));
                    }
                    break;

                    case Opcoes.FiltrarTarefas:
                    {
                        Console.Clear();

                        Console.WriteLine("1 - Ver todas as tarefas");
                        Console.WriteLine("2 - Ver tarefas concluidas");
                        Console.WriteLine("3 - Ver tarefas pendentes");

                        Tarefa.StatusTarefa statusTarefa = (Tarefa.StatusTarefa)Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(manipuladorTarefas.ListaTarefas(statusTarefa));
                    }
                    break;

                    case Opcoes.Sair:
                        Console.WriteLine("0");
                    break;

                    default:
                        Console.WriteLine("Opção inválida");
                    break;
                }

                opcao = (Opcoes)MostraMenu();
            }
        }
    }
}