namespace AdventOfCode_C_;

class Mapping{

    public List<SpecMapping> listOfMappings = new List<SpecMapping>();

    public List<Seed> loopOnMapping(List<Seed> listValue){
        List<Seed> newList = new List<Seed>();
        
        foreach (Seed v in listValue)
        {
            // newList.Add(testValue(v));
            testValue(newList, v);
        }
        return newList;
    }

    private void testValue(List<Seed> l, Seed v){
        foreach (SpecMapping sm in listOfMappings)
        {
            Seed tempoS = sm.testSeedRange(v);
            if(tempoS != null){
                l.Add(tempoS);
            }
        }
    }


    private long testValue(long v){
        bool found = false;
        long newV = -1;
        foreach (SpecMapping sm in listOfMappings)
        {
            if(!found){
                long tempoV = sm.testRange(v);
                if(tempoV != -1){
                    newV = tempoV;
                    found = true;
                }
            }
        }
        if(!found){
            newV = v;
        }
        return newV;
    }


}