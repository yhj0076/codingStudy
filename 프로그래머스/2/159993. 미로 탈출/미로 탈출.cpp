#include <iostream>
#include <queue>
#include <string>
#include <vector>

using namespace std;

int dx[4] = {1,0,-1,0};
int dy[4] = {0,1,0,-1};

int bfs(vector<string> maps, int & x, int & y, char target) {
    queue<pair<int, int>> q;
    queue<pair<int, int>> nextQ;
    bool visited[maps.size()][maps[0].length()];

    for (int i = 0; i < maps.size(); i++) {
        for (int j = 0; j < maps[0].length(); j++) {
            visited[i][j] = false;
        }
    }

    int timer = 0;

    visited[x][y] = true;
    q.push(make_pair(x, y));
    while (!q.empty()) {
        while (!q.empty()) {
            pair<int, int> cur = q.front();
            q.pop();

            for (int i = 0; i < 4; i++) {
                int nx = cur.first + dx[i];
                int ny = cur.second + dy[i];

                if (nx < 0 || nx >= maps.size() || ny < 0 || ny >= maps[0].length())
                    continue;

                if (!visited[nx][ny] && maps[nx].at(ny) != 'X') {
                    if (maps[nx][ny] == target) {
                        x = nx;
                        y = ny;
                        timer++;
                        return timer;
                    }
                    visited[nx][ny] = true;
                    nextQ.push(make_pair(nx, ny));
                }
            }
        }
        while (!nextQ.empty()) {
            q.push(nextQ.front());
            nextQ.pop();
        }
        timer++;
    }

    return -1;
}

int solution(vector<string> maps) {
    int answer = 0;

    int x = 0, y = 0;
    for (int i = 0; i < maps.size(); i++) {
        for (int j = 0; j < maps[0].size(); j++) {
            if (maps[i][j] == 'S') {
                x = i;
                y = j;
            }
        }
    }
    
    // bfs의 깊이로 판단
    int leverT = bfs(maps, x, y, 'L');
    if(leverT > 0)
        answer += leverT;
    else
        return -1;
    int exitT = bfs(maps, x, y, 'E');
    if(exitT > 0)
        answer += exitT;
    else
        return -1;
    return answer;
}