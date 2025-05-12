#include <iostream>
using namespace std;

const int MOD = 1000000007;

// 행렬 곱셈 함수
void multiply(long long F[2][2], long long M[2][2]) {
    long long x = (F[0][0] * M[0][0] % MOD + F[0][1] * M[1][0] % MOD) % MOD;
    long long y = (F[0][0] * M[0][1] % MOD + F[0][1] * M[1][1] % MOD) % MOD;
    long long z = (F[1][0] * M[0][0] % MOD + F[1][1] * M[1][0] % MOD) % MOD;
    long long w = (F[1][0] * M[0][1] % MOD + F[1][1] * M[1][1] % MOD) % MOD;

    F[0][0] = x;
    F[0][1] = y;
    F[1][0] = z;
    F[1][1] = w;
}

// 지수승 함수
void power(long long F[2][2], int n) {
    if (n == 0 || n == 1) return;

    long long M[2][2] = {{1, 1}, {1, 0}};
    power(F, n / 2);
    multiply(F, F);

    if (n % 2 != 0)
        multiply(F, M);
}

// 피보나치 수 계산
int fibonacci(int n) {
    if (n == 0) return 0;

    long long F[2][2] = {{1, 1}, {1, 0}};
    power(F, n - 1);

    return F[0][0];
}

int main() {
    int num;
    cin >> num;

    cout << fibonacci(num) << " " << num - 2;
    return 0;
}