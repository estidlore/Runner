using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleCreation : MonoBehaviour {
    public GameObject obstaclePrefab, obstacle_Height, obstacle_Width;
    public Transform ground;
    // Space between obstacles
    public float offset;
    GameObject[] obstaclePrefabs;
    Random random;
    LinkedList<GameObject> obstacles;
    // Obstacles' position respect the ground
    float limitZ;
    void Start() {
        // Prefabs of the obstacles variants
        obstaclePrefabs = new GameObject[]{obstaclePrefab, obstacle_Height, obstacle_Width};
        // Random generator
        random = new Random();
        // Obstacles list and y-axis position
        obstacles = new LinkedList<GameObject>();
        // Where the obstacles are created in the z-axis
        limitZ = ground.transform.localScale.z / 2;
        newObstacle();
    }
    void FixedUpdate() {
        // The last created obstacle's z-position <= z-position
        // of the ground's end - space between obstacles
        if (obstacles.Last.Value.transform.position.z <=
                ground.transform.position.z + limitZ - offset) {
            newObstacle();
            removeObstacle();
        }
    }
    void newObstacle() {
        // Random obstacle
        int i = random.Next(obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[i];
        // Random x-axis position
        float range = ground.transform.localScale.x - obstacle.transform.localScale.x;
        float x = (float) (random.NextDouble() - 0.5f) * range;
        // Relative position to ground
        Vector3 position = new Vector3(x, obstacle.transform.position.y,
                ground.transform.position.z + limitZ);
        // Create and add
        obstacles.AddLast(Instantiate(obstacle, position, Quaternion.identity));
    }
    void removeObstacle() {
        // If the oldest obstacle has fall out from the ground
        if (obstacles.First.Value.transform.position.y < 0) {
            // Remove from scene
            Destroy(obstacles.First.Value);
            // Remove from list
            obstacles.RemoveFirst();
        }
    }
}
