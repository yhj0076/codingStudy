fun main(){
    val score = readLine().toString()

    val front = score.substring(0,score.length/2).toCharArray()
    val last = score.substring(score.length/2,score.length).toCharArray()

    var frontSum = 0
    for(i in front){
        frontSum+=i.digitToInt()
    }

    var lastSum = 0
    for(i in last){
        lastSum+=i.digitToInt()
    }

    if(frontSum==lastSum){
        print("LUCKY")
    }
    else{
        print("READY")
    }
}
