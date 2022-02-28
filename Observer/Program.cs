// See https://aka.ms/new-console-template for more information
using Observer.Match;

var game = new Game();

var vesemir = new Card("vesemir", 6, false, TypeRow.CLOSE);
var keiraMetz = new Card("Keira Metz", 5, false, TypeRow.RANGED);
var weather = new Card("Weather", 0, false, TypeRow.CLOSE, TypeAbility.WEATHER);
var clearWeather = new Card("clearWeather", 0, false, null, TypeAbility.CLEAR_WEATHER);
var yennifer = new Card("Yennifer", 7, true, TypeRow.RANGED, TypeAbility.MEDIC);
var geralt = new Card("Geralt", 15, true, TypeRow.CLOSE);
var ves = new Card("Ves", 4, false, TypeRow.CLOSE);
var vesP1 = new Card("Ves", 4, false, TypeRow.CLOSE);
var morale = new Card("Morale", 1, false, TypeRow.CLOSE, TypeAbility.MORALE_BOOST);
var moraleP1 = new Card("Morale", 1, false, TypeRow.CLOSE, TypeAbility.MORALE_BOOST);
var dandelion = new Card("Dandelion", 2, false, TypeRow.CLOSE, TypeAbility.COMMANDERS_HORN_UNIT);
var dandelionP1 = new Card("Dandelion", 2, false, TypeRow.CLOSE, TypeAbility.COMMANDERS_HORN_UNIT);
var tightBond01 = new Card("TightBond", 4, false, TypeRow.CLOSE, TypeAbility.TIGHT_BOND);
var tightBondP1 = new Card("TightBond", 4, false, TypeRow.CLOSE, TypeAbility.TIGHT_BOND);
var tightBond02 = new Card("TightBond", 4, false, TypeRow.CLOSE, TypeAbility.TIGHT_BOND);
var zoltan = new Card("Zoltan", 4, false, TypeRow.CLOSE);

game.PlayerOne.Discard.Add(dandelionP1);
game.PlayerOne.Discard.Add(vesP1);

game.PlayerOne.PlayCardOnTheRow(vesemir);
game.PlayerTwo.PlayCardOnTheRow(geralt);

game.PlayerOne.PlayCardOnTheRow(keiraMetz);
game.PlayerTwo.PlayCardOnTheRow(ves);

game.PlayerOne.PlayCardOnTheRow(weather);
game.PlayerTwo.PlayCardOnTheRow(weather);

game.PlayerOne.PlayCardOnTheRow(clearWeather);
game.PlayerTwo.PlayCardOnTheRow(clearWeather);

game.PlayerOne.PlayCardOnTheRow(tightBond01);
game.PlayerTwo.PlayCardOnTheRow(dandelion);

game.PlayerOne.PlayCardOnTheRow(tightBond02);
game.PlayerTwo.PlayCardOnTheRow(morale);

game.PlayerOne.PlayCardOnTheRow(yennifer);
game.PlayerTwo.PlayCardOnTheRow(zoltan);

game.PlayerOne.PlayCardOnTheRow(moraleP1);
game.PlayerTwo.PlayCardOnTheRow(tightBondP1);

Console.WriteLine($"\nPlayer ONE");
foreach (var row in game.PlayerOne.Rows)
{
    Console.WriteLine($"Row {row.TypeRow} Strength {row.Score.Strength}");
    foreach (var card in row.Cards)
    {
        Console.WriteLine($"{card.Name} {card.Score.Strength} {card.Row} ");
        foreach (var stat in card.Score.Stats)
            Console.Write($"{stat.Key} : {stat.Value} ");
        Console.WriteLine();
    }
}


Console.WriteLine($"\nPlayer TWO");
foreach (var row in game.PlayerTwo.Rows)
{
    Console.WriteLine($"Row {row.TypeRow} Strength {row.Score.Strength}");
    foreach (var card in row.Cards)
    {
        Console.WriteLine($"{card.Name} {card.Score.Strength} {card.Row} ");
        foreach (var stat in card.Score.Stats)
            Console.Write($"{stat.Key} : {stat.Value} ");
        Console.WriteLine();
    }
}

Console.ReadLine();
