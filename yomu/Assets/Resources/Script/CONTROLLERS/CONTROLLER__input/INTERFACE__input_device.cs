using System;
using UnityEngine;


public interface INTERFACE__input_device {



        public bool Get_action( int _acao ){ throw new Exception(""); }
        public bool Get_action_down( int _acao ){ throw new Exception(""); }
        public bool Get_action_up( int _acao ){ throw new Exception(""); }

        public float Get_value_axis( int _axe ){ throw new Exception("");}

        public void Atualizar_key_bind( KeyCode[] _binds ){ throw new Exception(""); }
        public void Atualizar_acoes_bloqueadas( bool[] _acoes_bloqueadas ){ throw new Exception(""); }

        public void Update(){}

        public char[] Pegar_teclas(){ throw new Exception(""); }


}