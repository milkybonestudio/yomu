


public enum Input_code {

    // ** keyboard
        START,

            START_LETTERS,

                a,
                b,
                c,
                d,
                e,
                f,
                g,
                h,
                i,
                j,
                k,
                l,
                m,
                n,
                o,
                p,
                q,
                r,
                s,
                t,
                u,
                v,
                w,
                x,
                y,
                z,

            END_LETTERS,

            START_NUMBERS,

                // ** numbers podem ser tanto no padN quando no alphaN
                // ** se o player fizer shift + num8 vai retornar *
                // ** comandos vao ser sempre com control, entao ta de boa
                
                nun_0,
                nun_1,
                nun_2,
                nun_3,
                nun_4,
                nun_5,
                nun_6,
                nun_7,
                nun_8,
                nun_9,

            END_NUMBERS,

            START_ARROWS,

                left_arrow,
                right_arrow,
                up_arrow,
                down_arrow,

            END_ARROWS,

            START_BASIC_COMMANDS,

                space,
                enter,
                escape, 
                tab,
                back_space,

                page_up,
                page_down,

                home, 
                end, 
                delete, 
                insert,

                print_screen,
                pause,


            END_BASIC_COMMANDS,

            START_MOD,

                control, 
                alt, 
                shift,
                caps_lock,

            END_MOD,

            START_FN,

                f_1,
                f_2,
                f_3,
                f_4,
                f_5,
                f_6,
                f_7,
                f_8,
                f_9,
                f_10,
                f_11,
                f_12,

            END_FN,

        
        END,



}