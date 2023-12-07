using System.Collections.Immutable;

namespace AdventOfCode_C_;

class BoatRace{
    
    List<Race> listRace = new List<Race>();
    
    public BoatRace(){
        readInput();
        //fillTest2();
        computeAttempt();
    }

    void fillTest(){
        listRace.Add(new Race(7, 9));
        listRace.Add(new Race(15, 40));
        listRace.Add(new Race(30, 200));
    }

    void fillTest2(){
        listRace.Add(new Race(71530, 940200));
    }

    public void readInput(){
        //string[] lines = File.ReadAllLines("testDay6.txt");
        string[] lines = File.ReadAllLines("inputDay6.txt");
        string[] line1 = lines[0].Split(':');
        string[] valueTimeStr = line1[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] line2 = lines[1].Split(':');
        string[] valueDistanceStr = line2[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string time = "";
        string distance = "";
        for(int i=0; i<valueTimeStr.Length; i++){
            time += valueTimeStr[i];
            distance += valueDistanceStr[i];
            //Console.WriteLine(valueTimeStr[i]+"->"+valueDistanceStr[i]);
            //listRace.Add(new Race(long.Parse(valueTimeStr[i]), long.Parse(valueDistanceStr[i])));
        }
        long timeL = long.Parse(time);
        long distanceL = long.Parse(distance);
        listRace.Add(new Race(timeL, distanceL));
    }

    public void computeAttempt(){
        long finalR = 1;
        foreach (Race r in listRace)
        {
            r.computeResult();
            Console.WriteLine("Number of Attempt: "+r.possibleAttempt);
            finalR *= r.possibleAttempt;
        }
        Console.WriteLine("Final Result: "+finalR);
    }

}