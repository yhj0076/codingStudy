class Solution {
    public int solution(int[] bandage, int health, int[][] attacks) {
        int nowHealth = health;
        boolean dead = false;
//         for(int index = 0; index < attacks.length-1; index++){
//             int betweenTime = attacks[index+1][0] - attacks[index][0];
//             // damage phase
//             nowHealth = nowHealth - attacks[index][1];
//             if(nowHealth <= 0){
//                 dead = true;
//                 break;
//             }
            
//             // heal phase
//             if(betweenTime > bandage[0]){
//                 nowHealth = nowHealth + (bandage[0]*bandage[1]) + bandage[2];
//             }
//             else{   // betweenTime <= bandage[0]
//                 nowHealth = nowHealth + ((betweenTime-1) * bandage[1]);
//             }
//             if(nowHealth > health){
//                 nowHealth = health;
//             }
//         }
        
//         if(dead == false){
//             nowHealth = nowHealth - attacks[attacks.length-1][1];
//             if(nowHealth <= 0){
//                 dead = true;
//             }
//         }
        
//         if(dead){
//             return -1;
//         }
//         else{
//             return nowHealth;
//         }
        
        
        
        int time = 0;
        int atkIndex = 0;
        int healTime = 0;
        while(time<=attacks[attacks.length-1][0]){
            // atk phase
            if(time == attacks[atkIndex][0]){
                nowHealth -= attacks[atkIndex][1];
                atkIndex++;
                healTime = 0;
                if(nowHealth <= 0){
                    dead = true;
                }
            }
            // heal phase
            else{
                healTime++;
                nowHealth += bandage[1];
                if(healTime == bandage[0]){
                    nowHealth += bandage[2];
                    healTime = 0;
                }
                if(nowHealth > health){
                    nowHealth = health;
                }
            }
            time++;
        }
        
        if(dead){
            return -1;
        }
        else{
            return nowHealth;
        }
    }
}