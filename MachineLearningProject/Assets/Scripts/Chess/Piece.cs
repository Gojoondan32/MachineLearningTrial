using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
    private void OnMouseUp() {
        //Put it in the right position
        GridPosition exitPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        Debug.Log(exitPosition.x);
        Debug.Log(exitPosition.y);
        transform.position = LevelGrid.Instance.GetWorldPosition(exitPosition);
        
    }
    private void OnMouseExit() {
        
    }
}
