
using System;
using System.Threading;

namespace Trabalho_ProgramaçãoII
{
    internal class Program
    {
        // Variáveis globais
        static int opcao = 0;

        static int[] numeros = new int[10];
        static string[] nomes = new string[10];
        static string[] partidos = new string[10];
        static string[] propostas = new string[10];
        static int[] qntd_votos = new int[10];

        static string[] cpfs = new string[100];

        static int qntd_candidatos = 0;
        static int qntd_eleitores = 0;

        // Inicia o Programa
        static void Main(string[] args)
        {
            CadastrarCandidatosIniciais();
            SelecionarOpcao();
        }

        // Cadastra candidatos inicialmente
        static void CadastrarCandidatosIniciais()
        {
            numeros[0] = 13;
            nomes[0] = "Lula";
            partidos[0] = "PT";
            propostas[0] = "Diminuir a desigualdade social e fim da escala 6x1";
            qntd_votos[0] = 0;

            numeros[1] = 22;
            nomes[1] = "Flávio Bolsonaro";
            partidos[1] = "PL";
            propostas[1] = "Investimento em infraestrutura e segurança";
            qntd_votos[1] = 0;

            numeros[2] = 14;
            nomes[2] = "Renan Santos";
            partidos[2] = "MBL";
            propostas[2] = "Ajustes fiscais e combate a supersalários";
            qntd_votos[2] = 0;

            numeros[3] = 70;
            nomes[3] = "Augusto Cury";
            partidos[3] = "Avante";
            propostas[3] = "Redução da dívida pública e atenção à saúde preventiva";
            qntd_votos[3] = 0;

            qntd_candidatos = 4;
        }

        // Mostra o Menu de Opções
        static void MostrarMenu()
        {
            Console.WriteLine("--- MENU DE OPÇÕES ---");
            Console.WriteLine("1. Mostrar Candidatos");
            Console.WriteLine("2. Cadastrar Candidato");
            Console.WriteLine("3. Votar");
            Console.WriteLine("4. Apurar Votos");
            Console.WriteLine("0. Sair");

            Console.Write("\nEscolha uma opção: ");

            opcao = int.Parse(Console.ReadLine());
        }

        // Seleciona a opção do usuário
        static void SelecionarOpcao()
        {
            do
            {
                MostrarMenu();

                switch (opcao)
                {
                    case 1:
                        MostrarCandidatos();
                        break;

                    case 2:
                        CadastrarCandidato();
                        break;

                    case 3:
                        Votar();
                        break;

                    case 4:
                        Console.WriteLine("\n>>> Iniciando apuração de votos...");
                        Thread.Sleep(qntd_eleitores * 750 + 300);

                        if (qntd_candidatos == 0)
                        {
                            Console.WriteLine(">>>Não existem candidatos cadastrados para realizar a apuração.");
                            break;
                        }

                        if (qntd_eleitores == 0)
                        {
                            Console.WriteLine(">>> Não existem votos registrados para realizar a apuração.");
                            break;
                        }

                        Apuracao(1, 0);
                        return;

                    case 0:
                        Console.WriteLine("\n>>>Encerrando o programa...");
                        return;

                    default:
                        Console.WriteLine("\n>>>Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("");

            } while (opcao != 0);
        }

        // Lógica para mostrar candidatos
        static void MostrarCandidatos()
        {
            Console.WriteLine("\n>>> Buscando candidatos...");
            Thread.Sleep(qntd_candidatos * 750);

            Console.WriteLine("\n--- CANDIDATOS CADASTRADOS ---");

            if (qntd_candidatos == 0)
            {
                Console.WriteLine(">>> Nenhum candidato cadastrado.");
                return;
            }

            for (int i = 0; i < qntd_candidatos; i++)
            {
                Console.WriteLine(
                    $"Número: {numeros[i]}, " +
                    $"Nome: {nomes[i]}, " +
                    $"Partido: {partidos[i]}, " +
                    $"Proposta: {propostas[i]}, " +
                    $"Votos: {qntd_votos[i]}"
                );
            }

            Console.WriteLine();
        }


        // Verifica se o número do candidato já está cadastrado
        static bool VerificarNumeroCandidato(int numero)
        {
            for (int i = 0; i < qntd_candidatos; i++)
            {
                if (numeros[i] == numero)
                {
                    return true;
                }
            }
            return false;
        }
        
        
        // Lógica para cadastrar candidato
        static void CadastrarCandidato()
        {
            Console.WriteLine("\n--- CADASTRAR CANDIDATO ---");

            Console.WriteLine("Digite o número do candidato: ");

            int numero = int.Parse(Console.ReadLine());

            if (VerificarNumeroCandidato(numero))
            {
                Console.WriteLine("\n>>> Candidato já está cadastrado.");
                return;
            }

            Console.WriteLine("Digite o nome do candidato: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o partido do candidato: ");
            string partido = Console.ReadLine();

            Console.WriteLine("Digite a proposta do candidato: ");
            string proposta = Console.ReadLine();

            // Adiciona o candidato às listas
            numeros[qntd_candidatos] = numero;
            nomes[qntd_candidatos] = nome;
            partidos[qntd_candidatos] = partido;
            propostas[qntd_candidatos] = proposta;
            qntd_votos[qntd_candidatos] = 0;
            
            qntd_candidatos++;

            Console.WriteLine("\n>>> Candidato cadastrado com sucesso!");
            Console.WriteLine("");

        }

        static int BuscarCandidato(int numero)
        {
            for (int i = 0; i < qntd_candidatos; i++)
            {
                if (numeros[i] == numero)
                {
                    return i;
                }
            }

            return -1;
        }

        static bool VerificarCPF(string cpf)
        {
            if (cpf == null)
            {
                Console.WriteLine("\n>>> CPF inválido.");
                return false;
            } else
            {
                for (int i = 0; i < qntd_eleitores; i++)
                {
                    if (cpfs[i] == cpf)
                    {
                        Console.WriteLine("\n>>> Eleitor já votou.");
                        return false;
                    }
                }
            }

            return true;
        }

        // Lógica para votar
        static void Votar()
        {
            Console.WriteLine("\n--- VOTAR ---");

            Console.WriteLine("Digite o CPF do eleitor: ");

            string cpf = Console.ReadLine();

            Console.WriteLine("\n>>> Verificando CPF...");
            Thread.Sleep(1000);

            bool pode_votar = VerificarCPF(cpf);

            if(pode_votar == false)
            {
                return;
            }

            Console.WriteLine("Digite o número do candidato que deseja votar: ");

            int numero = int.Parse(Console.ReadLine());

            int indice = BuscarCandidato(numero);

            Console.WriteLine("\n>>> Buscando candidato...");
            Thread.Sleep(1000);

            if (indice == -1)
            {
                Console.WriteLine("\n>>> Candidato não encontrado.");
                return;
            } else {
                Console.WriteLine("\n--- CANDIDATO SELECIONADO ---");
                Console.WriteLine("Candidato: " + nomes[indice]);
                Console.WriteLine("Número: " + numeros[indice]);
                Console.WriteLine("Partido: " + partidos[indice]);

                Console.WriteLine("\n>>> Confirmar voto (S/N)");

                string confirmarVoto = Console.ReadLine();

                if(confirmarVoto != "S" && confirmarVoto != "s")
                {
                    Console.WriteLine("\n>>> OPERAÇÃO CANCELADA");
                    return;
                }

            }

            // Adiciona o voto ao candidato
            qntd_votos[indice]++;
            cpfs[qntd_eleitores] = cpf;
            qntd_eleitores++;
            Console.WriteLine("\n>>> Voto registrado com sucesso!");
        }

        // Lógica para apuração de votos
        static void Apuracao(int indice, int indiceVencedorAtual)
        {
            if (indice >= qntd_candidatos)
            {
                Console.WriteLine("\n>>> Votos apurados!");
                Thread.Sleep(1000);

                Console.WriteLine("\n>>> Checando resultados...");
                Thread.Sleep(1000);

                // Verifica se existe outro candidato com a mesma quantidade de votos
                for (int i = 0; i < qntd_candidatos; i++)
                {
                    if (i != indiceVencedorAtual &&
                        qntd_votos[i] == qntd_votos[indiceVencedorAtual])
                    {
                        Console.WriteLine("\n>>> EMPATE NA ELEIÇÃO!");
                        Console.WriteLine(">>> Será necessário realizar um segundo turno.");
                        return;
                    }
                }

                // Se não houver empate, anuncia o vencedor
                Console.WriteLine(
                    "\n>>> " + nomes[indiceVencedorAtual] +
                    " ganhou com " + qntd_votos[indiceVencedorAtual] + " votos!"
                );

                return;
            }

            // Verifica se o candidato atual possui mais votos que o candidato vencedor atual (aquele com mais votos que a função já encontrou até o momento)
            if (qntd_votos[indiceVencedorAtual] < qntd_votos[indice])
            {
                indiceVencedorAtual = indice;
            }

            indice++;

            Apuracao(indice, indiceVencedorAtual);
        }

    }
}