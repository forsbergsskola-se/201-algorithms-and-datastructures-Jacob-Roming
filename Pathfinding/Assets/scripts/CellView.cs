using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class CellView : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Material green;
    public Material white;
    public Material black;
    public Material brick;

    public void SetCell(Cell cell)
    {
        TextMeshProUGUI text = this.GetComponentInChildren<TextMeshProUGUI>();
        text.text = cell.cost.ToString();
        if (cell.visited)
        {
            GetComponent<Renderer>().material = brick;
            //sprite.color = Color.green;
            return;
        }
        
        if (cell.walkable)
        {
            GetComponent<Renderer>().material = brick;
            //sprite.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material = black;
            //sprite.color = Color.black;
        }
    }
}
