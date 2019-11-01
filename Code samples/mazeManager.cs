using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class mazeManager : MonoBehaviour {
    public class MazePos
    {
        public int rowPos;
        public int colPos;
        public MazePos(int r, int c)
        {
            rowPos = r;
            colPos = c;
        }
    }

    public GameObject mazeCubePrefab;
    //public GameObject mazeCubePathPrefab;
    public Transform startPrefab;
    public GameObject endPrefab;
    public Transform mazeParent;

    public int mazeRow = 30;
    public int mazeCol = 30;
    public float scale = 0.5f;
    bool isEndPos = false;

    List<MazePos> findPosList = new List<MazePos>();
    List<List<int>> mazeMapList = new List<List<int>>();

    public enum PosType
    {
        wall = 0, 
        path = 1,
        startPos = 2,
        endPos = 3,
    }

	// Use this for initialization
	void Start () {
		//inital the maze map list
        for(int i = 0; i < mazeRow; i++)
        {
            mazeMapList.Add(new List<int>());
            for(int j = 0; j < mazeCol; j++)
            {
                mazeMapList[i].Add((int)PosType.wall);
            }
        }

        //start pos
        int startPosRow = 0, startPosCol = 0;
        startPosRow = UnityEngine.Random.Range(1, mazeRow - 1);
        startPosCol = UnityEngine.Random.Range(1, mazeCol - 1);
        if (startPosRow % 2 == 0)
        {
            startPosRow -= 1;
        }
        if (startPosCol % 2 == 0)
        {
            startPosCol -= 1;
        }
        if (startPosRow == 0) startPosRow = 1;
        if (startPosCol == 0) startPosCol = 1;
        if (startPosRow == mazeRow - 1) startPosRow -= 1;
        if (startPosCol == mazeCol - 1) startPosCol -= 1;
        int randBorder = UnityEngine.Random.Range(0, 4);
        MazePos startPos = new MazePos(0, 0);
        if(randBorder == 0)
        {
            startPos = new MazePos(0, startPosCol);
        } else if(randBorder == 1)
        {
            startPos = new MazePos(mazeRow - 1, startPosCol);
        } else if(randBorder == 2)
        {
            startPos = new MazePos(startPosRow, 0);
        } else if (randBorder == 3)
        {
            startPos = new MazePos(startPosRow, mazeCol - 1);
        }


        mazeMapList[startPos.rowPos][startPos.colPos] = (int)PosType.startPos;
        startPrefab.transform.position = new Vector3((startPos.rowPos - (mazeRow / 2)) * scale, (startPos.colPos - (mazeCol / 2)) * scale, 0);


        findPosList.Add(startPos);

        //find path recursively
        FindPath(startPos);

        //show 
        ShowMap();
    }

    void FindPath(MazePos currentPos)
    {
        if(findPosList.Count >= mazeRow * mazeCol)
        {
            return;
        }

        List<MazePos> surroundPos = new List<MazePos>();
        FindSurroundPos(surroundPos, currentPos);
        while(surroundPos.Count > 0)
        {
            int randPosIndex = UnityEngine.Random.Range(0, surroundPos.Count);

            MazePos nextPos = surroundPos[randPosIndex];
            MazePos middlePosBetweenCurAndNext = new MazePos((currentPos.rowPos + nextPos.rowPos) / 2, (currentPos.colPos + nextPos.colPos) / 2);
            SetPosHaveFound(middlePosBetweenCurAndNext);
            SetPosHaveFound(nextPos);
            surroundPos.RemoveAt(randPosIndex);
            // keep finding
            FindPath(nextPos);

            FindSurroundPos(surroundPos, currentPos);
        }
    }

    void FindSurroundPos(List<MazePos> surroundPos, MazePos currentPos)
    {
        surroundPos.Clear();
        //up direction
        if(currentPos.rowPos >= 2)
        {
            if (currentPos.colPos != 0 && currentPos.colPos != mazeCol - 1)
            {
                AddPosToSurroundPosList(surroundPos, new MazePos(currentPos.rowPos - 2, currentPos.colPos));
            }
        }
        //down direction
        if (currentPos.rowPos < mazeRow - 2)
        {
            if (currentPos.colPos != 0 && currentPos.colPos != mazeCol - 1)
            {
                AddPosToSurroundPosList(surroundPos, new MazePos(currentPos.rowPos + 2, currentPos.colPos));
            }
        }
        //left direction
        if (currentPos.colPos >= 2)
        {
            if(currentPos.rowPos != 0 && currentPos.rowPos != mazeRow - 1)
            {
                AddPosToSurroundPosList(surroundPos, new MazePos(currentPos.rowPos, currentPos.colPos - 2));
            }
        }
        //right direction
        if (currentPos.colPos < mazeCol - 2)
        {
            if (currentPos.rowPos != 0 && currentPos.rowPos != mazeRow - 1)
            {
                AddPosToSurroundPosList(surroundPos, new MazePos(currentPos.rowPos, currentPos.colPos + 2));
            }
        }
    }

    void AddPosToSurroundPosList(List<MazePos> surroundPos, MazePos pos)
    {
        if ((pos.rowPos >= 0 && pos.colPos >= 0) && (pos.rowPos < mazeRow && pos.colPos < mazeCol) && mazeMapList[pos.rowPos][pos.colPos] == (int)PosType.wall)
        {
            surroundPos.Add(pos);
        }
    }

    void SetPosHaveFound(MazePos pos)
    {
        mazeMapList[pos.rowPos][pos.colPos] = (int)PosType.path;
        findPosList.Add(pos);
    }

    float addTime = 0;
    int addIndex = 0;
    List<MazePos> boderList = new List<MazePos>();
    int boderIndex = -1;
    int rotateAngle = 0;

    void ShowMap()
    {
        for (int i = 0; i < mazeRow; i++)
        {
            for (int j = 0; j < mazeCol; j++)
            {
                if(mazeMapList[i][j] == (int)PosType.wall)
                {
                    GameObject Cube2D = (GameObject)Instantiate(mazeCubePrefab, new Vector3((i - (mazeRow / 2)) * scale, (j - (mazeCol / 2)) * scale, 0), Quaternion.identity);
                    Cube2D.transform.localScale = new Vector3(scale, scale, scale);
                    Cube2D.transform.parent = mazeParent;
                }
            }
        }

        for(int i = 0; i < findPosList.Count; i++)
        {
            MazePos pos = findPosList[i];
            if (i != 0)
            {
                if (pos.rowPos == 0 || pos.colPos == 0 || pos.rowPos == mazeRow - 1 || pos.colPos == mazeCol - 1)
                {
                    boderList.Add(pos);
                }
            }
        }
        while(boderIndex < boderList.Count)
        {
            if (boderIndex == -1)
            {
                int randEndIndex = UnityEngine.Random.Range(0, boderList.Count);
                MazePos pos = boderList[randEndIndex];
                GameObject Cube2D = (GameObject)Instantiate(endPrefab, new Vector3((pos.rowPos - (mazeRow / 2)) * scale, (pos.colPos - (mazeCol / 2)) * scale, 0), Quaternion.identity);
                Cube2D.transform.localScale = new Vector3(scale, scale, scale);
                Cube2D.transform.parent = mazeParent;
                boderList.RemoveAt(randEndIndex);
            }
            else
            {
                MazePos pos = boderList[boderIndex];
                GameObject Cube2D = (GameObject)Instantiate(mazeCubePrefab, new Vector3((pos.rowPos - (mazeRow / 2)) * scale, (pos.colPos - (mazeCol / 2)) * scale, 0), Quaternion.identity);
                Cube2D.transform.localScale = new Vector3(scale, scale, scale);
                Cube2D.transform.parent = mazeParent;
            }
            boderIndex += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //addTime += Time.deltaTime;
        //if (addIndex < findPosList.Count)
        //{
        //    addTime = 0;
        //    MazePos pos = findPosList[addIndex];

        //    if(addIndex == 0)
        //    {
        //        GameObject Cube2D = (GameObject)Instantiate(startPrefab, new Vector3((pos.rowPos - (mazeRow / 2)) * scale, (pos.colPos - (mazeCol / 2)) * scale, 0), Quaternion.identity);
        //        Cube2D.transform.localScale = new Vector3(scale, scale, scale);
        //        Cube2D.transform.parent = mazeParent;
        //    } else
        //    {
        //        if(pos.rowPos == 0 || pos.colPos == 0 || pos.rowPos == mazeRow - 1 || pos.colPos == mazeCol - 1)
        //        {
        //            boderList.Add(pos);
        //        } else
        //        {
        //            GameObject Cube2D = (GameObject)Instantiate(mazeCubePathPrefab, new Vector3((pos.rowPos - (mazeRow / 2)) * scale, (pos.colPos - (mazeCol / 2)) * scale, 0), Quaternion.identity);
        //            Cube2D.transform.localScale = new Vector3(scale, scale, scale);
        //            Cube2D.transform.parent = mazeParent;
        //        }
        //    }

        //    addIndex += 1;
        //} else
        //{
        //    if(boderIndex < boderList.Count)
        //    {
        //        if(boderIndex == -1)
        //        {
        //            int randEndIndex = UnityEngine.Random.Range(0, boderList.Count);
        //            boderList.RemoveAt(randEndIndex);
        //        } else
        //        {
        //            MazePos pos = boderList[boderIndex];
        //            GameObject Cube2D = (GameObject)Instantiate(mazeCubePrefab, new Vector3((pos.rowPos - (mazeRow / 2)) * scale, (pos.colPos - (mazeCol / 2)) * scale, 0), Quaternion.identity);
        //            Cube2D.transform.localScale = new Vector3(scale, scale, scale);
        //            Cube2D.transform.parent = mazeParent;
        //        }
        //        boderIndex += 1;
        //    }
            
        //}
        mazeParent.rotation = Quaternion.Euler(0, 0, rotateAngle);

        if (Input.GetKey(KeyCode.Alpha0)) {
            rotateAngle += 5;
            mazeParent.rotation = Quaternion.Euler(0, 0, rotateAngle);
        }
        else if (Input.GetKey(KeyCode.Alpha1)) {
            rotateAngle -= 5;
            mazeParent.rotation = Quaternion.Euler(0, 0, rotateAngle);
        }
    }
}
