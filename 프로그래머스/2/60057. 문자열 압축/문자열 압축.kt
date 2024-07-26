class Solution {
    fun solution(s: String): Int {
        var answer = s.length

        for(i in 1 .. s.length/2){
            var arr = ArrayList<String>()
            var index = 0
            while (index < s.length) {
                if(index + i < s.length){
                    var subs = s.substring(index, index + i)
                    index += i
                    arr.add(subs)
                }
                else{
                    var subs = s.substring(index,s.length)
                    arr.add(subs)
                    break
                }
            }
            var count = 0
            var line = arr[0]
            var zip = ""
            for(i in 0..arr.lastIndex){
                if(line==arr[i]){
                    count++
                }
                else{
                    if(count>1) {
                        zip += count.toString()
                    }
                    zip += line
                    count = 1
                    line = arr[i]
                }
            }
            if(count>1) {
                zip += count.toString()
            }
            zip += line
            if(answer>zip.length){
                answer = zip.length
            }
        }
        return answer
    }
}