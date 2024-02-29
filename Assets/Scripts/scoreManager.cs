using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public int scorePlayer;
    public TextMeshProUGUI mensajeScore;
    public TextMeshProUGUI mensajeCombo;
    public TextMeshProUGUI mensajePublico;
    public int combo, failure;
    public AK.Wwise.Switch PublicoBien,PublicoPerfect, PublicoBad,PublicoVeryBad;
    public AK.Wwise.Switch porDos, porTres, porCuatro, porCinco, _normal;
    public AK.Wwise.Event Play_Modificador;
    public AudioManager _audio;
    enum SCORE_MULTIPLAYER
    {
        DOUBLE, TRIPLE, CUADRIPLE, PENTA, NORMAL
    };
    SCORE_MULTIPLAYER multiplayer = SCORE_MULTIPLAYER.NORMAL;

   // ESTADO_PUBLICO fallaste = ESTADO_PUBLICO.REGULAR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addScore(int score)
    {
        combo++;
        switch (multiplayer)
        {
            case SCORE_MULTIPLAYER.NORMAL:
                if (combo >= 5)
                {
                    multiplayer = SCORE_MULTIPLAYER.DOUBLE;
                    mensajeCombo.text = "Multiplayer: x2";
                    _audio.estadoPublico.SetGlobalValue(87f);
                    porDos.SetValue(this.gameObject);
                    Play_Modificador.Post(this.gameObject);


                }
                break;
            case SCORE_MULTIPLAYER.DOUBLE:
                    score *= 2;
                if (combo >= 10)
                {
                    multiplayer = SCORE_MULTIPLAYER.TRIPLE;
                    mensajeCombo.text = "Multiplayer: x3";
                    porTres.SetValue(this.gameObject);
                    Play_Modificador.Post(this.gameObject);
                }
                break;
            case SCORE_MULTIPLAYER.TRIPLE:
                score *= 3;
                if (combo >= 15)
                {
                    multiplayer = SCORE_MULTIPLAYER.CUADRIPLE;
                    mensajeCombo.text = "Multiplayer: x4";
                    porCuatro.SetValue(this.gameObject);
                    Play_Modificador.Post(this.gameObject);
                }
                break;
            case SCORE_MULTIPLAYER.CUADRIPLE:
                 score *= 4;
                if (combo >= 20)
                {
                    multiplayer = SCORE_MULTIPLAYER.PENTA;
                    mensajeCombo.text = "Multiplayer: x5";
                    mensajePublico.text = "Performance: Estas cabrón";
                    porCinco.SetValue(this.gameObject);
                    Play_Modificador.Post(this.gameObject);
                }
                break;
            case SCORE_MULTIPLAYER.PENTA:
                score *= 5;
                break;
            default:
                break;
        }
        scorePlayer += score;
        mensajeScore.text = $"Puntos:{scorePlayer}";
    }

    public void resetCombo()
    {
        combo = 0;
        multiplayer = SCORE_MULTIPLAYER.NORMAL;
        mensajeCombo.text = "Multiplayer: Normal";

    }

   public void addFailure()
    {
        failure++;

            if (failure >=10)
            {
                _audio.estadoPublico.SetGlobalValue(11f);
                mensajePublico.text = "Performance: Ya me quiero ir";
            }
            else if (failure >= 5)
                {
                _audio.estadoPublico.SetGlobalValue(34f);
                mensajePublico.text = "Performance: Malo";
                }
    } 

    
    public void resetFailure()
    {
        AkSoundEngine.SetSwitch("Modificadores", "Normal", this.gameObject);
        failure = 0;
        mensajePublico.text = "Performance: Regular";
        
    }


}
