


public class Info_estado {


    // --- INTERACAO PLAYER 

    public string nome;
    public string descricao;

    
    // aparece quando o player passar o mouse
    public string[] comentarios;
    

    public Reino_nome reino;
    public Estado_nome[] estados_ao_arredor;
    public Cidade_nome[] cidades;


    // --- INFO

    



}


#if UNITY_EDITOR || true


    public static class Leitor_info_estados_reino_humano_DEVELOPMENT {


        public static Info_estado Pegar_info_estado( Posicao _posicao ){

            Estado_nome estado = ( Estado_nome ) _posicao.estado_id;

            switch( estado ){

                case Estado_nome.San_sebastian : return Pegar_info_SAN_SEBASTIAN();
                default: throw new System.Exception( $"nao foi achado o estado { estado } para pegar os dados" );

            }



        }

        // outras linguas?
        public static Info_estado Pegar_info_SAN_SEBASTIAN(){

            Info_estado info_estado = new Info_estado();

            info_estado.nome = "San Sebastian";
            info_estado.descricao = "";
            info_estado.comentarios = new string[]{

                "Good state. hard."

            };

            info_estado.estados_ao_arredor = new Estado_nome[]{};

            info_estado.reino = Reino_nome.Humans;

            info_estado.cidades = new Cidade_nome[]{

                
                    Cidade_nome.saint_land,
                    Cidade_nome.sunnyvale,


            };




            return info_estado;

        }




    }
#endif