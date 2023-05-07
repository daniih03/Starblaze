using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCamShake : MonoBehaviour
{
private CinemachineVirtualCamera VC;

private CinemachineBasicMultiChannelPerlin multichannelperlin;

private float Duration, TotalDuration, TotalIntensity;

public static CinemachineCamShake instance;


private void Awake()
{
    VC = GetComponent<CinemachineVirtualCamera>();
    multichannelperlin = VC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

instance = this;


}

public void MoverCamara(float intensidad, float frecuencia, float tiempo)
{
    multichannelperlin.m_AmplitudeGain = intensidad;
    multichannelperlin.m_FrequencyGain = frecuencia;
    TotalIntensity = intensidad;
    TotalDuration = tiempo;
    Duration = tiempo;
}

private void Update()
{
    if(Duration > 0)
    {
        Duration -=Time.deltaTime;
        multichannelperlin.m_AmplitudeGain = Mathf.Lerp(TotalIntensity, 0, 1-(Duration/TotalDuration));
    }
}


}
