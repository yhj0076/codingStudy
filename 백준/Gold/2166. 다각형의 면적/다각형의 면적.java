import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringTokenizer st = new StringTokenizer(reader.readLine());

        int N = Integer.parseInt(st.nextToken());

        List<double[]> points = new ArrayList<>();

        for(int i = 0; i<N; i++){
            st = new StringTokenizer(reader.readLine());

            double[] point = new double[2];
            point[0] = Double.parseDouble(st.nextToken());
            point[1] = Double.parseDouble(st.nextToken());

            points.add(point);
        }

        double xSum = 0D;
        double ySum = 0D;

        for(int i = 0; i<points.size(); i++){
            if(i< points.size()-1) {
                xSum += points.get(i)[0] * points.get(i + 1)[1];
                ySum += points.get(i)[1] * points.get(i + 1)[0];
            } else {
                xSum += points.get(i)[0] * points.get(0)[1];
                ySum += points.get(i)[1] * points.get(0)[0];
            }
        }

        double result = Math.round((Math.abs(xSum-ySum)/2D)*10D)/10D;
        System.out.printf("%.1f%n",result);
    }
}