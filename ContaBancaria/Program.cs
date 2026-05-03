using ContaBancaria.Menu;
using ContaBancaria.Utils;

var conexao = new Conexao().Connection();
conexao.Open();

Console.WriteLine("Deu bom!");

conexao.Close();


//Menu menu = new Menu();
//menu.Executar();