import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static long answer = 0L;
    static int rest = 0;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int N = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());
        int[] healthTable = new int[N];

        ArrayList<Integer> visited = new ArrayList<>();

        st = new StringTokenizer(reader.readLine());
        for(int i = 0; i<N; i++){
            healthTable[i] = Integer.parseInt(st.nextToken())-K;
        }

        muscle(healthTable,N,visited);

        System.out.println(answer);
    }
    
    private static void muscle(int[] healthTable,int N,ArrayList<Integer> visited){
        for(int i = 0; i<N; i++){
            if(visited.contains(i)||rest+healthTable[i]<0){
                continue;
            } else {
                rest = rest + healthTable[i];
                visited.add(i);
                if(visited.size()==N){
                    answer++;
                    Object object = i;
                    visited.remove(object);
                    rest = rest - healthTable[i];
                    break;
                } else {
                    muscle(healthTable, N, visited);
                }
            }
        }
        if(!visited.isEmpty()) {
            int index = visited.remove(visited.size() - 1);
            rest = rest - healthTable[index];
        }
    }
}