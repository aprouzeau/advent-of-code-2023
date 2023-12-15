namespace AdventOfCode_C_;


class Day14{

    char [,] map;
    int numberRow;
    int numberColumn;

    int consecutiveNoChange;
    public Day14(){
        // string[] lines = File.ReadAllLines("testDay14.txt");
        string[] lines = File.ReadAllLines("inputDay14.txt");
        numberRow = lines.Length;
        numberColumn = lines[0].Length;
        map = new char[numberRow, numberColumn];
        for(int i=0; i<numberRow; i++){
            for(int j=0; j<numberColumn; j++){
                map[i, j] = lines[i][j];
            }
        }
        //map = lines;
        //printMap();

        /* for(int j=0; j<numberColumn; j++){
            int nextFreeSpot = 0;
            for(int i=0; i<numberRow; i++){
                char currentMap = map[i,j];
                
                if(currentMap == '.'){
                    nextFreeSpot = Math.Min(i, nextFreeSpot);
                }
                else if(currentMap == 'O'){
                    //char tempoChar = 
                    map[i, j] = '.';
                    map[nextFreeSpot, j] = 'O';
                    nextFreeSpot ++;

                }
                else if(currentMap == '#'){
                    nextFreeSpot = i+1;
                }
                //Console.WriteLine(currentMap+" - Next Free Spot: "+nextFreeSpot);
            }
        } */
        
        //int numberCycle = 3;
        consecutiveNoChange = 0;
        long limit = 1000000000;
        long count = 0;

        var startTimeSpan = TimeSpan.Zero;
        var periodTimeSpan = TimeSpan.FromMinutes(1);

        var timer = new System.Threading.Timer((e) =>
        {
            Console.WriteLine("Count: "+count);   
        }, null, startTimeSpan, periodTimeSpan);


        while(consecutiveNoChange<10){
            int numberOfChanges = Cycle();
            if(numberOfChanges == 0){
                consecutiveNoChange ++;
            }
            if(count == limit){
                consecutiveNoChange = 11;
            }
            count ++;
        }     
        


        string[] mapStr = new string[numberRow];
        int[] mapInt = new int[numberRow];
        for(int i=0; i<numberRow; i++){
            string line = "";
            for(int j=0; j<numberColumn; j++){
                line += map[i, j];
            }
            mapStr[i] = line;
            mapInt[i] = CountCharsUsingLinqCount(line, 'O');
            //Console.WriteLine(mapStr[i]+" -> "+mapInt[i]);
        }
        long sum = 0;
        for(int i=0; i<numberRow; i++){
            sum += mapInt[i]*(numberRow-i);
        }

        Console.WriteLine(sum);
        //Console.WriteLine("------- New Map -------");

        //printMap();
        
    }

    void printMap(){
        for(int i=0; i<numberRow; i++){
            string line = "";
            for(int j=0; j<numberColumn; j++){
                line += map[i, j];
            }
            Console.WriteLine(line);
        }
    }

    public int Cycle(){
        int numberOfChanges = 0;
        for(int i=0; i<4; i++){
            numberOfChanges += RollBall(i);
        }
        return numberOfChanges;
    }

    // 0: North, 1: West, 2: South, 3: East
    public int RollBall(int direction){
        int numberOfChanges = 0;
        switch (direction)
        {
            case 0:
                for(int j=0; j<numberColumn; j++){
                    int nextFreeSpot = 0;
                    for(int i=0; i<numberRow; i++){
                        char currentMap = map[i,j];
                        
                        if(currentMap == '.'){
                            nextFreeSpot = Math.Min(i, nextFreeSpot);
                        }
                        else if(currentMap == 'O'){
                            //char tempoChar = 
                            map[i, j] = '.';
                            map[nextFreeSpot, j] = 'O';
                            if(i!=nextFreeSpot){
                                numberOfChanges++;
                            }
                            nextFreeSpot ++;

                        }
                        else if(currentMap == '#'){
                            nextFreeSpot = i+1;
                        }
                        //Console.WriteLine(currentMap+" - Next Free Spot: "+nextFreeSpot);
                    }
                }
                break;
            case 1:
                for(int j=0; j<numberRow; j++){
                    int nextFreeSpot = 0;
                    for(int i=0; i<numberColumn; i++){
                        char currentMap = map[j,i];
                        
                        if(currentMap == '.'){
                            nextFreeSpot = Math.Min(i, nextFreeSpot);
                        }
                        else if(currentMap == 'O'){
                            //char tempoChar = 
                            map[j, i] = '.';
                            map[j, nextFreeSpot] = 'O';
                            if(i!=nextFreeSpot){
                                numberOfChanges++;
                            }
                            nextFreeSpot ++;

                        }
                        else if(currentMap == '#'){
                            nextFreeSpot = i+1;
                        }
                        //Console.WriteLine(currentMap+" - Next Free Spot: "+nextFreeSpot);
                    }
                }
                break;
            case 2:
                    for(int j=0; j<numberColumn; j++){
                        int nextFreeSpot = numberRow-1;
                        for(int i=numberRow-1; i>=0; i--){
                            char currentMap = map[i,j];
                            
                            if(currentMap == '.'){
                                nextFreeSpot = Math.Max(i, nextFreeSpot);
                            }
                            else if(currentMap == 'O'){
                                //char tempoChar = 
                                map[i, j] = '.';
                                map[nextFreeSpot, j] = 'O';
                                if(i!=nextFreeSpot){
                                    numberOfChanges++;
                                }
                                nextFreeSpot --;

                            }
                            else if(currentMap == '#'){
                                nextFreeSpot = i-1;
                            }
                            //Console.WriteLine(currentMap+" - Next Free Spot: "+nextFreeSpot);
                        }
                    }
                    break;
            case 3:
                for(int j=0; j<numberRow; j++){
                    int nextFreeSpot = numberColumn-1;
                    for(int i=numberColumn-1; i>=0; i--){
                        char currentMap = map[j,i];
                        
                        if(currentMap == '.'){
                            nextFreeSpot = Math.Max(i, nextFreeSpot);
                        }
                        else if(currentMap == 'O'){
                            //char tempoChar = 
                            //Console.WriteLine(nextFreeSpot);
                            map[j, i] = '.';
                            map[j, nextFreeSpot] = 'O';
                            if(i!=nextFreeSpot){
                                numberOfChanges++;
                            }
                            nextFreeSpot --;

                        }
                        else if(currentMap == '#'){
                            nextFreeSpot = i-1;
                        }
                        //Console.WriteLine(currentMap+" - Next Free Spot: "+nextFreeSpot);
                    }
                }
                break;
        }
        return numberOfChanges;
    }

    public int CountCharsUsingLinqCount(string source, char toFind)
    {
        return source.Count(t => t == toFind);
    }

    
}