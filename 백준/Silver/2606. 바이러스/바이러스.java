import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static HashSet<Integer> infection = new HashSet<>();
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int computers = Integer.parseInt(st.nextToken());

        st = new StringTokenizer(reader.readLine());

        int lines = Integer.parseInt(st.nextToken());

        ArrayList<Integer>[] matrix = new ArrayList[computers + 1];

        for(int i = 0; i<= computers; i++){
            matrix[i] = new ArrayList<>();
        }

        while(lines > 0){
            st = new StringTokenizer(reader.readLine());
            int start = Integer.parseInt(st.nextToken());
            int end = Integer.parseInt(st.nextToken());

            for(int i = 1; i<matrix.length; i++){
                if(i == start){
                    matrix[i].add(end);
                }
                if(i == end){
                    matrix[i].add(start);
                }
            }
            lines--;
        }

        infectionMethod(1,matrix);
        
        infection.remove(1);
        
        System.out.println(infection.size());
    }
    public static void infectionMethod(int infestedCpu,ArrayList<Integer>[] matrix){
        for(Integer cpuNum:matrix[infestedCpu]){
            if(infection.contains(cpuNum)){
                continue;
            }
            infection.add(cpuNum);
            infectionMethod(cpuNum,matrix);
        }
    }
}