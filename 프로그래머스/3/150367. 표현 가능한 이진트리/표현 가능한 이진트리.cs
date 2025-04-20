using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(long[] numbers) {
        int[] answer = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            long num = numbers[i];
            string binary = Convert.ToString(num, 2);

            if (binary.Length == 1)
            {
                answer[i] = 1;
                continue;
            }
            
            long maxBinary = 1;
            while (maxBinary <= binary.Length)
            {
                maxBinary <<= 1;
            }

            while (binary.Length < maxBinary-1)
            {
                binary = "0" + binary;
            }
            
            // 1번 조건 : 첫 문자열에서 가운데 기준 뒤쭉의 문자열에서 홀수 index의 값이 "1"인가...?
            // (이건 아닌 듯)
            int midIndex = binary.Length / 2;
            bool incredible = false;
            Queue<string> binaryList = new Queue<string>();
            binaryList.Enqueue(binary);
            while (binaryList.Count > 0)
            {
                string nowBinary = binaryList.Dequeue();
                midIndex = nowBinary.Length / 2;
                if (nowBinary[midIndex] == '0' && nowBinary.Contains('1'))
                {
                    // 루트 노드가 0인 사고가 났다.
                    incredible = true;
                    break;
                }
                else if (nowBinary.Length > 3)
                {
                    binaryList.Enqueue(nowBinary.Substring(0, midIndex));
                    binaryList.Enqueue(nowBinary.Substring(midIndex + 1, midIndex));
                }
            }

            if(incredible)
                answer[i] = 0;
            else
                answer[i] = 1;
        }
        return answer;
    }
}