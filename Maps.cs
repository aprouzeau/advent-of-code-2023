namespace AdventOfCode_C_;

class Maps{

    char[,] mapArray;
    int nbLines;
    int nbColumns;

    bool isSymLine;
    public int number;
    public Maps(List<string> strings){
        nbLines = strings.Count;
        nbColumns = strings.First().Length;
        mapArray = new char[nbLines, nbColumns];
        int count = 0;
        foreach(string s in strings){
            for(int j=0; j<nbColumns; j++){
                mapArray[count, j] = s[j];
            }
            count ++;
        }

        checkSymLine();
        checkSymColumn();
        if(isSymLine){
            number = (number+1)*100;
            //Console.WriteLine("Symetry on Line: "+this.number);
        }
        else{
            number = number+1;
            //Console.WriteLine("Symetry on Column: "+this.number);
        }
        
    }

    public void printMap(){
        for(int i=0; i<nbLines; i++){
            string toPrint = "";
            for(int j=0; j<nbColumns; j++){
                toPrint += mapArray[i, j];
            }
            Console.WriteLine(toPrint);
        }
        checkSymLine();
        if(isSymLine){
            checkSymColumn();
        }
        if(isSymLine){
            Console.WriteLine("Symetry on Line: "+this.number);
        }
        else{
            Console.WriteLine("Symetry on Column: "+this.number);
        }
        //Console.WriteLine("Symetry line:" +this.isSymLine+" - Line/Column Number");
    }

    public bool checkSymLine(){
        bool isSim = false;
        for(int i=0; i<nbLines-1; i++){
            if(isSymetricLine(i) == 1){
                isSim = true;
                this.isSymLine = true;
                this.number = i;
            }
        }
        return isSim;
    }
    public bool checkSymColumn(){
        bool isSim = false;
        for(int i=0; i<nbColumns-1; i++){
            if(isSymetricColumn(i) == 1){
                isSim = true;
                this.isSymLine = false;
                this.number = i;
            }
        }
        return isSim;
    }

    public int isSymetricLine(int lineNumber){
        int lineLeft = lineNumber;
        int lineRight = lineNumber + 1;
        int offset = 0;
        int possibleRight = nbLines-lineRight;
        int minPossible = Math.Min(lineLeft+1, possibleRight);
        int sym = 0;
        for(int i=0; i<minPossible; i++){
            for(int j=0; j<nbColumns; j++){
                if(mapArray[lineLeft-i, j] != mapArray[lineRight+i, j]){
                    sym ++;
                }
            }
        }
        return sym;

    }


    public int isSymetricColumn(int columnNumber){
        int columnLeft = columnNumber;
        int columnRight = columnNumber + 1;
        int offset = 0;
        int possibleRight = nbColumns-columnRight;
        int minPossible = Math.Min(columnLeft+1, possibleRight);
        int sym = 0;
        for(int i=0; i<minPossible; i++){
            for(int j=0; j<nbLines; j++){
                if(mapArray[j, columnLeft-i] != mapArray[j, columnRight + i]){
                    sym ++;
                }
            }
        }
        return sym;

    }
}