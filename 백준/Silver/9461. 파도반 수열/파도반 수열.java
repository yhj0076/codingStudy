import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        StringBuilder answer = new StringBuilder();
        long numSize = Long.parseLong(st.nextToken());

        for(long i = 0L; i<numSize; i++){
            st = new StringTokenizer(reader.readLine());
            int num = Integer.parseInt(st.nextToken());
            ArrayList<Long> queue = new ArrayList<>();
            int startNum = 1;
            while(startNum<=num){
                if(startNum < 4){
                    queue.add(1L);
                } else if (startNum < 6) {
                    queue.add(2L);
                } else {
                    long newNum = queue.get(4)+queue.remove(0);
                    queue.add(newNum);
                }
                startNum++;
            }
            answer.append(queue.get(queue.size()-1)).append("\n");
        }
        System.out.println(answer);
    }
}