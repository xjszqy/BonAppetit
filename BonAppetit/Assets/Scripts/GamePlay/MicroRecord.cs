using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroRecord : MonoBehaviour
{
    public AudioSource audioSource;
    public float[] volumeBuffer = new float[1024];
    public float[] pitchBuffer = new float[512];
    public float volume = 0;
    public float pitch = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.loop = true;
        string deviceName = Microphone.devices[0].ToString();
        audioSource.clip = Microphone.Start(deviceName, true, 1, AudioSettings.outputSampleRate);
        while(!(Microphone.GetPosition(deviceName)>0))
        {
            ;
        }
        audioSource.Play();
    }
    private void Update()
    {
        volume=GetMaxVolume()*60;
        pitch=GetMaxPitch();
        
    }
    public float GetMaxVolume()
    {
        audioSource.GetOutputData(volumeBuffer, 0);
        float maxVolume = 0;
        for(int i = 0; i < volumeBuffer.Length; i++)
        {
            if (volumeBuffer[i] > maxVolume)
            {
                maxVolume = volumeBuffer[i];
            }
        }
        return maxVolume;
    }
    float ConvertIndexToFrequency(int index, int fftSize, float sampleRate)
    {
        // Unity�е�Ƶ�����ݴ�0Hz��ʼ����NyquistƵ�ʽ����������ʵ�һ�룩
        float nyquistFrequency = sampleRate * 0.5f;
        float binWidth = nyquistFrequency / (fftSize - 1); // ÿ��FFT���bin��Ӧ��Ƶ�ʿ��

        // ����ʵ��Ƶ��
        float frequency = binWidth * index;

        return frequency;
    }

    // ��GetMaxPitch������ʹ�ô˺���
    public float GetMaxPitch()
    {
        audioSource.GetSpectrumData(pitchBuffer, 0, FFTWindow.Hanning);

        float maxPitchForce = 0f;
        int maxPitchIndex = 0;

        for (int i = 0; i < pitchBuffer.Length; i++)
        {
            if (pitchBuffer[i] > maxPitchForce)
            {
                maxPitchForce = pitchBuffer[i];
                maxPitchIndex = i;
            }
        }

        // ������������ת��ΪƵ��
        float maxPitchFrequency = ConvertIndexToFrequency(maxPitchIndex, pitchBuffer.Length, AudioSettings.outputSampleRate);
       
        // ���ص���Ƶ��ֵ��������
        return maxPitchFrequency;
    }

}
