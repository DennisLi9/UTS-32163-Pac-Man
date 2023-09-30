using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject outsideCornerPrefab;
    public GameObject outsideWallPrefab;
    public GameObject insideCornerPrefab;
    public GameObject insideWallPrefab;
    public GameObject standardPelletPrefab;
    public GameObject powerPelletPrefab;
    public GameObject tJunctionPrefab;
    public GameObject emptyPrefab;
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };
    
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                GameObject prefabToInstantiate = emptyPrefab; // Default to empty
                switch (levelMap[i, j])
                {
                    case 0:
                        // Leave as empty or you could instantiate a floor tile or something else if needed
                        break;
                    case 1:
                        prefabToInstantiate = outsideCornerPrefab;
                        break;
                    case 2:
                        prefabToInstantiate = outsideWallPrefab;
                        break;
                    case 3:
                        prefabToInstantiate = insideCornerPrefab;
                        break;
                    case 4:
                        prefabToInstantiate = insideWallPrefab;
                        break;
                    case 5:
                        prefabToInstantiate = standardPelletPrefab;
                        break;
                    case 6:
                        prefabToInstantiate = powerPelletPrefab;
                        break;
                    case 7:
                        prefabToInstantiate = tJunctionPrefab;
                        break;
                }

                // Instantiate the selected prefab at the appropriate grid position
                // Adjust the position calculation as needed for your game's scale
                Vector3 position = new Vector3(j, -i, 0);
                Instantiate(prefabToInstantiate, position, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
