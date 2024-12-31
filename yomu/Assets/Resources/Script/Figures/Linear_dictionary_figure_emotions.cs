
using System;



public class Linear_dictionary_figure_emotions{

        public static int length;

        public Linear_dictionary_figure_emotions( Figure_data_getter _data, Resource_structure_content _level_pre_allocation = Resource_structure_content.game_object ){

                UnityEngine.Debug.Log( "fgdf" );
                root_path = _data.path_root;
                level_re_allocation = _level_pre_allocation;

                if( length == 0 )
                    { length = ( int ) Visual_figure.END; }

                values = new Emotion_figure[ length ];

        }

        private Resource_structure_content level_re_allocation;
        private string root_path;
        public Emotion_figure[] values;


        

        public void Add( Emotion_figure _value ){

            // --- GET STRUCTURE

            _value.Set_figure_emotion_structure( root_path, level_re_allocation );

            values[ ( int ) _value.visual_figure ] = _value; 

        }



        
        public Emotion_figure[] Seal(){

                int number = 0;

                // --- GET NUMBER OF NONNULL
                for( int i = 0 ; i < values.Length ; i++ )
                    { if ( values[ i ] != null ) { number++; } }

                Emotion_figure[] ret = new Emotion_figure[ number ];

                // --- TRANSFER TO ARRAY
                int index = 0;
                for( int k = 0 ; k < values.Length ; k++ )
                    { if ( values[ k ] != null ) { ret[ index++ ] = values[ k ]; } }

                return ret;

        } 
        public Emotion_figure this[ int index ]{

                get { return values[ index ]; }
                set { values[ index ] = value; }

        }




}
