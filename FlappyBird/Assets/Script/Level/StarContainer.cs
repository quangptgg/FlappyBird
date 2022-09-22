using System.Collections.Generic;
using UnityEngine;

public class StarContainer : MonoBehaviour
{
    [SerializeField] private GameObject starGameObject;
    private readonly List<GameObject> starList = new List<GameObject>();
    private readonly float[] starPositions = {-4.0f, 0.0f, 6.0f};
    private const int numberOfStar = 3;

    void Start()
    {
        for (int idx = 0; idx < numberOfStar; idx++)
        {
            Vector3 positionToSpawn = new Vector3(starPositions[idx], Random.Range(-3, 3), 0.0f);
            GameObject gameObject =  Instantiate(starGameObject, positionToSpawn, Quaternion.identity, transform);
            starList.Add(gameObject);
        }
    }

    public void ResetStars()
    {
        foreach(GameObject star in starList)
        {
            star.SetActive(true);
        }
    }
}
