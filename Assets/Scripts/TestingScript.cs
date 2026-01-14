using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class TestingScript : MonoBehaviour
{
    private Grid _grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        _grid = new Grid(20, 10, 10F);
    }

    // Update is called once per frame
    private void Update() {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame) {
            Vector3 pos = Grid.GetMouseWorldPositon();
            Random num = new Random();
            _grid.SetValue(pos, num.Next());
            Debug.Log(pos.x + ", " + pos.y);
        }

        if (mouse.rightButton.wasPressedThisFrame) {
            Debug.Log(_grid.GetValue(Grid.GetMouseWorldPositon()));
        }
    }
}
