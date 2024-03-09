using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public class SaveObject {
        public Vector3 PlayerPostion;
        public float PlayerHealth;
        public int NumberOfGEMS;
        public List<GameObject> ActiveGems;
    }

    [SerializeField] private PlayerController PlayerInfo;
    [SerializeField] private Collect Gems;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            Load();
        }
    }

    private void Save() {
        SaveObject saveObject = new SaveObject {
            PlayerPostion = PlayerInfo.gameObject.transform.position,
            PlayerHealth = PlayerInfo.Health,
            NumberOfGEMS = Gems.GEMS,
            ActiveGems = Gems.GEMSList
        };
        string Json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/Data", Json);
    }

    private void Load() {
        if(File.Exists(Application.dataPath + "/Data")) {
            string Data = File.ReadAllText(Application.dataPath + "/Data");
            SaveObject LoadedObject = JsonUtility.FromJson<SaveObject>(Data);
            PlayerInfo.gameObject.transform.position = LoadedObject.PlayerPostion;
            PlayerInfo.Health = LoadedObject.PlayerHealth;
            Gems.GEMS = LoadedObject.NumberOfGEMS;
            Gems.GEMSList = LoadedObject.ActiveGems;
        }
        Gems.Return();
    }
}