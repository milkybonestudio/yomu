
using System;



public class Linear_dictionary_figure_modes{

        public static int length;

        public Linear_dictionary_figure_modes( Figure_data_getter _data, Resource_structure_content _level_pre_allocation = Resource_structure_content.game_object ){

                root_path = _data.path_root;
                level_re_allocation = _level_pre_allocation;

                if( length == 0 )
                    { length = ( int ) Figure_mode_type.END; }

                values = new Figure_mode[ length ];

        }

        private Resource_structure_content level_re_allocation;
        private string root_path;
        private Figure_mode[] values; // max
        private Figure_mode[] valid_figures_emotions;


        
        public void Add( Figure_mode _value ){

            // --- GET STRUCTURE

            _value.Set_figure_mode_structure( root_path, level_re_allocation );

            values[ ( int ) _value.visual_figure ] = _value;

        }


        public Figure_mode[] Get_valid(){

            if( valid_figures_emotions != null )
                { return valid_figures_emotions; }

            
                int number = 0;

                // --- GET NUMBER OF NONNULL
                for( int i = 0 ; i < values.Length ; i++ )
                    { if ( values[ i ] != null ) { number++; } }

                Figure_mode[] ret = new Figure_mode[ number ];

                // --- TRANSFER TO ARRAY
                int index = 0;
                for( int k = 0 ; k < values.Length ; k++ )
                    { if ( values[ k ] != null ) { ret[ index++ ] = values[ k ]; } }

                valid_figures_emotions = ret;

                return ret;

        }


        public Figure_mode Get( Figure_mode_type index ){ return values[ ( int ) index ]; }

        public Figure_mode this[ Figure_mode_type index ]{

                get { return values[ ( int ) index ]; }
                set { values[ ( int ) index ] = value; }

        }




}
