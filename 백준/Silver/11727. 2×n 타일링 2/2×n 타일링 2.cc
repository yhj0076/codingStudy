#include <iostream>

using namespace std;
const int MOD = 10007;

int main(int argc, char *argv[]) {

    int n;
    cin >> n;

    int memo[1001];
    memo[0] = 1;
    memo[1] = 1;
    memo[2] = 3;
    for (int i = 2; i <= n; i++) {
        memo[i] = (memo[i - 1] + 2 * memo[i - 2]) % MOD;
    }

    cout << memo[n];
}
