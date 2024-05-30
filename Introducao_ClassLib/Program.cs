using Controllers;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Introducao_MVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting proccess \n");

            Car car = new Car
            {
                Id = 1,
                Name = "Enzo",
                Color = "Red",
                Year = 2000
            };

            var result = string.Empty;
            var option = 0;
            do
            {
                Console.WriteLine(
                    "[ 1 ] Insert\n" +
                    "[ 2 ] Update\n" +
                    "[ 3 ] Delete\n" +
                    "[ 4 ] Get All\n" +
                    "[ 5 ] Get by ID\n" +
                    "[ 0 ] Sair \n");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        result = new CarController().Insert(car) ? "Registro Inserido." : "Erro ao inserir Registro.";
                        Console.WriteLine(result);
                        break;
                    case 2:
                        result = new CarController().Update(car) ? "Registro Atualizado." : "Erro ao Atualizar Registro.";
                        Console.WriteLine(result);
                        break;
                    case 3:
                        result = new CarController().Delete(car.Id) ? "Registro Deletado." : "Erro ao Excluir Registro.";
                        Console.WriteLine(result);
                        break;
                    case 4:
                        var allRegisters = new CarController().GetAll();
                        if (allRegisters != null) 
                        {
                            Console.WriteLine("Registros Encontrados: \n");
                            allRegisters.ForEach(r => Console.WriteLine(r + "\n"));
                        }
                        else
                        {
                            Console.WriteLine("Erro ao Buscar Registros.");
                        }
                        break;
                    case 5:
                        var register = new CarController().Get(car.Id);
                        if (register != null)
                        {
                            Console.WriteLine("Registro Encontrado: \n");
                            Console.WriteLine(register);
                        }
                        else
                        {
                            Console.WriteLine("Registro não encontrado.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Valor inválido");
                        break;
                }
                Console.ReadLine();
            }
            while (option > 0);
        }
    }
}
