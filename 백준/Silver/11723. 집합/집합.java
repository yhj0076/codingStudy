import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int arraySize = Integer.parseInt(reader.readLine());
        StringBuilder stringBuilder = new StringBuilder();
        HashSet<Integer> set = new HashSet<Integer>();
        while (arraySize > 0){
            String input = reader.readLine();
            if(input.equals("all")){
                set.clear();
                for(int i = 1; i<21; i++){
                    set.add(i);
                }
                arraySize--;
                continue;
            } else if(input.equals("empty")){
                set.clear();
                arraySize--;
                continue;
            }
            String[] order = input.split(" ");
            Integer number = Integer.valueOf(order[1]);
            switch (order[0]){
                case "add":{
                    set.add(number);
                    break;
                }
                case "remove":{
                    set.remove(number);
                    break;
                }
                case "check":{
                    Boolean isExist = set.contains(number);
                    if(isExist){
                        stringBuilder.append("1\n");
                    } else {
                        stringBuilder.append("0\n");
                    }
                    break;
                }
                case "toggle":{
                    if(set.contains(number)){
                        set.remove(number);
                    } else {
                        set.add(number);
                    }
                    break;
                }
            }
            arraySize--;
        }
        System.out.println(stringBuilder);
    }
}