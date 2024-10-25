import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static int n = 0;
    static boolean[][] visited = new boolean[1][1];
    static char[][] matrix = new char[n][n];
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        n = Integer.parseInt(st.nextToken());

        matrix = new char[n][n];

        visited = new boolean[n][n];

        for (int i = 0; i < n; i++) {
            st = new StringTokenizer(reader.readLine());
            String string = st.nextToken();
            for (int j = 0; j < n; j++) {
                matrix[i][j] = string.charAt(j);
            }
        }

        List<Position> positions = new ArrayList<>();
        List<Position> RBPositions = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if(!visited[i][j]) {
                    Position position = new Position(i,j);
                    dfs(position);
                    positions.add(position);
                }
            }
        }

        visited = new boolean[n][n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if(!visited[i][j]) {
                    Position position = new Position(i,j);
                    dfs(position);
                    RBPositions.add(position);
                }
            }
        }

        System.out.println(positions.size() + " " + RBPositions.size());
    }
    
    static class Position{
        Position(int x, int y) {
            this.x = x;
            this.y = y;
        }
        int x;
        int y;
        List<Position> side = new ArrayList<>();
    }
    
    static void dfs(Position position){
        visited[position.x][position.y] = true;

        int x = position.x;
        int y = position.y;
        if(x-1 >= 0 &&
                matrix[x-1][y] == matrix[x][y] &&
                !visited[x-1][y]){
            Position leftP = new Position(x-1,y);
            position.side.add(leftP);
            dfs(leftP);
        }
        if(x+1 < n &&
            matrix[x+1][y] == matrix[x][y] &&
                !visited[x+1][y]){
            Position rightP = new Position(x+1,y);
            position.side.add(rightP);
            dfs(rightP);
        }
        if(y+1 < n &&
                matrix[x][y+1] == matrix[x][y] &&
                !visited[x][y+1]){
            Position downP = new Position(x,y+1);
            position.side.add(downP);
            dfs(downP);
        }
        if(y-1 >= 0 &&
                matrix[x][y-1] == matrix[x][y] &&
                !visited[x][y-1]){
            Position upP = new Position(x,y-1);
            position.side.add(upP);
            dfs(upP);
        }
        
        if(matrix[x][y] == 'G'){
            matrix[x][y] = 'R';
        }
    }
}