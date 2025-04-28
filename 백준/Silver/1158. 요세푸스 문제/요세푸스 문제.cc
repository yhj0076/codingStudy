#include <iostream>

int main(int argc, char *argv[]) {
    int n, k;
    std::cin >> n >> k;

    int circle[n];
    for (int i = 0; i < n; ++i) {
        circle[i] = i + 1;
    }

    int pointer = n - 1;
    int result[n];
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < k; ++j) {
            do {
                pointer = (pointer + 1) % n;
            } while (circle[pointer] == 0);
        }
        result[i] = circle[pointer];
        circle[pointer] = 0;
    }

    std::cout << "<";
    for (int i = 0; i < n-1; ++i) {
        std::cout << result[i] << ", ";
    }
    std::cout << result[n-1] << ">";
    return 0;
}