import sys

sys.setrecursionlimit(1000001)

n = int(input())

graph = []
visited = []
dp = []
for i in range(n+1):
    graph.append([])
    visited.append(False)
    dp.append([0,0])

for i in range(n-1):
    start, end = map(int, sys.stdin.readline().split())
    graph[start].append(end)
    graph[end].append(start)

# dp[n][0] : (min(dp[child][0], dp[child][1]) + ... + min(dp[child][0], dp[child][1])) + 1
# dp[n][1] : dp[child][0] + ... + dp[child][0]
def dfs(n):
    if not visited[n]:
        visited[n] = True
        child = graph[n]

        for inner in child:
            if dfs(inner):
                # 방문한 적 없다면 수행
                dp[n][0] += min(dp[inner][0], dp[inner][1])
                dp[n][1] += dp[inner][0]

        dp[n][0] += 1
        return True
    else:
        return False


dfs(1)
print(min(dp[1][0],dp[1][1]))