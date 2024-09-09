import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static List<int[]> KNIGHT_MOVE = new ArrayList<>();
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        KNIGHT_MOVE.add(new int[]{1,2});
        KNIGHT_MOVE.add(new int[]{-1,2});
        KNIGHT_MOVE.add(new int[]{1,-2});
        KNIGHT_MOVE.add(new int[]{-1,-2});
        KNIGHT_MOVE.add(new int[]{2,1});
        KNIGHT_MOVE.add(new int[]{-2,1});
        KNIGHT_MOVE.add(new int[]{2,-1});
        KNIGHT_MOVE.add(new int[]{-2,-1});

        int testCase = Integer.parseInt(st.nextToken());

        StringBuilder answer = new StringBuilder();

        for(int i = 0; i<testCase; i++){
            st = new StringTokenizer(reader.readLine());

            int boardLength = Integer.parseInt(st.nextToken());

            int[][] chessBoard = new int[boardLength][boardLength];
            Queue<int[]> willVisit = new LinkedList<>();
            int[] start = new int[2];

            st = new StringTokenizer(reader.readLine());

            start[0] = Integer.parseInt(st.nextToken());
            start[1] = Integer.parseInt(st.nextToken());

            willVisit.add(start);

            st = new StringTokenizer(reader.readLine());

            int[] end = new int[2];

            end[0] = Integer.parseInt(st.nextToken());
            end[1] = Integer.parseInt(st.nextToken());

            boolean find = false;

            while(!willVisit.isEmpty() && !find){
                int[] nowPos = willVisit.poll();

                if(nowPos[0] == end[0] && nowPos[1] == end[1]){
                    int value = chessBoard[nowPos[0]][nowPos[1]];
                    answer.append(value).append("\n");
                    break;
                }

                for(int[] moving:KNIGHT_MOVE){
                    int x = nowPos[0] + moving[0];
                    int y = nowPos[1] + moving[1];

                    if(x<0 || y<0 || x >= chessBoard.length || y >= chessBoard.length
                    || chessBoard[x][y] != 0){
                        continue;
                    } else {
                        if(start[0] == x && start[1] == y){
                            continue;
                        }
                        int[] newPos = new int[]{x,y};
                        willVisit.add(newPos);
                        chessBoard[x][y] = chessBoard[nowPos[0]][nowPos[1]]+1;
                        if(x == end[0] && y == end[1]){
                            find = true;
                            if(chessBoard[x][y]!=0) {
                                answer.append(chessBoard[x][y]).append("\n");
                            } else {
                                answer.append(0).append("\n");
                            }
                        }
                    }
                }
            }
        }
        System.out.println(answer);
    }
}