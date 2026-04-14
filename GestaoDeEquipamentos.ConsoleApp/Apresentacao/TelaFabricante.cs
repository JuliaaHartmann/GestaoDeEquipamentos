using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante
{
    public RepositorioFabricante? repositorioFabricante;
    public RepositorioEquipamento? repositorioEquipamento;

    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar fabricante");
        Console.WriteLine("2 - Editar fabricante");
        Console.WriteLine("3 - Excluir fabricante");
        Console.WriteLine("4 - Visualizar fabricantes");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de Fabricante");
        Console.WriteLine("---------------------------------");

        Fabricante novoFabricante = new Fabricante();

        do
        {
            Console.Write("Digite o nome do Fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) &&
                novoFabricante.nome.Length >= 2)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o e-mail do fabricante: ");
        novoFabricante.email = Convert.ToString(Console.ReadLine());

        Console.Write("Digite o telefone do fabricante: ");
        novoFabricante.telefone = Convert.ToString(Console.ReadLine());

        repositorioFabricante.Cadastrar(novoFabricante);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O fabricante \"{novoFabricante.id}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Fabricantes");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
            "Id", "Nome", "E-mail", "Telefone"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante novoFabricante = new Fabricante();

        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) &&
                novoFabricante.nome.Length >= 3)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o e-mail do fabricante: ");
            novoFabricante.email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.email) &&
                novoFabricante.email.Length >= 3)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o telefone do fabricante: ");
            novoFabricante.telefone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.telefone) &&
                novoFabricante.telefone.Length >= 7)
            {
                break;
            }

        } while (true);

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o fabricante informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O fabricante \"{idSelecionado}\" foi editado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Fabricante");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
          "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
            "Id", "Nome", "E-mail", "Telefone"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

        if (conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O fabricante \"{idSelecionado}\" foi excluído com sucesso.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontar o fabricante \"{idSelecionado}\".");
            Console.WriteLine("---------------------------------");
        }

        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Fabricantes");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            "Id", "Nome", "Email", "Telefone", "Qtd Equipamentos"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            repositorioFabricante.ObterQuantidadeEquipamento(f!, repositorioEquipamento);

            Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
             f.id, f.nome, f.email, f.telefone, f.quantidadeEquipamentos
            );
        }

        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

}
