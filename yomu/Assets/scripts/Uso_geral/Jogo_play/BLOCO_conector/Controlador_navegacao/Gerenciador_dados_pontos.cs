

public class Gerenciador_dados_pontos {


        public MODULO_manipulador_container_estatico_completo manipulador_container_estatico_completo;

        public Gerenciador_dados_pontos(  string _nome_gerenciador, string _path_container ){

                manipulador_container_estatico_completo = new MODULO_manipulador_container_estatico_completo(  _nome_manipulador: _nome_gerenciador, _path_container: path_container, _pode_escrever_no_container: true , _forcar_pegar_container: true  );            

        }


    public Task_req req_pegar_container;
    public byte[] dados_atuais;
    public string path_container;

    public string nome_gerenciador;



    public void Carregar_novo_container( string _path ){


                if( req_pegar_container != null )
                    {
                        // --- TEM ALGO SENDO CARREGADO

                        // --- NAO DEIXA TERMINAR
                        req_pegar_container.pode_executar = false;
                        req_pegar_container = null;

                    }



                req_pegar_container = new Task_req( new Chave_cache(), $"Carregando dados do { nome_gerenciador }" );

                req_pegar_container.fn_iniciar = ( Task_req _req ) =>   {

                                                                                byte[] dados =System.IO.File.ReadAllBytes( path_container );

                                                                                req_pegar_container.dados = ( System.Object ) dados;
                                                                                return;

                                                                        };

                req_pegar_container.fn_finalizar = ( Task_req _req ) => {

                                                                                byte[] dados = ( byte[] ) req_pegar_container.dados;
                                                                                dados_atuais = dados;
                                                                                return;
                                                                                req_pegar_container = null;

                                                                        };

                return;

    }

}