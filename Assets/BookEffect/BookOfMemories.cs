using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookOfMemories : MonoBehaviour {

    public GameObject m_Particles;

    public GameObject m_Camera;

    public LayerMask m_BookLayer;

    public BookControl m_OpenBook;

   // public ScreenFader m_Fader;

    public Vector3 m_FinalParticleSize;
    public float m_MoveDuration = 5f;
    public float m_MoveDelay = 2f;

    public int m_SceneToLoad;

    private bool _BookTriggered;
	
	// Update is called once per frame
	void Update () {

        if (_BookTriggered) return;

        RaycastHit raycastHit;

        if (Physics.Raycast(new Ray(m_Camera.transform.position, m_Camera.transform.forward), out raycastHit, 5, m_BookLayer))
        {
            m_OpenBook.Open_Book();
            m_Particles.SetActive(true);

            _BookTriggered = true;

            m_Particles.transform.DOMove(m_Camera.transform.position, m_MoveDuration).SetDelay(m_MoveDelay);
            m_Particles.transform.DOScale(m_FinalParticleSize, m_MoveDuration).SetDelay(m_MoveDelay).OnComplete(delegate {
               // m_Fader.FadeOut(OnCompletedMove);
            });
        }
	}

    void OnCompletedMove()
    {
        SceneManager.LoadScene(m_SceneToLoad);
    }
}
