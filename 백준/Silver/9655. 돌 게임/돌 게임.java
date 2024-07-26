import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int stones = Integer.parseInt(reader.readLine());
        stones = stones % 4;
        switch (stones){
            case 0:
            case 2:{
                System.out.println("CY");
                break;
            }
            case 1:
            case 3:{
                System.out.println("SK");
                break;
            }
        }
    }
}