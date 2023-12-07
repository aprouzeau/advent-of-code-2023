using System.Linq;
namespace AdventOfCode_C_;

class Almanach{

    List<Seed> seeds = new List<Seed>();
    Mapping m;



    public Almanach(){
        //"Console.WriteLine("Hello, World from Almanach");"
        loadSeed();
    }

    public void loadSeed(){
        //testLoading();
        string[] lines = File.ReadAllLines("SeedTest.txt");
        // string[] lines = File.ReadAllLines("input.txt");
        string seedLine = lines[0];
        string [] seedPart = seedLine.Split(':');
        string seedNumber = seedPart[1].Trim();
        Console.WriteLine(seedNumber);
        string [] seedStr = seedNumber.Split(' ');
        seeds = CreateSeedList(seedStr);
        /*foreach(string s in seedStr){
            seeds.Add(long.Parse(s));
        }*/
        //WriteList(seeds);
        
        //foreach (string line in lines)
        //Console.WriteLine(line);
        Mapping mIP = new Mapping();
        List<Seed> valueSrc = seeds;
        long minLoc1 = GetMinSeedValue(valueSrc);
        Console.WriteLine("Minimum value: "+minLoc1);
        for(int i=2; i<lines.Length; i++){
            if(lines[i].Contains("map")){
                mIP = new Mapping();
            }
            else if(lines[i].Equals("")){
                //Console.WriteLine("Blank Line");
                List<Seed> resultp = mIP.loopOnMapping(valueSrc);
                valueSrc = resultp;
                long minLocT = GetMinSeedValue(valueSrc);
                Console.WriteLine("Minimum value: "+minLocT);
            }
            else{
                //Console.WriteLine(lines[i]);
                mIP.listOfMappings.Add(GetSpecMapping(lines[i]));
            }
        }
        // WriteList(valueSrc);
        List<Seed> results = mIP.loopOnMapping(valueSrc);
        valueSrc = results;
        
        //WriteList(valueSrc);
        long minLoc = GetMinSeedValue(valueSrc);
        Console.WriteLine("Minimum value: "+minLoc);


    }

    private List<Seed> CreateSeedList(string[] seedStr)
    {
        List<Seed> listSeeds = new List<Seed>();
        for(int i=0; i<seedStr.Length; i+=2){
            long start = long.Parse(seedStr[i]);
            long range = long.Parse(seedStr[i+1]);
            listSeeds.Add(new Seed(start, range));
        }

        return listSeeds;
    }

    private long GetMinSeedValue(List<Seed> l){
        long minV = 1000000000;
        foreach(Seed s in l){
            if(s.start< minV){
                minV = s.start;
            }
        }
        return minV;
    }

    private SpecMapping GetSpecMapping(string v)
    {
        string [] vStr = v.Trim().Split(' ');
        SpecMapping sm = new SpecMapping(long.Parse(vStr[0]), long.Parse(vStr[1]), long.Parse(vStr[2]));
        return sm;
    }

    /*void testLoading(){
        // 79 14 55 13
        seeds.Add(79);
        seeds.Add(14);
        seeds.Add(55);
        seeds.Add(10);

        m = new Mapping();
        m.listOfMappings.Add(new SpecMapping(50, 98, 2));
        m.listOfMappings.Add(new SpecMapping(52, 50, 48));

        List<long> soils = m.loopOnMapping(seeds);
        foreach (long s in soils)
        {
            Console.WriteLine(""+s);
        }
    }*/

    public void WriteList(List<long> listToWrite){
        foreach (long s in listToWrite)
        {
            Console.WriteLine(""+s);
        }
    }


}