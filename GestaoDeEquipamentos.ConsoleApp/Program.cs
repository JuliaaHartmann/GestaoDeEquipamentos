﻿using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();
RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

TelaEquipamento telaEquipamento = new TelaEquipamento();
telaEquipamento.repositorioEquipamento = repositorioEquipamento;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

TelaFabricante telaFabricante = new TelaFabricante();
telaFabricante.repositorioFabricante = repositorioFabricante;
telaFabricante.repositorioEquipamento = repositorioEquipamento;

// Dados teste
Fabricante fabricante = new Fabricante();
fabricante.nome = "Dell";
fabricante.email = "dell@dell.com";
fabricante.telefone = "0800123456";
repositorioFabricante.Cadastrar(fabricante);

Equipamento equipamento = new Equipamento();
equipamento.nome = "Notebook";
equipamento.fabricante = fabricante;
equipamento.precoAquisicao = 2000;
equipamento.dataFabricacao = DateTime.Now.AddYears(-5);

Equipamento equipamento2 = new Equipamento();
equipamento2.nome = "Monitor";
equipamento2.fabricante = fabricante;
equipamento2.precoAquisicao = 1200;
equipamento2.dataFabricacao = DateTime.Now.AddYears(-4);

repositorioEquipamento.Cadastrar(equipamento);
repositorioEquipamento.Cadastrar(equipamento2);

Chamado chamado = new Chamado();
chamado.titulo = "Quebrou o display";
chamado.descricao = "Está com deadpixel";
chamado.dataAbertura = DateTime.Now.AddDays(-7);
chamado.equipamento = equipamento;

repositorioChamado.Cadastrar(chamado);

while (true)
{
    //Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar equipamentos");
    Console.WriteLine("2 - Gerenciar chamados");
    Console.WriteLine("3 - Gerenciar fabricantes");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1")
        {
            string? opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaEquipamento.Cadastrar();

            else if (opcaoMenu == "2")
                telaEquipamento.Editar();

            else if (opcaoMenu == "3")
                telaEquipamento.Excluir();

            else if (opcaoMenu == "4")
                telaEquipamento.VisualizarTodos();
        }

        else if (opcaoMenuPrincipal == "2")
        {
            string? opcaoMenu = telaChamado.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaChamado.Cadastrar();

            else if (opcaoMenu == "2")
                telaChamado.Editar();

            else if (opcaoMenu == "3")
                telaChamado.Excluir();

            else if (opcaoMenu == "4")
                telaChamado.VisualizarTodos(deveExibirCabecalho: true);
        }
        
         else if (opcaoMenuPrincipal == "3")
        {
            string? opcaoMenu = telaFabricante.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaFabricante.Cadastrar();

            else if (opcaoMenu == "2")
                telaFabricante.Editar();

            else if (opcaoMenu == "3")
                telaFabricante.Excluir();

            else if (opcaoMenu == "4")
                telaFabricante.VisualizarTodos();
        }
    }
}