using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

startgame();
void startgame(){
    string start = "n";

    while (start != "y") // начало игры,играть или не играть вот в чём вопрос
    {
        Console.WriteLine("Welcome to fuck your moth... a mean blackjack!");
        Console.WriteLine("to start game write: 'y'");
        start = Console.ReadLine();
        if (start == "y")
        {
            game(); // Запуск игры
        }
    }
}


void game() // начало игры и его геймплей
{
    int number = 0;
    Console.WriteLine("handing out cards....// ");

    Players player = new Players("aroz", 0, ""); // создаётся игрок
    Players dealer = new Players("dealer", 0, "");// создаётся дилер

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

    void GiveRandomCard(Players player)
    {
        // переменная для вывода карты и счёта
        player.value += shuffle(out number); // прибавляем значение карты к счёту
        Deck card_dealer = (Deck)number; // вытаскиваем карту из перечисления
        player.cards += card_dealer + "/"; // объединение новых карт, для вывода руки
        checkAce();
        void checkAce()
        {
            if (player.cards.Contains("A") && player.value <= 10)
            {
                player.value += 10;
            }

            if (dealer.cards.Contains("A") && dealer.value <= 10)
            {
                dealer.value += 10;
            }
        }

    }


    static int shuffle(out int number) // генерация случайной карты
    {
        Random rnd = new Random();
        number = rnd.Next(1, 11);
        return number;

    }


    void gameplay()
    {
        gameActions();

        void gameActions()
        {
            string choose = "y";
            score(player,dealer);
            while (choose == "y") // пока игрок не пасанёт,цикл будет предлогать добор
            {
                Console.WriteLine("хотите взять карту или спасовать? 'y' - взять, 'n' - пас ");
                choose = Console.ReadLine();
                if (choose == "y")
                {
                    GiveRandomCard(player); // игрок добирает карты
                    score(player, dealer);
                }
                else if (dealer.value >= 17) // при счёте dealer 17 и более не идёт добор
                {
                    score(player, dealer);
                }
            }

            while (choose == "n") // дилер добирает нужное кол-во пи пасе игрока
            {
                if (dealer.value >= 17 && dealer.value <= 22) // при счёте dealer 17 и более не идёт добор
                {
                    score(player, dealer);
                    choose = "a";
                }
                else
                {
                    GiveRandomCard(dealer);
                    score(player, dealer);
                }
            }
            void score(Players player, Players dealer)
            {
                player.value = 20;
                dealer.value = player.value;
                Console.WriteLine($"Рука игрока {player.name}: /{player.cards} (счёт:{player.value})");
                Console.WriteLine($"Рука игрока {dealer.name}: /{dealer.cards} (счёт:{dealer.value})");
                switch (player.value)
                {
                    case 21:
                        endgame(win.playerWin);
                        startgame();
                        break;
                    case > 21:
                        endgame(win.playerLose);
                        startgame();
                        break;
                    case < 21:
                        endgame(win.playerInGame);
                        break;
                }
                switch (dealer.value)
                {
                    case 21:
                        endgame(win.playerLose);
                        startgame();
                        break;
                    case > 21:
                        endgame(win.playerWin);
                        startgame();
                        break;
                    case < 21:
                        endgame(win.playerInGame);
                        break;
                }
                if (dealer.value == player.value  && dealer.value >= 17 && choose == "n")
                {
                    endgame(win.tie);
                    startgame();
                }
                if (dealer.value >= 17 && dealer.value > player.value && choose == "n")
                {
                    endgame(win.playerLose);
                    startgame();
                }
                else if(dealer.value >= 17 && dealer.value < player.value && choose == "n")
                {
                    endgame(win.playerWin);
                    startgame();
                }

                void endgame(win status)
                {
                    switch (status)
                    {
                        case win.playerWin:
                            Console.WriteLine("вы выйграли!");
                            break;
                        case win.playerLose:
                            Console.WriteLine("вы Проебали!");
                            break;
                        case win.tie:
                            Console.WriteLine("ничья");
                            break;
                    }
                }

            }

        }

    }







    }


        
enum Deck {A = 1,two = 2, three = 3, four = 4, five = 5, // перечесление колоды карт
    six = 6, seven = 7, eight = 8, nine = 9, ten = 10, J = 10, Q = 10,K = 10,};
enum win { playerWin = 1, playerInGame = 2, playerLose = 3, tie = 4 }
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