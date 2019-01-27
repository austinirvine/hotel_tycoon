using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public int xSize = 10;
    public int zSize = 10;

    public Transform nodePrefab;
    public List<List<Transform>> nodeGrid = new List<List<Transform>>();

    private void Awake()
    {
        initGrid(); //creates grid list
    }

    // Start is called before the first frame update
    void Start()
    {

        initPossiblePaths(); //sets connections
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initGrid()
    {
        for (int i = 0; i < xSize; i++)
        {
            List<Transform> nodeGridRow = new List<Transform>();
            for (int j = 0; j < zSize; j++)
            {
                Transform newNode = Instantiate(nodePrefab, new Vector3((i * 10)  +5, 0, (j * 10) + 5), Quaternion.identity).transform;
                nodeGridRow.Add(newNode);
            }
            nodeGrid.Add(nodeGridRow);
        }
    } 

    void initPossiblePaths()
    {
        for (int i = 0; i < xSize; i++) //sets border possible paths, outside is null
        {
            for (int j = 0; j < zSize; j++)
            {
                if (i > 0)
                {
                    nodeGrid[i][j].GetComponent<Node>().possiblePaths[3] = nodeGrid[i - 1][j];
                }

                if (i < xSize - 1)
                {
                    nodeGrid[i][j].GetComponent<Node>().possiblePaths[1] = nodeGrid[i + 1][j];
                }

                if (j > 0)
                {
                    nodeGrid[i][j].GetComponent<Node>().possiblePaths[0] = nodeGrid[i][j - 1];
                }

                if (j < zSize - 1)
                {
                    nodeGrid[i][j].GetComponent<Node>().possiblePaths[2] = nodeGrid[i][j + 1];
                }
            }
        }
    }
}
