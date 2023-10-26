using System.Diagnostics.Tracing;
using System.Text;

public class GameFileManipulation
{
    private string[] files {get;set;}
    private string[] parameters { get; set; }

    private const ulong u = 1;
    private ulong whiteInfo = (u << 27) + (u << 36);
    private ulong blackInfo = (u << 28) + (u << 35);
    private ulong whiteCount = 2;
    private ulong blackCount = 2;
    private ulong whitePlays = 1;
    private bool firstTime = true;


    public void ReadFile(string turn)
    {
        
        if (turn == "m1")
        {
            if(firstTime)
            {
                string path = $"../front/{turn}.txt";
                using (StreamWriter sw = File.CreateText(path))
                {
                    string txt = 
                    whitePlays.ToString() + " " +
                    whiteInfo.ToString() + " " + 
                    whiteCount.ToString() + " " + 
                    blackInfo.ToString() + " " + 
                    blackCount.ToString(); 
                    sw.WriteLine(txt);
                };
                this.firstTime = false;
            }


            while(true){
                try{
                    string text = File.ReadAllText($"../front/[OUTPUT]{turn}.txt");
                    parameters = text.Split(' ');

                    parameters[0] = "1";
                    string param = "";

                    foreach (var p in parameters)
                        param += (p + " ");

                    File.WriteAllText($"../front/[OUTPUT]{turn}.txt", param);
                    System.IO.File.Move($"../front/[OUTPUT]{turn}.txt", $"../front/{turn}.txt");
                    
                }catch{
                }
            }
        }




        else if(turn == "m2")
        {
            while(true){
                try{
                    string text = File.ReadAllText($"../front/[OUTPUT]{turn}.txt");
                    parameters = text.Split(' ');
                    parameters[0] = "0";
                    string param = "";

                    foreach (var p in parameters)
                        param += (p + " ");

                    File.WriteAllText($"../front/[OUTPUT]{turn}.txt", param);
                    System.IO.File.Move($"../front/[OUTPUT]{turn}.txt", $"../front/{turn}.txt");
                } 
                catch{
                }
            }
        }

    }
}