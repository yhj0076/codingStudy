#include <iostream>

using namespace std;

int main() {
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int t;
    cin >> t;

    while (t--) {
        int n, m;
        cin >> n >> m;

        // 간선 입력 무시
        for (int i = 0; i < m; ++i) {
            int u, v;
            cin >> u >> v;
        }

        cout << (n - 1) << '\n';
    }

    return 0;
}
