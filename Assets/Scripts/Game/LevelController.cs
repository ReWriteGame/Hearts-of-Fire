using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelController")]
public class LevelController : ScriptableObject
{
  
 
    [SerializeField] private int savedLevel = 0;




    public void loadNextLevelCor()
    {
        int numberOfLevel = SceneManager.GetActiveScene().buildIndex;// получаем номер уровня
        if (numberOfLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberOfLevel);// загрузка след уровня номер можно посмотреть через shift + ctrl + b
    }

    public void loadLastLevelCor()
    {

        SceneManager.LoadScene(savedLevel);

    }

    public void reStartLevelCor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void loadLevelCor(int numLevel)
    {
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(numLevel);

    }

    public void exitCor()
    {
        Application.Quit();
        //print("exit game");

    }
}