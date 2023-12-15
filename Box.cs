
namespace AdventOfCode_C_;

class Box{

    Lens[] orderBox = new Lens[256];
    public IDictionary<string, int> lensDic = new Dictionary<string, int>();
    int numberOfLens;
    public Box(){
        numberOfLens = 0;
    }

    public void AddLens(string name, int focal){
        if(!lensDic.ContainsKey(name)){
            lensDic[name] = numberOfLens;
            numberOfLens ++;
        }
        orderBox[lensDic[name]] = new Lens(name, focal);
        
    }

    public void removeLens(string name){
        if(lensDic.ContainsKey(name)){
            int index = lensDic[name];
            lensDic.Remove(name);
            for(int i = index; i<numberOfLens-1; i++){
                orderBox[i] = orderBox[i+1];
                lensDic[orderBox[i+1].name] = i;
            }
            orderBox[numberOfLens-1] = null;
            numberOfLens --;
        }
    }

    internal int getOrder(string s)
    {
        if(lensDic.ContainsKey(s)){
            return lensDic[s] + 1;
        }
        else{
            return 0;
        }
    }

    internal int getFocal(string s)
    {
        if(lensDic.ContainsKey(s)){
            return orderBox[lensDic[s]].focal;
        }
        else{
            return 0;
        }
    }
}