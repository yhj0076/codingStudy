import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int n = Integer.parseInt(st.nextToken());
        int k = Integer.parseInt(st.nextToken());

        List<List<Integer>> allValue = new ArrayList<>();

        List<Integer> zeroValue = new ArrayList<>();
        for (int i = 0; i <= n; i++) {
            zeroValue.add(0);
        }
        allValue.add(zeroValue);

        List<theThing> things = new ArrayList<>();

        int result = 0;

        theThing zeroThing = new theThing(0,0);
        things.add(zeroThing);
        for (int i = 0; i < n; i++) {
            st = new StringTokenizer(reader.readLine());
            int w = Integer.parseInt(st.nextToken());
            int v = Integer.parseInt(st.nextToken());

            theThing thing = new theThing(w,v);
            things.add(thing);
        }

        for (int nowWeight = 1; nowWeight <= k; nowWeight++) {
            List<Integer> maxValue = new ArrayList<>();
            maxValue.add(0);
            for (int thingNum = 1; thingNum < things.size(); thingNum++) {
                theThing nowThing = things.get(thingNum);

                int leftWeight = nowWeight - nowThing.weight;
                if(leftWeight < 0){
                    leftWeight = 0;
                }

                int plusValue = allValue.get(leftWeight).get(thingNum-1) +  (nowWeight >= nowThing.weight + leftWeight ? nowThing.value : 0);

                int max = Math.max(plusValue,maxValue.get(thingNum-1));
                maxValue.add(max);
            }
            allValue.add(maxValue);
        }

        System.out.println(allValue.get(k).get(n));
    }
    
    public static class theThing{
        int weight;
        int value;
        public theThing(int w, int v) {
            this.weight = w;
            this.value = v;
        }
    }
}