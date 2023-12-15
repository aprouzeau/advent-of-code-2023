using System.Text;

namespace AdventOfCode_C_;

class Day15{

    public IDictionary<int, Box> boxDic = new Dictionary<int, Box>();
    List<string> lensName = new List<string>();

    public Day15(){
        // string s = "HASH";
        // Console.WriteLine(ComputeValue(s));
        /* byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);
        foreach(byte b in ASCIIValues) {
            Console.WriteLine(b);
        } */
        string[] lines = File.ReadAllLines("inputDay15.txt");
        // string[] lines = File.ReadAllLines("testDay15.txt");
        string[] instruc = lines[0].Split(',');
        /* long sum = 0;
        foreach(string s in instruc){
            sum += ComputeValue(s);
        } */
        foreach(string s in instruc){
            if(s.Contains('=')){
                string[] infos = s.Split('=');
                if(!boxDic.ContainsKey(ComputeValue(infos[0]))){
                    boxDic[ComputeValue(infos[0])] = new Box();
                }
                boxDic[ComputeValue(infos[0])].AddLens(infos[0], int.Parse(infos[1]));
                if(!lensName.Contains(infos[0])){
                    lensName.Add(infos[0]);
                }
            }
            else if(s.Contains('-')){
                string[] infos = s.Split('-');
                if(!boxDic.ContainsKey(ComputeValue(infos[0]))){
                    boxDic[ComputeValue(infos[0])] = new Box();
                }
                boxDic[ComputeValue(infos[0])].removeLens(infos[0]);
            }
        }

        long sum = 0;
        foreach(string s in lensName){
            sum += (ComputeValue(s)+1) * boxDic[ComputeValue(s)].getOrder(s) * boxDic[ComputeValue(s)].getFocal(s);
        }
        Console.WriteLine(sum);
        //Console.WriteLine(ComputeValue("qp"));


    }



    public int ComputeValue(string s){
        byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);
        int currentValue = 0;
        for(int i=0; i<ASCIIValues.Length; i++){
            currentValue += ASCIIValues[i];
            currentValue *= 17;
            currentValue %= 256;
        }
        return currentValue;
    }
}

