using Data;
using Items.Data;
using JetBrains.Annotations;
using Units.Data;
using UnityEngine;
using UnityEngine.UIElements;

namespace Units.Controllers {
    public class UnitController : MonoBehaviour {
        public GameObject movementAreaHighlight;
        public GameObject attackAreaHighlight;
        private ICharacterUnit _unit;
        private Vector3 _unitStartPosition;
        private Actions _currentAction;
        private GameObject[,] _highlightArea;
        void Start()
        {
            _unitStartPosition = transform.position;
            _unit = GetComponent<ICharacterUnit>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        [UsedImplicitly]
        public void OnAttackButton() {
            _currentAction = Actions.ATTACKING;
            ShowAttackArea();
        }

        [UsedImplicitly]
        public void OnMovementButton() {
            _currentAction = Actions.MOVING;
            ShowMovementArea();
        }
        
        public void OnMouseDown() {
            // When unit is clicked, show movement range, then action range when action is selected
            _currentAction = Actions.MOVING;
            // TODO: highlight character
        }

        private void ShowMovementArea() {
            int movementRadius = _unit.speed;
            CreateHighlightArea(movementAreaHighlight, movementRadius);
        }

        private void ShowAttackArea() {
            int attackRadius = _unit.equippedWeapon.range;
            CreateHighlightArea(attackAreaHighlight, attackRadius);
        }
        
        [UsedImplicitly]
        public void HideAreas() {
            foreach (GameObject obj in _highlightArea) {
                Destroy(obj);
            }
            _currentAction = Actions.NONE;
        }

        private void CreateHighlightArea(GameObject highlightTile, int radius) {
            _highlightArea = new GameObject[radius, 6];
            for (int i = 0; i < radius; i++) {
                for (int j = 0; j < 6; j++) {
                    _highlightArea[i, j] = Instantiate(highlightTile, transform);
                }
            }

            for (int i = 0; i < radius; i++) {
                _highlightArea[i, 0].transform.position = _unitStartPosition + Vector3.right;
                _highlightArea[i, 1].transform.position = _unitStartPosition + Vector3.left;
                    
                _highlightArea[i, 2].transform.position = _unitStartPosition + Vector3.forward;
                _highlightArea[i, 3].transform.position = _unitStartPosition + Vector3.back;
              
                _highlightArea[i, 4].transform.position = _unitStartPosition + new Vector3(-i, 0, -i);
                _highlightArea[i, 5].transform.position = _unitStartPosition + new Vector3(i, 0, i);
            }
        }

        private enum Actions {
            MOVING,
            ATTACKING,
            NONE
        }
    }
}
