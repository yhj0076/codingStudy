import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());

        List<Lan> LanList = new LinkedList<>();

        int donateLan = 0;

        for (int i = 0; i < n; i++) {
            st = new StringTokenizer(reader.readLine());
            String string = st.nextToken();
            for (int j = 0; j < n; j++) {
                char theCharacter = string.charAt(j);
                int changeToInt = 0;

                if (theCharacter >= 'a' && theCharacter <= 'z') {
                    changeToInt = theCharacter - 'a' + 1;
                } else if (theCharacter >= 'A' && theCharacter <= 'Z') {
                    changeToInt = theCharacter - 'A' + 27;
                }

                Lan lan = new Lan(i,j,changeToInt);
                LanList.add(lan);
            }
        }

        LanList.sort(Comparator.comparingInt(lan -> lan.length));

        List<Set<Integer>> usedCPU = new LinkedList<>();

        for (int i = 0; i < n; i++) {
            Set<Integer> nowSet = new HashSet<>();
            nowSet.add(i);
            usedCPU.add(nowSet);
        }

        for (int i = 0; i < LanList.size(); i++) {
            Lan nowLan = LanList.get(i);

            if(nowLan.length > 0) {
                Set<Integer> setA = null;
                for (int j = 0; j < usedCPU.size(); j++) {
                    if(usedCPU.get(j).contains(nowLan.AtoB[0])){
                        setA = usedCPU.get(j);
                        break;
                    }
                }

                Set<Integer> setB = null;
                for (int j = 0; j < usedCPU.size(); j++) {
                    if(usedCPU.get(j).contains(nowLan.AtoB[1])){
                        setB = usedCPU.get(j);
                        break;
                    }
                }

                if (setA == setB){
                    donateLan += nowLan.length;
                }
                else{
                    setA.addAll(setB);
                    usedCPU.remove(setB);
                }
            }
        }
        if(usedCPU.size() == 1){
            System.out.println(donateLan);
        }
        else{
            System.out.println(-1);
        }
    }
    
    static class Lan{
        int[] AtoB;
        int length;

        public Lan(int a, int b, int length) {
            this.length = length;
            AtoB = new int[]{a,b};
        }
    }
}