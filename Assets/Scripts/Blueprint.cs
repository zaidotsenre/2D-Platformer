using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint
{
    public List<Cell> Cells { get { return cells; } }
    public int Width { get { return width; } }  
    public int Height { get { return height; } }

    List<Cell> cells = new List<Cell>();

    int width;
    int height;

    public Blueprint(int width, int height)
    {
        this.width = width;
        this.height = height;
        Initialize();
        Design();

    }

    // Creates grid and sets the index value of every cell
    void Initialize()
    {
        cells.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Cell cell = new Cell();
                cell.index = i * width + j;
                cells.Add(cell);
            }
            
        }
    }

    // Iterative implementation of randomized depth-first search
    void Design()
    {
        Stack<Cell> stack = new Stack<Cell>();
        Cell first = cells[Random.Range(0, cells.Count)];
        first.visited = true;
        stack.Push(first);
        while (stack.Count > 0)
        {
            Cell current = stack.Pop();
            List<Cell> unvisitedNeighbors = GetUnvisitedNeighbors(current);
            if (unvisitedNeighbors.Count > 0)
            {
                stack.Push(current);
                Cell chosen = unvisitedNeighbors.Random();
                RemoveWalls(current, chosen);
                chosen.visited = true;
                stack.Push(chosen);
            }
        }
    }

    // Sets the entry and exit of the maze
    void SetEntryAndExit()
    {
        List<Cell> edgeCells = GetEdgeCells();

        Cell cell = edgeCells.Random();
        cell.exit = true;
        RemoveEdgeWall(cell);
        edgeCells.Remove(cell);

        edgeCells.Random().entry = true;
    }

    // Removes walls between the two given cells
    void RemoveWalls(Cell current, Cell next)
    {
        int difference = current.index - next.index;

        if (difference == -width)
        {
            current.top = true;
            next.bottom = true;
        }
        else if (difference == -1)
        {
            current.right = true;
            next.left = true;
        }
        else if (difference == width)
        {
            current.bottom = true;
            next.top = true;
        }
        else if (difference == 1)
        {
            current.left = true;
            next.right = true;
        }
    }

    // Removes outer grid walls of the given cell
    void RemoveEdgeWall(Cell cell)
    {
        if (cell.index >= cells.Count - 1 - width)
            cell.top = true;
        else if (cell.index % width == 0)
            cell.left = true;
        else if (cell.index < width)
            cell.bottom = true;
        else if (cell.index % width == width - 1)
            cell.right = true;
    }

    // Returns all cells on the edges of the grid
    List<Cell> GetEdgeCells()
    {
        List<Cell> edgeCells = new List<Cell>();
        foreach (Cell cell in cells)
        {
            if (cell.index >= cells.Count - 1 - width)
                edgeCells.Add(cell);
            if (cell.index % width == 0)
                edgeCells.Add(cell);
            if (cell.index < width)
                edgeCells.Add(cell);
            if (cell.index % width == width - 1)
                edgeCells.Add(cell);
        }
        return edgeCells;
    }

    List<Cell> GetUnvisitedNeighbors(Cell cell)
    {
        List<Cell> neighbors = new List<Cell>();

        // Get all neighbours
        if (cell.index < cells.Count - 1 - width)
            neighbors.Add(cells[cell.index + width]);
        if (cell.index % width != 0)
            neighbors.Add(cells[cell.index - 1]);
        if (cell.index >= width)
            neighbors.Add(cells[cell.index - width]);
        if (cell.index % width != width - 1)
            neighbors.Add(cells[cell.index + 1]);

        // Remove visited neighbors
        neighbors.RemoveAll(x => x.visited);

        return neighbors;
    }

}
