namespace AdventOfCode_C_;


public enum HandOrder
{
    FIVE = 6,
    FOUR = 5,
    HOUSE = 4,
    THREE = 3,
    TOWP = 2,
    ONEP = 1,
    HIGH = 0
}
class CamelCard{
    static public IDictionary<string, int> cardValue = new Dictionary<string, int>();

    public static int compareHand(Hand h1, Hand h2){
        if(h1.type > h2.type){
            return 1;
        }
        else if(h1.type < h2.type){
            return -1;
        }
        else{
            //bool foundIneq = false;
            int i = 0;
            while (i<5)
            {
                if(h1.valueCard[i] > h2.valueCard[i]){
                    return 1;
                }
                else if(h1.valueCard[i] < h2.valueCard[i]){
                    return -1;
                }
                i++;
            }
            return 0;
        }
    }

    List<Hand> allHands = new List<Hand>();

    public CamelCard(){
        cardValue.Add("J", 1);
        cardValue.Add("2", 2);
        cardValue.Add("3", 3);
        cardValue.Add("4", 4);
        cardValue.Add("5", 5);
        cardValue.Add("6", 6);
        cardValue.Add("7", 7);
        cardValue.Add("8", 8);
        cardValue.Add("9", 9);
        cardValue.Add("T", 10);
        //cardValue.Add("J", 11);
        cardValue.Add("Q", 12);
        cardValue.Add("K", 13);
        cardValue.Add("A", 14);
        


        //string[] lines = File.ReadAllLines("testDay7.txt");
        string[] lines = File.ReadAllLines("inputDay7.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            allHands.Add(new Hand(parts[0].Trim(), long.Parse(parts[1].Trim())));
        }
        allHands.Sort(compareHand);
        long result = 0;
        long k = 1;
        foreach(Hand h in allHands){

            result += h.bid*k;
            k++;
            //Console.WriteLine(h.handCard+": "+h.type);
        }
        Console.WriteLine("Final Result: "+result);
        //Console.WriteLine(HandOrder.HIGH<HandOrder.HOUSE);


    }

}