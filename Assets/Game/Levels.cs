using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Levels : MonoBehaviour
{
    public void RestartLevel()
    {
        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ����� � ��� �� ��������, ��� � �������
        SceneManager.LoadScene(currentSceneIndex);
    }
}
