using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WaveNumber;

    void UpdateWaveNumber(object sender, DataEventArgs<int> e)
    {
        WaveNumber.text = e.Data.ToString();
    }


}
