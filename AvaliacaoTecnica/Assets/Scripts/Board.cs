using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{

    bool empty;
    public bool endgame;
    public bool draw;

    [SerializeField]
    public GameObject[] board;

    void Start()
    {
        draw = false;
    }
    public void InitializeBoard()
    {
        board = new GameObject[9];

        board[0] = GameObject.Find("Plane1");
        board[1] = GameObject.Find("Plane2");
        board[2] = GameObject.Find("Plane3");
        board[3] = GameObject.Find("Plane4");
        board[4] = GameObject.Find("Plane5");
        board[5] = GameObject.Find("Plane6");
        board[6] = GameObject.Find("Plane7");
        board[7] = GameObject.Find("Plane8");
        board[8] = GameObject.Find("Plane9");
        
    }

	public bool  ValidateMoves()
    {
        endgame = false;

        //HORIZONTAL
        if (board[0].transform.childCount == 1  && board[1].transform.childCount == 1 && board[2].transform.childCount == 1)
            if (board[0].transform.GetChild(0).name == board[1].transform.GetChild(0).name && board[2].transform.GetChild(0).name == board[1].transform.GetChild(0).name) {
                endgame = true;
            }
        if (board[3].transform.childCount == 1 && board[4].transform.childCount == 1 && board[5].transform.childCount == 1)
            if (board[3].transform.GetChild(0).name == board[4].transform.GetChild(0).name &&
                board[4].transform.GetChild(0).name == board[5].transform.GetChild(0).name)
            {
                endgame = true;
            }
        if (board[6].transform.childCount == 1 && board[7].transform.childCount == 1 && board[8].transform.childCount == 1)
            if (board[6].transform.GetChild(0).name == board[7].transform.GetChild(0).name &&
                board[7].transform.GetChild(0).name == board[8].transform.GetChild(0).name)
            {
                endgame = true;
            }

        ////VERTICAL
         if (board[0].transform.childCount == 1  && board[3].transform.childCount == 1 && board[6].transform.childCount == 1)
        if (board[0].transform.GetChild(0).name == board[3].transform.GetChild(0).name &&
            board[3].transform.GetChild(0).name == board[6].transform.GetChild(0).name)
        {
            endgame = true;
        }
        if (board[1].transform.childCount == 1 && board[5].transform.childCount == 1 && board[7].transform.childCount == 1)
            if (board[1].transform.GetChild(0).name == board[5].transform.GetChild(0).name &&
                board[5].transform.GetChild(0).name == board[7].transform.GetChild(0).name)
            {
                endgame = true;
            }
        if (board[2].transform.childCount == 1 && board[6].transform.childCount == 1 && board[8].transform.childCount == 1)
            if (board[2].transform.GetChild(0).name == board[6].transform.GetChild(0).name &&
                board[6].transform.GetChild(0).name == board[8].transform.GetChild(0).name)
            {
                endgame = true;
            }
        //DIAGONAL
        if (board[0].transform.childCount == 1 && board[4].transform.childCount == 1 && board[8].transform.childCount == 1)
            if (board[0].transform.GetChild(0).name == board[4].transform.GetChild(0).name &&
                board[4].transform.GetChild(0).name == board[8].transform.GetChild(0).name)
            {
                endgame = true;
            }


        //Draw();

        return endgame;
    }

    //Not finished
    //public void Draw()
    //{
    //    if (endgame) {
    //        for (int i = 0; i < board.Length; i++) {
    //            if (board[i].transform.childCount == 1) {
    //                draw = true;
    //            }
    //            else draw = false;

    //        }
    //    }
    //}
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    //run array  detach children and eliminate gameobjects
    //public void Restart2()
    //{
    //    for (int i = 0; i < board.Length; i++) {
    //        board[i].transform.DetachChildren();
    //        Debug.Log(board[i].transform.name + board[i].transform.childCount);
    //    }
    //}
}
