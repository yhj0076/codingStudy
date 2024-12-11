import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static final int MAX_VALUE = (100000*99)+1;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());
        int city = Integer.parseInt(st.nextToken());

        st = new StringTokenizer(reader.readLine());
        int bus = Integer.parseInt(st.nextToken());

        int[][] map = new int[city+1][city+1];

        for (int i = 0; i < city+1; i++) {
            for (int j = 0; j < city+1; j++) {
                if(i != j) {
                    map[i][j] = MAX_VALUE;
                }
            }
        }

        for (int i = 0; i < bus; i++) {
            st = new StringTokenizer(reader.readLine());
            int startCity = Integer.parseInt(st.nextToken());
            int endCity = Integer.parseInt(st.nextToken());
            int cost = Integer.parseInt(st.nextToken());
            if(map[startCity][endCity] == MAX_VALUE) {
                map[startCity][endCity] = cost;
            } else {
                map[startCity][endCity] = Math.min(map[startCity][endCity],cost);
            }
        }

        for (int passCity = 1; passCity <= city; passCity++) {
            for (int startCity = 1; startCity <= city; startCity++) {
                for (int endCity = 1; endCity <= city; endCity++) {
                    if (startCity != endCity && startCity != passCity && passCity != endCity) {
                        int nowCost = map[startCity][endCity];
                        int passCost = map[startCity][passCity] + map[passCity][endCity];

                        nowCost = Math.min(nowCost,passCost);
                        map[startCity][endCity] = nowCost;
                    }
                }
            }
        }

        StringBuffer stringBuffer = new StringBuffer();
        for (int i = 1; i <= city; i++) {
            for (int j = 1; j <= city; j++) {
                if(map[i][j] < MAX_VALUE) {
                    stringBuffer.append(map[i][j]).append(" ");
                }
                else{
                    stringBuffer.append(0).append(" ");
                }
            }
            stringBuffer.append("\n");
        }
        System.out.println(stringBuffer);
    }
}