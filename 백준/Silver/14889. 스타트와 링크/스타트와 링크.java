import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    static int visitedLength = 0;
    static ArrayList<Integer> visited = new ArrayList<>();
    static ArrayList<Integer> nonVisited = new ArrayList<>();
    static int min = 999999999;
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());
        visitedLength = n/2;
        int varLength = n/2;
        int[][] matrix = new int[n+1][n+1];
        for(int i = 1; i<=n; i++){
            st = new StringTokenizer(reader.readLine());
            for(int j = 1; j<=n; j++){
                int power = Integer.parseInt(st.nextToken());
                if(i==j){
                    matrix[i][j] = 0;
                } else if (i<j) {
                    matrix[i][j] = power;
                } else {
                    matrix[i][j] = matrix[j][i] + power;
                    matrix[j][i] = matrix[i][j];
                }
            }
        }
        makeTeam(matrix,1,visitedLength-1,n);
        System.out.println(min);
    }
    public static void makeTeam(int[][] matrix,int start,int varLength,int n){
        for(int i = start; i<=n-varLength; i++){
            if(visited.size()<visitedLength) {
                visited.add(i);
                makeTeam(matrix, i + 1, varLength-1,n);
                visited.remove(visited.size()-1);
            }
            else{
                for(int existNum = 1; existNum<=n; existNum++){
                    if(!visited.contains(existNum)){
                        nonVisited.add(existNum);
                    }
                }
                int a = 0;
                int b = 0;
                for(int j = 0; j<visitedLength-1; j++){
                    for(int k = j+1; k<visitedLength; k++){
                        int x = visited.get(j);
                        int y = visited.get(k);
                        int v = nonVisited.get(j);
                        int w = nonVisited.get(k);
                        a = a + matrix[x][y];
                        b = b + matrix[v][w];
                    }
                }
                if(Math.abs(a-b)<min){
                    min = Math.abs(a-b);
                }
                nonVisited.clear();
                break;
            }
        }
    }
}