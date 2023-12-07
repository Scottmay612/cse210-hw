public class Golf : Game {
    public Golf() {
        _name = "Golf";
        _description = "This game is created after real life Golf. Therefore, the goal is to get the lowest amount of points possible.";
        _roundNum = 1;
        _endingLimit = 9;
        _gameRules = new List<string>() {
            "Players: Golf can be played with 2-6 players.",
            "Game setup: Each player is dealt 8 cards. They must lay them in 2 rows of 4 with all of the cards face down.",
            "Game start: Each player picks 2 of their 8 cards to turn over and display to everyone.",
            "Each round: Players will take turns drawing from the deck. If they like their card, they can swap it out with one of their current cards. If not, they can discard it and flip over one of the overturned cards.",
            "Card scores: Cards are numbered from 0 - 12. The goal is to have the lowest score as possible. If two cards in a column are the same, they cancel each other out and are equal to 0 points.",
            "Negative points: There are 8 '-5' cards in the deck. If a player gets 2 sets of the same card (4 cards total), it is equal to -10 points. If 3 sets (6 cards), it is equal to -15. If 4 sets (8 cards), it is equal to -20.",
            "Round end: When a player has flipped over their last card, the remaining players get one more turn and then the round is over.",
            "Scoring: At the end of each round, each player counts their points and adds it to their total score.",
            "Game end: After 9 rounds, the player with the least amount of points wins!"
        };
    }
    public Golf(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        _gameRules = new List<string>() {
            "Players: Golf can be played with 2-6 players.",
            "Game setup: Each player is dealt 8 cards. They must lay them in 2 rows of 4 with all of the cards face down.",
            "Game start: Each player picks 2 of their 8 cards to turn over and display to everyone.",
            "Each round: Players will take turns drawing from the deck. If they like their card, they can swap it out with one of their current cards. If not, they can discard it and flip over one of the overturned cards.",
            "Card scores: Cards are numbered from 0 - 12. The goal is to have the lowest score as possible. If two cards in a column are the same, they cancel each other out and are equal to 0 points.",
            "Negative points: There are 8 '-5' cards in the deck. If a player gets 2 sets of the same card (4 cards total), it is equal to -10 points. If 3 sets (6 cards), it is equal to -15. If 4 sets (8 cards), it is equal to -20.",
            "Round end: When a player has flipped over their last card, the remaining players get one more turn and then the round is over.",
            "Scoring: At the end of each round, each player counts their points and adds it to their total score.",
            "Game end: After 9 rounds, the player with the least amount of points wins!"
        };
    }
}