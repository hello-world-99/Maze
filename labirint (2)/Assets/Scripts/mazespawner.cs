
using UnityEngine;

public class mazespawner : MonoBehaviour {

    public GameObject CellConstruct;
	// Use this for initialization
	private void Start ()
    {
        mazegenerator generator = new mazegenerator();
        generatorcell[,] maze = generator.generate();
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
              cell c=  Instantiate(CellConstruct, new Vector2(x-12,y-19),Quaternion.identity).GetComponent<cell>();

                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);
            }
        }
    }

}
