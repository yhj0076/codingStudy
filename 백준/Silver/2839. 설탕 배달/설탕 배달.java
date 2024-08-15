import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int sugar = Integer.parseInt(st.nextToken());

        int answer = 0;

        while(sugar>=3){
            if(sugar%5==0){
                sugar-=5;
                answer++;
            }
            else {
                sugar-=3;
                answer++;
            }
        }

        if(sugar>0){
            System.out.println(-1);
        } else {
            System.out.println(answer);
        }
    }
}