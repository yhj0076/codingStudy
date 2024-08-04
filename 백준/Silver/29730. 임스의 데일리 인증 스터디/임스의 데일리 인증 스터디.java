import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        List<Integer> todoList = new ArrayList<>();

        HashMap<Integer, List<String>> map = new HashMap<>();

        List<Integer> baekJunList = new ArrayList<>();

        while(n>0){
            String study = reader.readLine();
            int length = study.length();

            if(study.contains("boj.kr/")){
                int quizNum = Integer.parseInt(study.substring(7));

                baekJunList.add(quizNum);
            } else {
                if(map.containsKey(length)){
                    List<String> existList = map.get(length);
                    existList.add(study);
                    map.put(length,existList);
                    todoList.add(length);
                } else {
                    List<String> newList = new ArrayList<>();
                    newList.add(study);
                    map.put(length,newList);
                    todoList.add(length);
                }
            }
            n--;
        }

        todoList.sort(Comparator.naturalOrder());
        baekJunList.sort(Comparator.naturalOrder());

        StringBuilder answer = new StringBuilder();

        while (!todoList.isEmpty() || !baekJunList.isEmpty()){
            if(!todoList.isEmpty()){
                Integer key = todoList.remove(0);
                List<String> existLIst = map.get(key);
                existLIst.sort(Comparator.naturalOrder());
                answer.append(existLIst.remove(0)).append("\n");
                map.put(key,existLIst);
            } else {
                Integer quizNum = baekJunList.remove(0);
                answer.append("boj.kr/").append(quizNum).append("\n");
            }
        }

        System.out.println(answer);
    }
}