using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/* Save and Load Functions
 * 
 * reference: https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
 * 
 */
public class SaveLoad {

     public static Game data = new Game();

     public static void Save()
     {
          Stream stream = File.Create(Application.persistentDataPath+ "/SavedGame.game");
          Debug.Log("File saved at "+Application.persistentDataPath);
          BinaryFormatter bf = new BinaryFormatter();
          bf.Serialize(stream, Game.current);
          stream.Close();

     }

     public static void Load()
     {
          if (File.Exists(Application.persistentDataPath + "/SavedGame.game"))
          {
               BinaryFormatter bf = new BinaryFormatter();
               Stream stream = File.Open(Application.persistentDataPath + "/SavedGame.game", FileMode.Open);
               data = (Game)bf.Deserialize(stream);
               stream.Close();

               //load Game scene
               SceneManager.LoadScene(2);
          }
          
     }

     /*public static List<Game> savedGames = new List<Game>();

     public static void Save(){
          SaveLoad.savedGames.Add(Game.current);
          BinaryFormatter bf = new BinaryFormatter();
          FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
          bf.Serialize(file, SaveLoad.savedGames);
          file.Close();
     }

     public static void Load(){
          if (File.Exists(Application.persistentDataPath + "/savedGames.gd")){
               BinaryFormatter bf = new BinaryFormatter();
               FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
               SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
               file.Close();
          }
     }*/
}
