#include <iostream>

using namespace std;

int main() {
    int n;
    cin >> n;

    int recentNum = 0;
    int upperCount = 0;
    int lowerCount = 0;

    int maxUpper = 0;
    int maxLower = 0;

    for (int i = 0; i < n; i++) {
        int num;
        cin >> num;

        if (recentNum < num) {
            upperCount++;
            maxLower = lowerCount > maxLower ? lowerCount : maxLower;
            lowerCount = 1;
        }
        else if (recentNum > num){
            maxUpper = upperCount > maxUpper ? upperCount : maxUpper;
            upperCount = 1;
            lowerCount++;
        }
        else {
            upperCount++;
            lowerCount++;
        }

        recentNum = num;
    }

    maxLower = lowerCount > maxLower ? lowerCount : maxLower;
    maxUpper = upperCount > maxUpper ? upperCount : maxUpper;

    cout << max(maxLower, maxUpper) << endl;
    return 0;
}