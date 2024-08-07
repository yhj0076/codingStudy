import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

//        int cityCount = Integer.parseInt(st.nextToken())-1;
        BigInteger cityCount = new BigInteger(st.nextToken());
        cityCount = cityCount.subtract(new BigInteger("1"));

//        List<Integer> roads = new ArrayList<>();
//        List<Integer> cities = new ArrayList<>();
        List<BigInteger> roads = new ArrayList<>();
        List<BigInteger> cities = new ArrayList<>();


//        int leftRoad = 0;
//        int cheapCity = 0;
        BigInteger cheapCity = new BigInteger("0");
        st = new StringTokenizer(reader.readLine());
//        for(int i = 0; i<cityCount; i++){
//            Integer road = Integer.parseInt(st.nextToken());
//            roads.add(road);
//            leftRoad+=road;
//        }
        for(BigInteger i = new BigInteger("0");
            i.compareTo(cityCount) < 0;
            i = i.add(new BigInteger("1"))){
            BigInteger road = new BigInteger(st.nextToken());
            roads.add(road);
        }



        st = new StringTokenizer(reader.readLine());
//        for(int i = 0; i<cityCount; i++){
//            Integer city = Integer.parseInt(st.nextToken());
//            cities.add(city);
//            if(cheapCity<city){
//                cheapCity = city;
//            }
//        }
        for(BigInteger i = new BigInteger("0");
            i.compareTo(cityCount) < 0;
            i = i.add(new BigInteger("1"))){
            BigInteger city = new BigInteger(st.nextToken());
            cities.add(city);
            if(cheapCity.compareTo(city) < 0){
                cheapCity = city;
            }
        }

//        int oilPrice = 0;
        BigInteger oilPrice = new BigInteger("0");
//        for(int i = 0; i<cityCount; i++){
//            if(cheapCity>cities.get(i)){
//                cheapCity = cities.get(i);
//            }
//            oilPrice = oilPrice + (cheapCity * roads.get(i));
//            leftRoad-=roads.get(i);
//        }
        for(BigInteger i = new BigInteger("0");
            i.compareTo(cityCount) < 0;
            i = i.add(new BigInteger("1"))){

            BigInteger nowCity = cities.remove(0);
            BigInteger nowRoad = roads.remove(0);

            if(cheapCity.compareTo(nowCity) > 0){
                cheapCity = nowCity;
            }
            oilPrice = oilPrice.add(cheapCity.multiply(nowRoad));
        }

        System.out.println(oilPrice);
    }
}