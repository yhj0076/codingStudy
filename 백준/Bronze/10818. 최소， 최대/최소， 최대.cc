#include <iostream>

int main()
{
	int* arr;
	int count = 0;
	int Max = -1000000;
	int Min = 1000000;
	std::cin >> count;	//배열의 크기를 입력 받음.

	arr = (int*)malloc(sizeof(int) * count);
	
	for (int i = 0; i < count; i++)
	{
		std::cin >> arr[i];
	}

	for (int i = 0; i < count; i++)
	{
		if (Max < arr[i])
		{
			Max = arr[i];
		}
	}

	for (int i = 0; i < count; i++)
	{
		if (Min > arr[i])
		{
			Min = arr[i];
		}
	}
	std::cout << Min <<" "<<Max<< std::endl;


	free(arr);
	return 0;
}