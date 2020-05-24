# 第6周 学习笔记

## 1. 知识总结

### 1.1. 动态规划

主要解决递归与分治的问题

把一个复杂的问题分解成简单的子问题

分治+最优子结构



动态规划和递归或者分治没有根本上的区别（关键看有没有最优的子结构）

共性：找到重复子问题

差异性：最优子结构、中途可以淘汰次优解



关键点：

   1. 最优子结构 `opt[n] = best_of(opt[n-1],opt[n-2], ...)`

   2. 存储中间状态：`opt[i]`

   3. 递推公式（美其名曰：状态转移方程或者DP方程）

      `Fib:opt[i] = opt[n-1] + opt[n-2] `

      二维路径：`opt[i,j] = opt[i+1][j] + opt[i][j+1]` (且判断`a[i,j]`是否空地)

**小结：**

1. 打破自己的思维惯性，形成机器思想
2. 理解复杂逻辑的关键
3. 也是职业进阶的要点要领


### 1.2. 例题解析

#### 1.2.1. Fibonacci数列

方法1：递归

时间复杂度：O(2^n)

```c#
private int fib(int n)
{
    if (n <= 0)
        return 0;
    else if (n == 1)
        return 1;
    else
        return fib(n - 1) + fib(n - 2);
}
```



方法2：记忆化搜索

时间复杂度：O(n)

```c#
private int fib(int n,int[] memo)
{
    if (n <= 1)
        return n;           
      
            
     if(memo[n-1] == 0)
     {
         memo[n-1] = fib(n - 1,memo) + fib(n - 2,memo);
     }

    return memo[n-1];
}
```

方法3：自低向上

时间复杂度：O(n)

```c#
private int fib(int n)
{
    if (n <= 1)
        return n;

     int[] a = new int[n+1];
     a[0] = 0;
     a[1]=1;

     for(int i = 2; i <= n; ++i)
     {
         a[i] = a[i - 1] + a[i - 2];
     }

    return a[n];
}
```



#### 1.2.2. 路径计数 

1. 不考虑有障碍物的情况

   ```c#
   public int UniquePaths(int m, int n)
   {
       int[,] dp = new int[m, n];
       for (int i = 0; i < n; i++) dp[0, i] = 1;
       for (int i = 0; i < m; i++) dp[i, 0] = 1;
       for (int i = 1; i < m; i++)
       {
           for (int j = 1; j < n; j++)
           {
               dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
           }
       }
       return dp[m - 1, n - 1];
   }
   ```

   优化：

   ```c#
   public int UniquePaths(int m, int n)
   {
       int[] cur = new int[n];
       Array.Fill(cur, 1);
       for (int i = 1; i < m; i++)
       {
           for (int j = 1; j < n; j++)
               cur[j] += cur[j - 1];
       }
   
       return cur[n - 1];
   }
   ```

   

2. 考虑有障碍物的情况

   ```c#
   public int UniquePathsWithObstacles(int[][] obstacleGrid)
   {
       int width = obstacleGrid[0].Length;
       int[] dp = new int[width];
       dp[0]= 1;
       foreach(int[] row in obstacleGrid)
       {
           for(int j = 0; j < width; j++)
           {
               if (row[j] == 1)
                   dp[j] = 0;
               else if (j > 0)
                   dp[j] += dp[j - 1];
           }
       }
       return dp[width - 1];
   }
   ```

   

#### 1.2.3. 最长公共子序列

将两个字符串转换成一个二维数组进行dp

```c#
public int LongestCommonSubsequence(string text1, string text2)
{
    if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
        return 0;

     int m = text1.Length;
     int n = text2.Length;

     int[,] dp = new int[m, n];

     for(int i=1;i<m;i++)
         for(int j = 1; j < n; j++)
         {
             if (text1[i - 1] == text2[j - 1])
                 dp[i, j] = 1 + dp[i - 1, j - 1];
             else
                 dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
         }

    return dp[m - 1, n - 1];           
}
```



#### 1.2.4. [爬楼梯](https://leetcode-cn.com/problems/climbing-stairs/description/)

DP方程：

   ` F(n) = F(n-1) + F(n-2)`



思考：

    1. 如果可以走 1步、2步、3步的情况
       2. 相邻两部的步伐不能相同的情况



// to do

#### 1.2.5. [三角形最小路径和](https://leetcode-cn.com/problems/triangle/)

思路：

    1. 递归
       2. dp



## 2. 刷题小结