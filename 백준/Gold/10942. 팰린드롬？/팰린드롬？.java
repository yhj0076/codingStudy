import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        StringBuilder answer = new StringBuilder();

        int n = Integer.parseInt(st.nextToken());

        int[] arr = new int[n];

        st = new StringTokenizer(reader.readLine());

        for (int i = 0; i < n; i++) {
            int num = Integer.parseInt(st.nextToken());
            arr[i] = (num);
        }

        st = new StringTokenizer(reader.readLine());
        int m = Integer.parseInt(st.nextToken());
        for (int i = 0; i < m; i++) {
            st = new StringTokenizer(reader.readLine());
            int s = Integer.parseInt(st.nextToken())-1;
            int e = Integer.parseInt(st.nextToken())-1;

            for (int j = s; j < e ; j++,s++, e--) {
                if(arr[j] != arr[e]){
                    answer.append("0\n");
                    break;
                }
            }

            if(arr[s] == arr[e]){
                answer.append("1\n");
            }
        }

        System.out.println(answer);
    }
}