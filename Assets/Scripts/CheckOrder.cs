using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckOrder : MonoBehaviour
{
    public Transform sun;

    public Transform[] planets;

    // correct radii (same as orbits)
    public float[] correctRadii = { 12.5f, 18f, 24f, 33f, 53f, 67f, 78f, 93f };

    // correct planet order
    public string[] correctNames = {
        "Mercury", "Venus", "Earth", "Mars",
        "Jupiter", "Saturn", "Uranus", "Neptune"
    };

    public float tolerance = 2f; // allow small error

    public GameObject winPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CheckPlanets();
        }
    }


    public void CheckPlanets()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            float distance = Vector3.Distance(planets[i].position, sun.position);

            // check if correct orbit
            if (Mathf.Abs(distance - correctRadii[i]) > tolerance)
            {
                Debug.Log("❌ Wrong order!");
                return;
            }

            // check if correct planet in that orbit
            if (planets[i].name != correctNames[i])
            {
                Debug.Log("❌ Wrong planet position!");
                return;
            }
        }

        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("✅ Correct Order! YOU WIN 🎉");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}