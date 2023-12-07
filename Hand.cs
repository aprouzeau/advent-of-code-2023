namespace AdventOfCode_C_;

class Hand{

    public string handCard;
    public long bid;
    public int[] valueCard;
    public HandOrder type;

    int numberJ;

    public Hand(string hand, long bid){
        this.bid = bid;
        this.handCard = hand;
        this.valueCard = new int[hand.Length];
        List<String> lst = new List<string>();
        for(int i=0; i<handCard.Length; i++){
            valueCard[i] = CamelCard.cardValue[handCard[i]+""];
            lst.Add(handCard[i]+"");
            if(handCard[i] == 'J'){
                numberJ ++;
            }
        }


        var query = lst.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

        switch (query.Count)
        {
            case 0:
                if(numberJ == 1){
                    this.type = HandOrder.ONEP;
                }
                else{
                    this.type = HandOrder.HIGH;
                }
                break;
            case 1:
                switch(query.First().Counter){
                    case 5:
                        this.type = HandOrder.FIVE;
                        break;
                    case 4:
                        if(numberJ == 1){
                            this.type = HandOrder.FIVE;
                        }
                        else if(numberJ == 4){
                            this.type = HandOrder.FIVE;
                        }
                        else{
                            this.type = HandOrder.FOUR;
                        }
                        break;
                    case 3:
                        if(numberJ == 1){
                            this.type = HandOrder.FOUR;
                        }
                        else if(numberJ == 3){
                            this.type = HandOrder.FOUR;
                        }
                        else{
                            this.type = HandOrder.THREE;
                        }
                        break;
                    case 2:
                        if(numberJ == 1){
                            this.type = HandOrder.THREE;
                        }
                        else if(numberJ == 2){
                            this.type = HandOrder.THREE;
                        }
                        else{
                            this.type = HandOrder.ONEP;
                        }
                        break;
                }
                break;
            case 2:
                bool foundThree = false;
                foreach (var s in query)
                {
                    if(s.Counter == 3){
                        foundThree = true;
                    }
                    if(foundThree){
                        if(numberJ == 2){
                            this.type = HandOrder.FIVE;
                        }
                        else if(numberJ == 3){
                            this.type = HandOrder.FIVE;
                        }
                        else{
                            this.type = HandOrder.HOUSE;
                        }
                    }
                    else{
                        if(numberJ == 2){
                            this.type = HandOrder.FOUR;
                        }
                        else if(numberJ == 1){
                            this.type = HandOrder.HOUSE;
                        }
                        else{
                            this.type = HandOrder.TOWP;
                        }
                    }
                }
                break;
        }
        //Console.WriteLine(this.handCard+": "+this.type+". Number of J: "+this.numberJ);
        

    }

}