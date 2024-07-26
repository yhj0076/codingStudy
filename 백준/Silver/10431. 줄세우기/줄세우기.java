import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int testCase = Integer.parseInt(reader.readLine());

        StringBuilder answer = new StringBuilder();

        int footMove = 0;
        while(testCase>0) {
            footMove = 0;
            String lineCase = reader.readLine();
            String[] line = lineCase.split(" ");
            answer.append(line[0]).append(" ");
            List<Integer> sortedLine = new ArrayList<Integer>();
            int studentFirst = Integer.parseInt(line[1]);
            sortedLine.add(studentFirst);
            if(line.length<=2){
                answer.append(footMove).append("\n");
                testCase--;
                continue;
            }
            for(int i = 2; i<line.length; i++){
                int student = Integer.parseInt(line[i]);

                int index = sortedLine.size()-1;
                int lastStudent = sortedLine.get(index);
                while(student<lastStudent){
                    index--;
                    footMove++;
                    if(index < 0){
                        break;
                    }
                    lastStudent = sortedLine.get(index);
                }
                sortedLine.add(index+1,student);
            }

            answer.append(footMove).append("\n");
            testCase--;
        }
        System.out.println(answer);
    }
}