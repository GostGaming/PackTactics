using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Grid {
    private int _width; 
    private int _height;
    private static float _cellSize;
    private int[,] _gridArray;
    private static Camera _camera;
    public Grid(int width, int height, float cellSize) {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _gridArray = new int[width, height];
        _camera = Camera.main;
        
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Debug.DrawLine(
                    GetWorldPosition(x,y), GetWorldPosition(x, y + 1), Color.white, 1000f, false
                );
                Debug.DrawLine(
                    GetWorldPosition(x,y), GetWorldPosition(x + 1, y), Color.white, 1000f, false
                );
            }
        }
        Debug.DrawLine(
            GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 1000f, false
        );
        Debug.DrawLine(
            GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 1000f, false
        );
    }

    private static Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * _cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

    public void SetValue(int x, int y, int value) {
        if (x < 0 || x >= _width || y < 0 || y >= _height) { return; }
        _gridArray[x, y] = value;
    }

    public void SetValue(Vector3 worldPosition, int value) {
        GetXY(worldPosition, out int x, out int y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x < 0 || x >= _width || y < 0 || y >= _height) { return 0; }
        return _gridArray[x, y];
    }

    public int GetValue(Vector3 worldPosition) {
        GetXY(worldPosition, out int x, out int y);
        return GetValue(x, y);
    }
    
    public static Vector3 GetMouseWorldPositon() {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        if (!_camera) return new Vector3();
        Ray ray = _camera.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, 0));
        return ray.origin;
    }
}

//public class HexGrid : MonoBehaviour {
//    [SerializeField] private Transform pfSquare;
//
//    private GridXZ<GridObject> gridXZ;
//
//    private class GridObject { /* TODO */ }
//
//    private void Awake() {
//        int width = 10;
//        int height = 6;
//        float cellSize = 1f;
//        gridXZ = new GridXZ<GridObject>(width, height, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int y)) => new GridObject();
//
//        for (int x = 0; x < width; x++) {
//            for (int z = 0; z < height; z++) {
//                Intantiate(pfSquare, gridXZ.GetWorldPosition(x, z), Quaternion.identity);
//            }
//        }
//    }
//}
