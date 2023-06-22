using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update

    public float movementThreshold = 3f;
    public string enemyTag = "Enemy";
    public string ballObjectname = "Ball";
    private Rigidbody ballRigidBody;
    void Start()
    {
        GameObject ball = GameObject.Find(ballObjectname);
        ballRigidBody = ball.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (ballRigidBody.velocity.magnitude <= movementThreshold
        && enemies.Length != 0 
        && transform.Find("Ball") == null)
        {
            Invoke(nameof(ReloadLevel), 2f);
        }
        Debug.Log(ballRigidBody.velocity.magnitude);
        if (enemies.Length == 0){
            Invoke(nameof(nextLevel),2f);
        }

    }
    void nextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
