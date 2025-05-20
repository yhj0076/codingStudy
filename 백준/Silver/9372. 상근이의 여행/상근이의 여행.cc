#include <iostream>
#include <vector>

using namespace std;

vector<int> answer;

int main(int argc, char *argv[]) {
    int t;
    cin >> t;

    for (int i = 0; i < t; i++) {
        int n;
        int m;

        cin >> n >> m;

        for (int j = 0; j < m; j++) {
            int from;
            int to;
            cin >> from >> to;
        }
        
        answer.push_back(n-1);
    }

    for (int i = 0; i < t; i++) {
        cout << answer[i] << endl;
    }

    return 0;
}
