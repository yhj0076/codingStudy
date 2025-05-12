#include <iostream>

using namespace std;
const int MOD = 1000000007;

int fibonacci(int n) {
    int num1 = 1;
    int num2 = 1;
    int num3 = 2;

    for (int i = 2; i < n; i++) {
        num3 = num1 + num2;
        if (num3 > MOD)
            num3 -= MOD;
        num1 = num2;
        num2 = num3;
    }

    return num3;
}

int main(int argc, char *argv[]) {
    int num;
    cin >> num;

    cout << fibonacci(num) << " " << num - 2;
    return 0;
}