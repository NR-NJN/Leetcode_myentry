public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
      var result = new List<int[]>();
      var tList = new List<(int start, int end)>(); //new interval into the existing one
      foreach(var interval in intervals) {    //loop thru existing
          if(newInterval[0]<interval[0]){ //chec if new interval lies before current one
              tList.Add((newInterval[0], newInterval[1])); //add new interval
          }
          tList.Add((interval[0], interval[1]));  //current
      }
      if(tList.Count==0 || tList.Count==intervals.Length ){ //also chec if the list has a value interval or not i.e empty list
          tList.Add((newInterval[0], newInterval[1]));
      }  
   
                                                                    //new interval does not lie before any interval add 1 at the last
       var LList = new LinkedList<(int start, int end)> (tList);
       var temp = LList.First;
        while(temp!=null){
            var cur = temp.Value; // current node
            while(temp.Next!=null) {  //keep on merging with the next item until you reach a non overlapping interval                       
                var next = temp.Next.Value;
                if(next.start<=cur.end){ //check if its overlapping or not
                    cur.end=Math.Max(next.end, cur.end); //merge next with current
                    temp = temp.Next;                                    // take the maximum out of them  
                }
                else{
                    break;
                }
            
            }
            result.Add(new []{cur.start, cur.end});
            temp=temp.Next;
        }
        
        
        return result.ToArray();
    }
}