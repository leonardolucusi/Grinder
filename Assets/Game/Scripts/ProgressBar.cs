using TMPro;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float maxXp = 1000f;
    public int currentXP = 0;
    public GameObject player;
    private PlayerCombat playerCombat;
    public Transform xp;
    private void Awake()
    {
        playerCombat = player.GetComponent<PlayerCombat>();
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        xp.GetComponent<TextMeshProUGUI>().text = playerCombat.xp.ToString();
        SetSliderValue(playerCombat.xp);
    }

    void SetSliderValue(int xp)
    {
        float normalizedValue = Mathf.Clamp01((float)xp / maxXp);
        slider.value = normalizedValue;
    }
}
