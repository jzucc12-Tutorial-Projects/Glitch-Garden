using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] int attackerNum = 0;
    [SerializeField] float winWaiter = 3.5f;
    bool levelTimerFinished = false;


    private void Start()
    {
        winLabel.SetActive(false);
    }
    // Start is called before the first frame update
    public void AttackerSpawned()
    {
        attackerNum++;
    }

    // Update is called once per frame
    public void AttackerKilled()
    {
        attackerNum--;
        if (attackerNum <= 0 && levelTimerFinished)
            StartCoroutine(HandleWinCondition());
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        //Play SFX with Audio Source
        yield return new WaitForSeconds(winWaiter);
        GetComponent<SceneLoader>().LoadNextLevel();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

}
