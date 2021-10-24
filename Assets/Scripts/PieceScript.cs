using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public ParticleSystem DestructionEffect;
    static Camera cam;
    static public BoardScript bs;
    bool isDragging = false;

    static bool endGame = false;
    Vector2 prevPos;

    static Vector2[] vector2Sym = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    public AudioClip[] glassBreaking;

    bool IsThereViableMove(GameObject ball)
    {
        foreach (Vector2 dir in vector2Sym)
        {
            Vector2 posSym = 2 * new Vector2(dir.x, -dir.y) + (Vector2)ball.transform.localPosition;
            Vector2 jumpedOver = new Vector2(dir.x, -dir.y) + (Vector2)ball.transform.localPosition;

            if (IsWithinBoard(posSym) && !WorldToGetBoard(posSym) && WorldToGetBoard(jumpedOver))
            {
                return false;
            }
        }
        return true;
    }


    private void Start()
    {
        cam = Camera.main;
        prevPos = transform.localPosition;
        BoardScript.ball_object_board[(int)prevPos.x + 3, (int)prevPos.y + 3] = gameObject;
        endGame = false;
    }

    void OnMouseDown()
    {
        if (!endGame)
        {
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        Vector2 pos = new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y));
        Vector2 dist = (prevPos - pos) / 2;

        Vector2 jumpOverPos = dist + pos;


        if ((dist == Vector2.up || dist == Vector2.down || dist == Vector2.left || dist == Vector2.right) && IsWithinBoard(pos) && !WorldToGetBoard(pos) && WorldToGetBoard(jumpOverPos))
        {

            SetBallBoardPosition(prevPos, null);
            SetBallBoardPosition(pos, gameObject);
            transform.localPosition = prevPos = pos;

            GameObject jumpedOver = WorldToGetBallBoard(jumpOverPos);
            SetBallBoardPosition(jumpOverPos, null);

            jumpedOver.GetComponent<Animator>().SetTrigger("ShowCracks");
            jumpedOver.GetComponent<Collider2D>().enabled = false;
            BoardScript.ass.PlayOneShot(glassBreaking[0]);

            NullBallBoardPosition(jumpOverPos);

            bool gameOver = true;
            int leftBallCounter = 0;
            foreach (GameObject ball in BoardScript.ball_object_board)
            {
                if (ball != null && ball != BoardScript.plh)
                {
                    leftBallCounter++;
                    gameOver = IsThereViableMove(ball);
                    if (!gameOver)
                    {
                        break;
                    }
                }

            }

            if (gameOver)
            {
                endGame = true;
                if (PlayerPrefs.GetInt("HighScore", 0) < leftBallCounter)
                {
                    PlayerPrefs.SetInt("HighScore", leftBallCounter);
                }

                if (PlayerPrefs.GetInt("LowScore", 50) > leftBallCounter)
                {
                    PlayerPrefs.SetInt("LowScore", leftBallCounter);
                }

                if (leftBallCounter == 1 && BoardScript.ball_object_board[3, 3] != null)
                {
                    bs.TrueGameEnd();
                }
                else
                {
                    bs.GameEnd();
                }
            }

        }
        else
        {
            transform.localPosition = prevPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.Translate(cam.ScreenToWorldPoint(Input.mousePosition) - transform.position + Vector3.forward);
        }
    }

    void Explode()
    {
        ParticleSystem explosionEffect = Instantiate(DestructionEffect).GetComponent<ParticleSystem>();

        explosionEffect.transform.position = gameObject.transform.position + Vector3.back;
        //play it
        explosionEffect.Play();
        Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
        Destroy(gameObject);

        BoardScript.ass.PlayOneShot(glassBreaking[Random.Range(1, 3)]);


        bs.UpdateScore();

    }
    bool WorldToGetBoard(Vector2 pos) { return (bool)BoardScript.ball_object_board[(int)pos.x + 3, (int)pos.y + 3]; }
    GameObject WorldToGetBallBoard(Vector2 pos) { return BoardScript.ball_object_board[(int)pos.x + 3, (int)pos.y + 3]; }
    void NullBallBoardPosition(Vector2 pos) { BoardScript.ball_object_board[(int)pos.x + 3, (int)pos.y + 3] = null; }
    bool IsWithinBoard(Vector2 pos) { return pos.x * pos.x <= 9 && pos.y * pos.y <= 9; }
    void SetBallBoardPosition(Vector2 pos, GameObject go) { BoardScript.ball_object_board[(int)pos.x + 3, (int)pos.y + 3] = go; }
}
