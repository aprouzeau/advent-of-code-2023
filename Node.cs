
namespace AdventOfCode_C_;

class Node{

    string name;
    public Node right;
    public Node left;

    public bool isStart;
    public bool isEnd;

    public Node(string n){
        this.name = n;
        this.isStart = false;
        this.isEnd = false;
        if(name.Contains("A")){
            this.isStart = true;
        }
        if(name.Contains("Z")){
            this.isEnd = true;
        }
    }

    internal Node Travel(char nextMove)
    {
        if(nextMove == 'R'){
            return this.right;
        }
        else{
            return this.left;
        }
    }

    /*public Node travelTo(string target, int step){
        if(target == this.name){
            Console.WriteLine("Number of steps: "+step);
        }
        
    }*/

}