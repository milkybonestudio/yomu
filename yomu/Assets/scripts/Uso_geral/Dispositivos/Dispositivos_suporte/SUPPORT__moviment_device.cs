using System;
using UnityEngine;


public static class SUPPORT__moviment_device {


        public static void Mover_dispositivo( float _quantidade_para_adicionar_X,  float _quantidade_para_adicionar_Y, Dispositivo _device ){

                // --- VERIFICACOES
                if( _device.dispositivo_game_object == null )
                    { throw new System.Exception( $"Tentou mover o dipositivo { _device.interface_dispositivo.Pegar_nome() } mas o game_object estava null"); }

                Vector3 posicao_atual = _device.dispositivo_game_object.transform.localPosition;
                Vector3 nova_posicao = ( posicao_atual + new Vector3( _quantidade_para_adicionar_X, _quantidade_para_adicionar_Y, 0f ) );

                _device.dispositivo_game_object.transform.localPosition = nova_posicao;
                return;

            
        }


}