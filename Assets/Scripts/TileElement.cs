using UnityEngine;

public class TileElement : MonoBehaviour
{
    private bool isDragging = false;
    private bool isMoving = false;
    private bool isCollidingWithCell = false;
    private Vector3 offset;

    private Cell currentCell;
    private Cell cellTemp;

    private void Start()
    {
        GetCurrentCell();
    }

    private void Update()
    {
        if (isMoving && !isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    offset = transform.position - hit.point;
                    isDragging = true;
                }
            }
        }

        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point + offset;
            }
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
        isDragging = false;

        if (isCollidingWithCell && currentCell != cellTemp)
        {
            if (cellTemp.isEmpty)
            {
                ResetPosition();
                gameObject.SetActive(false);
                currentCell.isEmpty = true;
                cellTemp.isEmpty = false;
                cellTemp.currentAnimalTier = currentCell.currentAnimalTier;
                currentCell.currentAnimalTier = 0;
                cellTemp.animals[cellTemp.currentAnimalTier].SetActive(true);
            }
            else if (!cellTemp.isEmpty)
            {
                if (cellTemp.currentAnimalTier == currentCell.currentAnimalTier && cellTemp.currentAnimalTier + 1 < cellTemp.animals.Length)
                {
                    ResetPosition();
                    Merge();
                }
                else
                {
                    ResetPosition();
                    Swap();
                }
            }
        }
        else ResetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Cell>())
        {
            isCollidingWithCell = true;

            cellTemp = other.GetComponent<Cell>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Cell>()) isCollidingWithCell = false;
    }

    private void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
    }

    private void Swap()
    {
        HideAllAnimals(currentCell);
        HideAllAnimals(cellTemp);

        int tier = currentCell.currentAnimalTier;

        currentCell.currentAnimalTier = cellTemp.currentAnimalTier;
        cellTemp.currentAnimalTier = tier;

        currentCell.animals[currentCell.currentAnimalTier].SetActive(true);
        cellTemp.animals[cellTemp.currentAnimalTier].SetActive(true);
    }

    private void Merge()
    {
        HideAllAnimals(currentCell);
        HideAllAnimals(cellTemp);

        currentCell.isEmpty = true;

        cellTemp.currentAnimalTier = currentCell.currentAnimalTier;
        currentCell.currentAnimalTier = 0;

        cellTemp.currentAnimalTier++;
        cellTemp.animals[cellTemp.currentAnimalTier].SetActive(true);
    }

    private void GetCurrentCell()
    {
        currentCell = transform.parent.transform.parent.GetComponent<Cell>();
    }

    private void HideAllAnimals(Cell cell)
    {
        for (int i = 0; i < cell.animals.Length; i++)
        {
            cell.animals[i].SetActive(false);
        }
    }
}
