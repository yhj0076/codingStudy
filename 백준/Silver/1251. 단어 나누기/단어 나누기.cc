#include <algorithm>
#include <iostream>

using namespace std;

int main(int argc, char *argv[]) {
    string s;
    cin >> s;

    string answer;

    for (int i = 1; i <= s.size() - 2; i++) {
        for (int j = 1; j <= s.size() - i - 1; j++) {
            string a = s.substr(0, i);
            string b = s.substr(i, j);
            string c = s.substr(i + j);

            reverse(a.begin(), a.end());
            reverse(b.begin(), b.end());
            reverse(c.begin(), c.end());

            string ret = a + b + c;
            if (answer == "") answer = ret;
            else if (ret < answer) answer = ret;
        }
    }

    cout << answer;
    return 0;
}