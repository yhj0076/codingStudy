import java.util.*

class Solution {
    fun solution(food_times: IntArray, k: Long): Int {
                var list = mutableListOf<Pair<Int,Int>>()
        for(i in 1..food_times.size){
            list.add(Pair(i,food_times[i-1]))
        }
        list.sortBy{it.second}

        var size = food_times.size
        var remain = k
        var answer = -1
        var food_time1 = 0
        var food_time2 = 0

        var it = list.iterator()
        while(it.hasNext()){
            food_time2 = it.next().second
            var use = (food_time2.toLong() - food_time1.toLong())*size.toLong()
            if(use > remain){
                var subList = list.drop(food_times.size - size) as MutableList<Pair<Int,Int>>
                subList.sortBy { it.first }
                answer = subList.get((remain%size).toInt()).first
                break
            }
            remain -= use
            food_time1 = food_time2
            size--
        }
        return answer
    }
}