import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int[] heartPosition = {0,0};    // {x,Y} == x행, y열

        boolean heartFind = false;
        boolean armsFind = false;
        boolean waistFind = false;
        boolean legsFind = false;

        int leftArm = 0;
        int rightArm = 0;
        int waist = 0;
        int leftLeg = 0;
        int rightLeg = 0;


        int matrixSize = Integer.parseInt(reader.readLine());
        int index = 0;
        String[][] matrix = new String[matrixSize][matrixSize];
        while(index<matrixSize){
            String line = reader.readLine();
            matrix[index] = line.split("");
            // 심장 찾기
            if(line.contains("*")&&!heartFind){
                heartPosition[0] = index+1;
                heartPosition[1] = line.indexOf('*');
                heartFind = true;
                index++;
                continue;
            }
            index++;
        }

        // 왼팔 찾기
        int x = heartPosition[0];
        int y = heartPosition[1]-1;
        String point = matrix[x][y];  // 심장 위치부터
        while(point.equals("*")){
            leftArm++;
            y--;
            if(y<0)
                break;
            point = matrix[x][y];
        }

        // 오른팔 찾기
        x = heartPosition[0];
        y = heartPosition[1]+1;
        point = matrix[x][y];
        while(point.equals("*")){
            rightArm++;
            y++;
            if(y>=matrixSize)
                break;
            point = matrix[x][y];
        }

        // 허리 찾기
        x = heartPosition[0]+1;
        y = heartPosition[1];
        point = matrix[x][y];
        while (point.equals("*")){
            waist++;
            x++;
            if(x>=matrixSize)
                break;
            point = matrix[x][y];
        }
        int[] underPosition = {x,y};

        //왼다리 찾기
        x = underPosition[0];
        y = underPosition[1]-1;
        point = matrix[x][y];
        while(point.equals("*")){
            leftLeg++;
            x++;
            if(x>=matrixSize)
                break;
            point = matrix[x][y];
        }

        //오른다리 찾기
        x = underPosition[0];
        y = underPosition[1]+1;
        point = matrix[x][y];
        while (point.equals("*")){
            rightLeg++;
            x++;
            if(x>=matrixSize)
                break;
            point = matrix[x][y];
        }
        heartPosition[0]++;
        heartPosition[1]++;
        System.out.println(heartPosition[0]+" "+heartPosition[1]+"\n"+
                leftArm+" "+rightArm+" "+waist+" "+leftLeg+" "+rightLeg);
    }
}