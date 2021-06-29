using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] EnemySpawner[] enemies;
    [SerializeField] float delay,min,max;
    public Levels[] levels;
    public Levels currentLevel;
    public LevelxD currentLevelxD;
    public int level;
    int rndEnemyNum;
    bool loop = true;

    public int UIvurulmasıgereken;
    public GameObject levelLoadingImage;
    public GameObject gameOverScreen;
    public Sprite currentTargetIcon;

    void Start()
    {
        level = 1;
        currentLevel = levels[0];
        currentLevelxD = new LevelxD(currentLevel);
        StartCoroutine(PickASpawnPoint());
    }

    private IEnumerator PickASpawnPoint()
    {
        while (loop)
        {
            loop = false;
            rndEnemyNum = UnityEngine.Random.Range(0,enemies.Length);
            delay = UnityEngine.Random.Range(min,max);
            enemies[rndEnemyNum].selectedAnimal = SelectAnimal();
            enemies[rndEnemyNum].isAvailable = true;
            yield return new WaitForSeconds(delay);
            loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UIvurulmasıgereken = currentLevelxD.vurulmasıGereken - currentLevelxD.vurulan;
        currentTargetIcon = currentLevelxD.animalIcon;
        foreach (var enemy in enemies)
        {

        }
       
    }

    public GameObject SelectAnimal()
    {
        bool isCowExist = currentLevelxD.cowCount > 0;
        bool isChickenExist = currentLevelxD.chickenCount > 0;
        bool isPigExist = currentLevelxD.pigCount > 0;

        while(isCowExist || isChickenExist || isPigExist)
        {
            int randomSayı = UnityEngine.Random.Range(0, 3);
            switch (randomSayı)
            {
                case 0:
                    if (isPigExist)
                    {
                        currentLevelxD.pigCount -= 1;
                        return currentLevel.Pig;
                    }
                    break;
                case 1:
                    if (isCowExist)
                    {
                        currentLevelxD.cowCount -= 1;
                        return currentLevel.Cow;
                    }
                    break;
                case 2:
                    if (isChickenExist)
                    {
                        currentLevelxD.chickenCount -= 1;
                        return currentLevel.Chicken;
                    }
                    break;
                default:
                    break;
            }
        }
        NextLevel();
        return null;
    }

    public void NextLevel()
    {
        StopAllCoroutines();

        if (currentLevelxD.vurulan >= currentLevelxD.vurulmasıGereken)
        {
            StartCoroutine(NextLevelIenum());
            levelLoadingImage.SetActive(true);
        }
        else
        {
            Debug.Log("Level Failed");

            StartCoroutine(showgameOverScreen());
        }
        
    }

    IEnumerator showgameOverScreen()
    {
        yield return new WaitForSeconds(5);
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "the level will start again";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }

    IEnumerator NextLevelIenum()
    {
        //Level dEİĞİŞİRKen ki bekleme süresi
        yield return new WaitForSeconds(3f);
        levelLoadingImage.SetActive(false);
        level += 1;
        currentLevel = levels[level - 1];
        currentLevelxD = new LevelxD(currentLevel);
        loop = true;
        StartCoroutine(PickASpawnPoint());
        yield return null;
    }
}

[System.Serializable]
public class LevelxD
{
    public int cowCount;
    public int pigCount;
    public int chickenCount;
    public int vurulan = 0;
    public int vurulmasıGereken;
    public Animals vur;
    public Sprite animalIcon;

    public LevelxD(Levels levels)
    {
        cowCount = levels.cowCount;
        pigCount = levels.pigCount;
        chickenCount = levels.chickenCount;
        vur = levels.vurulmasıGereken;
        vurulmasıGereken = levels.vurulmasıGerekenSayı;
        animalIcon = levels.targetAnimalIcon;

    }
}