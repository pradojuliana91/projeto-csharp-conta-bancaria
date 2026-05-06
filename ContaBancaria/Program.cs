using ContaBancaria.Menu;
using ContaBancaria.Utils;

var conexao = new Database().Connection();
conexao.Open();

Console.WriteLine("Deu bom!");

Menu menu = new Menu();
menu.Executar();

conexao.Close();

