using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class TOOL__create_initial_textures {

        public static void Create( MODULE__textures_manager _module) {

        
                //mark

                // ** quando for fazer as cartas ver os formatos que vai precisar e fazer um modo especifico

                
                int length = Enum.GetValues( typeof( Texture_sizes ) ).Length;
                _module.textures = new Texture2D[ length ][];
                _module.textures_locks = new bool[ length ][];
                _module.indentificadores = new string[ length ][];


                // ** squares
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._20_X_20,  _number: 25, _height: 20, _width: 20 );       // 40kb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._50_X_50,  _number: 20, _height: 50, _width: 50 );       // 200kb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._100_X_100,  _number: 10, _height: 100, _width: 100 );     // 400kb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._150_X_150,  _number: 10, _height: 150, _width: 150 );     // 900kb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._250_X_250,  _number: 10, _height: 250, _width: 250 );     // 2,5mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._500_X_500,  _number: 5, _height: 500, _width: 500 );      // 5mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._750_X_750,  _number: 3, _height: 750, _width: 750 );      // 6,9mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._1000_X_1000,  _number: 3, _height: 1000, _width: 1000 );    // 12mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._1500_X_1500,  _number: 1, _height: 1500, _width: 1500 );    // 9mb


                // ** special

                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._1920_X_1080,  _number: 6, _height: 1080, _width: 1920 );    // 49mb

                // ** rect

                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._20_X_60,  _number: 5, _height: 20, _width: 60 );           // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._50_X_150,  _number: 5, _height: 50, _width: 150 );         // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._100_X_300,  _number: 5, _height: 100, _width: 300 );       // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._150_X_450,  _number: 5, _height: 150, _width: 450 );       // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._200_X_600,  _number: 5, _height: 200, _width: 600 );       // 0mb

                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._300_X_700,  _number: 5, _height: 300, _width: 700 );       // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._400_X_900,  _number: 5, _height: 400, _width: 900 );       // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._500_X_1100,  _number: 5, _height: 500, _width: 1100 );     // 0mb
                Get_textures_start(  _module.textures, _module.textures_locks, _module.indentificadores,  ( int ) Texture_sizes._600_X_1500,  _number: 5, _height: 600, _width: 1500 );     // 0mb


        }


        [ MethodImpl( MethodImplOptions.AggressiveInlining ) ]
        private static void Get_textures_start( Texture2D[][] textures, bool[][] textures_locks, string[][] indentificadores, int slot, int _number, int _height, int _width  ){

                textures[ slot ] = new Texture2D[ _number ];
                textures_locks[ slot ] = new bool[ _number ];
                indentificadores[ slot ] = new string[ _number ];

                Texture2D[] texs = textures[ slot ];
                
                for( int i = 0 ; i < _number ; i++)
                    { texs[ i ] = new Texture2D( _width, _height );}

                return;

        }

}