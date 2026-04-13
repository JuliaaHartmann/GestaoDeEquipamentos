using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado?[] chamados = new Chamado[100];

    public void Cadastrar(Chamado novoChamado)
    {
        novoChamado.id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                chamados[i] = novoChamado;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Chamado novoEquipamento)
    {
        Chamado? chamadoSelecionado = SelecionarPorId(idSelecionado);

        if (chamadoSelecionado == null)
            return false;

        chamadoSelecionado.titulo = novoEquipamento.titulo;
        chamadoSelecionado.descricao = novoEquipamento.descricao;
        chamadoSelecionado.dataAbertura = novoEquipamento.dataAbertura;
        chamadoSelecionado.equipamento = novoEquipamento.equipamento;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
                continue;

            if (c.id == idSelecionado)
            {
                chamados[i] = null;
                return true;
            }
        }

        return false;
    }

    public Chamado? SelecionarPorId(string idSelecionado)
    {
        Chamado? equipamentoSelecionado = null;

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
                continue;

            if (c.id == idSelecionado)
            {
                equipamentoSelecionado = c;
                break;
            }
        }

        return equipamentoSelecionado;
    }

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }
}