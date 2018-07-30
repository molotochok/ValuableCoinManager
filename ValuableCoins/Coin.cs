using System;
using System.ComponentModel;
using System.Drawing;

namespace ValuableCoins
{
    [Serializable]
    public class Coin
    {
        public Coin()
        {
            Id    = 0;
            Name  = "";
            Metal = "";
            Par   = "";
            Price = 0;
            Date  = new DateTime();
        }
        public Coin(int id, string name, string metal, string par, int price, DateTime date)
        {
            Id = id;
            Name = name;
            Metal = metal;
            Par = par;
            Price = price;
            Date = date;
        }
        public Coin(Coin coin)
        {
            this.Id    = coin.Id;
            this.Name  = coin.Name;
            this.Metal = coin.Metal;
            this.Par   = coin.Par;
            this.Price = coin.Price;
            this.Date  = coin.Date;
        }

        [Browsable(false)]
        public int Id        { get; set; }
        public string Name   { get; set; }
        public string Metal  { get; set; }
        public string Par    { get; set; }
        public int Price     { get; set; }
        public DateTime Date { get; set; }
    }
}
