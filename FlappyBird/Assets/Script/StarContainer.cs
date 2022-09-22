using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContainer : MonoBehaviour
{
    [SerializeField] private GameObject starGameObject;
    private List<GameObject> starList = new List<GameObject>();
    private float[] starPositions = {-4.0f, 0.0f, 6.0f};
    private const int numberOfStar = 3;

    // Start is called before the first frame update
    void Start()
    {
        for (int idx = 0; idx < numberOfStar; idx++)
        {
            Vector3 positionToSpawn = new Vector3(starPositions[idx], Random.Range(-3, 3), 0.0f);
            GameObject star =  Instantiate(starGameObject, positionToSpawn, Quaternion.identity, transform);
            starList.Add(star);
        }
    }

    public void ResetStars()
    {
        foreach(GameObject star  in starList)
        {
            star.SetActive(true);
        }
    }
}
