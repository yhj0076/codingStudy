import math
import sys
from queue import PriorityQueue

answer = ""

caveSize = int(sys.stdin.readline())
visited = [[False for _ in range(caveSize)] for _ in range(caveSize)]
trySize = 0
while caveSize != 0:
    trySize += 1
    lostRupee = [[math.inf for _ in range(caveSize)] for _ in range(caveSize)]
    cave = [list(map(int, sys.stdin.readline().split())) for _ in range(caveSize)]
    visited = [[False for _ in range(caveSize)] for _ in range(caveSize)]

    lostRupee[0][0] = cave[0][0]

    que = PriorityQueue()

    que.put((0, (0,0)))
    while not que.empty():
        node = que.get()
        #print("get node : (%d,(%d, %d))"%(node[0],node[1][0],node[1][1]))
        if not visited[node[1][0]][node[1][1]]:
            visited[node[1][0]][node[1][1]] = True
            if node[1][0]+1 < caveSize:
                downCost = cave[node[1][0]+1][node[1][1]]
                lostRupee[node[1][0] + 1][node[1][1]] = min(lostRupee[node[1][0]][node[1][1]]+downCost,lostRupee[node[1][0] + 1][node[1][1]])
                que.put((lostRupee[node[1][0] + 1][node[1][1]], (node[1][0] + 1, node[1][1])))
            if node[1][1]+1 < caveSize:
                rightCost = cave[node[1][0]][node[1][1]+1]
                lostRupee[node[1][0]][node[1][1] + 1] = min(lostRupee[node[1][0]][node[1][1]]+rightCost, lostRupee[node[1][0]][node[1][1] + 1])
                que.put((lostRupee[node[1][0]][node[1][1] + 1], (node[1][0], node[1][1] + 1)))
            if node[1][0]-1 > -1:
                upCost = cave[node[1][0]-1][node[1][1]]
                lostRupee[node[1][0] - 1][node[1][1]] = min(lostRupee[node[1][0]][node[1][1]]+upCost,lostRupee[node[1][0] - 1][node[1][1]])
                que.put((lostRupee[node[1][0] - 1][node[1][1]], (node[1][0] - 1, node[1][1])))
            if node[1][1]-1 > -1:
                leftCost = cave[node[1][0]][node[1][1]-1]
                lostRupee[node[1][0]][node[1][1]-1] = min(lostRupee[node[1][0]][node[1][1]]+leftCost,lostRupee[node[1][0]][node[1][1]-1])
                que.put((lostRupee[node[1][0]][node[1][1]-1], (node[1][0], node[1][1]-1)))

    answerNum = lostRupee[caveSize-1][caveSize-1]
    #새로운 동굴 사이즈 입력
    answer += "Problem %d: %d\n" % (trySize,answerNum)
    caveSize = int(sys.stdin.readline())
print(answer)