var deckOfCards = new List<Card>
{
    new Card(1, Suit.Clubs),
    new Card(2, Suit.Clubs),
    new Card(3, Suit.Clubs),
    new Card(4, Suit.Clubs),
    new Card(5, Suit.Clubs),
    new Card(6, Suit.Clubs),
    new Card(7, Suit.Clubs),
    new Card(11, Suit.Clubs),
    new Card(12, Suit.Clubs),
    new Card(13, Suit.Clubs),

    new Card(1, Suit.Hearts),
    new Card(2, Suit.Hearts),
    new Card(3, Suit.Hearts),
    new Card(4, Suit.Hearts),
    new Card(5, Suit.Hearts),
    new Card(6, Suit.Hearts),
    new Card(7, Suit.Hearts),
    new Card(11, Suit.Hearts),
    new Card(12, Suit.Hearts),
    new Card(13, Suit.Hearts),

    new Card(1, Suit.Diamonds),
    new Card(2, Suit.Diamonds),
    new Card(3, Suit.Diamonds),
    new Card(4, Suit.Diamonds),
    new Card(5, Suit.Diamonds),
    new Card(6, Suit.Diamonds),
    new Card(7, Suit.Diamonds),
    new Card(11, Suit.Diamonds),
    new Card(12, Suit.Diamonds),
    new Card(13, Suit.Diamonds),

    new Card(1, Suit.Spades),
    new Card(2, Suit.Spades),
    new Card(3, Suit.Spades),
    new Card(4, Suit.Spades),
    new Card(5, Suit.Spades),
    new Card(6, Suit.Spades),
    new Card(7, Suit.Spades),
    new Card(11, Suit.Spades),
    new Card(12, Suit.Spades),
    new Card(13, Suit.Spades),
};

var players = new List<Player> 
{ 
    new Player(1, "Jaco", isDealer: true), 
    new Player(2, "Hinri"), 
    new Player(3, "Leo") 
};

//TODO: Aqui deve começar a contagem de pontos pelo próximo jogador ao lado do dealer... O dealer tem que ser o último jogador a falar quantos pontos faz
for(var i = 0; i < players.Count(); i++)
{
    players[i].Hand = new Card[3];    
    
    for(int f = 0; f < 3; f++)
    {        
        var randomNumber = new Random().Next(0, deckOfCards.Count() - 1);
        var cardSelected = deckOfCards[randomNumber];

        players[i].Hand[f] = cardSelected;
        deckOfCards.RemoveAt(randomNumber);
    }    
}

//TODO: Implementar a lógica de queimar a carta. O Dealer é que decide se a carta vai ser queimada ou não
var random = new Random().Next(0, deckOfCards.Count() - 1);
var cardReviewed = deckOfCards[random];

Console.WriteLine($"Carta virada: Número: {cardReviewed.Number} - Naipe: {cardReviewed.Suit}");

var cardManilha = 0;

if(cardReviewed.Number == 7)
    cardManilha = 11;
else if(cardReviewed.Number == 13)
    cardManilha = 1;
else
    cardManilha = cardReviewed.Number + 1;

Console.WriteLine($"Carta manilha: Número: {cardManilha}");





int pointsOnTable = 0;
for(var i=0; i < players.Count(); i++){
    Console.WriteLine($"Player: {players[i].Name} - Cartas: ");

    foreach(var card in players[i].Hand){
        Console.WriteLine($"Número da carta: {card.Number} - Naipe: {card.Suit}");
    }

    bool pointsIsValid = true;
    do{
        Console.WriteLine($"Jogador {players[i].Name}, quantos pontos você faz?");
        var pointsPlayerMakes = Convert.ToInt32(Console.ReadLine());

        var isLastPlayer = players.Count() - 1 == i;

        if(isLastPlayer && (pointsOnTable + pointsPlayerMakes) == 3)
        {
            Console.WriteLine($"Total de pontos na mesa: {pointsOnTable} - A quantidade total de pontos não pode fechar em 3");
            pointsIsValid = false;
        }            
        else
        {
            pointsOnTable += pointsPlayerMakes;
            pointsIsValid = true;
        } 
    }while(pointsIsValid == false);

    Console.WriteLine("-------------------------------");
}



// int round = 0;
// while(round < 3)
// {
//     var player = players.Find(x => x.IsDealer); //jogador que começa é o próximo jogador que deu as cartas
// }

//Lista circular
// void nextItem() {
//     index++; // increment index (jogador atual)
//     index %= items.Count; // clip index (turns to 0 if index == items.Count)
//     // as a one-liner:
//     /* index = (index + 1) % items.Count; */

//     FazAlgo();
// }
