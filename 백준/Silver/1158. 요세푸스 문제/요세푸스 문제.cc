#include <iostream>
#include <vector>

using namespace std;

int main(int argc, char *argv[]) {
    int n, k;
    std::cin >> n >> k;

    vector<int> circle;
    for (int i = 0; i < n; i++) {
        circle.push_back(i+1);
    }

    int pointer = 0;
    vector<int> result;
    for (int i = 0; i < n; i++) {
        pointer = (pointer + k - 1) % circle.size();
        result.push_back(circle[pointer]);
        circle.erase(circle.begin() + pointer);
    }

    cout << "<";
    for (int i = 0; i < result.size(); i++) {
        cout << result[i];
        if (i != result.size() - 1) {
            cout << ", ";
        }
    }
    cout << ">" << endl;

    return 0;
}