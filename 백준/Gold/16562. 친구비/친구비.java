import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int node = Integer.parseInt(st.nextToken());
        int edge = Integer.parseInt(st.nextToken());
        long JsMoney = Long.parseLong(st.nextToken());

        long startMoney = JsMoney;

        st = new StringTokenizer(reader.readLine());
        int[] cost = new int[node];
        for (int i = 0; i < node; i++) {
            int money = Integer.parseInt(st.nextToken());
            cost[i] = money;
        }

        List<List<Integer>> graph = new ArrayList<>();

        for (int i = 1; i <= node; i++) {
            List<Integer> miniSet = new LinkedList<>();
            miniSet.add(i);
            graph.add(miniSet);
        }

        for (int i = 0; i < edge; i++) {
            st = new StringTokenizer(reader.readLine());
            int a = Integer.parseInt(st.nextToken());
            int b = Integer.parseInt(st.nextToken());

            List<Integer> innerA = null;
            List<Integer> innerB = null;

            for (int j = 0; j < graph.size(); j++) {
                List<Integer> findSet = graph.get(j);
                if(findSet.contains(a)){
                    innerA = findSet;
                }
                if(findSet.contains(b)){
                    innerB = findSet;
                }
            }

            if(innerA != innerB){
                innerA.addAll(innerB);
                graph.remove(innerB);
            }
        }

        for (int i = 0; i < graph.size(); i++) {
            int min = Integer.MAX_VALUE;
            List<Integer> theFriends = graph.get(i);
            for (int j = 0; j < theFriends.size(); j++) {
                int theCost = cost[theFriends.get(j)-1];
                if(theCost < min){
                    min = theCost;
                }
            }
            JsMoney -= min;
            if(JsMoney < 0){
                System.out.println("Oh no");
                return;
            }
        }

        System.out.println(startMoney - JsMoney);
    }
}