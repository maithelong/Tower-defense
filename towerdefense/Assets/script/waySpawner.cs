using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waySpawner : MonoBehaviour
{
    public Transform eneyFrefab;
    public Transform spawnPoint;
    public float timeBetweenWave = 5f;
    private float countDown = 2f;
    private int wayIndex = 0;
    public Text wayCountDownText;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(countDown<=0f)
        {
            StartCoroutine(spawnWay());
            countDown = timeBetweenWave;
        }    
        countDown-=Time.deltaTime;
        wayCountDownText.text =Mathf.Round(countDown).ToString();//Mathf.Round() dùng để làm tròn số 
    }
    IEnumerator spawnWay()
    { 
        wayIndex++;
        for(int i=0; i < wayIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
       
    }
    void spawnEnemy()
    {
        Instantiate(eneyFrefab, spawnPoint.position, spawnPoint.rotation);
    }    
}
