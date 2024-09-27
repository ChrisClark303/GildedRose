﻿using System.Collections.Generic;

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
            foreach (Item item in Items) //for instead of foreach! 
            {
                //nested ifs! Magic strings! 
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros") //can probably combine this with the above IF?
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50) //magic number
                    {
                        item.Quality++;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert") //magic string
                        {
                            if (item.SellIn < 11) //magic number
                            {
                                if (item.Quality < 50) //magic number
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6) //magic number
                            {
                                if (item.Quality < 50) //magic number
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0) //HandlePastSellBy()? - could return early instead of all these nested ifs! 
                {
                    if (item.Name != "Aged Brie") //magic string
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert") //magic string
                        {
                            if (item.Quality > 0) //combine ifs
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros") //magic string
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50) //magic number
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}