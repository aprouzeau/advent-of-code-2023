namespace AdventOfCode_C_;

class Day13{
    List<Maps> listMaps = new List<Maps>();
    public Day13(){
        string[] lines = File.ReadAllLines("inputDay13.txt");
        //string[] lines = File.ReadAllLines("testDay13.txt");
        List<string> bufferedLines = new List<string>();
        foreach(string s in lines){
            if(s ==""){
                listMaps.Add(new Maps(bufferedLines));
                bufferedLines = new List<string>();
            }
            else{
                bufferedLines.Add(s);
            }
        }
        listMaps.Add(new Maps(bufferedLines));

        long finalNumber = 0;

        foreach(Maps m in listMaps){
            //m.printMap();
            finalNumber += m.number;
            //Console.WriteLine("");
        }

        Console.WriteLine(finalNumber);
    }
}