import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static int n = 0;
    static List<Integer> visitedDFS = new ArrayList<>();
    static List<Integer> visitedBFS = new ArrayList<>();
    static Queue<Integer> queueBFS = new LinkedList<>();
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        n = Integer.parseInt(st.nextToken());
        int m = Integer.parseInt(st.nextToken());
        int v = Integer.parseInt(st.nextToken());

        int[][] graph = new int[n+1][n+1];

        while(m>0){
            st = new StringTokenizer(reader.readLine());
            int a = Integer.parseInt(st.nextToken());
            int b = Integer.parseInt(st.nextToken());
            graph[a][b] = 1;
            graph[b][a] = 1;
            m--;
        }

        dfs(graph,v);
        bfs(graph,v);
        StringBuilder answer = new StringBuilder();
        for(int num:visitedDFS){
            answer.append(num).append(" ");
        }
        answer.deleteCharAt(answer.length()-1);
        answer.append("\n");
        for(int num:visitedBFS){
            answer.append(num).append(" ");
        }
        answer.deleteCharAt(answer.length()-1);
        System.out.println(answer);
    }
    public static void dfs(int[][] graph,int start){
        visitedDFS.add(start);

        for(int j = 1; j <= n; j++){
            if(graph[start][j] == 1 && !visitedDFS.contains(j)){
                dfs(graph, j);
            }
        }
    }
    public static void bfs(int[][] graph,int start){
        queueBFS.add(start);
        visitedBFS.add(start);

        while(!queueBFS.isEmpty()) {
            int node = queueBFS.poll();

            for(int j = 1; j <= n; j++) {
                if(graph[node][j] == 1 && !visitedBFS.contains(j)) {
                    queueBFS.add(j);
                    visitedBFS.add(j);
                }
            }
        }
    }
}