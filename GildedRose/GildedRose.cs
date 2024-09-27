using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items; //no accessor, name not correct for a field.
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++) //for instead of foreach! 
            {
                //nested ifs! Magic strings! 
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros") //can probably combine this with the above IF?
                        {
                            Items[i].Quality--;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50) //magic number
                    {
                        Items[i].Quality++;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") //magic string
                        {
                            if (Items[i].SellIn < 11) //magic number
                            {
                                if (Items[i].Quality < 50) //magic number
                                {
                                    Items[i].Quality++;
                                }
                            }

                            if (Items[i].SellIn < 6) //magic number
                            {
                                if (Items[i].Quality < 50) //magic number
                                {
                                    Items[i].Quality++;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn--;
                }

                if (Items[i].SellIn < 0) //HandlePastSellBy()? - could return early instead of all these nested ifs! 
                {
                    if (Items[i].Name != "Aged Brie") //magic string
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") //magic string
                        {
                            if (Items[i].Quality > 0) //combine ifs
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros") //magic string
                                {
                                    Items[i].Quality--;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = 0;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50) //magic number
                        {
                            Items[i].Quality++;
                        }
                    }
                }
            }
        }
    }
}