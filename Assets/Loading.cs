using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public LoadingBar loadingBar;
    public static float h_Percent;
    public TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        h_Percent = 0;
        loadingBar.SetMaxValue(h_Percent);
    }

    // Update is called once per frame
    void Update()
    {
        if (h_Percent < 100)
        {
            h_Percent += 0.3f;
            loadingBar.SetValue((float)h_Percent);
            textMeshProUGUI.text = "" + (int)h_Percent + "%";
        }
        else
        {
            if(h_Percent >= 100) {
                h_Percent = 0;
                loadingBar.SetValue(0);
            }
        }



    }
}
