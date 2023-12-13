namespace AdventOfCode_C_;

class Galaxy{
    
    public int number;
    public int initLine;
    public int initColumn;

    public int finalLine;

    public int finalColumn;

    public Galaxy(int number, int line, int column){
        this.number = number;
        this.initLine = line;
        this.initColumn = column;
        this.finalLine = line;
        this.finalColumn = column;
    }
}