import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        StringBuilder line = new StringBuilder(st.nextToken());
        StringBuilder reversed = new StringBuilder(line);
        reversed.reverse();

        int innerPalendrome = 0;

        for (int i = 1; i <= reversed.length(); i++) {
            StringBuilder subs = new StringBuilder(reversed.substring(0, i));
            StringBuilder subsR = new StringBuilder(subs).reverse();
            if(subs.compareTo(subsR) == 0 && innerPalendrome < subs.length()){
                innerPalendrome = subs.length();
            }
        }

        System.out.println(line.length()*2-innerPalendrome);
    }
}