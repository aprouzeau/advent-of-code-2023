namespace AdventOfCode_C_;


class Day11{

    List<int> emptyColumns = new List<int>();
    List<int> emptyLines = new List<int>();

    char[][] rawInpt;
    char[][] finalInpt;
    List<int> galaxyComputed = new List<int>();
    List<Galaxy> listFoundGalaxy = new List<Galaxy>();

    int offset = 1000000;
    public Day11(){
        string[] lines = File.ReadAllLines("inputDay11.txt");
        //string[] lines = File.ReadAllLines("testDay11.txt");
        int numberRow = lines.Length;
        int numberColumn = lines[0].Length;
        //Console.WriteLine(numberRow+" Rows, "+numberColumn+" Columns");
        bool foundGalaxy = false;
        bool[] foundGalaxyColumn = new bool[numberColumn];
        rawInpt = new char[numberRow][];
        int countGalaxy = 0;
        for(int k=0; k<numberColumn; k++){
            foundGalaxyColumn[k] = false;
        }
        for(int i=0; i<numberRow; i++){
            foundGalaxy = false;
            rawInpt[i] = new char[numberColumn];
            for(int j=0; j<numberColumn; j++){
                rawInpt[i][j] = lines[i][j];
                if(rawInpt[i][j] == '#'){
                    foundGalaxy = true;
                    foundGalaxyColumn[j] = true;
                    countGalaxy ++;
                    listFoundGalaxy.Add(new Galaxy(countGalaxy, i, j));
                }
            }
            if(!foundGalaxy){
                emptyLines.Add(i);
            }
        }
        for(int k=0; k<numberColumn; k++){
            if(!foundGalaxyColumn[k]){
                emptyColumns.Add(k);
            }
        }
        /*Console.WriteLine("Empty Lines:");
        foreach(int i in emptyLines){
            Console.WriteLine(i+"");
        }
        Console.WriteLine("Empty Columns:");
        foreach(int i in emptyColumns){
            Console.WriteLine(i+"");
        }*/
        int newNumberRow = numberRow + emptyLines.Count;
        int newNumberColumn = numberColumn + emptyColumns.Count;
        finalInpt = new char[newNumberRow][];
        int offSetLine = 0;
        int offSetColumn = 0;
        //int countGalaxy = 0;
        /*for(int i=0; i<newNumberRow; i++){
            finalInpt[i] = new char[newNumberColumn];
            //Console.WriteLine(i);
            offSetColumn = 0;
            for(int j=0; j<newNumberColumn; j++){
                //Console.WriteLine("j: "+j);
                finalInpt[i][j] = rawInpt[i-offSetLine][j-offSetColumn];
                //finalInpt[i][j] = '.';*/
                /*if(rawInpt[i-offSetLine][j-offSetColumn] == '#'){
                    countGalaxy ++;
                    listFoundGalaxy.Add(new Galaxy(countGalaxy, i, j));

                }*/
                /*if(emptyColumns.Contains(j-offSetColumn)){
                    j++;
                    finalInpt[i][j] = '.';
                    offSetColumn ++;
                }
            }
            if(emptyLines.Contains(i-offSetLine)){
                i++;
                finalInpt[i] = new char[newNumberColumn];
                for(int j=0; j<newNumberColumn; j++){
                    finalInpt[i][j] = '.';
                }
                offSetLine ++;
            }
        }*/
        foreach(int line in emptyLines){
            foreach(Galaxy g in listFoundGalaxy){
                if(g.initLine > line){
                    g.finalLine += offset-1;
                }
            }
        }
        foreach(int column in emptyColumns){
            foreach(Galaxy g in listFoundGalaxy){
                if(g.initColumn > column){
                    g.finalColumn += offset-1;
                }
            }
        }
        /*for(int i=0; i<newNumberRow; i++){
            Console.WriteLine(finalInpt[i]);
        }*/
        //Console.WriteLine("Found Galaxy: "+countGalaxy);
        /*foreach(Galaxy g in listFoundGalaxy){
            Console.WriteLine("Galaxy "+g.number+": "+g.initLine+";"+g.initColumn);
        }*/
        Galaxy[] gArray = listFoundGalaxy.ToArray();
        long sum = 0;
        for(int g = 0; g<countGalaxy; g++){
            for(int h = g+1; h<countGalaxy; h++){
                long distLine = Math.Abs(gArray[h].finalLine-gArray[g].finalLine);
                long distColmumn = Math.Abs(gArray[h].finalColumn-gArray[g].finalColumn);
                sum += (distLine+distColmumn);
            }
        }
        Console.WriteLine("Sum: "+sum);

    }
}