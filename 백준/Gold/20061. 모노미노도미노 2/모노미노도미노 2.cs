public class Starter
{
    class Field
    {
        List<bool[]> field = new List<bool[]>();
        public int score = 0;
        public int blockCount = 0;
        public Field()
        {
            for (int i = 0; i < 6; i++)
                field.Add(new bool[4]);
        }

        // 0 - [0, 1, 2, 3]
        // 1 - [0, 1, 2, 3]
        // 2 - [0, 1, 2, 3]
        // 3 - [0, 1, 2, 3]
        // 4 - [0, 1, 2, 3]
        // 5 - [0, 1, 2, 3]
        public void AddBlock(int type, int pos, bool isBlue = false)
        {
            switch (type)
            {
                // 1칸 짜리
                case 1:
                {
                    blockCount += 1;
                    for (int i = 1; i < 6; i++)
                    {
                        var line = field[i];
                        if (line[pos])
                        {
                            int val = i - 1;
                            field[val][pos] = true;
                            CheckInFull(ref val);
                            return;
                        }
                    }

                    int end = 5;
                    field[5][pos] = true;
                    CheckInFull(ref end);
                    break;
                }

                // 가로 (1x2)
                case 2:
                {
                    blockCount += 2;
                    if (!isBlue)
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            var line = field[i];
                            if (line[pos] || line[pos + 1])
                            {
                                int val = i - 1;
                                field[val][pos] = true;
                                field[val][pos + 1] = true;
                                CheckInFull(ref val);
                                return;
                            }
                        }

                        field[5][pos] = true;
                        field[5][pos + 1] = true;
                    }
                    else
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            var line = field[i];
                            if (line[pos] || line[pos - 1])
                            {
                                int val = i - 1;
                                field[val][pos] = true;
                                field[val][pos - 1] = true;
                                CheckInFull(ref val);
                                return;
                            }
                        }

                        field[5][pos] = true;
                        field[5][pos - 1] = true;
                    }

                    int end = 5;
                    CheckInFull(ref end);
                    break;
                }
                
                
                // 세로(2*1)
                case 3:
                {
                    blockCount += 2;
                    for (int i = 2; i < 6; i++)
                    {
                        var line = field[i];
                        if (line[pos])
                        {
                            field[i - 1][pos] = true;
                            field[i - 2][pos] = true;
                            int val = i - 1;
                            CheckInFull(ref val);
                            val--;
                            CheckInFull(ref val);
                            return;
                        }
                    }
                    
                    int end = 5;
                    field[5][pos] = true;
                    field[4][pos] = true;
                    CheckInFull(ref end);
                    end--;
                    CheckInFull(ref end);
                    break;
                }
            }
        }

        private void CheckInFull(ref int lineIndex)
        {
            if (lineIndex < 2)
            {
                int deleteBlocks = 0;
                for (int i = 0; i < 4; i++)
                {
                    if(field[5][i])
                        deleteBlocks++;
                }
                blockCount -= deleteBlocks;
                field.RemoveAt(5);
                field.Insert(0, new bool[4]);
                return;
            }
            
            bool check = true;
            for (int i = 0; i < 4; i++)
                check &= field[lineIndex][i];

            if (check)
            {
                field.RemoveAt(lineIndex);
                field.Insert(0, new bool[4]);
                lineIndex++;
                score++;
                blockCount -= 4;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        Field green = new Field();
        Field blue = new Field();
        
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            
            int blockType = int.Parse(input[0]);
            int x = int.Parse(input[1]);
            int y = int.Parse(input[2]);
            
            green.AddBlock(blockType, y);
            
            if (blockType == 2)
            {
                blue.AddBlock(3, 3-x,true);
            }
            else if (blockType == 3)
            {
                blue.AddBlock(2, 3-x,true);
            }
            else
            {
                blue.AddBlock(1, 3-x,true);
            }
        }
        
        int fullScore = green.score + blue.score;
        Console.WriteLine(fullScore);
        int fullBlocks = green.blockCount + blue.blockCount;
        Console.WriteLine(fullBlocks);
    }
}