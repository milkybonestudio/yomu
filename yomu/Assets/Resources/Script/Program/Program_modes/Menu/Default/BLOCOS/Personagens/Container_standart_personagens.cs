using UnityEngine;
using UnityEngine.UI;

public class Container_standart_personagens {


        public GameObject container;


        // --- PERSONAGEM

                public GameObject personagem_container_game_object;
                public Image personagem_container_image;
                
                public GameObject personagem_imagem_game_object;
                public Image personagem_imagem_image;


                public GameObject personagem_imagem_proxima_imagem_game_object;
                public Image personagem_imagem_proxima_imagem_image;
                public GameObject personagem_imagem_imagem_anterior_game_object;
                public Image personagem_imagem_imagem_anterior_image;

                public GameObject personagem_imagem_nome_slot_game_object;
                public Image personagem_imagem_nome_slot_image;

        // --- INFORMACAO



                public GameObject informacao_container_game_object;
                public Image informacao_container_image;

                public GameObject informacao_descricao_game_object;
                public Image informacao_descricao_image;

                public GameObject informacao_bloco_gosta__E__nao_gosta_game_object;
                public Image informacao_bloco_gosta__E__nao_gosta_image;

                        public GameObject informacao_bloco__GOSTA_game_object;
                        public Image informacao_bloco__GOSTA_image;
                        public GameObject informacao_bloco__NAO_GOSTA_game_object;
                        public Image informacao_bloco__NAO_GOSTA_image;


                public GameObject informacao_bloco_outros_personagens_game_object;
                public Image informacao_bloco_outros_personagens_image;
                
                        public GameObject informacao_bloco_outros_personagens_container__GOSTA_game_object;
                        public Image informacao_bloco_outros_personagens_container__GOSTA_image;
                        public GameObject informacao_bloco_outros_personagens_container_icone__GOSTA_game_object;
                        public Image informacao_bloco_outros_personagens_container_icone__GOSTA_image;

                        public GameObject[] informacao_bloco_outros_personagens_icones__GOSTA_game_objects;
                        public Image[] informacao_bloco_outros_personagens_icones__GOSTA_images;


                        public GameObject informacao_bloco_outros_personagens_container__NAO_GOSTA_game_object;
                        public Image informacao_bloco_outros_personagens_container__NAO_GOSTA_image;
                        public GameObject informacao_bloco_outros_personagens_container_icone__NAO_GOSTA_game_object;
                        public Image informacao_bloco_outros_personagens_container_icone__NAO_GOSTA_image;

                        public GameObject[] informacao_bloco_outros_personagens_icones__NAO_GOSTA_game_objects;
                        public Image[] informacao_bloco_outros_personagens_icones__NAO_GOSTA_images;
                
                        



        public Container_standart_personagens( GameObject _pai ){

                

                // container = GAME_OBJECT.Criar_filho( "Container", _pai );

                // // --- PERSONAGEM

                //         personagem_container_game_object  = GAME_OBJECT.Criar_filho( "personagem_container", container );

                //         personagem_imagem_game_object = GAME_OBJECT.Criar_filho( "personagem_container", container );
                //         personagem_imagem_image = IMAGE.Criar_imagem_somente_com_sprite()
                        

                //         personagem_container_image = IMAGE.Criar_imagem_somente_com_sprite( "personagem_container_game_object", personagem_container_game_object, personagem_container_sprite  );

                //         personagem_imagem_proxima_imagem_game_object  = GAME_OBJECT.Criar_filho( "personagem_imagem_proxima_imagem_game_object", personagem_container_game_object );
                //         personagem_imagem_proxima_imagem_image = IMAGE.Criar_imagem_somente_com_sprite( "personagem_imagem_proxima_imagem_game_object", personagem_imagem_proxima_imagem_game_object, personagem_imagem_proxima_imagem_sprite  );
                //         personagem_imagem_imagem_anterior_game_object  = GAME_OBJECT.Criar_filho( "personagem_imagem_imagem_anterior_game_object", personagem_container_game_object );
                //         personagem_imagem_imagem_anterior_image = IMAGE.Criar_imagem_somente_com_sprite( "personagem_imagem_imagem_anterior_game_object", personagem_imagem_imagem_anterior_game_object, personagem_imagem_imagem_anterior_sprite  );

                //         personagem_imagem_nome_slot_game_object  = GAME_OBJECT.Criar_filho( "personagem_imagem_nome_slot", personagem_container_game_object );
                //         personagem_imagem_nome_slot_image = IMAGE.Criar_imagem_somente_com_sprite( "personagem_imagem_nome_slot_game_object", personagem_imagem_nome_slot_game_object, personagem_imagem_nome_slot_sprite  );



                // // --- INFORMACAO
                //         informacao_container_game_object  = GAME_OBJECT.Criar_filho( "informacao_container", container );

                //         informacao_descricao_game_object  = GAME_OBJECT.Criar_filho( "informacao_descricao",  );

                //         informacao_bloco_gosta__E__nao_gosta_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_gosta__E__nao_gosta",  );

                //                 informacao_bloco__GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco__GOSTA",  );
                //                 informacao_bloco__NAO_GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco__NAO_GOSTA",  );


                //         informacao_bloco_outros_personagens_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_outros_personagens",  );
                        
                //                 informacao_bloco_outros_personagens_container__GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_outros_personagens_container__GOSTA",  );
                //                 informacao_bloco_outros_personagens_container_icone__GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_outros_personagens_container_icone__GOSTA",  );

                //                 informacao_bloco_outros_personagens_icones__GOSTA_game_objects  = new GameObject [ 0 ];


                //                 informacao_bloco_outros_personagens_container__NAO_GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_outros_personagens_container__NAO_GOSTA",  );
                //                 informacao_bloco_outros_personagens_container_icone__NAO_GOSTA_game_object  = GAME_OBJECT.Criar_filho( "informacao_bloco_outros_personagens_container_icone__NAO_GOSTA",  );

                //                 informacao_bloco_outros_personagens_icones__NAO_GOSTA_game_objects  = new GameObject[ 0 ];
                                

        }

}