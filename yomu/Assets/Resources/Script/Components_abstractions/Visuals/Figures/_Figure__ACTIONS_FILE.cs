using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public abstract partial class Figure{


        public virtual void Change_mode( Figure_mode _visual ){

            current_mode.Deactivate();
            current_mode = modes.Get( _visual );

            return;
            
        }

        public virtual void Change_direction( Figure_mode_direction _new_direction ){


            current_mode.Change_direction( _new_direction );
            

            return;
            
        }




        public virtual void Blick( Blink_data _data ){ 

            current_mode.Blink( _data ); 

            if( current_mode_type != transition_mode_type )
                { transition_mode.Blink( _data ); }

        }

        public virtual void Speak( Speak_data _data = default ){ 

            Console.Log( "veio speak" );
            current_mode.Speak( _data ); 

            if( current_mode_type != transition_mode_type )
                { transition_mode.Speak( _data ); }

        }


        //mark
        // ** emoji ficaria em cima da figure e nao de cada mode_quad
        public virtual void Activate_emoji( Figure_mode_emoji _emoji ){ current_mode.Activate_emoji( _emoji ); }


        // public void Focus( bool _is_focus ){ Set_focus( _is_focus ); }



}