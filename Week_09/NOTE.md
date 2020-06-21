# 第9周 学习笔记

## 1. 知识总结

### 1.1. 高级动态规划

#### 1.1.1. 常见dp题目和状态转移方程

##### 爬楼梯

递归公式
$$
f(0) = 0,
f(1) = 1,
f(n) = f(n-1) + f(n-2)
$$

##### 不同路径

递归公式：
$$
f(x,y) = f(x-1,y) + f(x,y-1)
$$

```
dp[i][j] 状态的定义

dp[i][j] = dp[i-1][j] + dp[j][i-1]
```



##### 打家劫舍

方案1：

   `dp[i]` 状态的定义：打劫 `0 -> i` 房子，最多可以得到多少钱

  `dp[i] = max(dp[i-2] + nums[i],dp[i-1])`

方案2：

  ```
dp[i][0] 状态定义：没偷 nums[i] 的情况下，打劫 0 -> i 房子，最多可以得到多少钱
dp[i][1] 状态定义：有偷 nums[i] 的情况下，打劫 0 -> i 房子，最多可以得到多少钱

dp[i][0] = max(dp[i-1][0],dp[i-1][1])
dp[i][1] = dp[i-1][0] + num[i]
  ```



##### 最小路径和

```
dp[i][j]状态的定义：minPath(A[1 - > i][1 - > j])

dp[i][j] = min(dp[i-1][j],dp[i][j-1]) + A[i][j]
```



##### 股票买卖

```
dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
              max(  选择 rest,         选择 sell            )
```

解析：今天我没有持有股票，有两种可能：

     - 我昨天就没有持有，然后今天选择 rest ，所以我今天还是没有持有
     - 我昨天持有股票，但是今天我 sell 了，所以我今天没有持有股票了

```
dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
              max( 选择 rest,       选择 buy)
```

解析：今天我持有股票，有两种可能：

- 我昨天就持有股票，然后今天选择 rest，所以我今天还是持有股票
- 我昨天没有持有，但今天我选择 buy ，所以今天我就持有股票了。

初始状态：
```
dp[-1][k][0] = dp[i][0][0] = 0
dp[-1][k][1] = dp[i][0][1] = -infinity
```

状态转移方程：

```
dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
```



#### 1.1.2. 高阶dp问题

##### 复杂度来源

1. 状态拥有更多维度（二维、三维、或者更多、甚至需要压缩）
2. 状态方程更加复杂



### 1.2. 字符串算法

#### 1.2.1. 字符串基础知识

immutable：java , python , C#

mutable: C++

##### 常用操作：

###### 遍历字符串：

Python:

```python
for ch in "abbc":
    print(ch)
```

Jave：

```java
String x ="abbc";
for(int i=0;i<x.size();i++){
    char ch=x.charAt(i);
}
for ch in x.toCharArray(){
    System.out.println(ch);
}
```

C++：

```C++
string x("abbc");
for(int i=0;i<s1.length();i++){
    cout<<x[i]
}
```

C#:

```C#
string x="abbc";
for(int i=0;i<x.Length;i++){
    char ch=x[i];
}

foreach(var ch in x.ToCharArray()){
    Console.WriteLine(ch);
}
```



###### 字符串比较

Java：

```java
String x="abb";
String y="abb";

x == y  ---> false  // 比较指针，而不是比较字符串的内容
    
x.equals(y)  ----> true  // 比较字符串的内容
x.equalsIgnoreCase(y) ---> true  // 忽略大小写，比较字符串的内容
```



#### 1.2.2. 高级字符串算法

动态规划 + 字符串

[1143. 最长子序列](https://leetcode-cn.com/problems/longest-common-subsequence/)

```
dp[i][j] = dp[i-1][j-1] + 1 (if s1[i-1] == s2[j-1])
else dp[i][j] = max(dp[i-1][j],dp[i][j-1])
```

最长子串

```
dp[i][j] = dp[i-1][j-1] + 1 (if s1[i-1] == s2[j-1])
else dp[i][j] = 0
```

[72. 编辑距离](https://leetcode-cn.com/problems/edit-distance/)

```
dp[i][j] 代表 word1 到 i 位置转换成 word2 到 j 位置需要最少步数

当 word1[i] == word2[j] , dp[i][j] == dp[i-1][j-1]
当 word1[i] != word2[j], dp[i][j] = min(dp[i-1][j-1], dp[i-1][j],dp[i][j-1])+1

其中， dp[i-1][j-1] 表示替换操作， dp[i-1][j] 表示删除操作，dp[i][j-1] 表示插入操作。
```



#### 1.2.3. 字符串匹配算法

##### 1.2.3.1. 暴力法（brute force）

时间复杂度：O(mn)

```java
public static int forceSearch(String txt, String pat) {
    int M = txt.length();
    int N = pat.length();
    for (int i = 0; i <= M - N; i++) {
        int j;
        for (j = 0; j < N; j++) {
            if (txt.charAt(i + j) != pat.charAt(j))
                break;
        }
        if (j == N) {
            return i;
        }
        // 更加聪明？ 
        // 1. 预先判断 hash(txt.substring(i, M)) == hash(pat)
        // 2. KMP 
    }
    return -1;
}
```



##### 1.2.3.2. Rabin-Karp 算法

算法思想：

1. 假设子串的长度为M(pat)，目标字符串的长度为 N(txt)
2. 计算子串的hash值 hash_pat
3. 计算目标字符串 txt 中每个长度为M的子串的 hash 值（共需要计算 N - M + 1 次）
4. 比较 hash 值：如果 hash 值不同，字符串必然不匹配；如果  hash 值相同，还需要使用朴素算法再次判断

```java
public final static int D = 256;
public final static int Q = 9997;
static int RabinKarpSerach(String txt, String pat) {
    int M = pat.length();
    int N = txt.length();
    int i, j;
    int patHash = 0, txtHash = 0;
    for (i = 0; i < M; i++) {
        patHash = (D * patHash + pat.charAt(i)) % Q;
        txtHash = (D * txtHash + txt.charAt(i)) % Q;
    }
    int highestPow = 1;  // pow(256, M-1)
    for (i = 0; i < M - 1; i++) 
        highestPow = (highestPow * D) % Q;
    for (i = 0; i <= N - M; i++) { // 枚举起点
        if (patHash == txtHash) {
            for (j = 0; j < M; j++) {
                if (txt.charAt(i + j) != pat.charAt(j))
                    break;
            }
            if (j == M)
                return i;
        }
        if (i < N - M) {
            txtHash = (D * (txtHash - txt.charAt(i) * highestPow) + txt.charAt(i + M)) % Q;
            if (txtHash < 0)
                txtHash += Q;
        }
    }
    return -1;
}
```



#####  1.2.3.3. KMP算法

http://www.ruanyifeng.com/blog/2013/05/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm.html

算法思想：

​       当子串与目标字符串不匹配时，其实你已经知道了前面已经匹配成功那一部分的字符（包括子串与目标字符串）。

​       设法利用这个已知信息，不要把“搜索位置”移回已经比较过的位置，继续吧它向后移，这样就是提高了效率。

##### 1.2.3.4. Boyer-Moore算法

https://www.ruanyifeng.com/blog/2013/05/boyer-moore_string_search_algorithm.html

##### 1.2.3.5. Sunday算法

https://blog.csdn.net/u012505432/article/details/52210975

## 2. 刷题小结

### [387. 字符串中的第一个唯一字符](https://leetcode-cn.com/problems/first-unique-character-in-a-string/)

```C#
public int FirstUniqChar(string s)
{
    int[] chars = new int[26];

    foreach(char c in s.ToCharArray())
    {
        chars[c-'a']++;
    }

    for(int i=0;i<s.Length;i++)
    {
        if (chars[s[i]-'a'] == 1)
            return i;
    }
    return -1;
}
```

### [151. 翻转字符串里的单词](https://leetcode-cn.com/problems/reverse-words-in-a-string/)

```c#
public string ReverseWords(string s)
{
    if (string.IsNullOrWhiteSpace(s)) return "";

    var arry = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);

    StringBuilder sb = new StringBuilder();

    for(int i=arry.Length-1;i>=0;i--)
    {
        sb.Append(arry[i]);

        if(i>0)
           sb.Append(" ");
    }

    return sb.ToString();
}
```

