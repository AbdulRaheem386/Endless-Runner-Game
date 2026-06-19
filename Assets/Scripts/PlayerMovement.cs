using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform Center_pos;
    [SerializeField] Transform Right_pos;
    [SerializeField] Transform Left_pos;


    int current_pos = 0;

    public float side_speed;
    public float running_speed;
    public float jump_speed;

    [SerializeField] Rigidbody rb;

    [SerializeField] Animator Player_Animator;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject Game_Main_Menu;
    [SerializeField] GameObject During_Game_Panel;

    //player speed increse
    float nextespeedincreaseZ = 500f;

    public bool IsGameStarted;
    bool IsGameOver;

    // Start is called before the first frame update
    void Start()
    {
        IsGameStarted = false;
        IsGameOver = false;
        current_pos = 0; // 0 = center , 1 = Right , 2 = Left

        During_Game_Panel.SetActive(false);

        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
       /* if (!IsGameStarted || !IsGameOver)
        {
            Play_Game();
           /* if (Input.GetMouseButtonDown(0))
            {
                 IsGameStarted = true;
                  Player_Animator.SetInteger("IsRunning", 1);
                  Tab_to_start.SetActive(false);
                  During_Game_Panel.SetActive(true);

                
            }
        }*/
        if (IsGameStarted)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + running_speed * Time.deltaTime);

            if (current_pos == 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 1;
                    Sound_Manager.instance.Playside();
                    
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 2;
                    Sound_Manager.instance.Playside();

                }
            }
            else if (current_pos == 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    current_pos = 0;
                    Sound_Manager.instance.Playside();

                }
            }
            else if (current_pos == 2)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current_pos = 0;
                    Sound_Manager.instance.Playside();

                }
            }

            float targetx = transform.position.x;

            if (current_pos == 0)
            {
                targetx = Center_pos.position.x;
            }
            else if (current_pos == 1)
            {
                targetx = Right_pos.position.x;
            }
            else if (current_pos == 2)
            {
                targetx = Left_pos.position.x;
            }

            Vector3 targetPos = new Vector3(targetx, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, side_speed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * jump_speed;
                Player_Animator.SetTrigger("IsJump");
                Sound_Manager.instance.Playjump();
            }

           // transform.Translate(Vector3.forward * running_speed * Time.deltaTime);

            if(transform.position.z >= nextespeedincreaseZ)
            {
                running_speed += 1f;
                nextespeedincreaseZ += 500f;
            } 
        }

        if (IsGameOver)
        {
            if (!GameOverPanel.gameObject.active)
            {
                GameOverPanel.SetActive(true);
                
            }
        }

        
    }

    public void ScenePause()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void MoveLeft()
    {
        if (current_pos == 0)
        {

            current_pos = 2;
            Sound_Manager.instance.Playside();
        }
        else if (current_pos == 1)
        {
            current_pos = 0;
            Sound_Manager.instance.Playside();
        }
    }

    public void MoveRight()
    {
        if (current_pos == 0)
        {
            current_pos = 1;
            Sound_Manager.instance.Playside();
        }
        else if (current_pos == 2)
        {
            current_pos = 0;
            Sound_Manager.instance.Playside();
        }
    }

    public void Jump()
    {
        rb.velocity = Vector3.up * jump_speed;
        Player_Animator.SetTrigger("IsJump");
        Sound_Manager.instance.Playjump();
    }

    public void StartGame()
    {
        IsGameStarted = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "object")
        {
            IsGameStarted = false;
            IsGameOver = true;
            Player_Animator.applyRootMotion = true;
            Player_Animator.SetTrigger("IsDied");
            Sound_Manager.instance.Playhit();

            StartCoroutine(GameOverDelay());
           
        }
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSecondsRealtime(1f);

        ScenePause();
    }

    //gamestart
    public void Play_Game()
    {
        IsGameStarted = true;
        IsGameOver = false;
        Time.timeScale = 1f;
        Player_Animator.SetInteger("IsRunning", 1);
        Game_Main_Menu.SetActive(false);
        During_Game_Panel.SetActive(true);
    }


}