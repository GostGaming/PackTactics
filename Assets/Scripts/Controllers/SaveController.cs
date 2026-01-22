using System.IO;
using Data;
using UnityEngine;

namespace Controllers { 
    public class SaveController : MonoBehaviour {

        private string _saveLocation;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start() {
            _saveLocation = Path.Combine(Application.persistentDataPath, "SaveData.json");
            LoadGame();
        }

        public void SaveGame() {
            SaveData saveData = new SaveData {
                playerPosition = GetPlayer().transform.position,
            };
            
            File.WriteAllText(_saveLocation, JsonUtility.ToJson(saveData));
        }

        public void LoadGame() {
            if (File.Exists(_saveLocation)) {
                SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_saveLocation));
                GetPlayer().transform.position = saveData.playerPosition;
            } else { 
                SaveGame();
            }
        }

        private GameObject GetPlayer() {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }
}
