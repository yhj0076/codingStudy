import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static List<Integer> fiboCount = new ArrayList<>();
    public static int m;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        m = Integer.parseInt(st.nextToken());    // 입력

        int step = 2;
        int allLength = 0;

        fiboCount.add(7);
        fiboCount.add(5);

        while(m > fiboCount.get(fiboCount.size()-1)){
            int newNum = fiboCount.get(fiboCount.size()-2) + fiboCount.get(fiboCount.size()-1) + 1;
            fiboCount.add(newNum);
            step++;
        }
        step--;
        dfs(step);

        StringBuilder sb = new StringBuilder("Messi Gimossi");

        if(sb.charAt(m-1) == ' '){
            System.out.println("Messi Messi Gimossi");
        }
        else{
            System.out.println(sb.charAt(m-1));
        }
    }
    static void dfs(int step){
        int length = fiboCount.get(step);

        int left = fiboCount.get(step-1);
        int right = fiboCount.get(step-1)+2;

        if(m > 13) {
            if (m <= left) {
                dfs(step - 1);
            } else if (m >= right) {
                m -= left+1;
                dfs(step - 2);
            }
            else {
                m = 6;
            }
        }
    }
}