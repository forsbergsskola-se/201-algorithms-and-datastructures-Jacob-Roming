using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private List<State> playerStartPositions;
    public State goal;
    public event Action<State> stateChanged;
    public event Action<State, int> MultiplayerStateChanged;
    public event Action<State, State, State, State> InitPlayerPositions;
    private Grid grid = null;

    private bool multiplayer = false;

    public State Player1Start
    {
        get
        {
            return playerStartPositions[0];
        }
        set
        {
            playerStartPositions[0] = value;
            if (multiplayer == false)
            {
                stateChanged?.Invoke(value);
            }
        }
    }

    [ContextMenu("Find Goal")]
    public void FindGoal()
    {
        var path = BreadthFirstSearch(playerStartPositions[0], goal);
        StartCoroutine(co_playPath(path));
    }

    [ContextMenu("Dijkstra")]
    public void RunDijktra()
    {
        var path = Dijkstra(playerStartPositions[0], goal);
        StartCoroutine(co_playPath(path));
        multiplayer = false;
    }

    [ContextMenu("Random multiplayer")]
    public void MultiplayerRandom()
    {
        List<State> startPositions = new List<State>();
        Random rand = new Random();
        startPositions.AddRange(playerStartPositions.ToArray());
        for (int i = 0; i < 4; i++)
        {
            State position = startPositions[i];
            position.playerPosition.x = rand.Next(0, 10);
            position.playerPosition.y = rand.Next(0, 10);
            startPositions[i] = position;
        }
        Debug.Log("Start positions is " + startPositions.Count + " long");
        MultiplayerBaseFunction(startPositions);
    }
    
    [ContextMenu("Multiplayer")]
    public void RunDijktraMultiplayer()
    {
        List<State> startPositions = new List<State>();
        startPositions.AddRange(playerStartPositions.ToArray());
        MultiplayerBaseFunction(startPositions);
       
    }

    private void MultiplayerBaseFunction(List<State> startPositions)
    {
         multiplayer = true;
        List<Dictionary<State, State>> playerPaths = new List<Dictionary<State, State>>();
        InitPlayerPositions.Invoke(startPositions[0],startPositions[1],startPositions[2],startPositions[3]);

        for (int i = 0; i < 4; i++)
        {
            playerPaths.Add(DijkstraMultiplayer(startPositions[i], goal,i));
        }
        /*playerPaths = new List<Dictionary<State, State>>();
        for (int i = 0; i < 4; i++)
        {
            playerPaths.Add(DijkstraMultiplayer(startPositions[i], goal,i));
        }*/
        //Time to calculate the node with the lowest total cost!
        //Grid grid = null;
        if (grid == null)
        {
            foreach (var VARIABLE in playerPaths[0])
            {
                grid = VARIABLE.Key.Grid;
            }
        }

        int cellWithLowestTotalCost = -1;
        float lowestCost = float.MaxValue;
        for (int i = 0; i < grid!.Cells.Length; i++)
        {
            if (grid.Cells[i].costPerPlayer[0] + grid.Cells[i].costPerPlayer[1] + grid.Cells[i].costPerPlayer[2] + grid.Cells[i].costPerPlayer[3] < lowestCost)
            {
                cellWithLowestTotalCost = i;
                lowestCost = grid.Cells[i].costPerPlayer[0] + grid.Cells[i].costPerPlayer[1] + grid.Cells[i].costPerPlayer[2] + grid.Cells[i].costPerPlayer[3];
            }
        }
        Debug.Log("The cell with the lowest cost was: " + cellWithLowestTotalCost);
        //ok now we need to convert this int into a state......
        State goalNode = grid.Cells[cellWithLowestTotalCost].thisCellsState;//this is ugly but it works



        List<List<State>> Paths = new List<List<State>>();
        for (int i = 0; i < 4; i++)
        {
            Paths.Add(new List<State>());
        }
        
        State checkingNode;
        for (int i = 0; i < 4; i++)
        {
            checkingNode = goalNode;
            while (checkingNode.Equals(startPositions[i]) == false)
            {
                //This is where we are building the paths for the players
                Debug.Log("This is the current goal: " + goalNode.playerPosition.x + "," + goalNode.playerPosition.x);
                Paths[i].Add(checkingNode);
                checkingNode = playerPaths[i][checkingNode];
            }

            Paths[i].Reverse();
            StartCoroutine(co_playPathForPlayer(Paths[i], i));
        }
        grid.ResetCost();
       
    }
    
    IEnumerator co_playPath(IEnumerable<State> path)
    {
        foreach (var state in path)
        {
            yield return new WaitForSeconds(0.5f);
            Player1Start = state;
            
        }
    }
    IEnumerator co_playPathForPlayer(IEnumerable<State> path, int player)
    {
        State PlayerCharacter;
        switch (player)
        {
            case 0:
            default:
                PlayerCharacter = playerStartPositions[0];
                break;
            case 1:
                PlayerCharacter = playerStartPositions[1];
                break;
            case 2: PlayerCharacter = playerStartPositions[2];
                break;
            case 3:
                PlayerCharacter = playerStartPositions[3];
                break;
                
        }
        foreach (var state in path)
        {
            yield return new WaitForSeconds(0.5f);
            //PlayerCharacter = state;
            MultiplayerStateChanged(state, player);
        }
    }


    public IEnumerable<State> BreadthFirstSearch(State start, State end)
    {
        Dictionary<State, State> predecessor = new Dictionary<State, State>();

        Queue<State> nodesToCheck = new Queue<State>();
        nodesToCheck.Enqueue(start);


        while (nodesToCheck.Count != 0)
        {
            State currentNode = nodesToCheck.Peek();

            foreach (var node in currentNode.GetSuccessors())
            {
                Cell cell = node.Grid.GetCell(node.playerPosition);
                if (cell.visited)
                {
                    continue;
                }
                predecessor.Add(node,currentNode);
                if (node.Equals(end))
                {
                    List<State> path = new List<State>();
                    State checkingNode = node;
                    while (checkingNode.Equals(start) == false)
                    {
                        
                        path.Add(checkingNode);
                        checkingNode = predecessor[checkingNode];
                        
                    }

                    path.Reverse();
                    return path;
                }

                //visitedNodes.Add(node);
                cell.visited = true;
                nodesToCheck.Enqueue(node);
            }

            nodesToCheck.Dequeue();
        }

        return null;
    }
    public IEnumerable<State> Dijkstra(State start, State end)
    {
        Dictionary<State, State> predecessor = new Dictionary<State, State>();
        Dictionary<State, float> costs = new Dictionary<State, float>();
        int numberOfLoops = 0;
        Queue<State> nodesToCheck = new Queue<State>();
        nodesToCheck.Enqueue(start);
        costs.Add(start,0);
        bool foundGoal = false;
        State goal = start; //This is bad, should be changed

        while (nodesToCheck.Count != 0 && numberOfLoops < 100)
        {
            State currentNode = nodesToCheck.Peek();
            currentNode.Grid.GetCell(currentNode.playerPosition).currentCost = costs[currentNode]; //??? is this correct?
            
            foreach (var node in currentNode.GetSuccessors())
            {
                Cell cell = node.Grid.GetCell(node.playerPosition);
                
                Debug.Log("The cells currentCost is: " + cell.currentCost);
                if (costs[currentNode] + cell.cost < cell.currentCost)
                {
                    nodesToCheck.Enqueue(node);
                    cell.currentCost = costs[currentNode] + cell.cost;
                    if (costs.ContainsKey(node))
                    {
                        costs[node] = costs[currentNode] + cell.cost;
                    }
                    else
                    {
                        costs.Add(node, costs[currentNode] + cell.cost);
                    }

                    if (predecessor.ContainsKey(node))
                    {
                        predecessor[node] = currentNode;
                    }
                    else
                    {
                        predecessor.Add(node, currentNode);
                    }

                    if (node.Equals(end))
                    {
                        foundGoal = true;
                        goal = node;
                    }
                }
                cell.visited = true;
                
                
            }

            numberOfLoops++;
            nodesToCheck.Dequeue();
        }
        if (foundGoal)
        {
            Debug.Log("We got there");
            List<State> path = new List<State>();
            State checkingNode = goal;

                    
            while (checkingNode.Equals(start) == false)
            {
                path.Add(checkingNode);
                checkingNode = predecessor[checkingNode];
            }
            path.Reverse();
            return path;
        }

        return null;
    }
    
    public Dictionary<State,State> DijkstraMultiplayer(State start, State end, int playerNumber)
    {
        Dictionary<State, State> predecessor = new Dictionary<State, State>();
        Dictionary<State, float> costs = new Dictionary<State, float>();
        Queue<State> nodesToCheck = new Queue<State>();
        nodesToCheck.Enqueue(start);
        costs.Add(start,0);
        
        while (nodesToCheck.Count != 0)
        {
            State currentNode = nodesToCheck.Peek();
            currentNode.Grid.GetCell(currentNode.playerPosition).currentCost = costs[currentNode];
            
            foreach (var node in currentNode.GetSuccessors())
            {
                Cell cell = node.Grid.GetCell(node.playerPosition);
                cell.thisCellsState = node;
                if (costs[currentNode] + cell.cost < cell.costPerPlayer[playerNumber])
                {
                    nodesToCheck.Enqueue(node);
                    cell.costPerPlayer[playerNumber] = costs[currentNode] + cell.cost;
                    if (costs.ContainsKey(node))
                    {
                        costs[node] = costs[currentNode] + cell.cost;
                    }
                    else
                    {
                        costs.Add(node, costs[currentNode] + cell.cost);
                    }

                    if (predecessor.ContainsKey(node))
                    {
                        predecessor[node] = currentNode;
                    }
                    else
                    {
                        predecessor.Add(node, currentNode);
                    }
                }

                cell.visited = true;

            }
            nodesToCheck.Dequeue();
        }
        return predecessor;//when we run this a second time for a player not all positions are found...
    }
}
