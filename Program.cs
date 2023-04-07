
Menu();

static void Menu()
{
    Console.Clear();

    System.Console.WriteLine(@" BEM VINDO AO EDITOR DE TEXTO DO FELIPE - DIA DE PRODUCAO 06-04-2023
    O que voce deseja fazer?
1 - Abrir arquivo
2 - Criar novo arquivo
3 - Excluir um arquivo
0 - Sair");

    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 1: Abrir(); break;
        case 2: Editar(); break;
        case 3: Excluir(); break;
        case 0: System.Environment.Exit(0); break;
        default: Menu(); break;
    }
}

static void Abrir()
{
    Console.Clear();
    System.Console.WriteLine("Qual caminho do arquivo?");
    var path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
        var text = file.ReadToEnd();
        System.Console.WriteLine(text);
    }

    Console.WriteLine();
    Console.ReadLine();
    Menu();
}

static void Editar()
{
    Console.Clear();

    Console.WriteLine(@"Digite seu texto abaixo: (ESC para sair)
    _________________________________________________");

    string text = "";

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

static void Salvar(string text)
{
    Console.Clear();
    System.Console.WriteLine("Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    System.Console.WriteLine($"O arquivo {path} foi salvo com sucesso!");
    Console.ReadLine();
    Menu();

}

static void Excluir()
{
    Console.Clear();
    System.Console.WriteLine("Qual caminho para excluir o arquivo?");
    var path = Console.ReadLine();
    File.Delete(path);
    Console.WriteLine("Excluindo...");
    Thread.Sleep(2000);
    Console.WriteLine("Arquivo excluido. PRESS ANY KEY");
    Console.ReadLine();
    Menu();
}