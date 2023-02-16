using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameView : MonoBehaviour
{
   public Game game;
   public GameObject playerOne;
   public GameObject playerTwo;
   public GameObject playerThree;
   public GameObject playerFour;
   [SerializeField] private CellView tilePrefab;
   private List<CellView> tiles = new List<CellView>();

   private void Start()
   {
      game.stateChanged += GameOnStateChanged;
      GameOnStateChanged(game.Player1Start);
      game.MultiplayerStateChanged += MultiplayerGameStateChanged;
      game.InitPlayerPositions += InitializePlayerPositions;
   }

   public void InitializePlayerPositions(State p1, State p2, State p3, State p4)
   {
      playerOne.transform.position = new Vector3(p1.playerPosition.x, p1.playerPosition.y, 0);
      playerTwo.transform.position = new Vector3(p2.playerPosition.x, p2.playerPosition.y, 0);
      playerThree.transform.position = new Vector3(p3.playerPosition.x, p3.playerPosition.y, 0);
      playerFour.transform.position = new Vector3(p4.playerPosition.x, p4.playerPosition.y, 0);
   }

   private void GameOnStateChanged(State state)
   {
      playerOne.transform.position = new Vector3(state.playerPosition.x, state.playerPosition.y,0);
      

      
      foreach (var tile in tiles)
      {
         Destroy(tile.gameObject);
         
      }
      tiles.Clear();
      
      for(int x = 0; x < state.Grid.width; x++)
      {
         for (int y = 0; y < state.Grid.Height; y++)
         {
            var tile = Instantiate(tilePrefab, new Vector3(x,y,0.2f), Quaternion.identity);
            tile.SetCell(state.Grid.GetCell(x,y));
            tiles.Add(tile);
         }
      }
   }

   private void MultiplayerGameStateChanged(State state, int playerNumber)
   {
      //Honestly this switch statement is pretty smart, I shouldve thought of this from the beginning
      GameObject player;
      switch(playerNumber)
      {
         case 0:
         default:
            player = playerOne;
            break;
         case 1:
            player = playerTwo;
            break;
         case 2:
            player = playerThree;
            break;
         case 3:
            player = playerFour;
            break;
      }
      
      foreach (var tile in tiles)
      {
         Destroy(tile.gameObject);
         
      }
      tiles.Clear();
      
      
      for(int x = 0; x < state.Grid.width; x++)
      {
         for (int y = 0; y < state.Grid.Height; y++)
         {
            var tile = Instantiate(tilePrefab, new Vector3(x,y,0.2f), Quaternion.identity);
            tile.SetCell(state.Grid.GetCell(x,y));
            tiles.Add(tile);
         }
      }

      player.transform.position = new Vector3(state.playerPosition.x, state.playerPosition.y, 0);

   }

}
