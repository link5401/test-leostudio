#include <iostream>
#include <vector>
#include <bits/stdc++.h>

/*
Bài 2: Kích thước mảng con dài nhất:
Cho trước 1 mảng array kiểu int[], lấy ra các phần tử từ mảng array tạo ra mảng
con thỏa mãn: Giá trị tuyệt đối của hiệu 2 phần tử bất kỳ trong mảng đều nhỏ hơn
hoặc bằng 1 Trong số tất cả các mảng con thỏa mãn hãy in ra kích thước mảng con
có độ dài lớn nhất

*/
//Approach 1: We can sort it first and then brute force the solutions but that would slow down the algorithm and make it not fun => O(nlogn) + O(n^2)

//Approach 2: Brute force it anyways, find the appropriate values corespoding the current index and then count them => O(n^2)
//Approach 3: Map all the possible pairs and their frequency, return the highest frequency pair => O(n) + O(m) => this would be O(n).


/*
suppose n is the number of elements in the array, m is the number of different values in the array
Time complexity : O(n) + O(m) => O(n)
Space complexity: O(m) as we assign a hash map.
We will traverse the array and checks for each elemnt 2 related pairs {i, i+1} and {i-1, i}. Because i is always in 1 of two pair, we increase the frequency of both pair by 1.
If we meets i+1 in the future iterations, it would increase {(i+1)-1, i+1} hence increases {i,i+1}.
After obtaining a hash map of pairs and frequency, we simply traverse the hash map to find the highest frequency and return them

*/
int LargestSubsetLength(std::vector<int>& arr) {
    std::map<std::pair<int, int>,int> map;
    //counting different pairs 
    for(auto i : arr){
        map[{i,i+1}]++;
        map[{i-1,i}]++;
    }
    //finding the highest frequency pair
    int highest = 0;
    for(auto i : map){
        if (i.second >= highest) highest = i.second;
    }
    return highest;

}

int main() {
    std::vector<int> input{1, 1, 4, 4,4, 2, 2, 5, 5, 5, 3};
    std::cout << LargestSubsetLength(input);
}
