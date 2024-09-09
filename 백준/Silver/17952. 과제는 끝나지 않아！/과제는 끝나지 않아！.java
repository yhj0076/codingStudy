import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int N = Integer.parseInt(st.nextToken());

        List<long[]> inBrain = new ArrayList<>();

        long score = 0;

        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(reader.readLine());

            int isHw = Integer.parseInt(st.nextToken());
            if(isHw == 1){
                long[] hw = new long[2];
                hw[0] = Long.parseLong(st.nextToken());
                hw[1] = Long.parseLong(st.nextToken());
                inBrain.add(hw);
            }
            if(!inBrain.isEmpty()) {
                long[] leftHw = inBrain.get(inBrain.size() - 1);
                leftHw[1]--;
                if (leftHw[1] == 0) {
                    score += leftHw[0];
                    inBrain.remove(inBrain.size() - 1);
                }
            }
        }
        System.out.println(score);
    }
}