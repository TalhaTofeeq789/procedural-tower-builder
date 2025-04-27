using UnityEngine;
  using UnityEngine.SceneManagement;

  public class GameManager : MonoBehaviour
  {
      public Transform towerBase;
      public float maxTiltAngle = 30f;

      void Update()
      {
          float tilt = Vector3.Angle(Vector3.up, towerBase.up);
          if (tilt > maxTiltAngle)
          {
              Debug.Log("Game Over");
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }
      }
  }