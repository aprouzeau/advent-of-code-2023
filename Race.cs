namespace AdventOfCode_C_;

class Race{
    public long time;
    public long distance;

    public long possibleAttempt;

    public Race(long t, long d){
        this.time = t;
        this.distance = d;
    }

    public void computeResult(){
        double delta = Math.Pow(time, 2) - 4*distance;
        if(delta<0){
            possibleAttempt = 0;
        }
        else if(delta == 0){
            possibleAttempt = 0;
        }
        else{
            double x1 = 0.5*(time - Math.Sqrt(delta));
            double x2 = 0.5*(time + Math.Sqrt(delta));
            double xMin = Math.Min(x1, x2);
            double xMax = Math.Max(x1, x2)-0.0000001;
            double xFloor = Math.Floor(xMin);
            double xCeiling = Math.Floor(xMax);
            long diff = (long)((xCeiling - xFloor));
            possibleAttempt = diff;
        }
    }


}