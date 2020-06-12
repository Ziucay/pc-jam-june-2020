using UnityEngine;
public class Laser : MonoBehaviour
{
    private float scaleCoefficient;

    void Start()
    {
        scaleCoefficient = 0.4f;
        DisableLaser();
    }

    public void DisableLaser()
    {
        gameObject.SetActive(false);
    }

    public void DirectLaser(Vector3 towerPosition, Vector3 enemyPosition)
    {
        gameObject.SetActive(true);
        
        float deltaX = towerPosition.x - enemyPosition.x;
        float deltaY = towerPosition.y - enemyPosition.y;

        // Change position. Place between the tower and an enemy. 
        transform.position = new Vector3((towerPosition.x + enemyPosition.x) / 2,
            (towerPosition.y + enemyPosition.y) / 2, 0);

        // Change the scale. Its length is equal to the distance between the tower and an enemy. 
        Vector3 newScale = transform.localScale;
        newScale.x = scaleCoefficient * Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
        transform.localScale = newScale;

        // Change the rotation. Calculate the angle between the tower and an enemy. 
        float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}