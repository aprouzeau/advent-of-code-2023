
namespace AdventOfCode_C_;

class Day1{


    public Day1(){
        string[] lines = File.ReadAllLines("inputDay1.txt");
        //string[] lines = File.ReadAllLines("testDay1.txt");

        long sum = 0;
        foreach(string s in lines){
            sum += int.Parse(GetFirstAndLastNumber(s));
        }
        Console.WriteLine(sum);
    }

    private string GetFirstAndLastNumber(string s)
    {
        
                
        
        char firstNumber = ' ';
        char lastNumber = ' ';
        bool lookForFirst = true;
        bool lookForLast = true;
        int count = 0;
        int firstIndex = 0;
        int lastIndex = s.Length - 1;
        while(lookForFirst || lookForLast){
            if(lookForFirst){
                if(Char.IsNumber(s, count)){
                    firstNumber = s[count];
                    lookForFirst = false;
                    firstIndex = count;
                }
            }
            if(lookForLast){
                if(Char.IsNumber(s, s.Length - 1 - count)){
                    lastNumber = s[s.Length - 1 - count];
                    lookForLast = false;
                    lastIndex = s.Length - 1 - count;
                }
            }
            count ++;

            if(count>=s.Length){
                if(lookForFirst){
                    firstIndex = s.Length - 1;
                    lookForFirst = false;

                }
                if(lookForLast){
                    lastIndex = 0;
                    lookForLast = false;
                }
                
                
            }
        }
        string[] numberStrArray = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        char[] numberArray = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
        for(int i=0; i<numberArray.Length; i++){
            List<int> oneLise = AllIndexesOf(s, numberStrArray[i]);
            if(oneLise.Count>0){
                if(firstIndex>oneLise.First()){
                    firstIndex = oneLise.First();
                    firstNumber = numberArray[i];
                }
                if(lastIndex<oneLise.Last()){
                    lastIndex = oneLise.Last();
                    lastNumber = numberArray[i];
                }
            }
        }
        

        Console.WriteLine("First: "+firstNumber +" Last Number: "+ lastNumber+"");
        return firstNumber +""+ lastNumber+"";
    }


    public static List<int> AllIndexesOf(string str, string value) {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("the string to find may not be empty", "value");
        List<int> indexes = new List<int>();
        for (int index = 0;; index += value.Length) {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }
}