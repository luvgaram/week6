using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w6_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;
            int col = 0;
            int row = 0;
            int moveTo = 5;
            int[,] maze = new int[,] // 미로를 만듭니다
            {
                {1,2,3,4,5,6},
                {7,8,9,10,11,12},
                {13,14,15,16,17,18},
                {19,20,21,22,23,24},
                {25,26,27,28,29,30}
            };

            const int cnt = 6;
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt - 1; j++)
                {
                    Console.SetCursorPosition(i * 2,j);
                    Console.Write(maze[j,i]);
                }
            }
            // 미로를 그립니다

            int[,,] route = new int[,,] // 좌, 하, 우, 상으로 갈 수 있는지 0, 1, 2, 3에 표시하고 4에는 이동한 곳, 5에는 왔는지를 표시합니다
            {
                {{1, 2, 0, 0, 0, 0}, {1, 2, 0, 0, 2, 0}, {1, 2, 0, 0, 3, 0}, {1, 2, 0, 0, 4, 0}, {1, 2, 0, 0, 5, 0}, {0, 2, 0, 0, 6, 0}},
                {{1, 2, 0, 0, 7, 0}, {1, 2, 3, 4, 8, 0}, {1, 2, 3, 4, 9, 0}, {1, 2, 3, 4, 10, 0}, {1, 2, 3, 4, 11, 0}, {0, 2, 3, 0, 12, 0},},
                {{1, 2, 0, 0, 13, 0}, {1, 2, 3, 4, 14, 0}, {1, 2, 3, 4, 15, 0}, {1, 2, 3, 4, 16, 0}, {1, 2, 3, 4, 17, 0}, {0, 2, 3, 0, 18, 0},},
                {{1, 2, 0, 0, 19, 0}, {1, 2, 3, 4, 20, 0}, {1, 2, 3, 4, 21, 0}, {1, 2, 3, 4, 22, 0}, {1, 2, 3, 4, 23, 0}, {0, 2, 3, 0, 24, 0},},
                {{1, 0, 0, 0, 25, 0}, {1, 0, 0, 4, 26, 0}, {1, 0, 0, 4, 27, 0}, {1, 0, 0, 4, 28, 0}, {1, 0, 0, 4, 29, 0}, {0, 0, 0, 0, 30, 0},}
            };

            int[, ,] routeOriginal = new int[,,]
            {
                {{1, 2, 0, 0, 0, 0}, {1, 2, 0, 0, 2, 0}, {1, 2, 0, 0, 3, 0}, {1, 2, 0, 0, 4, 0}, {1, 2, 0, 0, 5, 0}, {0, 2, 0, 0, 6, 0}},
                {{1, 2, 0, 0, 7, 0}, {1, 2, 3, 4, 8, 0}, {1, 2, 3, 4, 9, 0}, {1, 2, 3, 4, 10, 0}, {1, 2, 3, 4, 11, 0}, {0, 2, 3, 0, 12, 0},},
                {{1, 2, 0, 0, 13, 0}, {1, 2, 3, 4, 14, 0}, {1, 2, 3, 4, 15, 0}, {1, 2, 3, 4, 16, 0}, {1, 2, 3, 4, 17, 0}, {0, 2, 3, 0, 18, 0},},
                {{1, 2, 0, 0, 19, 0}, {1, 2, 3, 4, 20, 0}, {1, 2, 3, 4, 21, 0}, {1, 2, 3, 4, 22, 0}, {1, 2, 3, 4, 23, 0}, {0, 2, 3, 0, 24, 0},},
                {{1, 0, 0, 0, 25, 0}, {1, 0, 0, 4, 26, 0}, {1, 0, 0, 4, 27, 0}, {1, 0, 0, 4, 28, 0}, {1, 0, 0, 4, 29, 0}, {0, 0, 0, 0, 30, 0},}
            };

            Stack<int> stackCol = new Stack<int>();
            Stack<int> stackRow = new Stack<int>();

            stackCol.Push(col);
            stackRow.Push(row); // stack 구조를 col, row로 만들고 0 값을 넣습니다

            Stack<int> stackNum = new Stack<int>(); // 숫자를 보관합니다


            while (maze[col, row] != 30 || sum < 435) // 도착 위치에 다다를 때까지 이동합니다
            {
                Move(ref col, ref row, ref sum, maze, route, routeOriginal, ref stackCol, ref stackRow, ref stackNum, ref moveTo);
                   
                Console.WriteLine();
            }


            Console.ReadLine();
        }

        static void Direction(ref int moveTo)
        {
            Random random = new Random();
            Thread.Sleep(5);
            moveTo = random.Next(1, 5);
        }

        static int Move(ref int col, ref int row, ref int sum, int[,] maze, int[,,] route, int[,,] routeOriginal, ref Stack<int> stackCol, ref Stack<int> stackRow, ref Stack<int> stackNum, ref int moveTo)
        {
            if ((route[col, row, 0] == 0 || (row < 5 && route[col, row + 1, 4] == 0)) && ((route[col, row, 1] == 0) || (col < 4 && route[col + 1, row, 4] == 0) && ((route[col, row, 2] == 0) || (row > 0 && route[col, row - 1, 4] == 0)) && ((route[col, row, 3] == 0) || (col > 0 && route[col - 1, row, 4] == 0))))// 갈 곳이 없을 때
            {
                if (maze[col, row] == 30 && sum > 434) // 현재 위치가 30이고 모든 수에 들렀다면(전체 수를 더한 값이 435라면)
                {
                    return maze[col, row];
                } else{
                    Eraze(col, row, ref maze);
                    for (int i = 0; i < 5; i++) // 30이 아니거나 모든 수에 들르지 않았다면 이전 표시를 원복합니다
                    {
                        route[col, row, i] = routeOriginal[col, row, i];
                    }
                    col = stackCol.Pop();
                    row = stackRow.Pop(); // 이전 위치로 돌아갑니다
                    sum = sum - stackNum.Pop(); // 전체 수에서 해당 값을 뺍니다 
                    Print(col, row, ref moveTo);
                    switch (route[col, row, 5]) // 돌아간 후 해당 방향으로 이동할 수 없음을 표시합니다
                    {
                        case 1: 
                            route[col, row, 0] = 0;
                            break;
                        case 2: 
                            route[col, row, 1] = 0;
                            break;
                        case 3: 
                            route[col, row, 2] = 0;
                            break;
                        case 4: 
                            route[col, row, 3] = 0;
                            break;
                    }

                    return maze[col, row];
                }
            }
            else
            {
                Direction(ref moveTo);
                switch(moveTo) // moveTo 값으로 검사합니다
                {
                    case 1:
                        if (route[col, row, 0] == 1 && route[col, row + 1, 4] != 0)
                        {
                            stackCol.Push(col);
                            stackRow.Push(row); // 현재 위치를 stack 에 넣습니다
                            stackNum.Push(maze[col, row]); // 숫자를 stack 에 넣습니다
                            route[col, row, 4] = 0; // 들른 곳임을 기록합니다
                            route[col, row, 0] = 0; // 이동 방향을 막습니다
                            route[col, row, 5] = 1; // 이동 방향을 기록합니다
                            sum = sum + maze[col, row];
                            Print(col, row, ref moveTo);
                            row = row + 1; // 오른쪽으로 이동합니다
                            //route[col, row, 2] = 0; // 온 방향을 막습니다 
                            break;
                        }
                        break;
                    case 2:
                        if (route[col, row, 1] == 2 && route[col + 1, row, 4] != 0)
                        {
                            stackCol.Push(col);
                            stackRow.Push(row); // 현재 위치를 stack 에 넣습니다
                            stackNum.Push(maze[col, row]); // 숫자를 stack 에 넣습니다
                            route[col, row, 4] = 0; // 들른 곳임을 기록합니다
                            route[col, row, 1] = 0; // 이동 방향을 막습니다
                            route[col, row, 5] = 2; // 이동 방향을 기록합니다
                            sum = sum + maze[col, row];
                            Print(col, row, ref moveTo);
                            col = col + 1; // 아래쪽으로 이동합니다
                            //route[col, row, 3] = 0; // 온 방향을 막습니다 
                            break;
                        }
                        break;
                    case 3:
                        if (route[col, row, 2] == 3 && route[col, row - 1, 4] != 0)
                        {
                            stackCol.Push(col);
                            stackRow.Push(row); // 현재 위치를 stack 에 넣습니다
                            stackNum.Push(maze[col, row]); // 숫자를 stack 에 넣습니다
                            route[col, row, 4] = 0; // 들른 곳임을 기록합니다
                            route[col, row, 2] = 0; // 이동 방향을 막습니다
                            route[col, row, 5] = 3; // 이동 방향을 기록합니다
                            sum = sum + maze[col, row];
                            Print(col, row, ref moveTo);
                            row = row - 1; // 왼쪽으로 이동합니다
                            //route[col, row, 0] = 0; // 온 방향을 막습니다 
                            break;
                        }
                        break;
                    case 4:
                        if (route[col, row, 3] == 4 && route[col - 1 , row, 4] != 0)
                        {
                            stackCol.Push(col);
                            stackRow.Push(row); // 현재 위치를 stack 에 넣습니다
                            stackNum.Push(maze[col, row]); // 숫자를 stack 에 넣습니다
                            route[col, row, 4] = 0; // 들른 곳임을 기록합니다
                            route[col, row, 3] = 0; // 이동 방향을 막습니다
                            route[col, row, 5] = 4; // 이동 방향을 기록합니다
                            sum = sum + maze[col, row];
                            Print(col, row, ref moveTo);
                            col = col - 1; // 윗쪽으로 이동합니다
                            //route[col, row, 1] = 0; // 온 방향을 막습니다 
                            break;
                        }
                        break;
                }
                return maze[col, row];
            } 
        }
        static void Print(int col, int row, ref int moveTo) //이동 경로를 그립니다
        {
            Console.SetCursorPosition(row * 2, col);
            switch(moveTo) // moveTo 값으로 검사합니다
            {
                case 1:
                    Console.Write("▷");
                    break;
                case 2:
                    Console.Write("▽");
                    break;
                case 3:
                    Console.Write("◁");
                    break;
                case 4:
                    Console.Write("△");
                    break;
            }
            
        }
        static void Eraze(int col, int row, ref int[,]maze) //이전 경로를 지웁니다
        {
            Console.SetCursorPosition(row * 2, col);
            Console.Write(maze[col,row]);
        }
    }
}
