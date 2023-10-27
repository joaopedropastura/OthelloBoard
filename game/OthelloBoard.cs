public record struct OthelloBoard(byte Wplays, ulong Winfo, byte Wcount, ulong Binfo, byte Bcount)
{
    ulong table = Winfo | Binfo, border = 0;
    List<int> positions = new List<int> { 1, 9, 8, 7 };

    public List<ulong> plays = new List<ulong> { };


    ulong tableBorder = 18411139144890810879;
    public ulong GetBorderGame()
    {
        for (int i = 0; i < 4; i++)
        {
            border |= table << positions[i];
            border |= table >> positions[i];
        }
        border ^= table;

        return border;
    }

    public void verifyPlays(ulong pieces1, ulong pieces2)
    {
        ulong tempBorder, findEnemy, findAlly = 0, newTable = 0;
        bool playAvailable = false;
        for (int j = 0; j < 64; j++)
        {
            tempBorder = border >>> 63 - j;
            if (!((tempBorder & 1) == 1)){
                continue;
            }

            for (int i = 0; i < 4; i++)
            {
                findEnemy = tempBorder >>> positions[i];
                if ((findEnemy & 1) == 1)
                {
                    continue;
                }
                if (!((findEnemy & pieces1) == 1))
                {
                    continue;
                }
                System.Console.WriteLine("c");
                while ((findEnemy & tableBorder) != 1)
                {
                    System.Console.WriteLine("d");
                    findAlly = findEnemy >>> positions[i];
                    if ((findAlly & pieces2) > 0)
                        playAvailable = true;
                }

                while ((findEnemy & tableBorder) != 1)
                {
                    if (playAvailable == false)
                        break;

                    findAlly |= findEnemy >>> positions[i];
                    if ((findAlly & pieces1) > 0)
                        newTable |= findEnemy >>> positions[i];
                }
                playAvailable = false;
                newTable |= tempBorder | pieces2;
                plays.Add(newTable);
            }

        }
    }



    public void PlaysAvailable()
    {
        if (Wplays == 1)
            verifyPlays(Binfo, Winfo);
        else
            verifyPlays(Winfo, Binfo);

        foreach (var i in plays)
        {
            System.Console.WriteLine(i);
        }

    }


    public bool GameEnded()
    {
        PlaysAvailable();

        return plays.Count() == 0 ? true : false;
    }

    // public OthelloBoard Clone()
    // {
    //     OthelloBoard copy = new OthelloBoard();
    //     Array.Copy(
    //         this.data, 
    //         copy.data, 
    //         this.data.Length
    //     );
    //     Array.Copy(
    //         this.sums, 
    //         copy.sums, 
    //         this.sums.Length
    //     );
    //     return copy;
    // }


    // public IEnumerable<OthelloBoard> Next()
    // {
    //     var clone = this.Clone();
    //     for (int b = 0; b < boards; b++)
    //     {
    //         if (!CanPlay(b))
    //             continue;

    //         for (int p = 0; p < 9; p++)
    //         {
    //             if (data[b * 9 + p])
    //                 continue;

    //             clone.Play(b, p);
    //             yield return clone;
    //             clone = this.Clone();
    //         }
    //     }
    // }


}
