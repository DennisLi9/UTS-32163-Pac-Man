using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
	public GameObject emptyPrefab;
    public GameObject outsideCornerPrefabR;
	public GameObject outsideCornerPrefabU;
	public GameObject outsideCornerPrefabL;
	public GameObject outsideCornerPrefabD;
    public GameObject outsideWallPrefabH;
	public GameObject outsideWallPrefabS;
    public GameObject insideCornerPrefabR;
	public GameObject insideCornerPrefabU;
	public GameObject insideCornerPrefabL;
	public GameObject insideCornerPrefabD;
    public GameObject insideWallPrefabS;
	public GameObject insideWallPrefabH;
    public GameObject standardPelletPrefab;
    public GameObject powerPelletPrefab;
    public GameObject tJunctionPrefab;
    int[,] levelMap =
    {
        {1,5,5,5,5,5,5,5,5,5,5,5,5,15},
        {6,13,13,13,13,13,13,13,13,13,13,13,13,11},
        {6,13,7,12,12,10,13,7,12,12,12,10,13,11},
        {6,14,11,0,0,11,13,11,0,0,0,11,13,11},
        {6,13,8,12,12,9,13,8,12,12,12,9,13,8},
        {6,13,13,13,13,13,13,13,13,13,13,13,13,13},
        {6,13,7,12,12,10,13,7,10,13,7,12,12,12},
        {6,13,8,12,12,9,13,11,11,13,8,12,12,10},
        {6,13,13,13,13,13,13,11,11,13,13,13,13,11},
        {2,5,5,5,5,4,13,11,8,12,12,10,0,11},
        {0,0,0,0,0,6,13,11,7,12,12,9,0,8},
        {0,0,0,0,0,6,13,11,11,0,0,0,0,0},
        {0,0,0,0,0,3,13,11,11,0,7,12,12,0},
        {5,5,5,5,5,3,13,8,9,0,11,0,0,0},
        {0,0,0,0,0,0,13,0,0,0,11,0,0,0},
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
                // Adjust these values to fit the size of your sprites
                float xScaleFactor = 0.15f; 
                float yScaleFactor = 0.15f;
                
                GameObject prefabToInstantiate = emptyPrefab; // Default to empty
                switch (levelMap[i, j])
                {
                    case 0:
                        // Leave as empty or you could instantiate a floor tile or something else if needed
                        break;
                    case 1:
                        prefabToInstantiate = outsideCornerPrefabR;
                        break;
                    case 2:
                        prefabToInstantiate = outsideCornerPrefabU;
                        break;
                    case 3:
                        prefabToInstantiate = outsideCornerPrefabL;
                        break;
                    case 4:
                        prefabToInstantiate = outsideCornerPrefabD;
                        break;
                    case 5:
                        prefabToInstantiate = outsideWallPrefabH;
                        break;
                    case 6:
                        prefabToInstantiate = outsideWallPrefabS;
                        break;
                    case 7:
                        prefabToInstantiate = insideCornerPrefabR;
                        break;
					case 8:
						prefabToInstantiate = insideCornerPrefabU;
                        break;
					case 9:
						prefabToInstantiate = insideCornerPrefabL;
                        break;
					case 10:
                        prefabToInstantiate = insideCornerPrefabD;
                        break;
                    case 11:
                        prefabToInstantiate = insideWallPrefabS;
                        break;
					case 12:
						prefabToInstantiate = insideWallPrefabH;
                        break;
					case 13:
						prefabToInstantiate = standardPelletPrefab;
                        break;
					case 14:
						prefabToInstantiate = powerPelletPrefab;
                        break;
					case 15:
						prefabToInstantiate = tJunctionPrefab;
                        break;
                }
                
                // Instantiate the selected prefab at the appropriate grid position
                // Adjust the position calculation as needed for your game's scale
                Vector3 position = new Vector3(j * xScaleFactor, -i * yScaleFactor, 0); 
                Instantiate(prefabToInstantiate, position, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
