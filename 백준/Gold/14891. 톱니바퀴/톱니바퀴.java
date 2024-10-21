import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        List<String> gears = new ArrayList<>();

        gears.add(st.nextToken());

        st = new StringTokenizer(reader.readLine());
        gears.add(st.nextToken());

        st = new StringTokenizer(reader.readLine());
        gears.add(st.nextToken());

        st = new StringTokenizer(reader.readLine());
        gears.add(st.nextToken());

        st = new StringTokenizer(reader.readLine());
        int spinCount = Integer.parseInt(st.nextToken());

        // index 2 -> 오른쪽
        // index 6 -> 왼쪽

        for (int i = 0; i < spinCount; i++) {
            st = new StringTokenizer(reader.readLine());
            int gearNum = Integer.parseInt(st.nextToken())-1;
            int spin = Integer.parseInt(st.nextToken());

            int tmpSpin = spin;
            List<Integer> needSpin = new ArrayList<>();

            needSpin.add(spin);

            int leftGear = gearNum-1;
            int rightGear = gearNum+1;

            while(leftGear>-1){
                if(gears.get(leftGear).charAt(2) != gears.get(leftGear+1).charAt(6)){
                    tmpSpin*=-1;
                    needSpin.add(0,tmpSpin);
                }
                else{
                    while(leftGear>-1) {
                        needSpin.add(0, 0);
                        leftGear--;
                    }
                }
                leftGear--;
            }

            tmpSpin = spin;

            while(rightGear<4){
                if(gears.get(rightGear).charAt(6) !=
                        gears.get(rightGear-1).charAt(2)){
                    tmpSpin*=-1;
                    needSpin.add(tmpSpin);
                }
                else{
                    while(rightGear<4) {
                        needSpin.add(0);
                        rightGear++;
                    }
                }
                rightGear++;
            }

            for (int j = 0; j < 4; j++) {
                int where = needSpin.get(j);
                String tmpGear = gears.get(j);
                tmpGear = Spin(where,tmpGear);
                gears.set(j,tmpGear);
            }
        }

        StringBuilder binary = new StringBuilder();
        for (int i = 3; i >= 0; i--) {
            binary.append(gears.get(i).charAt(0));
        }

        int score = Integer.parseInt(binary.toString(),2);
        System.out.println(score);
    }
    
    static String Spin(int where, String gear){
        if(where > 0){
            gear = WatchSpin(gear);
        }
        else if(where < 0){
            gear = ReverseSpin(gear);
        }
        return gear;
    }
    
    static String WatchSpin(String gear){
        char lastCharacter = gear.charAt(7);

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append(lastCharacter).append(gear.substring(0,7));

        return stringBuilder.toString();
    }
    
    static String ReverseSpin(String gear){
        char firstCharacter = gear.charAt(0);

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append(gear.substring(1,8)).append(firstCharacter);

        return stringBuilder.toString();
    }
}