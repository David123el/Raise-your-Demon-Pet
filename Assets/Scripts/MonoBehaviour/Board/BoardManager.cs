using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class BoardManager : MonoBehaviour
{
    public static BoardItem[,] board;
    public static Int2 boardSize;

    public int xBoard;
    public int yBoard;

    BoardItem draggedItem;

    Vector3 initialDragPosition;
    Vector3 currentMousePosition;
    Vector3 initialItemPosition;

    const float guiBGPos = 100f;

    static Ray ray;
    public static RaycastHit hit;

    public GameObject backgroundTile;
    public Transform backgroundParent;

    public GameObject houseObj;
    public GameObject roadObj;
    public GameObject powerPlantObj;
    public GameObject waterTowerObj;
    public GameObject commercialObj;

    public GameObject guiBG;

    public Text demolisherStatus;

    static GameObject tempObj;
    BoardItem tempBoardItem;
    public Camera guiCam;

    public GameObject merchRoad;
    public GameObject coins;
    public GameObject population;
    public int coinsDisplay;
    public static float coinsAmount;
    public int populationDisplay;
    public static int populationAmount;

    public static Text coinsText;
    public static Text populationText;

    static float timeOfClicking;
    static float timeSinceClicking;
    static float timeOfDelay = 0.1f;

    public static bool isDraggingFromMenu = false;
    public static bool isTryingToDragAnItem = false;
    public static bool isTryingToDemolish = false;
    public static bool isClickingUI = false;
    public static bool hasStartedChecking = false;

    //public static List<IResourceProvider> listOfProviders = new List<IResourceProvider>();
    //public static List<IBuilding> listOfBuildings = new List<IBuilding>();

    void Awake()
    {
        coinsAmount = coinsDisplay;
        populationAmount = populationDisplay;
    }

    void Start()
    {
        boardSize = new Int2(xBoard, yBoard);
        board = new BoardItem[boardSize.x, boardSize.y];

        InitializeBoard();

        coinsText = coins.GetComponent<Text>();
        coinsText.text = coinsAmount.ToString();

        populationText = population.GetComponent<Text>();

        guiBG = GameObject.Find("Structures Background");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDraggingFromMenu)
            {
                timeOfClicking = Time.time;

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100))
                {
                    var temp = hit.collider.GetComponent<BoardItem>();
                    if (temp != null)
                        isTryingToDragAnItem = true;
                    else isTryingToDragAnItem = false;

                    //if (isTryingToDemolish)
                    //{
                    //    if (hit.collider.gameObject != null)
                    //        Demolish();
                    //}

                    hasStartedChecking = true;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            //if (!isDraggingFromMenu && isTryingToDragAnItem)
            //{
            //    timeSinceClicking = Time.time - timeOfClicking;
            //    if (timeSinceClicking >= timeOfDelay)
            //        if (draggedItem == null && !CameraManager.isDraggingCamera)
            //            AttemptToDrag(Input.mousePosition);
            //    if (draggedItem != null)
            //        Drag(Input.mousePosition);
            //}
        }
        if (Input.GetMouseButtonUp(0))
        {
            //if (draggedItem != null)
            //    ReleaseDrag();
            //isTryingToDragAnItem = false;
        }

        if (isTryingToDemolish || isClickingUI)
        {
            guiBG.transform.localPosition = new Vector3(0, -400, 0);

            if (isTryingToDemolish)
                demolisherStatus.text = "On";
        }
        else
        {
            demolisherStatus.text = "Off";

            guiBG.transform.localPosition = new Vector3(0, -200, 0);
        }
    }

    void InitializeBoard()
    {
        for (int i = 0; i < boardSize.x; i++)
        {
            for (int j = 0; j < boardSize.y; j++)
            {
                var temp = (GameObject)Instantiate(backgroundTile, new Vector3(i, j), Quaternion.identity);
                temp.transform.SetParent(backgroundParent);
            }
        }
    }

    public void InstantiateRoad()
    {
        isClickingUI = true;
        isDraggingFromMenu = true;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);

        tempObj = null;
        tempObj = Instantiate(roadObj, new Vector3(flatZPos.x, flatZPos.y, 0), Quaternion.identity) as GameObject;

        DragObjFromMenu();
    }

    public void InstantiatePowerPlant()
    {
        isClickingUI = true;
        isDraggingFromMenu = true;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);
        Int2 int2Pos = new Int2((int)flatZPos.x, (int)flatZPos.y);

        tempObj = null;
        tempObj = Instantiate(powerPlantObj, new Vector3(flatZPos.x, flatZPos.y, 0), Quaternion.identity) as GameObject;

        tempBoardItem = tempObj.GetComponent<BoardItem>();
        if (tempBoardItem != null)
        {
            tempBoardItem.PositionInWorld = flatZPos;
            tempBoardItem.PositionInArray = int2Pos;
        }
    }

    public void InstantiateWaterTower()
    {
        isClickingUI = true;
        isDraggingFromMenu = true;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);
        Int2 int2Pos = new Int2((int)flatZPos.x, (int)flatZPos.y);

        tempObj = null;
        tempObj = Instantiate(waterTowerObj, new Vector3(flatZPos.x, flatZPos.y, 0), Quaternion.identity) as GameObject;

        tempBoardItem = tempObj.GetComponent<BoardItem>();
        if (tempBoardItem != null)
        {
            tempBoardItem.PositionInWorld = flatZPos;
            tempBoardItem.PositionInArray = int2Pos;
        }
    }

    public void InstantiateHouse()
    {
        isClickingUI = true;
        isDraggingFromMenu = true;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);
        Int2 int2Pos = new Int2((int)flatZPos.x, (int)flatZPos.y);

        tempObj = null;
        tempObj = Instantiate(houseObj, new Vector3(flatZPos.x, flatZPos.y, 0), Quaternion.identity) as GameObject;

        tempBoardItem = tempObj.GetComponent<BoardItem>();
        if (tempBoardItem != null)
        {
            tempBoardItem.PositionInWorld = flatZPos;
            tempBoardItem.PositionInArray = int2Pos;
        }
    }

    public void InstantiateCommercial()
    {
        isClickingUI = true;
        isDraggingFromMenu = true;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);
        Int2 int2Pos = new Int2((int)flatZPos.x, (int)flatZPos.y);

        tempObj = null;
        tempObj = Instantiate(commercialObj, new Vector3(flatZPos.x, flatZPos.y, 0), Quaternion.identity) as GameObject;

        tempBoardItem = tempObj.GetComponent<BoardItem>();
        if (tempBoardItem != null)
        {
            tempBoardItem.PositionInWorld = flatZPos;
            tempBoardItem.PositionInArray = int2Pos;
        }
    }

    public void DragObjFromMenu()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 flatZPos = new Vector3(Mathf.Round(worldMousePos.x), Mathf.Round(worldMousePos.y), 0);
        Int2 int2Pos = new Int2((int)flatZPos.x, (int)flatZPos.y);

        tempObj.transform.position = flatZPos;

        tempBoardItem = tempObj.GetComponent<BoardItem>();
        if (tempBoardItem != null)
        {
            tempBoardItem.PositionInWorld = flatZPos;
            tempBoardItem.PositionInArray = int2Pos;
            tempBoardItem.GameBoard = this;

            draggedItem = tempBoardItem;
        }
    }

    //public void PlaceObjOnSurface()
    //{
    //    GameObject guiBG = GameObject.Find("Structures Background");
    //    guiBG.transform.localPosition = new Vector3(0, -200, 0);

    //    tempBoardItem = tempObj.GetComponent<BoardItem>();
    //    if (tempBoardItem != null)
    //    {
    //        if (coinsAmount >= tempBoardItem.Value)
    //        {
    //            if (IsInRange(tempBoardItem, tempBoardItem.PositionInWorld)
    //            && IsNotHeld(tempBoardItem, tempBoardItem.PositionInArray))
    //            {
    //                coinsAmount -= tempBoardItem.Value;
    //                coinsText.text = coinsAmount.ToString();

    //                tempBoardItem.PositionInWorld = tempBoardItem.transform.position;
    //                tempBoardItem.PositionInArray = new Int2((int)tempBoardItem.transform.position.x, (int)tempBoardItem.transform.position.y);
    //                FillBoard(tempBoardItem, tempBoardItem.PositionInArray);

    //                //var conductive = tempBoardItem.GetComponent<BoardItem>() as IConductive;
    //                //if (conductive != null)
    //                //    conductive.StartChecking(true);

    //                //var conductive = tempBoardItem.GetComponent<BoardItem>() as IConductive;
    //                //if (conductive != null)
    //                //    if (conductive is MultiSpriteResourceConductiveManager)
    //                //    {
    //                //        listOfBuildings.All(x => { x.Refresh(); return true; });
    //                //        conductive.StartChecking(true);
    //                //    }
                    
    //                //var tempBuildingType = tempBoardItem.GetComponent<BuildingManager>();
    //                //if (tempBuildingType != null)
    //                //{
    //                //    if (tempBuildingType.buildingType == BuildingType.house)
    //                //    {
    //                //        int temp = populationAmount += 2;
    //                //        populationText.text = temp.ToString();

    //                //        listOfBuildings.Add(tempBuildingType);
    //                //        //listOfProviders.All(x => { x.StartChecking(true); return true; });
    //                //    }
    //                //}

    //                //var tempResourceProvider = tempBoardItem as IResourceProvider;
    //                //if (tempResourceProvider != null)
    //                //{
    //                //    listOfProviders.Add(tempResourceProvider);
    //                //    tempResourceProvider.StartChecking(true);
    //                //}

    //                #region Update Road Neighbor Sprites
    //                var ms = tempBoardItem as IMultiSprites;
    //                if (ms != null)
    //                {
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(tempBoardItem);

    //                    if (tempBoardItem.PositionInArray.x + 1 < boardSize.x)
    //                        if (board[tempBoardItem.PositionInArray.x + 1, tempBoardItem.PositionInArray.y] != null)
    //                        {
    //                            var ms1 = board[tempBoardItem.PositionInArray.x + 1, tempBoardItem.PositionInArray.y] as IMultiSprites;

    //                            if (ms1 != null)
    //                                MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                        }

    //                    if (tempBoardItem.PositionInArray.x - 1 > 0)
    //                        if (board[tempBoardItem.PositionInArray.x - 1, tempBoardItem.PositionInArray.y] != null)
    //                        {
    //                            var ms1 = board[tempBoardItem.PositionInArray.x - 1, tempBoardItem.PositionInArray.y] as IMultiSprites;

    //                            if (ms1 != null)
    //                                MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                        }

    //                    if (tempBoardItem.PositionInArray.y + 1 < boardSize.y)
    //                        if (board[tempBoardItem.PositionInArray.x, tempBoardItem.PositionInArray.y + 1] != null)
    //                        {
    //                            var ms1 = board[tempBoardItem.PositionInArray.x, tempBoardItem.PositionInArray.y + 1] as IMultiSprites;

    //                            if (ms1 != null)
    //                                MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                        }

    //                    if (tempBoardItem.PositionInArray.y - 1 > 0)
    //                        if (board[tempBoardItem.PositionInArray.x, tempBoardItem.PositionInArray.y - 1] != null)
    //                        {
    //                            var ms1 = board[tempBoardItem.PositionInArray.x, tempBoardItem.PositionInArray.y - 1] as IMultiSprites;

    //                            if (ms1 != null)
    //                                MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                        }
    //                }
    //                #endregion
    //            }
    //            else
    //            {
    //                Destroy(tempObj);
    //            }
    //        }
    //        else
    //        {
    //            print("Insufficient funds!");
    //            Destroy(tempObj);
    //        }

    //        //listOfBuildings.All(x => { x.Refresh(); return true; });
    //    }

    //    isDraggingFromMenu = false;
    //    isClickingUI = false;
    //    draggedItem = null;

    //    //PrintBoard();
    //}
    
    public void ToggleDemolishMode()
    {
        isClickingUI = true;

        isTryingToDemolish = !isTryingToDemolish;
    }

    public void ToggleIsClickingUI()
    {
        isClickingUI = false;
    }

    //void Demolish()
    //{
    //    ClearBoard(hit.collider.GetComponent<BoardItem>(), hit.collider.GetComponent<BoardItem>().PositionInArray);

    //    var ms = hit.collider.GetComponent<BoardItem>() as IMultiSprites;
    //    if (ms != null)
    //    {
    //        MultiSpriteResourceConductiveManager.UpdateSprites(hit.collider.GetComponent<BoardItem>());

    //        if (hit.collider.GetComponent<BoardItem>().PositionInArray.x + 1 < boardSize.x)
    //            if (board[hit.collider.GetComponent<BoardItem>().PositionInArray.x + 1, hit.collider.GetComponent<BoardItem>().PositionInArray.y] != null)
    //            {
    //                var ms1 = board[hit.collider.GetComponent<BoardItem>().PositionInArray.x + 1, hit.collider.GetComponent<BoardItem>().PositionInArray.y] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }

    //        if (hit.collider.GetComponent<BoardItem>().PositionInArray.x - 1 > 0)
    //            if (board[hit.collider.GetComponent<BoardItem>().PositionInArray.x - 1, hit.collider.GetComponent<BoardItem>().PositionInArray.y] != null)
    //            {
    //                var ms1 = board[hit.collider.GetComponent<BoardItem>().PositionInArray.x - 1, hit.collider.GetComponent<BoardItem>().PositionInArray.y] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }

    //        if (hit.collider.GetComponent<BoardItem>().PositionInArray.y + 1 < boardSize.y)
    //            if (board[hit.collider.GetComponent<BoardItem>().PositionInArray.x, hit.collider.GetComponent<BoardItem>().PositionInArray.y + 1] != null)
    //            {
    //                var ms1 = board[hit.collider.GetComponent<BoardItem>().PositionInArray.x, hit.collider.GetComponent<BoardItem>().PositionInArray.y + 1] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }

    //        if (hit.collider.GetComponent<BoardItem>().PositionInArray.y - 1 > 0)
    //            if (board[hit.collider.GetComponent<BoardItem>().PositionInArray.x, hit.collider.GetComponent<BoardItem>().PositionInArray.y - 1] != null)
    //            {
    //                var ms1 = board[hit.collider.GetComponent<BoardItem>().PositionInArray.x, hit.collider.GetComponent<BoardItem>().PositionInArray.y - 1] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }
    //    }

    //    var conductive = hit.collider.GetComponent<BoardItem>() as IConductive;
    //    if (conductive != null)
    //        if (conductive is MultiSpriteResourceConductiveManager)
    //            conductive.StartChecking(false);

    //    var tempResourceProvider = hit.collider.GetComponent<BoardItem>() as IResourceProvider;
    //    if (tempResourceProvider != null)
    //    {
    //        tempResourceProvider.StartChecking(false);
    //        if (listOfProviders.Contains(tempResourceProvider))
    //            listOfProviders.Remove(tempResourceProvider);
    //    }

    //    var tempBuilding = hit.collider.GetComponent<BoardItem>() as BuildingManager;
    //    if (tempBuilding != null)
    //        if (tempBuilding.buildingType == BuildingType.house)
    //        {
    //            tempBuilding.StartChecking(false);
    //            if (listOfBuildings.Contains(tempBuilding))
    //                listOfBuildings.Remove(tempBuilding);
    //        }

    //    coinsAmount += hit.collider.GetComponent<BoardItem>().Value / 2;
    //    coinsText.text = coinsAmount.ToString();

    //    Destroy(hit.collider.gameObject);
    //}

    //void AttemptToDrag(Vector3 mousePos)
    //{
    //    ray = Camera.main.ScreenPointToRay(mousePos);
        
    //    if (Physics.Raycast(ray, out hit, 100))
    //    {
    //        if (hit.collider.tag == "Draggable")
    //        {
    //            draggedItem = hit.collider.transform.GetComponent<BoardItem>();
    //            var temp = Camera.main.ScreenToWorldPoint(mousePos);
    //            temp[0] = Mathf.Round(temp[0]);
    //            temp[1] = Mathf.Round(temp[1]);
    //            temp[2] = 0;
    //            initialDragPosition = temp - draggedItem.transform.position;
    //            initialItemPosition = draggedItem.transform.position;
    //            ClearBoard(draggedItem, new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y));

    //            var conductor = draggedItem as IConductive;
    //            if (conductor != null)
    //                if (hasStartedChecking)
    //                    conductor.StartChecking(false);

    //            var tempRoad = draggedItem as MultiSpriteResourceConductiveManager;
    //            if (tempRoad != null)
    //                ClearBoard(draggedItem, draggedItem.PositionInArray);

    //            hasStartedChecking = false;

    //            #region Update Road Neighbor Sprites
    //            if (draggedItem.PositionInArray.x + 1 < boardSize.x)
    //            {
    //                if (board[draggedItem.PositionInArray.x + 1, draggedItem.PositionInArray.y] != null)
    //                {
    //                    var ms1 = board[draggedItem.PositionInArray.x + 1, draggedItem.PositionInArray.y] as IMultiSprites;

    //                    if (ms1 != null)
    //                        MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                }
    //            }

    //            if (draggedItem.PositionInArray.x - 1 > 0)
    //            {
    //                if (board[draggedItem.PositionInArray.x - 1, draggedItem.PositionInArray.y] != null)
    //                {
    //                    var ms1 = board[draggedItem.PositionInArray.x - 1, draggedItem.PositionInArray.y] as IMultiSprites;

    //                    if (ms1 != null)
    //                        MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                }
    //            }

    //            if (draggedItem.PositionInArray.y + 1 < boardSize.y)
    //            {
    //                if (board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y + 1] != null)
    //                {
    //                    var ms1 = board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y + 1] as IMultiSprites;

    //                    if (ms1 != null)
    //                        MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                }
    //            }

    //            if (draggedItem.PositionInArray.y - 1 > 0)
    //            {
    //                if (board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y - 1] != null)
    //                {
    //                    var ms1 = board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y - 1] as IMultiSprites;

    //                    if (ms1 != null)
    //                        MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //                }
    //            }
    //            #endregion
    //        }
    //    }
    //}

    void Drag(Vector3 mousePos)
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 delta = currentMousePosition - initialDragPosition;

        Int2 deltaStep = new Int2(Mathf.RoundToInt(initialDragPosition.x + delta.x), Mathf.RoundToInt(initialDragPosition.y + delta.y));

        if (initialDragPosition.x <= boardSize.x && initialDragPosition.y <= boardSize.y
            && initialDragPosition.x >= 0 && initialDragPosition.y >= 0)
            draggedItem.transform.position = new Vector3(deltaStep.x - initialDragPosition.x, deltaStep.y - initialDragPosition.y, -1);
    }

    //void ReleaseDrag()
    //{
    //    if (IsInRange(draggedItem, draggedItem.transform.position)
    //        && IsNotHeld(draggedItem, new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y)))
    //    {
    //        draggedItem.transform.position = new Vector3(draggedItem.transform.position.x, draggedItem.transform.position.y, 0);
    //        draggedItem.PositionInWorld = draggedItem.transform.position;
    //        draggedItem.PositionInArray = new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y);
    //        FillBoard(draggedItem, new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y));

    //        var conductor = draggedItem as IConductive;
    //        if (conductor != null)
    //            conductor.StartChecking(true);

    //        //var conductive = draggedItem.GetComponent<BoardItem>() as IConductive;
    //        //if (conductive != null)
    //        //    if (conductive is MultiSpriteResourceConductiveManager)
    //        //        listOfProviders.All(x => { x.StartChecking(true); return true; });

    //        //var tempProvider = draggedItem.GetComponent<BoardItem>() as IResourceProvider;
    //        //if (tempProvider != null)
    //        //    tempProvider.StartChecking(true);

    //        //var tempHouse = draggedItem.GetComponent<BoardItem>() as BuildingManager;
    //        //if (tempHouse != null)
    //        //    if (tempHouse.buildingType == BuildingType.house)
    //        //        listOfProviders.All(x => { x.StartChecking(true); return true; });


    //        //listOfProviders.All(x => { x.StartChecking(true); return true; });
    //        //listOfBuildings.All(x => { x.Refresh(); return true; });

    //        //Update Self - Road sprite
    //        var tempMultiSprite = draggedItem as IMultiSprites;
    //        if (tempMultiSprite != null)
    //            MultiSpriteResourceConductiveManager.UpdateSprites(draggedItem);

    //        #region Update Neighbor Roads
    //        if (draggedItem.PositionInArray.x + 1 < boardSize.x)
    //        {
    //            if (board[draggedItem.PositionInArray.x + 1, draggedItem.PositionInArray.y] != null)
    //            {
    //                var ms1 = board[draggedItem.PositionInArray.x + 1, draggedItem.PositionInArray.y] as IMultiSprites;
                    
    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }
    //        }

    //        if (draggedItem.PositionInArray.x - 1 > 0)
    //        {
    //            if (board[draggedItem.PositionInArray.x - 1, draggedItem.PositionInArray.y] != null)
    //            {
    //                var ms1 = board[draggedItem.PositionInArray.x - 1, draggedItem.PositionInArray.y] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }
    //        }

    //        if (draggedItem.PositionInArray.y + 1 < boardSize.y)
    //        {
    //            if (board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y + 1] != null)
    //            {
    //                var ms1 = board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y + 1] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }
    //        }

    //        if (draggedItem.PositionInArray.y - 1 > 0)
    //        {
    //            if (board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y - 1] != null)
    //            {
    //                var ms1 = board[draggedItem.PositionInArray.x, draggedItem.PositionInArray.y - 1] as IMultiSprites;

    //                if (ms1 != null)
    //                    MultiSpriteResourceConductiveManager.UpdateSprites(ms1 as BoardItem);
    //            }
    //        }
    //        #endregion

    //        //PrintBoard();
    //    }
    //    else
    //    {
    //        draggedItem.transform.position = initialItemPosition;
    //        draggedItem.PositionInWorld = draggedItem.transform.position;
    //        draggedItem.PositionInArray = new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y);
    //        FillBoard(draggedItem, new Int2((int)draggedItem.transform.position.x, (int)draggedItem.transform.position.y));

    //        //var conductive = draggedItem.GetComponent<BoardItem>() as IConductive;
    //        //if (conductive != null)
    //        //    if (conductive is MultiSpriteResourceConductiveManager)
    //        //        listOfProviders.All(x => { x.StartChecking(true); return true; });

    //        //var tempProvider = draggedItem.GetComponent<BoardItem>() as IResourceProvider;
    //        //if (tempProvider != null)
    //        //    tempProvider.StartChecking(true);

    //        //var tempHouse = draggedItem.GetComponent<BoardItem>() as BuildingManager;
    //        //if (tempHouse != null)
    //        //    if (tempHouse.buildingType == BuildingType.house)
    //        //        listOfProviders.All(x => { x.StartChecking(true); return true; });

    //        var conductive = draggedItem.GetComponent<BoardItem>() as IConductive;
    //        if (conductive != null)
    //            conductive.StartChecking(true);

    //        //listOfBuildings.All(x => { x.Refresh(); return true; });

    //        //PrintBoard();
    //    }

    //    draggedItem = null;
    //}

    bool IsInRange(BoardItem item, Vector3 pos)
    {
        if (pos.x <= boardSize.x - item.Size.x && pos.y <= boardSize.y - item.Size.y
           && pos.x >= 1 && pos.y >= 1)
            return true;
        return false;
    }

    public static bool IsInRange(int x, int y)
    {
        Int2 tempPosInArr = new Int2(x, y);

        if (tempPosInArr.x < boardSize.x && tempPosInArr.y < boardSize.y
           && tempPosInArr.x >= 0 && tempPosInArr.y >= 0)
            return true;
        return false;
    }

    bool IsNotHeld(BoardItem item, Int2 pos)
    {
        for (int i = 0; i < item.Size.x; i++)
            for (int j = 0; j < item.Size.y; j++)
                if (board[pos.x + i, pos.y + j] != null)
                    return false;
        return true;
    }

    void FillBoard(BoardItem item, Int2 pos)
    {
        for (int i = 0; i < item.Size.x; i++)
            for (int j = 0; j < item.Size.y; j++)
                board[pos.x + i, pos.y + j] = item;
    }

    void ClearBoard(BoardItem item, Int2 pos)
    {
        for (int i = 0; i < item.Size.x; i++)
            for (int j = 0; j < item.Size.y; j++)
                board[pos.x + i, pos.y + j] = null;
    }

    //Vector3 DrawLineOfRoads(MultiSpriteResourceConductiveManager firstRoad)
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit, 100))
    //    {
    //        var tempCell = hit.collider.GetComponent<BoardItem>();
    //        if (tempCell != null)
    //        {
    //            var tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //            float roundX = Mathf.Round(tempPos.x);
    //            float roundY = Mathf.Round(tempPos.y);

    //            return new Vector3((int)roundX, (int)roundY);
    //        }
    //    }
    //    return firstRoad.PositionInWorld;
    //}

    //void PlaceRoads(Vector3 pos, MultiSpriteResourceConductiveManager firstRoad)
    //{
    //    if (pos.x == firstRoad.PositionInWorld.y)
    //        for (int i = 0; i < pos.x; i++)
    //        {
    //            if (IsInRange((int)pos.x, (int)pos.y))
    //                if (IsNotHeld(firstRoad as BoardItem, new Int2((int)pos.x, (int)pos.y)))
    //                {
    //                    Instantiate(roadObj, pos, Quaternion.identity);
    //                    FillBoard(firstRoad as BoardItem, new Int2((int)pos.x, (int)pos.y));
    //                }
    //        }
    //    else if (pos.x == firstRoad.PositionInWorld.x)
    //        for (int i = 0; i < pos.y; i++)
    //        {
    //            if (IsInRange((int)pos.x, (int)pos.y))
    //                if (IsNotHeld(firstRoad as BoardItem, new Int2((int)pos.x, (int)pos.y)))
    //                {
    //                    Instantiate(roadObj, pos, Quaternion.identity);
    //                    FillBoard(firstRoad as BoardItem, new Int2((int)pos.x, (int)pos.y));
    //                }
    //        }
    //}

    void PrintBoard()
    {
        string line;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            line = "";
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == null)
                    line += "-----,";
                else if (board[i, j])
                {
                    line += "boardItem-,";
                }
            }
            print(line);
        }
    }
}
