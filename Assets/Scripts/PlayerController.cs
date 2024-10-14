using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Camera playerCamera;

    public float speed = 5f;
    public float rotationSpeed = 2f;
    public bool isBuildMode = false;

    private void Start()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        if(playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    private void Update()
    {
        // Handle player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Handle camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * rotationSpeed, 0);
        playerCamera.transform.Rotate(-mouseY * rotationSpeed, 0, 0);

        // Handle build mode activation
        if(Input.GetKeyDown(KeyCode.B))
        {
            isBuildMode = !isBuildMode;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity/*,  Your layer mask here */)) // Replace with your layer mask
            {
                // Check if the hit object is a grid cell
                GridCell gridCell = hit.transform.GetComponent<GridCell>();
                if(gridCell != null)
                {
                    // Select the grid cell
                    SelectGridCell(gridCell);
                }
                else
                {
                    Debug.Log("non grid");
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.H) && selectedGridCell != null)
        {
            // Build a house on the selected grid cell
            BuildHouse(selectedGridCell);
        }

        //transform.Translate(new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime);
        //
        //// Handle camera rotation
        //if(Input.GetMouseButton(1))
        //{
        //    float mouseX = Input.GetAxis("Mouse X");
        //    float mouseY = Input.GetAxis("Mouse Y");
        //
        //    transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
        //    transform.Rotate(Vector3.left, mouseY * rotationSpeed * Time.deltaTime);
        //}
        //
        //// Handle build mode activation/deactivation
        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    buildMode = !buildMode;
        //    Cursor.visible = !buildMode;
        //}
        //
        //// Handle building placement
        //if(buildMode && Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //
        //    if(Physics.Raycast(ray, out hit, buildDistance, groundLayer))
        //    {
        //        if(buildingManager.CheckPlacementValidity(hit.point))
        //        {
        //            buildingManager.BuildBuilding(selectedBuilding, hit.point);
        //        }
        //    }
        //}
        //
        //// Handle building editing
        //if(Input.GetMouseButtonDown(0) && !buildMode)
        //{
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //
        //    if(Physics.Raycast(ray, out hit))
        //    {
        //        Building building = hit.collider.GetComponent<Building>();
        //        if(building != null)
        //        {
        //            EditBuilding(building.buildingData);
        //        }
        //    }
        //}
    }

    private GridCell selectedGridCell;

    private void SelectGridCell(GridCell gridCell)
    {
        Debug.Log("Clicked grid cell: X = " + gridCell.transform.position.x + ", Z = " + gridCell.transform.position.z);

        // Deselect the previous grid cell (if any)
        if(selectedGridCell != null)
        {
            selectedGridCell.Deselect();
        }

        // Select the new grid cell
        selectedGridCell = gridCell;
        selectedGridCell.Select();
    }

    private void BuildHouse(GridCell gridCell)
    {
        // Check if the grid cell is available for building
        if(BuildingManager.Instance.CheckGridAvailability(gridCell.transform.position))
        {
            // Build a house on the grid cell
            BuildingData houseData = BuildingData.House; // Assuming you have a House building data instance
            BuildingManager.Instance.BuildBuilding(houseData, gridCell.transform.position);
        }
    }

    void EditBuilding(BuildingData buildingData)
    {
        // Implement your edit menu logic here
        Debug.Log("Editing building: " + buildingData.name);
    }
    public void BuildMode()
    {
        // Implement logic to switch UI or display building selection options
    }

    public void PlaceBuilding(BuildingData buildingData)
    {
        // Implement logic to check if building can be placed
        // Instantiate building prefab at the targeted location
        if(BuildingManager.Instance.CheckPlacementValidity(buildingData.placementRule, buildingData.cost))
        {
            BuildingManager.Instance.BuildBuilding(buildingData, selectedGridCell.transform.position);
        }
    }

    //public float cameraHeight = 1.5f;
    //
    //public LayerMask groundLayer;
    //public float buildDistance = 3f;
    //
    //public Camera mainCamera;
    //public BuildingManager buildingManager;
    //
    //private bool buildMode = false;
    //private BuildingData selectedBuilding;
}