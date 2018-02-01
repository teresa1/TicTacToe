using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region privateVars

    #region GameObjects

    private GameObject O;

    private GameObject X;

    private GameObject marker;

    private GameObject grid;

    private GameObject _oponentMarker;

    private GameObject cell;

    private GameObject RestartCube;


    #endregion

    private GameStatus gameStatus;

    private int maxRayDistance = 25;
    private int random1;

    private Text questionText;
    private RaycastHit hit;

    string firstPlay;
    string oponentMarker;
    string hitname;

    bool canPlay;

    private Player player;
    private Board board;
    #endregion


    void Start ()
    {

        player = new Player();
        board = new Board();

        gameStatus = GameStatus.Choosing;
        questionText = GameObject.Find("questionText").GetComponent<Text>();

        EventManager.instanciateGrid += InstanciateGrid;

        EventManager.instanciateMarker += InstanciateMarker;

        firstPlay = "X";

        O = GameObject.Find("O");
        X = GameObject.Find("X");


        RestartCube = GameObject.Find("RestartCube");
    }
	
	void Update ()
    {
        
        
        switch (gameStatus)
        {
            case GameStatus.Choosing:
                Choosing();
                break;
            case GameStatus.Playing:
                Playing();
                break;
            case GameStatus.Restart:
                Restart();
                break;
            default:
                break;
        }

    }

    void Raycast()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        //RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance)) {
            
            hitname = hit.transform.name;

            Debug.Log(hitname);
        }
        
    }
    
    void Choosing()
    {
       if (Input.GetMouseButton(0))
        {
            Raycast();

            if (hitname != null)
            {
                player.playerMarker = hitname;
               

                Destroy(X);
                Destroy(O);

                InstanciateGrid();

                board.InitializeBoard();


                if (player.playerMarker == "X")
                {
                    oponentMarker = "O";
                    player.firstPlay = true;
                    player.turn = true;
                }

                else {
                    oponentMarker = "X";
                    player.firstPlay = false;
                    player.turn = false;
                }



                gameStatus = GameStatus.Playing;

                Debug.Log(hitname);
            }
        }
    }
    

    void Playing()
    {

        if (player.turn)
        {
            questionText.text = "It's your turn";
            if (Input.GetMouseButtonDown(0))
            {
                
                {
                    GameObject Cell;
                    Raycast();
                    if (hit.collider != null)
                    {
                        Debug.Log("Encontrei collider");
                        Cell = GameObject.Find(hitname);
                        if(hitname == "RestartCube")
                        {
                           Restart();
                        }
                        if (Cell.transform.childCount == 0) {
                            InstanciateMarker();

                            marker.transform.position = GameObject.Find(hitname).transform.position;
                            marker.transform.parent = GameObject.Find(hitname).transform;
                           
                            player.turn = false;

                        }

                        board.ValidateMoves();
                        CPUPPlay();
                        board.ValidateMoves();

                        if (board.endgame) {
                            questionText.text = "Game Over";
                            gameStatus = GameStatus.Restart;
                        }

                        Debug.Log("end game?" + board.endgame);
                    }
                   

                   
                }

               
                
            }
            

        }else CPUPPlay();

    }

   

    
    void InstanciateGrid()
    {
        grid = Instantiate(Resources.Load("Prefabs/Grid", typeof(GameObject))) as GameObject;
        
    }

    void InstanciateMarker()
    {
        marker = new GameObject();
        marker = Instantiate(Resources.Load("Prefabs/" + player.playerMarker, typeof(GameObject))) as GameObject;
        
       
    }
       
       

    void CPUPPlay()
    {
        //Add wait time
        questionText.text = "It's CPUs turn";
        canPlay = false;

        do {
            random1 = Random.Range(0, 9);

            if (board.board[random1].transform.childCount == 0)
            {
                canPlay = true;
                cell = GameObject.Find(board.board[random1].name);
                break;
            }
           

        } while (canPlay == false);

        _oponentMarker = new GameObject();

       _oponentMarker = Instantiate(Resources.Load("Prefabs/" + oponentMarker, typeof(GameObject))) as GameObject;

        //saveguard if marker is null
        if (_oponentMarker != null) {
            _oponentMarker.transform.position = cell.transform.position;
            _oponentMarker.transform.parent = cell.transform;
        }


        player.turn = true;
    }

    void Restart()
    {
        board.Restart();
        gameStatus = GameStatus.Playing;
    }

    enum GameStatus
    {
       Choosing,
       Playing,
       Restart
    }

  
}
