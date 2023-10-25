public record struct OthelloBoard(ulong Winfo, ulong Binfo, byte Wcount, byte Bcount, byte Wplays)
{
    ulong table = Winfo | Binfo, border;
    List<int> positions = new List<int>{1, 9, -9, -1, -8, 8, 7, -7};

    
    ulong tableBorder = 18411139144890810879;
    public void GetBorderGame()
    {
        if((table & tableBorder) > 0)
        {
            for(int i = 0; i < 8; i++)
                border |= table >>> positions[i];
            border ^= table;
        }
    }

    public ulong PlaysAvailable()
    {
        ulong tempBorder, findEnemy, findAlly, playAvailable = 0;
        if(Wplays == 1)
        {

            ulong temMap = border | Winfo;
            for(int j = 0; j < 64; j++)
            {
                tempBorder = border >>> 63 - j;
                if(!((tempBorder & 1 )== 1))
                    continue;

                for(int i = 0; i < 8; i++)
                {
                    findEnemy = tempBorder >>> positions[i];
                    if(!((findEnemy & 1 )== 1))
                        continue;
                    if(!((findEnemy & Binfo )> 0))
                        continue;
                    while((findEnemy & tableBorder) != 1)
                    {
                        findAlly = findEnemy >>> positions[i];
                        if((findAlly & Winfo) > 0)
                            playAvailable |= tempBorder;
                    } 
                }
            }
        }
        else
        {
            for(int j = 0; j < 64; j++)
            {
                tempBorder = border >>> 63 - j;
                if(!((tempBorder & 1 )== 1))
                    continue;

                for(int i = 0; i < 8; i++)
                {
                    findEnemy = tempBorder >>> positions[i];
                    if(!((findEnemy & 1 )== 1))
                        continue;
                    if(!((findEnemy & Winfo )> 0))
                        continue;
                    while((findEnemy & tableBorder) != 1)
                    {
                        findAlly = findEnemy >>> positions[i];
                        if((findAlly & Binfo) > 0)
                            playAvailable |= tempBorder;
                    } 
                }
            }
        }
        
        return playAvailable;
    }

}
