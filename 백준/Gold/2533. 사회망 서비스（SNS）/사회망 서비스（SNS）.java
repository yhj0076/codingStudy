import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static List<List<Integer>> graph = new ArrayList<>();
    public static boolean[] visited;
    public static int[][] dp;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        visited = new boolean[n+1];
        dp = new int[n+1][2];

        for (int i = 0; i < n+1; i++) {
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < n-1; i++) {
            st = new StringTokenizer(reader.readLine());
            int start = Integer.parseInt(st.nextToken());
            int end = Integer.parseInt(st.nextToken());

            graph.get(start).add(end);
            graph.get(end).add(start);
        }

        dfs(1);
        System.out.println(Math.min(dp[1][0],dp[1][1]));
    }
    
    public static boolean dfs(int num){
        if(!visited[num]){
            visited[num] = true;
            List<Integer> innerGraph = graph.get(num);
            for (int i = 0; i < innerGraph.size(); i++) {
                int value = innerGraph.get(i);
                if(dfs(value)){
                    dp[num][0] += Math.min(dp[value][0],dp[value][1]);
                    dp[num][1] += dp[value][0];
                }
            }
            dp[num][0] += 1;
            return true;
        }
        else{
            return false;
        }
    }
}