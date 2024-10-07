import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;
import java.util.*;

public class Main {
    static int moving = 0;
    static StringBuilder answer = new StringBuilder();
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        String blocks = st.nextToken();
        int blockInt = Integer.parseInt(blocks);
        if(blockInt<=20) {
            printMove(blockInt, 1, 3);
            System.out.println(String.valueOf(moving) + answer);
        }
        else {
            System.out.println(BigInteger.TWO.pow(blockInt).subtract(BigInteger.ONE));
        }
    }

    public static void printMove(int stair,int start, int end){
        int mid = 6-start-end;
        if(stair == 2) {
            answer.append("\n").append(start).append(" ").append(mid);
            moving++;
            answer.append("\n").append(start).append(" ").append(end);
            moving++;
            answer.append("\n").append(mid).append(" ").append(end);
            moving++;
        }
        else{
            printMove(stair-1,start,mid);
            answer.append("\n").append(start).append(" ").append(end);
            moving++;
            printMove(stair-1,mid,end);
        }
    }
}