# **To open the pathfinding asignment, open the "Pathfinding" folder in unity**
If youve followed Marcs loom on how to make a pathfinding visualisation in unity (and I know you have) you know how to run the path finding algorithm
Theyre named "multiplayer" and "random multiplayer" in the editor.




# **Asigment documentation**


## **The problem to be solved**
The problem that I have set out to solve is one which involves several different player characters on a grid.
These characters want to meet somewhere, in the most efficient manner (lowest cost) possible.

The most interesting part of this problem is that there is no defined goal at the start.
The pathfinding must be done without a predefined goal, instead the goal is decided *after* the pathing has finished.
The most efficient place to meet up cant be decided until it is known how difficult it is for each player to navigate to different grid spots.

Some squares on the grid can be completely inaccessible, while others have an above average cost for traversal.
This needs to be taken into consideration when acessing the most efficent place to meet up at.

## **Real world applications**
A real life application could be for an RPG game with a grid system where you want characters to meet up for a cuscene or the like.
Or perhaps if you have several NPCs who are supposed to travel around the gameworld in a group, that have become scattered for some reason and need to meet up again.


## **Potential approaches**

The easiest solution would be to simply set an abitrary location to meet up (presumably in the middle of the map) and have each player path there with any functional pathfinding algorithm.
The obvious problem here would be that the selected goal would very rarely be the most efficient place to meet up, so the failure rate would be very high.
Upsides would be a potentially low usage of computer resources.

Thus this approach can be considered to be equal to NoSort or BogoPath.

### **Knowing where to meet up**
To make an actual effort to find the most efficent node to meet up on the cost to travel to a node needs to be saved, once for each player.
We can then add the cost of each player traveling to the node together to the get total value of how expensive it would be to have every player travel there.
If we compare this total cost values of different nodes we can find the node with the lowest total cost. This will be the node we want everyone to travel to.


One possible approach would be to have an A* like algorithm, that searches out another player as a goal.
Each player would do this once per other player.
This would lead to poor scaling in situations with many players.
This problem could be mitigated by not reevaluating paths between pair of players that have already been calculated (but in reverse) by another player.
But this would increase code complexity and would not solve the problem entirely.

Another problem that might arrise is that the algorithm will never find the node that is actually the most efficent meeting spot. 
This is because the algorithm simpy tries to travel between each player as efficently as possible, so many nodes will never be visited and evaluated.
This problem will get worse the larger and more complex (lots of winding paths and warrying node costs) the map is.

### **The chosen solution**
The solution I decided to go with is an algorithm that visits every node for each player.
While this can get computationally expensive on large maps, it does scale linearly whith the number of players.
This makes it an efficent algorithm for cramped maps with many players.

It is also guaranteed to always find the ideal meetup point in every situation that has a solution (eg none of the players are trapped or in an inaccessibe location).
Since paths are saved in such a way that nodes simply remember which previous node was the most efficent way to reach it the most efficent path to every node on the map is stored in an efficent and easily accesible way.
This also means that the pathfinding algorithm does not need to know which node is the most efficient to meet up at, it simply stores the most efficent path to all nodes.

One downside of the current structure is that the cost of traveling to a node for a certain player is stored in the node itself and not in the player.
This makes the node dependant on players and vice versa in a way that is unecessary and should be avoided. But in its current state the program works and Im lazy, so hey ho.






