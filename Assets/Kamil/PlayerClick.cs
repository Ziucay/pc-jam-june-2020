using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerClick : MonoBehaviour
{
    [SerializeField] GameObject wallPrefabWall;
    [SerializeField] GameObject wallPrefabWallBottomLeft;
    [SerializeField] GameObject wallPrefabWallBottomRight;
    [SerializeField] GameObject wallPrefabWallReverse;
    [SerializeField] GameObject wallPrefabWallTopLeft;
    [SerializeField] GameObject wallPrefabWallTopRight;
    private Vector3 mousePos;
    private Vector3 objectPos;
    
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.x = Mathf.Round(objectPos.x);
            objectPos.y = Mathf.Round(objectPos.y);
            if (CanPlaceHere(objectPos))
            {
                PlaceBlock(objectPos);
                updateImage();
            }
            else
            {
                Debug.Log("Can't place here");
            }
        }
    }

    void PlaceBlock(Vector3 objectPos)
    {
        int state = CheckNeighbours(objectPos);
            switch (state)
            {
                case(1):
                    Instantiate(wallPrefabWall, objectPos, Quaternion.identity);
                    break;
                case(2):
                    Instantiate(wallPrefabWallReverse, objectPos, Quaternion.identity);
                    break;
                case(3):
                    Instantiate(wallPrefabWallTopLeft, objectPos, Quaternion.identity);
                    break;
                case(4):
                    Instantiate(wallPrefabWallTopRight, objectPos, Quaternion.identity);
                    break;
                case(5):
                    Instantiate(wallPrefabWallBottomLeft, objectPos, Quaternion.identity);
                    break;
                case(6):
                    Instantiate(wallPrefabWallBottomRight, objectPos, Quaternion.identity);
                    break;
            }
    }
    
    
    bool CanPlaceHere(Vector3 pos)
    {
        GameObject[] walls;
        walls = GameObject.FindGameObjectsWithTag("Repairable");
        foreach (GameObject wall in walls)
        {
            if (wall.transform.position.x == pos.x && wall.transform.position.y == pos.y)
            {
                return false;
            }
        }

        return true;
    }

    int CheckNeighbours(Vector3 pos)
    {
        GameObject[] walls;
        walls = GameObject.FindGameObjectsWithTag("Repairable");
        bool isLeft = false;
        bool isRight = false;
        bool isTop = false;
        bool isBottom = false;

        foreach (GameObject wall in walls)
        {
            if (wall.transform.position.x == pos.x - 1.0f && wall.transform.position.y == pos.y)
            {
                isLeft = true;
            }
            if (wall.transform.position.x == pos.x + 1.0f && wall.transform.position.y == pos.y)
            {
                isRight = true;
            }
            if (wall.transform.position.y == pos.y - 1.0f && wall.transform.position.x == pos.x) 
            {
                isBottom = true;
            }
            if (wall.transform.position.y == pos.y + 1.0f && wall.transform.position.x == pos.x)
            {
                isTop = true;
            }

        }

        if (isTop && isLeft)
        {
            return 6;
        }

        if (isTop && isRight)
        {
            return 5;
        }

        if (isBottom && isLeft)
        {
            return 4;
        }

        if (isBottom && isRight)
        {
            return 3;
        }

        if (isTop || isBottom)
        {
            return 2;
        }

        return 1;
    }


    void updateImage()
    {
        GameObject[] walls;
        walls = GameObject.FindGameObjectsWithTag("Repairable");
        foreach (GameObject wall in walls)
        {
            Vector2 wallPos;
            wallPos.x = wall.transform.position.x;
            wallPos.y = wall.transform.position.y;
            Destroy(wall);
            PlaceBlock(wallPos);
        }
    }
}
