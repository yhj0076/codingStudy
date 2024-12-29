import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static List<List<Integer>> graph;
    public static boolean[] visited;
    public static int[] village;
    public static int[][] dp;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        village = new int[n+1];
        visited = new boolean[n+1];

        graph = new ArrayList<>();
        graph.add(new ArrayList<>());

        st = new StringTokenizer(reader.readLine());
        for (int i = 1; i <= n; i++) {
            village[i] = Integer.parseInt(st.nextToken());
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < n-1; i++) {
            st = new StringTokenizer(reader.readLine());
            int start = Integer.parseInt(st.nextToken());
            int end = Integer.parseInt(st.nextToken());
            graph.get(start).add(end);
            graph.get(end).add(start);
        }

        dp = new int[n+1][2];
        dfs(1);

        System.out.println(Math.max(dp[1][0],dp[1][1]));
    }
    
    public static void dfs(int num){
        visited[num] = true;
        dp[num][1] = village[num];
        for (int i = 0; i < graph.get(num).size(); i++) {
            int nextNum = graph.get(num).get(i);
            if(!visited[nextNum]){
                dfs(nextNum);
                dp[num][0] += Math.max(dp[nextNum][0], dp[nextNum][1]);
                dp[num][1] += dp[nextNum][0];
            }
        }
    }
}