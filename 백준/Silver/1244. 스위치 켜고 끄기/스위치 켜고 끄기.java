import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int switches = Integer.parseInt(reader.readLine());
        int[] switchArray = new int[switches];

        StringTokenizer st = new StringTokenizer(reader.readLine());
        for(int i = 0; i<switches; i++){
            switchArray[i] = Integer.parseInt(st.nextToken());
        }

        int students = Integer.parseInt(reader.readLine());
        while(students>0){
            st = new StringTokenizer(reader.readLine());

            int gender = Integer.parseInt(st.nextToken());
            int num = Integer.parseInt(st.nextToken());
            if(gender == 1){
                for(int i = 1; i<=switches; i++){
                    if(i%num == 0){
                        if(switchArray[i-1] == 1){
                            switchArray[i-1] = 0;
                        }
                        else{
                            switchArray[i-1] = 1;
                        }
                    }
                }
            } else {
                num--;
                int left = num-1;
                int right = num+1;
                if(switchArray[num] == 1){
                    switchArray[num] = 0;
                }
                else{
                    switchArray[num] = 1;
                }
                while (left>=0 && right<switches){
                    if(switchArray[left] == switchArray[right]){
                        if(switchArray[left] == 1){
                            switchArray[left] = 0;
                            switchArray[right] = 0;
                        }
                        else{
                            switchArray[left] = 1;
                            switchArray[right] = 1;
                        }
                    } else {
                        break;
                    }
                   
                    left--;
                    right++;
                }
            }
            students--;
        }
        StringBuilder answer = new StringBuilder();
        for(int i = 0; i<switches; i++){
            answer.append(switchArray[i]).append(" ");
            if((i+1)%20 == 0){
                answer.append("\n");
            }
        }
        answer.deleteCharAt(answer.length()-1);
        System.out.println(answer);
    }
}