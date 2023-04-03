using System;

string choose = "n";

while (choose != "y") // начало игры,играть или не играть вот в чём вопрос
{ 
    Console.WriteLine("Welcome to fuck your moth... a mean blackjack!");
    Console.WriteLine("to start game write: 'y'");
    choose = Console.ReadLine();
    if(choose == "y")
    {
        startgame(); // Запуск игры
    }
}


void startgame() // начало игры и его геймплей
{
    int number = 0;
    Console.WriteLine("handing out cards....// ");

    Players player = new Players("aroz", 0, ""); // создаётся игрок
    Players dealer = new Players("dealer", 0, "");// создаётся дилер

    void GiveRandomCard (Players player)
    {
        // переменная для вывода карты и счёта
        player.value += shuffle(out number); // прибавляем значение карты к счёту
        Deck card_dealer = (Deck)number; // вытаскиваем карту из перечисления
        player.cards += card_dealer + "/"; // объединение новых карт, для вывода руки
                                           
    }

    for (int i = 0; i < 2; i++) // раздача стартовых карт игрокам
    {
        if (i != 1) // Дилер получает карту, кроме 2!
        {
            GiveRandomCard(dealer);
            GiveRandomCard(player);
        }
        else
        {
            GiveRandomCard(player);
        }

    }

    gameplay();
    static int shuffle(out int number) // генерация случайной карты
    {
        Random rnd = new Random();
        number = rnd.Next(1, 11);
        return number;

    }
    void gameplay()
    {
        if (player.cards.Contains("A") && player.value <= 10)
        {
                player.value += 10;
        }

        if (dealer.cards.Contains("A") && dealer.value <= 10)
        {
                dealer.value += 10;
        }

        Console.WriteLine($"Рука игрока {player.name}: /{player.cards} (счёт:{player.value})");
        Console.WriteLine($"Рука игрока {dealer.name}: /{dealer.cards} (счёт:{dealer.value})");

    }
}
        
enum Deck {A = 1,two = 2, three = 3, four = 4, five = 5, // перечесление колоды карт
    six = 6, seven = 7, eight = 8, nine = 9, ten = 10, J = 10, Q = 10,K = 10,};
class Players // класс для создание игрока и дилера
{
    public string name;
    public int value;
    public string cards;
    public Players(string name, int value, string cards) // конструктор игроков
    {
        this.name = name;
        this.value = value;
        this.cards = cards;
    }
}