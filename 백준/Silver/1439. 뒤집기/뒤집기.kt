fun main(){
    val line = readLine().toString()
    var lastCheck = line.first()
    var count:Int = 1
    for(i in line){
        if(i!=lastCheck){
            lastCheck = i
            count++
        }
    }
    print(count/2)
}