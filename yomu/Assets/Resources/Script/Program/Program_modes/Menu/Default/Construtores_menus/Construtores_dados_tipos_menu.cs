

// public static class Construtores_dados_tipos_menu {

//         // *** devolve os dados de cada tipo menu 
//         // ** posicao
//         // ** imagens statics que podem ser liberadas
//         // ** variacoes de imagens 

//         public static Dados_menu Construir( Tipo_menu_background _tipo_menu ){

//                 // --- CONSTROI O GENERICO PRIMEIRO

//                 Dados_menu dados_menu = Construir_dados_genericos();

//                 switch( _tipo_menu ){

//                         case Tipo_menu_background.catedral_corredor: return Construtor_dados_menu_CATEDRAL_CORREDOR.Construir( dados_menu );
//                 }

//                 return dados_menu;

//         }



//         private static Dados_menu Construir_dados_genericos(){


//                 Dados_menu dados_menu = new Dados_menu();

                
//                 int numero_de_blocos = ( System.Enum.GetValues( typeof( Menu_bloco ) ) ).Length ;
                
//                 dados_menu.posicoes_blocos = new int[ ( numero_de_blocos * 2 ) ];

//                 dados_menu.posicoes_interativos_menu_por_bloco = new int [ numero_de_blocos ][];
//                 dados_menu.interativos_menu_imagens_por_bloco = new int[ numero_de_blocos ][];
//                 dados_menu.interativos_menu_animacoes_por_bloco = new int[ numero_de_blocos ][][];



//                 // --- INTERATIVO MENU


//                         int numero_interativos_menu_personagens = 0; // 6 persoangens + 2 botoes
//                         int numero_interativos_menu_galeria = 8; // 6 paineis + 2 potoes
//                         int numero_interativos_menu_novo_jogo = 1;
//                         int numero_interativos_menu_saves = 0; // 6 slots + 2 botoes
//                         int numero_interativos_menu_configuracoes = 0; // se for realmente deixar tudo no container mudar depois


//                         // --- COLOCA DADOS
//                         // *** os interativos menu sao sempre os mesmos

//                         dados_menu.posicoes_interativos_menu_por_bloco[ ( int ) Menu_bloco.personagens ] = new int[ ( numero_interativos_menu_personagens * 2 ) ];
//                         dados_menu.posicoes_interativos_menu_por_bloco[ ( int ) Menu_bloco.galeria ] = new int[ ( numero_interativos_menu_galeria * 2 ) ];
//                         dados_menu.posicoes_interativos_menu_por_bloco[ ( int ) Menu_bloco.novo_jogo ] = new int[ ( numero_interativos_menu_novo_jogo * 2 ) ];
//                         dados_menu.posicoes_interativos_menu_por_bloco[ ( int ) Menu_bloco.saves ] = new int[ ( numero_interativos_menu_saves * 2 ) ];
//                         dados_menu.posicoes_interativos_menu_por_bloco[ ( int ) Menu_bloco.configuracoes ] = new int[ ( numero_interativos_menu_configuracoes * 2 ) ];


//                         dados_menu.interativos_menu_imagens_por_bloco[ ( int ) Menu_bloco.personagens   ] = new int[  numero_interativos_menu_personagens  ];
//                         dados_menu.interativos_menu_imagens_por_bloco[ ( int ) Menu_bloco.galeria   ] = new int[  numero_interativos_menu_galeria  ];
//                         dados_menu.interativos_menu_imagens_por_bloco[ ( int ) Menu_bloco.novo_jogo   ] = new int[  numero_interativos_menu_novo_jogo  ];
//                         dados_menu.interativos_menu_imagens_por_bloco[ ( int ) Menu_bloco.saves   ] = new int[  numero_interativos_menu_saves  ];
//                         dados_menu.interativos_menu_imagens_por_bloco[ ( int ) Menu_bloco.configuracoes   ] = new int[  numero_interativos_menu_configuracoes  ];

//                 return dados_menu;

//         }



// }