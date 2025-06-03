#include <iostream>
#include <unordered_map>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, m;
    cin >> n >> m;

    unordered_map<string, int> word_book;
    string word;

    for (int i = 0; i < n; i++) {
        cin >> word;
        if (word.length() >= m) {
            word_book[word]++;
        }
    }

    // map to vector
    vector<string> words;
    for (const auto& entry : word_book) {
        words.push_back(entry.first);
    }

    // 정렬: 빈도 내림차순, 길이 내림차순, 사전 오름차순
    sort(words.begin(), words.end(), [&](const string& a, const string& b) {
        if (word_book[a] != word_book[b])
            return word_book[a] > word_book[b]; // 빈도 높은 순
        if (a.length() != b.length())
            return a.length() > b.length();     // 길이 긴 순
        return a < b;                           // 사전순 오름차순
    });

    for (const string& w : words) {
        cout << w << '\n';
    }

    return 0;
}
