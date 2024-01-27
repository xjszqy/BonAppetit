using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransfer : MonoBehaviour
{
    #region �ֶ�

    public AudioSource CurInput;

    [SerializeField] private float volume;
    [SerializeField] private float tune;
    [SerializeField] private float length;
    private string recordDevice;
    private AudioClip microphoneRecode;

    #endregion

    #region Unity�ص�
    void Start()
    {
        recordDevice = Microphone.devices[0];
        StartCoroutine(autoRecordSinging());
    }

    private void Update()
    {

    }

    #endregion

    #region ����

    private IEnumerator autoRecordSinging()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            microphoneRecode = Microphone.Start(recordDevice, true, 1, 44100);
        }
    }

    #endregion

}
