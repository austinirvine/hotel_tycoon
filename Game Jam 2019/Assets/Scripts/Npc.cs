using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    float angerTimer;
    bool isAngry;
    public float maxAngerTime = 30.0f;
    CreateGrid gridRef;
    GameManager gameManager;

    float waitTimer = 0.0f;
    bool isWaiting;

    float serveTimer = 0.0f;
    bool isBeingServed;

    float curTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        angerTimer = 0.0f;
        gridRef = GameObject.Find("PathManager").GetComponent<CreateGrid>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        //find nearest reception and queue up

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingServed)
        {
            isAngry = false;
            curTimer -= Time.deltaTime;
            if(curTimer < 0)
            {
                //move to next task
            }
        }



        if (isAngry)
        {
            angerTimer += Time.deltaTime;

            if(angerTimer >= maxAngerTime)
            {
                isAngry = true;
                gameManager.decrement(20);
                //unoccupy hotel room
                GetComponent<NodeList>().travel(
                    gridRef.nodeGrid[0][0],
                    destroyMe
                );
            }
        }
    }

    void destroyMe()
    {
        Destroy(this);
    }
}
