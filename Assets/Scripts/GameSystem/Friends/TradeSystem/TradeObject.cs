using System;

[System.Serializable]
public class TradeObject
{
    public int playerID;
    public int playerToTradeID;
    public int steelAmount;
    public int steelCost;
    public bool acceptTrade1;
    public bool acceptTrade2;
    public bool isComplete1;
    public bool isComplete2;
}
