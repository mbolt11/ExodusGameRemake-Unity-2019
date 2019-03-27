using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirt : MonoBehaviour
{
    private int life = 2;
    private BoardState board;

    private void Start()
    {
        board = BoardState.getBoard();
    }

    public void BlueDirtHit()
    {
        life--;
        if(life <= 0)
        {
            if (gameObject.GetComponent<HidingTreasure>().showTreasure())
            {
                Destroy(gameObject);
            }
            else
            {
                Vector2 boardLocation = board.findBoardLocation(transform);
                Destroy(gameObject);
                board.updateBoard(boardLocation, 0);
            }
        }
    }
}
