using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BlockSpawner : MonoBehaviour
{
    [Header("Block Settings")]
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float swingSpeed = 2f;
    [SerializeField] private float swingWidth = 5f;
    [SerializeField] private float spawnHeightOffset = 5f;

    [Header("Game Settings")]
    [SerializeField] private float maxTiltAngle = 30f;
    [SerializeField] private Transform towerTop;

    public GameObject replayButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI perfectPlacementText; 

    private GameObject currentBlock;
    private GameObject lastBlock;
    private float time;
    private bool gameOver = false;

    private int blockCount = 0;
    private int imperfectPlacements = 0;
    private float swayStrength = 1f;

    void Start()
    {
        SpawnBlock(Vector3.up * spawnHeightOffset);
        perfectPlacementText.gameObject.SetActive(false); // Hide perfect message initially
    }

    void Update()
    {
        if (gameOver) return;

        if (currentBlock != null)
        {
            time += Time.deltaTime * swingSpeed;
            float x = Mathf.Sin(time) * swingWidth;
            Vector3 pos = currentBlock.transform.position;
            pos.x = x;
            currentBlock.transform.position = pos;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                DropCurrentBlock();
            }

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                DropCurrentBlock();
            }
#endif
        }

        if (lastBlock != null)
        {
            Rigidbody rb = lastBlock.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float tiltAngle = Vector3.Angle(Vector3.up, rb.transform.up);

                if (tiltAngle > maxTiltAngle)
                {
                    TriggerGameOver();
                }
            }
        }
    }

    void DropCurrentBlock()
    {
        currentBlock.GetComponent<Rigidbody>().isKinematic = false;

        bool isPerfect = false;

        if (lastBlock != null)
        {
            float distanceX = Mathf.Abs(currentBlock.transform.position.x - lastBlock.transform.position.x);
            float distanceZ = Mathf.Abs(currentBlock.transform.position.z - lastBlock.transform.position.z);

            float allowedTolerance = 0.5f;

            if (distanceX > allowedTolerance || distanceZ > allowedTolerance)
            {
                if (imperfectPlacements < 15)
                {
                    swayStrength += 0.1f;
                    imperfectPlacements++;
                }
            }
            else
            {
                isPerfect = true;
                ShowPerfectPlacementMessage();
            }
        }

        lastBlock = currentBlock;
        currentBlock = null;

        if (towerTop != null)
        {
            towerTop.position = lastBlock.transform.position;
        }

        // Realistic shake after tower is tall
        if (blockCount >= 10)
        {
            AddRandomSwayForce(lastBlock);
        }

        Invoke(nameof(SpawnNextBlock), 0.5f);
    }

    void SpawnNextBlock()
    {
        Vector3 spawnPos = lastBlock.transform.position + Vector3.up * spawnHeightOffset;
        SpawnBlock(spawnPos);

        blockCount++;
        scoreText.text = "Score: " + blockCount;

        swingSpeed = 2f + swayStrength;
    }

    void SpawnBlock(Vector3 position)
    {
        currentBlock = Instantiate(blockPrefab, position, Quaternion.identity);
        currentBlock.GetComponent<Rigidbody>().isKinematic = true;

        float randomX = Random.Range(4.5f, 6.0f);
        float randomZ = Random.Range(4.5f, 6.0f);
        currentBlock.transform.localScale = new Vector3(randomX, 2f, randomZ);

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        currentBlock.GetComponent<Renderer>().material.color = randomColor;

        time = 0f;
    }

    void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        gameOver = true;
        Time.timeScale = 0.5f;
        replayButton.SetActive(true);
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void AddRandomSwayForce(GameObject block)
    {
        if (block != null)
        {
            Rigidbody rb = block.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomForce = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
                rb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }

    void ShowPerfectPlacementMessage()
    {
        perfectPlacementText.gameObject.SetActive(true);
        CancelInvoke(nameof(HidePerfectPlacementMessage)); // in case a previous hide is pending
        Invoke(nameof(HidePerfectPlacementMessage), 1.0f);
    }

    void HidePerfectPlacementMessage()
    {
        perfectPlacementText.gameObject.SetActive(false);
    }
}