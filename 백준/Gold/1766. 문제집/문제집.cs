using System;
using System.Collections.Generic;

namespace codingStudy
{
    public class Starter
    {
        class Node
        {
            public int InDegree { get; set; } = 0; // 진입 차수
            public List<int> Edges { get; } = new List<int>(); // 연결된 노드들

            public void AddEdge(int to)
            {
                Edges.Add(to);
            }
        }

        public static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split();
            int n = int.Parse(nm[0]); // 노드 수
            int m = int.Parse(nm[1]); // 간선 수

            // 그래프 생성
            Node[] graph = new Node[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new Node();
            }

            // 간선 입력
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split();
                int from = int.Parse(input[0]);
                int to = int.Parse(input[1]);

                graph[from].AddEdge(to);
                graph[to].InDegree++;
            }

            // 우선순위 큐 (작은 번호가 우선)
            PriorityQueue<int, int> pQ = new PriorityQueue<int, int>();

            // 진입 차수가 0인 노드 추가
            for (int i = 1; i <= n; i++)
            {
                if (graph[i].InDegree == 0)
                {
                    pQ.Enqueue(i, i);
                }
            }

            List<int> result = new List<int>(); // 결과를 저장할 리스트

            while (pQ.Count > 0)
            {
                int current = pQ.Dequeue();
                result.Add(current);

                // 연결된 노드들의 진입 차수 감소
                foreach (var neighbor in graph[current].Edges)
                {
                    graph[neighbor].InDegree--;
                    if (graph[neighbor].InDegree == 0)
                    {
                        pQ.Enqueue(neighbor, neighbor);
                    }
                }
            }

            // 결과 출력
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
