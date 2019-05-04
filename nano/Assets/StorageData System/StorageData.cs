using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class StorageData{
    public static BaseModel LoadData(string path){
        string fullPath = Application.persistentDataPath + "/" + path + ".tce"; // tce is ta certo extension
        if(!File.Exists(fullPath))
            return default(BaseModel);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(fullPath, FileMode.Open);
        BaseModel data = (BaseModel) bf.Deserialize(fs);
        fs.Close();
        return data;
    }
    public static bool SaveData(BaseModel data, string path){
        if(path == ""){
            Debug.LogWarning("WARNING STORAGE DATA: ID PATH NAME IS EMPTY");
        }
        if(!data.GetType().IsSerializable){
            Debug.LogError("StorageData.SaveData<T>: NOT SERIALIZABLE CLASS TYPE CARAI!!!");
            return false;
        }
        BinaryFormatter bf = new BinaryFormatter();
        string fullPath = Application.persistentDataPath + "/" + path + ".tce";
        FileStream fs = new FileStream(fullPath, FileMode.Create);
        bf.Serialize(fs, (BaseModel)data);
        fs.Close();
        return true;
    }
}