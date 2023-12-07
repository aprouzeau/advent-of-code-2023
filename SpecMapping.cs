namespace AdventOfCode_C_;

class SpecMapping{
    private long startSrc;
    private long startDest;
    private long range;

    public SpecMapping(long dest, long src, long range){
        this.startDest = dest;
        this.startSrc = src;
        this.range = range;
    }

    public long testRange(long v){

        if(v >= startSrc && v < startSrc+range){
            return (startDest + (v - startSrc));
        }
        else{
            return -1;
        }
    }

    public Seed testSeedRange(Seed s){
        if((s.start > startSrc+range) || (startSrc>s.start+s.range)){
            return null;
        }else{
            long interS = Math.Max(startSrc, s.start);
            long interE = Math.Min(startSrc+range, s.start+s.range);

            long newStart = startDest + (interS - startSrc);
            long newEnd = startDest + (interE - startSrc);
            long newRange = newEnd - newStart;

            Seed newS = new Seed(newStart, newRange);
            return newS;
        }
    }

}