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

### [64. 最小路径和](https://leetcode-cn.com/problems/minimum-path-sum/)

方法1：暴力解法

​     对每一个节点，都考虑向右和向下两个路径，选择权重小的那个

时间复杂度：O(2 ^ n+m)

空间复杂度：O(n+m)

直接超时了

```C#
public int MinPathSum(int[][] grid)
{
    return Calculate(grid, 0, 0);
}

private int Calculate(int[][] grid,int i,int j)
{
    if (i == grid.Length || j == grid[0].Length)
        return int.MaxValue;

    if (i == grid.Length - 1 && j == grid[0].Length - 1)
        return grid[i][j];

    return grid[i][j] + Math.Min(Calculate(grid, i + 1, j), Calculate(grid, i, j + 1));
}
```

方法 2：动态规划

状态表示：用一个二维数组 `dp` , `dp[i,j]`表示从坐标 `(i,j)` 到右下角的最小路径权值

状态转移：

​      ` dp(i,j)  = grid(i,j) + min(dp(i+1,j),dp(i,j+1))`

确定边界：`dp[grid.Length-1,grid[0].Length - 1] = grid[grid.Length-1][grid[0].Length - 1]`

​      dp 矩阵 右下角的那个格子的值就是 grid 右下角的那个值

时间复杂度：O(nm)

空间复杂度：O(nm)

```C#
public int MinPathSum(int[][] grid)
{
    int lastRowIndex = grid.Length-1;
    int lastColIndex = grid[0].Length-1;

    int[,] dp = new int[lastRowIndex+1, lastColIndex+1];

    for(int i = lastRowIndex; i >= 0; i--)
    {
        for(int j = lastColIndex; j >= 0; j--)
        {
            if (i == lastRowIndex && j != lastColIndex)
                dp[i, j] = grid[i][j] + dp[i, j + 1];
            else if (i != lastRowIndex && j == lastColIndex)
                dp[i, j] = grid[i][j] + dp[i + 1, j];
            else if (i != lastRowIndex && j != lastColIndex)
                dp[i, j] = grid[i][j] + Math.Min(dp[i + 1, j], dp[i, j + 1]);
            else
                dp[i, j] = grid[i][j];
        }
    }
    return dp[0, 0];
}
```

方法 3：动态规划优化

不创建dp数组，直接在grid数组中进行修改，节省空间

时间复杂度：O(nm)

空间复杂度：O(1)

```c#
public int MinPathSum(int[][] grid)
{
    int lastRowIndex = grid.Length - 1;
    int lastColIndex = grid[0].Length - 1;

    for(int i = lastRowIndex; i >= 0; i--)
    {
        for(int j = lastColIndex; j >= 0; j--)
        {
            if (i == lastRowIndex && j != lastColIndex)
                grid[i][j] = grid[i][j] + grid[i][j + 1];
            else if(i!=lastRowIndex && j==lastColIndex)
                grid[i][j] = grid[i][j] + grid[i+1][j];
            else if(i!= lastRowIndex && j!=lastColIndex)
                grid[i][j] = grid[i][j] + Math.Min(grid[i][j + 1],grid[i + 1][j]);  
        }
    }
    return grid[0][0];
}
```

### [91.解码方法](https://leetcode-cn.com/problems/decode-ways)

方法1：暴力解法（递归）

   如果当前数字是0，那么返回0

  如果当前数字 + 后一个数字组合 <= 26：

​                 Recursion(currentIndex + 1) + Recursion(currentIndex + 2)

如果当前数字 + 后一个数字组合 > 26

​                Recursion(currentIndex + 1) 

时间复杂度：O(n ^ 2)

空间复杂度：O(n)

```C#
public int NumDecodings(string s)
{
    if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;

    int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

    return Recursion(nums, 0);            
}

private int Recursion(int[] nums,int currentIndex)
{
    if (nums[currentIndex] == 0)
        return 0;

    if (currentIndex == nums.Length - 1)
    {
        // 最后一个字母
        return 1;
    }            

    int nextSum = Recursion(nums, currentIndex + 1);
    int current = 0;

    if (currentIndex < nums.Length - 1)
    {
        if (nums[currentIndex] * 10 + nums[currentIndex + 1] <= 26)
        {
            if (currentIndex < nums.Length - 2)
                current = Recursion(nums, currentIndex + 2);
            else
                current = 1;
        }
    }
    return current + nextSum;
}
```

方法2：动态规划

状态表示：一维数组表示 dp[i] 表示从第i个元素到第n个元素的所有方案数

状态转移：

```
    nums[i] = 0 , dp[i] = 0

    nums[i] * 10 + nums[i-1] <=26

                       dp[i] = dp[i+1] + dp[i+2]
                             > 26
                       dp[i] = dp[i+1]
```

边界条件：

​    最后一个数字是0时，dp[length - 1]  =0，否则等于1

时间复杂度：O(n)

空间复杂度：O(n)

```C#
public int NumDecodings(string s)
{
    if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;

    int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

    int lastIndex = nums.Length - 1;
    int[] dp = new int[nums.Length];

    if (nums[lastIndex] == 0)
        dp[lastIndex] = 0;
    else
        dp[lastIndex] = 1;

    for (int i = lastIndex - 1; i >= 0; i--)
    {
        if (nums[i] == 0)
        {
            dp[i] =0;
            continue;
        }

        if (nums[i] * 10 + nums[i + 1] <= 26)
        {
            if (i < lastIndex - 1)
                dp[i] = dp[i + 1] + dp[i + 2];
            else
                dp[i] = 1 + dp[i + 1];
        }
        else
            dp[i] = dp[i + 1];
    }
    return dp[0];
}
```

方法 3：动态规划优化

​    用两个变量记录 dp[i+1] 和 dp[i+2]的值

时间复杂度：O(n)

空间复杂度：O(n)

```C#
public int NumDecodings(string s)
{
    if (string.IsNullOrWhiteSpace(s) || s.StartsWith("0")) return 0;
    
    int[] nums = s.ToCharArray().Select(c => c - '0').ToArray();

    int lastIndex = nums.Length - 1;
    int temp = 1;
    int result = 0;


    if (nums[lastIndex] > 0)
        result = 1;

    for (int i = lastIndex - 1; i >= 0; i--)
    {
        if (nums[i] == 0)
        {
            temp = result;
            result = 0;
            continue;
        }

        if (nums[i] * 10 + nums[i + 1] <= 26)
        {
            result += temp;
            temp = result - temp;
        }
        else
            temp = result;
    }
    return result;
}
```

