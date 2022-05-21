public class Player
{
    public Player(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public Player(long id, string name, bool isDealer)
    {
        Id = id;
        Name = name;
        IsDealer = isDealer;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public Card[] Hand { get; set; }
    public int Score { get; set; }
    public int PointsDoes { get; set; }
    public bool IsDealer { get; set; }
}