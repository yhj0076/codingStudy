#include <iostream>
int main() {
    std::ios::sync_with_stdio(false);
    std::cin.tie(nullptr);

    int t, n, m, u, v;
    std::cin >> t;
    while (t--) {
        std::cin >> n >> m;
        while (m--) std::cin >> u >> v; // 입력 무시
        std::cout << (n - 1) << '\n';
    }
}

