import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());
        int TaeSuNewScore = Integer.parseInt(st.nextToken());
        int p = Integer.parseInt(st.nextToken());

        String input = reader.readLine();
        if(input != null) {
            st = new StringTokenizer(input);
        } else {
            st = new StringTokenizer(" ");
        }

        List<Integer> ranking = new ArrayList<>();
        int score = 0;
        int rank = 0;
        while(n>0){
            score = Integer.parseInt(st.nextToken());
            if(score > TaeSuNewScore){
                ranking.add(score);
                rank = ranking.size();
            } else if (score == TaeSuNewScore) {
                ranking.add(score);
            } else {
                break;
            }
            n--;
        }
        rank++;
        ranking.add(TaeSuNewScore);
        if(ranking.size()>p){
            System.out.println(-1);
        } else{
            System.out.println(rank);
        }
    }
}