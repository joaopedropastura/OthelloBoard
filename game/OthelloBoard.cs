public record struct OthelloBoard(ulong Winfo, ulong Binfo, byte Wcount, byte Bcount, byte Wplays)
{
    ulong table = Winfo | Binfo, border;

    const ulong tableBorder = 18411139144890810879;
    public ulong PlaysAvailable()
    {

        if(!table & tableBorder)
        {
            for(int i = 0; i < 8; i++)
            {
                       
            }
        }

    }

}
