

public static class SKILLS_DADOS {


    public static int[] xp_para_o_proximo_nivel = new int[]{


        // FORMULA:
        
        // valor += ( 8 * ( level_quadrado )  )  +  ( level * 7 )  + valor_fixo ; 
        // valor += ( 4 * ( level_quadrado )  - ( 4 *20 *20)   )  * ( level / 20 )  ; 
        
        // valor += ( 15  * ( level_quadrado )  - ( 15 *50 * 50 )  )  *  ( level / 50 )  ; 
        // valor += ( 40  * ( level_quadrado )  - ( 40 *60 * 60 )  )  *  ( level / 60 )  ; 
        // valor += ( 45  * ( level_quadrado )  - ( 45 *70 * 70 )  )  *  ( level / 70 )  ; 
        // valor += ( 280 * ( level_quadrado )  - ( 275 *85 *85 )  )  *  ( level / 85 )  ; 
        // valor += ( 375 * ( level_quadrado )  - ( 375 *90 *90 )  )  *  ( level / 90 )  ; 

        // valor += ( 600 * ( level_quadrado )  - ( 600 *94 *94 )  )  *  ( level / 94 )  ; 
        // valor += ( 15_000 * ( (level - 94 ) * ( level - 94 ) * ( level - 94 ) * ( level - 94 )  ) * ( level / 94 ) ) ; 
        // valor += (  73_999  )  * ( level / 98 )  ;



        /* 0 */    -1,
        /* 1:  */  191,
        /* 2:  */  413,
        /* 3:  */  682,
        /* 4:  */  1_014,
        /* 5:  */  1_425,
        /* 6:  */  1_931,
        /* 7:  */  2_548,
        /* 8:  */  3_292,
        /* 9:  */  4_179,
        /* 10 :*/   5_225,
        /* 11 :*/   6_446,
        /* 12 :*/   7_858,
        /* 13 :*/   9_477,
        /* 14 :*/   11_319,
        /* 15 :*/   13_400,
        /* 16 :*/   15_736,
        /* 17 :*/   18_343,
        /* 18 :*/   21_237,
        /* 19 :*/   24_434,
        /* 20 :*/   27_950,
        /* 21 :*/   31_965,
        /* 22 :*/   36_503,
        /* 23 :*/   41_588,
        /* 24 :*/   47_244,
        /* 25 :*/   53_495,
        /* 26 :*/   60_365,
        /* 27 :*/   67_878,
        /* 28 :*/   76_058,
        /* 29 :*/   84_929,
        /* 30 :*/   94_515,
        /* 31 :*/   104_840,
        /* 32 :*/   115_928,
        /* 33 :*/   127_803,
        /* 34 :*/   140_489,
        /* 35 :*/   154_010,
        /* 36 :*/   168_390,
        /* 37 :*/   183_653,
        /* 38 :*/   199_823,
        /* 39 :*/   216_924,
        /* 40 :*/   239_780,
        /* 41 :*/   263_939,
        /* 42 :*/   289_433,
        /* 43 :*/   316_294,
        /* 44 :*/   344_554,
        /* 45 :*/   374_245,
        /* 46 :*/   405_399,
        /* 47 :*/   438_048,
        /* 48 :*/   472_224,
        /* 49 :*/   507_959,
        /* 50 :*/   545_285,
        /* 51 :*/   585_749,
        /* 52 :*/   629_413,
        /* 53 :*/   676_339,
        /* 54 :*/   726_589,
        /* 55 :*/   780_225,
        /* 56 :*/   837_309,
        /* 57 :*/   897_903,
        /* 58 :*/   962_069,
        /* 59 :*/   1_029_869,
        /* 60 :*/   1_114_165,
        /* 61 :*/   1_207_543,
        /* 62 :*/   1_310_153,
        /* 63 :*/   1_422_145,
        /* 64 :*/   1_543_669,
        /* 65 :*/   1_674_875,
        /* 66 :*/   1_815_913,
        /* 67 :*/   1_966_933,
        /* 68 :*/   2_128_085,
        /* 69 :*/   2_299_519,
        /* 70 :*/   2_481_385,
        /* 71 :*/   2_680_178,
        /* 72 :*/   2_896_138,
        /* 73 :*/   3_129_505,
        /* 74 :*/   3_380_519,
        /* 75 :*/   3_649_420,
        /* 76 :*/   3_936_448,
        /* 77 :*/   4_241_843,
        /* 78 :*/   4_565_845,
        /* 79 :*/   4_908_694,
        /* 80 :*/   5_294_630,
        /* 81 :*/   5_700_537,
        /* 82 :*/   6_126_663,
        /* 83 :*/   6_573_256,
        /* 84 :*/   7_040_564,
        /* 85 :*/   7_564_960,
        /* 86 :*/   8_158_447,
        /* 87 :*/   8_821_833,
        /* 88 :*/   9_555_926,
        /* 89 :*/   10_361_534,
        /* 90 :*/   11_239_465,
        /* 91 :*/   12_258_402,
        /* 92 :*/   13_419_903,
        /* 93 :*/   14_725_526,
        /* 94 :*/   16_176_829,
        /* 95 :*/   17_903_770,
        /* 96 :*/   20_119_107,
        /* 97 :*/   23_575_598,
        /* 98 :*/   30_000_000,
        /* 99 :*/   100_000_000



    };







}