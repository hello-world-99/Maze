
using System;
using System.Collections.Generic;
using UnityEngine;
public class generatorcell
{
    public int X;
    public int Y;
    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Visited=false;
    public int distance;
}
public class mazegenerator
{

    // Use this for initialization
    public int width = 25;
    public int height = 39;
    public generatorcell[,] generate()
    {
        generatorcell[,] maze = new generatorcell[width, height];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new generatorcell { X = x, Y = y };
            }
        }



        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, height - 1].WallLeft = false;
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[width-1,y].WallBottom = false;
        }












            remove(maze);
        MazeExit(maze);


        return maze;
    }

    private void MazeExit(generatorcell[,] maze)
    {
        generatorcell end = maze[0,0];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, height - 2].distance > end.distance) end = maze[x, height - 2];
            if (maze[x, 0].distance > end.distance) end = maze[x, 0];
        }
        for (int y = 0; y < maze.GetLength(0); y++)
        {
            if (maze[width-2, y].distance > end.distance) end = maze[width - 2, y];
            if (maze[0, y].distance > end.distance) end = maze[0, y];
        }
        if (end.X == 0) end.WallLeft = false;
        else if (end.Y == 0) end.WallBottom = false;
        else if (end.X == width-2) maze[end.X+1,end.Y].WallLeft = false;
        else if (end.Y == height-2) maze[end.X, end.Y+1].WallBottom = false;
    }

    private void remove(generatorcell[,] maze)
    {
        generatorcell current = maze[0, 0];
        current.Visited = true;
        current.distance = 0;

        Stack<generatorcell> stack = new  Stack<generatorcell>();
        do
        {
            List<generatorcell> unvisited = new List<generatorcell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisited.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y-1].Visited) unvisited.Add(maze[x, y-1]);
            if (x < width-2 && !maze[x + 1, y].Visited) unvisited.Add(maze[x + 1, y]);
            if (y < height-2 && !maze[x , y+1].Visited) unvisited.Add(maze[x , y+1]);
            if(unvisited.Count>0)
            {
                generatorcell chosen = unvisited[UnityEngine.Random.Range(0, unvisited.Count)];
                RemoveWall(current, chosen);




                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.distance = stack.Count;
                    
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);

    }

    private void RemoveWall(generatorcell a, generatorcell b)
    {
        if(a.X==b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }
}