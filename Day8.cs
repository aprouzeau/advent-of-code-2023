namespace AdventOfCode_C_;

class Day8{

    string path;
    //List<Node> listNodes = new List<Node>();
    IDictionary<string, Node> listNodes = new Dictionary<string, Node>();

    List<Node> startingNode = new List<Node>();
    List<Node> endingNode = new List<Node>();

    public Day8(){
        
        string[] lines = File.ReadAllLines("inputDay8.txt");
        //string[] lines = File.ReadAllLines("test3Day8.txt");
        this.path = lines[0];
        Console.WriteLine(path);
        for(int i=2; i<lines.Length; i++){
            string[] firstSplit = lines[i].Split('=');
            string name = firstSplit[0].Trim();
            string[] secondSlit = firstSplit[1].Split(',');
            string left = secondSlit[0].Trim().Substring(1);
            string right = secondSlit[1].Trim().Substring(0, 3);
            Console.WriteLine(name+": "+left+"->"+right);
            //Node l, r, n = null;
            if(!listNodes.ContainsKey(left)){
                Node l = new Node(left);
                listNodes[left] = l;
                if(l.isStart){
                    startingNode.Add(l);
                }
                if(l.isEnd){
                    endingNode.Add(l);
                }
            }
            if(!listNodes.ContainsKey(right)){
                Node r = new Node(right);
                listNodes[right] = r;
                if(r.isStart){
                    startingNode.Add(r);
                }
                if(r.isEnd){
                    endingNode.Add(r);
                }
            }
            if(!listNodes.ContainsKey(name)){
                Node n = new Node(name);
                listNodes[name] = n;
                if(n.isStart){
                    startingNode.Add(n);
                }
                if(n.isEnd){
                    endingNode.Add(n);
                }
            }
            Node current = listNodes[name];
            current.left = listNodes[left];
            current.right = listNodes[right];


        }

        //Node startNode = listNodes["AAA"];
        //Node endNode = listNodes["ZZZ"];
        //Node currentNode = startNode;
        List<Node> currentNodes = new List<Node>();
        foreach(Node n in startingNode){
            currentNodes.Add(n);
        }
        
        List<long> listStep = new List<long>();
        
        int endNodeReach = 0;
        long finalStep = 1;

        foreach(Node startN in startingNode){
            int countPath = 0;
            long step = 0;
            Node currentN = startN;
            bool foundEnd = false;
            while(!foundEnd){
                if(countPath >= this.path.Length){
                    countPath = 0;
                }
                char nextMove = this.path[countPath];
                Node tempoNode = currentN.Travel(nextMove);
                currentN = tempoNode;
                countPath ++;
                step ++;
                if(currentN.isEnd){
                    foundEnd = true;
                }
            }
            listStep.Add(step);
            finalStep *= step;

        }

        long lcmR = listStep.First();

        foreach(long s in listStep){
            long lcmTempo = lcm(lcmR, s);
            lcmR = lcmTempo;
        }


        /*while(!foundEnd){
            endNodeReach = 0;
            if(countPath >= this.path.Length){
                countPath = 0;
            }
            char nextMove = this.path[countPath];
            List<Node> tempoList = new List<Node>();
            foreach(Node n in currentNodes){
                Node target = n.Travel(nextMove);
                if(target.isEnd){
                    endNodeReach ++;
                }
                tempoList.Add(target);
            }
            currentNodes = tempoList;

            // Node tempoNode = currentNode.Travel(nextMove);
            // currentNode = tempoNode;
            countPath ++;
            step ++;
            if(endNodeReach == currentNodes.Count){
                foundEnd = true;
            }
            if(currentNode == endNode){
                foundEnd = true;
            }
        }*/
        Console.WriteLine("Number of Steps: "+lcmR);



    }

    long gcf(long a, long b){
        while( b != 0){
            long temp = b;
            b = a%b;
            a = temp;
        }
        return a;
    }

    long lcm(long a, long b){
        return (a/gcf(a, b))*b;
    }
}