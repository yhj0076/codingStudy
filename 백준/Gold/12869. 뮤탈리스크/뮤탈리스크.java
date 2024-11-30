import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static Set<String> visited = new HashSet<>();
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        int[] scv = new int[n];

        st = new StringTokenizer(reader.readLine());

        for (int i = 0; i < n; i++) {
            int health = Integer.parseInt(st.nextToken());
            scv[i] = health;
        }

        int[][] attackPatterns1 = {{9, 3, 1}, {9, 1, 3}, {3, 9, 1}, {3, 1, 9}, {1, 9, 3}, {1, 3, 9}};
        int[][] attackPatterns2 = {{9, 3}, {3, 9}};

        if(n == 1){
            if(scv[0] % 9 == 0){
                System.out.println(scv[0]/9);
            }
            else{
                System.out.println((scv[0]+9)/9);
            }
        }
        else if(n == 2){
            int stage = 1;
            Queue<int[]> firstQueue = new ArrayDeque<>();
            firstQueue.add(scv);
            while(firstQueue != null) {
                firstQueue = attack(attackPatterns2, firstQueue);
                if(firstQueue != null){
                    stage++;
                }
                else{
                    System.out.println(stage);
                }
            }
        }
        else{
            int stage = 1;
            Queue<int[]> firstQueue = new ArrayDeque<>();
            firstQueue.add(scv);
            while(firstQueue != null) {
                firstQueue = attack(attackPatterns1, firstQueue);
                if(firstQueue != null){
                    stage++;
                }
                else{
                    System.out.println(stage);
                }
            }
        }
    }
    
    static Queue<int[]> attack(int[][] attackPattern, Queue<int[]> queue){
        Queue<int[]> nextQueue = new ArrayDeque<>();
        boolean destroyed = true;
        // 빼기 작업
        while (!queue.isEmpty()) {
            int[] newScv = queue.poll();
            for (int i = 0; i < attackPattern.length; i++) {
                destroyed = true;
                int[] newScvClone = newScv.clone();
                for (int j = 0; j < newScvClone.length; j++) {
                    newScvClone[j] -= attackPattern[i][j];
                    if(newScvClone[j] > 0){
                        destroyed = false;
                    }
                }
                String stateKey = Arrays.toString(newScvClone);
                if(visited.contains(stateKey)){
                    continue;
                }
                else{
                    visited.add(stateKey);
                    nextQueue.add(newScvClone);
                }
                if(destroyed){
                    return null;
                }
            }
        }

        if(!destroyed){
            return nextQueue;
        }
        return nextQueue;
    }
}