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

    public Sprite wallBlockSprite;
    public Sprite attackTowerSprite;
    public Sprite healTowerSprite;
    public Sprite slowerTowerSprite;

    public GameObject transparentBlock;
    private SpriteRenderer spriteRendererTransparentBlock;

    // Type of somme unit.
    // Player can push one of these buttons 1 - 9, 0
    // to chose the element to place on the map.
    // Input settings by this moment:
    // 1 - place the Wall
    // 2 - place the Attack Tower
    // 3 - place the Heal Tower
    // 4 - place the Slower Tower
    // 5 - null
    // 6 - null
    // 7 - null
    // 8 - null
    // 9 - null
    // 0 - null
    private int unitType = 1;
    private TowerManager towerManager;

    void Start()
    {
        towerManager = FindObjectOfType<TowerManager>();
        spriteRendererTransparentBlock = transparentBlock.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        Vector3 objectPos = GetObjectPosition(GetMousePosition());

        // Show possible unit which can be set
        ShowTransparentBlock(objectPos);

        // Set new unit
        CheckMouseClick(objectPos);

        // Switch the unit type
        CheckUnitSelector();
    }

    // Полупрозрачная клетка, показывающая, что сюда можно поставить блок
    private void ShowTransparentBlock(Vector3 objectPos)
    {
        transparentBlock.transform.position = objectPos;

        switch (unitType)
        {
            case 1:
                spriteRendererTransparentBlock.sprite = wallBlockSprite;
                break;
            case 2:
                spriteRendererTransparentBlock.sprite = attackTowerSprite;
                break;
            case 3:
                spriteRendererTransparentBlock.sprite = healTowerSprite;
                break;
            case 4:
                spriteRendererTransparentBlock.sprite = slowerTowerSprite;
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 0:
                break;
        }
    }

    private void CheckMouseClick(Vector3 objectPos)
    {
        if (Input.GetMouseButton(0))
        {
            if (CanPlaceHere(objectPos))
            {
                PlaceUnit(objectPos);
            }
            else
            {
                Debug.Log("Can't place here");
            }
        }
    }

    private void CheckUnitSelector()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            unitType = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            unitType = 2;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            unitType = 3;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            unitType = 4;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            unitType = 5;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            unitType = 6;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            unitType = 7;
        }

        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            unitType = 8;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            unitType = 9;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            unitType = 0;
        }
        */
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;

        return mousePos;
    }

    private Vector3 GetObjectPosition(Vector3 mousePos)
    {
        Vector3 objectPos;
        objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        objectPos.x = Mathf.Round(objectPos.x);
        objectPos.y = Mathf.Round(objectPos.y);

        return objectPos;
    }

    private bool CanPlaceHere(GameObject[] objects, Vector3 pos)
    {
        foreach (GameObject currentObject in objects)
        {
            if (currentObject.transform.position.x == pos.x && currentObject.transform.position.y == pos.y)
            {
                return false;
            }
        }

        return true;
    }

    private bool CanPlaceHere(Vector3 pos)
    {
        // We can't place a new unit on objects defined by tags:
        string[] tags = {"Enemy", "Ally", "Tower", "Wall", "Block"};
        GameObject[] objects;

        foreach (string tag in tags)
        {
            objects = GameObject.FindGameObjectsWithTag(tag);
            if (!CanPlaceHere(objects, pos))
            {
                return false;
            }
        }

        return true;
    }

    private void PlaceUnit(Vector3 objectPos)
    {
        switch (unitType)
        {
            case 1:
                PlaceWall(objectPos);
                updateImage();
                break;
            case 2:
                towerManager.AddAttackTower(objectPos);
                break;
            case 3:
                towerManager.AddHealTower(objectPos);
                break;
            case 4:
                towerManager.AddSlowerTower(objectPos);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 0:
                break;
        }
    }

    private void PlaceWall(Vector3 objectPos)
    {
        int state = CheckNeighbours(objectPos);
        switch (state)
        {
            case (1):
                Instantiate(wallPrefabWall, objectPos, Quaternion.identity);
                break;
            case (2):
                Instantiate(wallPrefabWallReverse, objectPos, Quaternion.identity);
                break;
            case (3):
                Instantiate(wallPrefabWallTopLeft, objectPos, Quaternion.identity);
                break;
            case (4):
                Instantiate(wallPrefabWallTopRight, objectPos, Quaternion.identity);
                break;
            case (5):
                Instantiate(wallPrefabWallBottomLeft, objectPos, Quaternion.identity);
                break;
            case (6):
                Instantiate(wallPrefabWallBottomRight, objectPos, Quaternion.identity);
                break;
        }
    }

    private int CheckNeighbours(Vector3 pos)
    {
        GameObject[] walls;
        walls = GameObject.FindGameObjectsWithTag("Wall");
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

    private void updateImage()
    {
        GameObject[] walls;
        walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            Vector2 wallPos;
            wallPos.x = wall.transform.position.x;
            wallPos.y = wall.transform.position.y;
            Destroy(wall);
            PlaceWall(wallPos);
        }
    }
}
