#include <cmath>
#include <iostream>
#include <vector>
/*
Cho trước 1 mảng array kiểu int[] và 1 biến offset kiểu int. Hãy xây dựng hàm dịch chuyển thứ tự mảng array theo quy tắc sau: 
Nếu offset > 0 thì dịch chuyển mảng sang phải.
Nếu offset < 0 thì dịch chuyển mảng sang trái.
Ví dụ:
offset = -3;
array = [1,2,3,4,5]
Kết quả trả về: [4,5,1,2,3]

*/

//solutions
//Time complexity O(n) => n is offset as we only traverse an offset number of times.
//Space complexity O(1) => we dont use any extra memory, not even for output
std::vector<int> moveArrayByOffset(std::vector<int>& arr, int offset) {
    //if offset < 0, append the first elemnent to the array and the pop the first elemnt
    if (offset < 0) {
        for (int i = 0; i < abs(offset); i++) {
            arr.push_back(arr.front());
            arr.erase(arr.begin());
        }
    }
    //if offset > 0, insert the last element into the start of the array, then erase it 
    else if (offset > 0) {
        for (int i = 0; i < abs(offset); i++) {
            arr.insert(arr.begin(),arr.back());
            arr.pop_back();
        }
    }
    // return arr, if offset == 0, return the same thing
    return arr;
}

int main() {
    std::vector<int> input{1, 2, 3, 4, 5};
    for (auto i : moveArrayByOffset(input, -3)) {
        std::cout << i << " ";
    }
}