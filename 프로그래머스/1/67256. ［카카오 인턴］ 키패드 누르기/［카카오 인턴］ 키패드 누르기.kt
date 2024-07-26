class Solution {
    fun solution(numbers: IntArray, HandType: String): String {
    
    var HandPos_L:Array<Int> = arrayOf(0,3)
    var HandPos_R:Array<Int> = arrayOf(2,3)
    var targetKeypad:Array<Int> = arrayOf(0,0)

    var distance_L = 0
    var distance_R = 0
    val LR_List:Array<String> = Array(numbers.size,{""})


    for(i in 0 until numbers.size)
    {
        when(numbers[i])
        {
            1 -> {
                LR_List[i] = "L"
                HandPos_L = arrayOf(0,0)
            }
            4 -> {
                LR_List[i] = "L"
                HandPos_L = arrayOf(0,1)
            }
            7 -> {
                LR_List[i] = "L"
                HandPos_L = arrayOf(0,2)
            }
            3 -> {
                LR_List[i] = "R"
                HandPos_R = arrayOf(2,0)
            }
            6 -> {
                LR_List[i] = "R"
                HandPos_R = arrayOf(2,1)
            }
            9 -> {
                LR_List[i] = "R"
                HandPos_R = arrayOf(2,2)
            }
            2 -> {
                targetKeypad = arrayOf(1,0)
                distance_L = Math.abs(targetKeypad[0]-HandPos_L[0])+Math.abs(targetKeypad[1]-HandPos_L[1])
                distance_R = Math.abs(targetKeypad[0]-HandPos_R[0])+Math.abs(targetKeypad[1]-HandPos_R[1])
                if(distance_L>distance_R)
                {
                    LR_List[i] = "R"
                    HandPos_R = arrayOf(1,0)
                }
                else if(distance_L<distance_R)
                {
                    LR_List[i] = "L"
                    HandPos_L = arrayOf(1,0)
                }
                else
                {
                    when(HandType)
                    {
                        "right" -> {
                            LR_List[i] = "R"
                            HandPos_R = arrayOf(1,0)
                        }
                        "left" -> {
                            LR_List[i] = "L"
                            HandPos_L = arrayOf(1,0)
                        }
                    }
                }
            }
            5 -> {
                targetKeypad = arrayOf(1,1)
                distance_L = Math.abs(targetKeypad[0]-HandPos_L[0])+Math.abs(targetKeypad[1]-HandPos_L[1])
                distance_R = Math.abs(targetKeypad[0]-HandPos_R[0])+Math.abs(targetKeypad[1]-HandPos_R[1])
                if(distance_L>distance_R)
                {
                    LR_List[i] = "R"
                    HandPos_R = arrayOf(1,1)
                }
                else if(distance_L<distance_R)
                {
                    LR_List[i] = "L"
                    HandPos_L = arrayOf(1,1)
                }
                else
                {
                    when(HandType)
                    {
                        "right" -> {
                            LR_List[i] = "R"
                            HandPos_R = arrayOf(1,1)
                        }
                        "left" -> {
                            LR_List[i] = "L"
                            HandPos_L = arrayOf(1,1)
                        }
                    }
                }
            }
            8 -> {
                targetKeypad = arrayOf(1,2)
                distance_L = Math.abs(targetKeypad[0]-HandPos_L[0])+Math.abs(targetKeypad[1]-HandPos_L[1])
                distance_R = Math.abs(targetKeypad[0]-HandPos_R[0])+Math.abs(targetKeypad[1]-HandPos_R[1])
                if(distance_L>distance_R)
                {
                    LR_List[i] = "R"
                    HandPos_R = arrayOf(1,2)
                }
                else if(distance_L<distance_R)
                {
                    LR_List[i] = "L"
                    HandPos_L = arrayOf(1,2)
                }
                else
                {
                    when(HandType)
                    {
                        "right" -> {
                            LR_List[i] = "R"
                            HandPos_R = arrayOf(1,2)
                        }
                        "left" -> {
                            LR_List[i] = "L"
                            HandPos_L = arrayOf(1,2)
                        }
                    }
                }
            }
            0 -> {
                targetKeypad = arrayOf(1,3)
                distance_L = Math.abs(targetKeypad[0]-HandPos_L[0])+Math.abs(targetKeypad[1]-HandPos_L[1])
                distance_R = Math.abs(targetKeypad[0]-HandPos_R[0])+Math.abs(targetKeypad[1]-HandPos_R[1])
                if(distance_L>distance_R)
                {
                    LR_List[i] = "R"
                    HandPos_R = arrayOf(1,3)
                }
                else if(distance_L<distance_R)
                {
                    LR_List[i] = "L"
                    HandPos_L = arrayOf(1,3)
                }
                else
                {
                    when(HandType)
                    {
                        "right" -> {
                            LR_List[i] = "R"
                            HandPos_R = arrayOf(1,3)
                        }
                        "left" -> {
                            LR_List[i] = "L"
                            HandPos_L = arrayOf(1,3)
                        }
                    }
                }
            }
            else -> LR_List[i] = "0"
        }
    }
        var answer = ""
        for(i in 0 until LR_List.size)
        {
            answer = answer.plus(LR_List[i])
        }
        return answer
    }
}