import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        List<Integer> ListA = new ArrayList<>();
        List<Integer> ListB = new ArrayList<>();

        st = new StringTokenizer(reader.readLine());
        for(int i = 0; i<n; i++){
            ListA.add(Integer.parseInt(st.nextToken()));
        }

        st = new StringTokenizer(reader.readLine());
        for(int i = 0; i<n; i++) {
            ListB.add(Integer.parseInt(st.nextToken()));
        }

        ListA.sort(Comparator.naturalOrder());
        ListB.sort(Comparator.reverseOrder());
        int answer = 0;
        for(int i = 0; i<n; i++){
            int numA = ListA.remove(0);
            int numB = ListB.remove(0);
            answer += numA*numB;
        }
        System.out.println(answer);
    }
}