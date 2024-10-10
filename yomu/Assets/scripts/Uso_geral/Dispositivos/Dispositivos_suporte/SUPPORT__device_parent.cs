using System;
using UnityEngine;


public static class SUPPORT__device_parent {


        public static void Anexar_dispositivo( GameObject _pai, Dispositivo _device ){



                if( _pai == null )
                    { throw new Exception( $"Tentou Anexar o dipositivo { _device.interface_dispositivo.Get_name() } mas o game_object <color=red><b>pai</b></color> estava null"); }

                _device.dispositivo_game_object.transform.SetParent( _pai.transform, false );
                _device.dados_dispositivo.path_para_o_dispositivo = GAME_OBJECT.Pegar_path( _device.dispositivo_game_object );

                return;
            
        }

        public static void Mudar_pai_dispositivo( GameObject _pai, Dispositivo _device ){

            // --- VERIFICACOES
            if( _device.dispositivo_game_object == null )
                { throw new Exception( $"Em mudar pai do dispositivo { _device.interface_dispositivo.Get_name() } o game_pobject do dispositivo estava null"); }

            if( _pai == null )
                { throw new Exception( $"Em mudar pai do dispositivo { _device.interface_dispositivo.Get_name() } o pai estava null" ); }
            
            string path_pai = GAME_OBJECT.Pegar_path( _pai );
            string novo_path = ( path_pai + "/" + _device.interface_dispositivo.Get_name() );

            _device.dados_dispositivo.path_para_o_dispositivo = novo_path;

            _device.dispositivo_game_object.transform.SetParent( _pai.transform, false );

            return;

        }


}