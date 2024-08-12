import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        final BigInteger NUMBER= new BigInteger("1000000007");

        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int x = Integer.parseInt(st.nextToken());
        int y = Integer.parseInt(st.nextToken());

        List<List<BigInteger>> arrList = new ArrayList<>();

        List<BigInteger> startList = new ArrayList<>();
        startList.add(BigInteger.ONE);
        arrList.add(startList);

        for(int i = 0; i<x; i++){
            List<BigInteger> innerList = arrList.get(i);
            for(int j = 1; j<y; j++){
                BigInteger lastNum = innerList.get(j-1);
                BigInteger lastNum2 = new BigInteger("0");
                BigInteger lastNum3 = new BigInteger("0");
                if(i>0){
                    List<BigInteger> upperList = arrList.get(i-1);
                    lastNum2 = upperList.get(j-1);
                    lastNum3 = upperList.get(j);
                }
                BigInteger addAll = lastNum.add(lastNum2).add(lastNum3);
                innerList.add(addAll);
            }
            List<BigInteger> newList = new ArrayList<>();
            newList.add(BigInteger.ONE);
            arrList.add(newList);
        }

        BigInteger answerNum = arrList.get(x-1).get(y-1).mod(NUMBER);
        System.out.println(answerNum);
    }
}