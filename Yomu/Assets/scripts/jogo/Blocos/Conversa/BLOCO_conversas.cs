using UnityEngine;
using System;
using UnityEngine.UI;



/*

    conversas nao trocam background, sempre flipam foco, o personagem fica sempre no mesmo zoom, sempre fica no centro, e sempre só tem 1

*/




public class Bloco_conversa {


        public string tipo =  null ;
        public string texto = null ;
        public string mod  =  null ; 
        public string add  =  null ; 
        public string sub  =  null ;
        public string[] cenas = null;             

        
}


public class Blocos_conversa_info {


        public Bloco_conversa[] blocos;

        public Bloco_conversa bloco_atual;

        
        public GameObject personagem;
        public Image personagem_imagem;

        public Color personagem_cor = Color.black;


        public int[] blocos_atuais ;

        public int cena_atual = 0 ;

        public bool esta_mostrando_blocos = false;


        public string personagem_nome = null;
        public string personagem_imagem_folder = null;

    
}



public class BLOCO_conversas {

        public static BLOCO_conversas instancia;
        public static BLOCO_conversas Pegar_instancia(){ return instancia; }


        public static BLOCO_conversas Construir(){ 
                
                instancia = new BLOCO_conversas(); 
                                
                        //  bloco_jogo = BLOCO_jogo.Pegar_instancia( true );
                        instancia.conversas_leitor = Conversas_leitor.Pegar_instancia();

                        instancia.container_conversa = new GameObject( "Conversa" );
                        instancia.container_conversa.transform.SetParent( GameObject.Find( "Tela/Canvas/Jogo" ).transform , false);


                
                return instancia;
                
        }
 
        public bool tem_opcoes = false;

        public Pergaminho_modelo_1 pergaminho;


        //public BLOCO_jogo bloco_jogo;
        public Conversas_leitor conversas_leitor;

        

        public Blocos_conversa_info blocos_info = null;

        public GameObject container_conversa;




        public void Iniciar ( string _personagem_nome , string _nome_conversa  ){




              //  bloco_jogo.update_tipo_atual = Jogo_update_tipo.conversas;

                //this.pergaminho  = Controlador_tela_jogo.Pegar_instancia().pergaminho;

                string[] cenas_atuais_raw = Pegar_cenas_raw ( _personagem_nome , _nome_conversa  );

                blocos_info = Pegar_blocos( cenas_atuais_raw );

                blocos_info.personagem_cor = Cores.Pegar_cor( ( Nome_cor ) Enum.Parse( typeof( Nome_cor )   ,  ( _personagem_nome + "_default_text_color" ) ) );

                blocos_info.personagem_imagem_folder = "images/in_game/personagens/" + _personagem_nome + "/";

                blocos_info.personagem_nome = _personagem_nome;


                Criar_tela_conversas();

                this.pergaminho.Levantar_pergaminho();

                Ler_bloco( 0 ); // sempre le start

                Dados_blocos.Pegar_instancia().req_mudar_UI = new Req_mudar_UI(
                        _novo_tipo : Tipo_UI.in_game,
                        _UI_partes : new bool []{ false , false , true  }
                );




        }



        public void Update(){


                    if( Controlador_input.Get_down( Key_code.esc ) ){ 

                            Encerrar_conversa(); 
                            return;
                            
                    }

                    if( blocos_info.esta_mostrando_blocos ){ return; }

                    if(   Controlador_input.Get_down( Key_code.space ) ||  Controlador_input.Get_down( Key_code.mouse_left ) ) {

                            Ler(); 
                            return;                    
                    }

        }




        public void Ler(){


                if( blocos_info.blocos_atuais.Length == 0 ) { 

                    Encerrar_conversa(); 
                    return;
                    
                }

                if( blocos_info.cena_atual == (blocos_info.bloco_atual.cenas.Length - 2) ){ // a ultima sempre é somente a imagem

                    Mostrar_blocos();
                    return;

                }


                Ler_cena();


                return;

                
        }





        public void Ler_cena(){


                blocos_info.cena_atual++;
                int cena_atual = blocos_info.cena_atual;

                string personagem_nome = blocos_info.personagem_nome;

                Color cor = blocos_info.personagem_cor;


                string cena = blocos_info.bloco_atual.cenas [ cena_atual ];

                string[] partes = cena.Split(",", 4);

                string nome = (new string (  partes[ 0 ].ToCharArray() ,  1 , partes[ 0 ].Length -1  ) ).Trim();
                string effects = partes[ 1 ].Trim();
                string personagem_imagem_nome = partes[ 2 ].Trim();
                string texto = (new string (  partes[ 3 ].ToCharArray() ,  0 , partes[ 3 ].Length -1  ) ).Trim();

                if( effects != ""){ throw new ArgumentException("ainda nao pode usar"); }


                void Colocar_imagem( string _imagem_nome ){


                        string path_personagem = blocos_info.personagem_imagem_folder;

                        Sprite nova_sprite = Resources.Load< Sprite >(  path_personagem + _imagem_nome );

                        if( nova_sprite == null ) { throw new ArgumentException("nao foi achado imagem no path: " + ( path_personagem + _imagem_nome  ) ); }

                        blocos_info.personagem_imagem.sprite = nova_sprite;             

                }

                Colocar_imagem( personagem_imagem_nome ) ;


                

                if( nome != personagem_nome ){ cor = Color.black; }

                this.pergaminho.Escrever( texto , personagem_nome, cor, 0 );


            


        }

        public void Ler_bloco( int _numero_bloco ){


                int i = 0;

                Bloco_conversa novo_bloco = blocos_info.blocos[ _numero_bloco ] ;
                blocos_info.bloco_atual = novo_bloco; 

                string mod_raw = novo_bloco.mod;

                string[] mods = mod_raw.Split(",");

                int numero_mods = mods.Length;
                if( mods[ 0 ].Trim() == "" ) { numero_mods--; }

                for( int mod = 0 ; mod < mods.Length; mod++ ){


                    
                }




                blocos_info.cena_atual = -1;

                blocos_info.esta_mostrando_blocos = false;

                Bloco_conversa[] blocos = blocos_info.blocos;






                string[] add_str = novo_bloco.add.Split(",");
                
                int numero_adds = add_str.Length;
                if( add_str[ 0 ].Trim() == "" ) { numero_adds--; }

                int[] add_numero = new int[ numero_adds ];

                for( int index_add = 0 ; index_add < numero_adds ; index_add++ ){

                        string nome_bloco = add_str [ index_add ].Trim();

                        for( int index_bloco = 0 ;  index_bloco < blocos.Length  ; index_bloco++ ){
                                
                                if( blocos[ index_bloco ].tipo == nome_bloco ) {

                                        add_numero[ index_add ] = index_bloco ;
                                        break;

                                }

                                if( index_bloco == (blocos.Length - 1) ) { throw new ArgumentException( "nao foi achado nome bloco para adicionar. veio: " + nome_bloco ); }

                        }


                }







                string[] sub_str = novo_bloco.sub.Split(",");

                
                int numero_subs = sub_str.Length;
                if( sub_str[ 0 ].Trim() == "" ) { numero_subs--; }



                int[] sub_numero = new int[ numero_subs ];

                for( int index_sub = 0 ; index_sub < numero_subs ; index_sub++ ){

                        string nome_bloco = sub_str [ index_sub ].Trim();

                        for( int index_bloco = 0 ;  index_bloco < blocos.Length  ; index_bloco++ ){


                                if( blocos[ index_bloco ].tipo == nome_bloco ) {

                                        sub_numero[ index_sub ] = index_bloco ;
                                        break;

                                }

                                if( index_bloco == (blocos.Length - 1) ) { throw new ArgumentException( "nao foi achado nome bloco para remover. veio: " + nome_bloco ); }

                        }


                }

                blocos_info.blocos_atuais = Mat.Calcular_array_int ( blocos_info.blocos_atuais , sub_numero , add_numero ) ;





                Ler_cena();

                return;

                //  le modificadores 


        }

        public void Mostrar_blocos(){


            
                blocos_info.cena_atual++;
                int cena_atual = blocos_info.cena_atual;

                
                string cena = blocos_info.bloco_atual.cenas [ cena_atual ];

                string nova_imagem = ( new string  ( cena.ToCharArray() , 1 ,  cena.Length - 2 ) ).Trim() ;

                Colocar_imagem( nova_imagem ) ; 
                

                int numero_blocos_atuais = blocos_info.blocos_atuais.Length;

                int[] numero_blocos = blocos_info.blocos_atuais;

                string[] textos = new string[ numero_blocos_atuais ];

                for( int n = 0 ; n < numero_blocos_atuais ; n++ ){

                    textos[ n ] = blocos_info.blocos[ numero_blocos[ n ] ].texto ;

                }

                

                pergaminho.Iniciar_conversas( textos , numero_blocos );

                return;

        }






        public void Finalizar(){

                // passar encerrar para ca

        }




        public void Encerrar_conversa(){


                pergaminho.Abaixar_pergaminho();

                //BLOCO_jogo.Pegar_instancia().update_tipo_atual = Jogo_update_tipo.movimento;

                Dados_blocos.Pegar_instancia().req_mudar_UI = new Req_mudar_UI(

                        _novo_tipo : Tipo_UI.in_game,
                        _UI_partes : new bool []{ false , true , false  }
                );




                Mono_instancia.Destroy( container_conversa );
                container_conversa = null ;


                blocos_info = null ;
                
                return;


        }



        public void Colocar_imagem( string _imagem_nome ){

                if( _imagem_nome == "" ) { return; }

                string path_personagem = blocos_info.personagem_imagem_folder;

                Sprite nova_sprite = Resources.Load< Sprite >(  path_personagem + _imagem_nome );

                if( nova_sprite == null ) { throw new ArgumentException("nao foi achado imagem no path: " + ( path_personagem + _imagem_nome  ) ); }

                blocos_info.personagem_imagem.sprite = nova_sprite;       
    
                return;      

        }













        public void Criar_tela_conversas(){

            
                //GameObject container = Controlador_tela_jogo.Pegar_instancia().game_object_para_outros_modos;
                GameObject container = null;
                            
                if( container.transform.childCount > 0 ){

                        Mono_instancia.Destroy(  container.transform.GetChild( 0 ).gameObject );

                }


                this.container_conversa = new GameObject("Conversas") ;
                container_conversa.transform.SetParent(  container.transform   , false ) ;


                blocos_info.personagem = Geral.Criar_imagem( "Personagem" , container_conversa, 2160f, 2160f,  null , 1f ) ;
              //  blocos_info.personagem.transform.localPosition = new Vector3( 0f , -540f , 0f );
                blocos_info.personagem_imagem = Geral.ultima_imagem ;

    

        }



        public string[] Pegar_cenas_raw( string _personagem_nome , string _nome_conversa ){


                // if( Application.isEditor ){

                //         string cenas_texto = Conversas_compilador.Compilar( _personagem_nome , _nome_conversa );
                //         string[] cenas = cenas_texto.Split("&");
                //         return cenas;

                // }

                string cenas_compiladas_texto = Resources.Load<TextAsset>( "files/conversas/" + _personagem_nome + "/" + _nome_conversa ).text;

                
                string[] cenas_finais  =  Manipulador_texto_.Pegar_cenas(cenas_compiladas_texto);
                return cenas_finais;

        }



        public Blocos_conversa_info Pegar_blocos( string[] _blocos_raw ){

                Blocos_conversa_info retorno = new Blocos_conversa_info ();


                Bloco_conversa[] blocos = new Bloco_conversa[ _blocos_raw.Length ];

                for ( int bloco_index = 0 ; bloco_index < _blocos_raw.Length ; bloco_index++ ){

                        int linha = 0;
                        int i = 0;

                        Bloco_conversa bloco = new Bloco_conversa();

                        string bloco_raw = _blocos_raw[ bloco_index ];
                        string[] linhas =  bloco_raw.Split("\r\n");
                        int numero_linhas_nao_vazias = 0;
                    
                        for(  linha = 1 ; linha < ( linhas.Length - 1 ) ; linha++ ){

                                linhas [ linha ] = linhas [ linha ].Trim();

                                if( linhas [ linha ] == "" ) { continue; }
                                numero_linhas_nao_vazias++;
                                continue;

                        }
                        

                        string[] linhas_trim = new string[ numero_linhas_nao_vazias ];

                        for( linha = 1 ; linha < ( linhas.Length - 1 ) ; linha++ ){

                                if( linhas [ linha ] == "" ) { continue; }
                                linhas_trim[ i ] = linhas[ linha ];
                                i++;
                                continue;
                        }

                        
                        int numero_linhas_obrigatorias_info = 5;
                        int numero_cenas = ( numero_linhas_nao_vazias - numero_linhas_obrigatorias_info );

                        
                        bloco.cenas = new string[ numero_cenas ];

                        bloco.tipo = Pegar_valor( linhas_trim[ 0 ] );
                        bloco.texto  = Pegar_valor( linhas_trim[ 1 ] );
                        bloco.mod  = Pegar_valor( linhas_trim[ 2 ] );
                        bloco.add  = Pegar_valor( linhas_trim[ 3 ] );
                        bloco.sub  = Pegar_valor( linhas_trim[ 4 ] );

                        for( linha = 5 ; linha < numero_linhas_nao_vazias ; linha++ ){

                                bloco.cenas[ linha - 5 ] = linhas_trim[ linha ] ;

                        }


                        blocos [ bloco_index ] = bloco;


                }

                retorno.blocos = blocos;

                return retorno;


                string Pegar_valor( string _str ){

                    string[] a = _str.Split(":");
                    if( a.Length == 1 ) { return ""; }

                    return a[ 1 ].Trim();

                }

        }






        
        /*


        [

        ]


        [
            bloco : biscoitos_1
            bloco_texto : eu comi os biscoitos
            adicionar_blocos: 
            remover_blocos: biscoitos_1
            mod :  amor : 20 , amizade : 10 , odio : 10
            
            [ player ,  , sorry... I eat it ]
            [ personagem , normal@rage(meme)@ba@esquerda , wHaT!? ]
            
        ]
        
        */






}