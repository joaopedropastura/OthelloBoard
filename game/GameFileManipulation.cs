using System.Text;

public class GameFileManipulation
{

    private string[] parameters { get; set; }

    private const ulong u = 1;
    private ulong whiteInfo = (u << 27) + (u << 36);
    private ulong blackInfo = (u << 28) + (u << 35);
    private ulong whiteCount = 2;
    private ulong blackCount = 2;
    private ulong whitePlays = 1;


    public void ReadFile(string turn)
    {

        if (turn == "m1")
        {
            string path = $"../front/{turn}.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                string txt = 
                whiteInfo.ToString() + " " + 
                whiteCount.ToString() + " " + 
                blackInfo.ToString() + " " + 
                blackCount.ToString() + " " + 
                whitePlays.ToString();

                sw.WriteLine(txt);
            };
            
        }

        // string text = File.ReadAllText(file);
        // parameters = text.Split(' ');

        // System.IO.File.Move(file, "../front/m2.txt");
    }
}