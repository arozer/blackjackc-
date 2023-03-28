using System.IO.Pipes;
using static System.Runtime.InteropServices.JavaScript.JSType;

string choose = "n";

while (choose != "y") // начало игры,играть или не играть вот в чём вопрос
{ 
    Console.WriteLine("Welcome to fuck your mot... a mean blackjack!");
    Console.WriteLine("to start game write: 'y'");
    choose = Console.ReadLine();
    if(choose == "y")
    {
        startgame(); // Запуск игры
    }
}


void startgame() // начало игры и его геймплей
{

    Console.WriteLine("handing out cards");

    Players player = new Players("aroz", 0);
    Players dealer = new Players("dealer", 0);

    for (int i = 0; i <= 2; i++)
    {
        int number = 0; // переменная для вывода карты и счёта
        dealer.value += shuffle(out number);
        Deck card = (Deck)number;
        Console.WriteLine(card);
        // Дилер шафлит первые 2 карты
        player.value += shuffle(out number);
        card = (Deck)number;
        Console.WriteLine(card);
        // игрок шафлит первые 2 карты
    }


    static int shuffle (out int number)
    {
        Random rnd = new Random();
        number = rnd.Next(1, 11);
        return number;
        
    }

    
}
enum Deck {A1 = 1,two = 2, three = 3, four = 4, five = 5,
    six = 6, seven = 7, eight = 8, nine = 9, ten = 10, J = 10, Q = 10,K = 10, A11 =11};
class Players // класс для создание игрока и дилера
{
    public string name;
    public int value;
    public int[] hand = Array.Empty<int>();
    public Players(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}