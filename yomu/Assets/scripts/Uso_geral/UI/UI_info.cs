using System;
using UnityEngine;


public class UI_info {



    public GameObject game_object;
    public Tipo_UI tipo;
    public Action Mostrar;
    public Action Esconder;
    public Action< bool[] , bool > Mudar_visibilidade;

    public UI_info( GameObject _game_object = null , Tipo_UI _tipo = Tipo_UI.nada , Action< bool[] , bool> _mudar_visibilidade = null ,  Action _esconder = null , Action _mostrar = null){

        this.game_object = _game_object;
        this.Esconder = _esconder;
        this.Mostrar = _mostrar;
        this.tipo = _tipo ;
        this.Mudar_visibilidade = _mudar_visibilidade;

    }

}
