using System;
using UnityEngine;


public abstract class Input_device {


        public string nome_modulo = "Not_give";

        public virtual bool Get_action( int _acao ){ throw new Exception(""); }
        public virtual bool Get_action_down( int _acao ){ throw new Exception(""); }
        public virtual bool Get_action_up( int _acao ){ throw new Exception(""); }

        public virtual float Get_value_axis( int _axe ){ throw new Exception("");}

        public virtual void Atualizar_key_bind( KeyCode[] _binds ){ throw new Exception(""); }
        public virtual void Atualizar_acoes_bloqueadas( bool[] _acoes_bloqueadas ){ throw new Exception(""); }

        public abstract void Update();

        public virtual char[] Pegar_teclas(){ throw new Exception(""); }


}