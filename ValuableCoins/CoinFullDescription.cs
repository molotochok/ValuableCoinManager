using System;
using System.Drawing;

namespace ValuableCoins
{
    class CoinFullDescription
    {
        public CoinFullDescription(Coin coin,               float weight,       
                                   float mintQualityrGrade, string group,           
                                   string series,           int circulation,         
                                   string description,      string obverseReverseDescription)
                                  // Image obverseImage,      Image reverseImage)
        {
            Coin = coin;

            Weight = weight;
            MintQualityrGrade = mintQualityrGrade;
            Group = group;
            Series = series;
            Circulation = circulation;

            Description = description;
            ObverseReverseDescription = obverseReverseDescription;

            /*ObverseImage = obverseImage;
            ReverseImage = reverseImage;*/
        }

        public Coin Coin { get; set; }

        public float Weight { get; set; }
        public float MintQualityrGrade { get; set; }
        public string Group { get; set; }
        public string Series { get; set; }
        public int Circulation { get; set; }

        public string Description { get; set; }
        public string ObverseReverseDescription { get; set; }

       // public Image ObverseImage { get; set; }
       // public Image ReverseImage { get; set; }
    }
}