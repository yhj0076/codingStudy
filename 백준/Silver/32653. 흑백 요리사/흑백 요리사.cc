#include <cmath>
#include <iostream>

using namespace std;

int main(int argc, char *argv[]) {
    int n;
    cin >> n;

    long long answer = 1;

    // 소수 목록 : 2, 3, 5, 7, 11, 13, 17, 19, 23
    int prime[]{2, 3, 5, 7, 11, 13, 17, 19, 23};
    long square[]{0, 0, 0, 0, 0, 0, 0, 0, 0};

    for (int i = 0; i < n; i++) {
        int steak;
        cin >> steak;

        for (int j = 0; j < 9; j++) {
            if (steak < prime[j])
                break;

            int square_number = square[j];
            if (square_number == 0)
                square_number = 1;

            bool is_prime = true;
            while (steak % (int)pow(prime[j],square_number) == 0) {
                square[j]++;
                square_number = square[j];
                is_prime = false;
            }
            if (!is_prime)
                square[j]--;
        }
    }

    for (int i = 0; i < 9; i++) {
        answer *= pow(prime[i], square[i]);
    }

    cout << answer * 2;
    return 0;
}