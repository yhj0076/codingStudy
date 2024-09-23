import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static HashSet<Integer> visited = new HashSet<>();
    static int answer = 0;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());
        int m = Integer.parseInt(st.nextToken());

        st = new StringTokenizer(reader.readLine());

        int real = Integer.parseInt(st.nextToken());
        List<Integer> realPeople = new ArrayList<>();
        for (int i = 0; i < real; i++) {
            realPeople.add(Integer.parseInt(st.nextToken()));
        }

        ArrayList<Integer>[] graph = new ArrayList[n+1];
        for (int i = 0; i < graph.length; i++) {
            graph[i] = new ArrayList<>();
        }

        ArrayList<ArrayList<Integer>> partyParty = new ArrayList<>();

        for (int i = 0; i < m; i++) {
            st = new StringTokenizer(reader.readLine());
            int people = Integer.parseInt(st.nextToken());
            ArrayList<Integer> drawLine = new ArrayList<>();
            for (int j = 0; j < people; j++) {
                int num = Integer.parseInt(st.nextToken());
                drawLine.add(num);
            }
            partyParty.add(drawLine);

            if(drawLine.size()>1){
                for (int j = 0; j < drawLine.size()-1; j++) {
                    int start = drawLine.get(j);
                    int end = drawLine.get(j+1);
                    if(!graph[start].contains(end)) {
                        graph[start].add(end);
                    }
                    if(!graph[end].contains(start)) {
                        graph[end].add(start);
                    }
                }
            }
        }

        for (int i = 0; i < real; i++) {
            dfs(realPeople.get(i),graph);
        }

        for (int i = 0; i < m; i++) {
            ArrayList<Integer> nowParty = partyParty.get(i);
            nowParty.retainAll(visited);
            if(nowParty.isEmpty()){
                answer++;
            }
        }

        System.out.println(answer);
    }
    
    static void dfs(int index, ArrayList<Integer>[] graph){
        if(!visited.contains(index)){
            visited.add(index);
        }
        for(int num:graph[index]){
            if(!visited.contains(num)){
                visited.add(num);
                dfs(num,graph);
            }
        }
    }
}