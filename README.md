# :underage: Yomu :underage:

 > [!CAUTION]
> Just a remainder, this game is 18+ so if you are underage get the fuck out here :anger::exclamation:

 &nbsp;&nbsp;This is basically the entire game. If you wanna install and change some things it`s fine. But the code is in portuguese, at least 90%. Some people encrypt information with aes, I just use brazil language. I will just not show the files in production, generally in the first draft I make some questionable jokes that just after I read one day later I realise that was written in the worst way possible. The actual content used in the game will be show and can be modified.<br>
 &nbsp;&nbsp;Actual functionality code would be hard to implement, but I will develop in a way that makes create change content/data more easy. Things like change images, alternative visual novel scripts, change character's internal data will be more easy.

 > [!CAUTION]
> The code now is a little messy because I am changing a bunch of stuff. so the majority of it is just pure :x: useless :x:

 &nbsp;&nbsp;A short introduction of how to read the code:


 The code has 5 main assemblies: 
 - Development : Manipulating files into final compact form + testing ** DON`T EXIST IN BUILD 
 - Main : Can control everything + have the only Update function of the entire code
 - Jogo : The game itself => need to load stuff
 - Run_time_data => Data that don`t make sense load everything to the ram, load dynamically with reflection :fearful:
 - Uso_geral => Things that every logic needs to have or know

 <br>

 The "jogo"/Game contains blocks with one in their own assembly and responsable for one game type. <br>

 The flow is:
 ```
  A -> B  =>  ( A ) knows / can access / have as reference ( B ) 

                              Main  
     ---------------------------|--------------------------------------------------------------------
     |                          |                                                                   |
     |                          V                                                                   |
     |                 ------> Jogo                                                                 |
     |               /          |   \                                                               |
     |             /            |     \                                                             |
     |           /              |       \--------------------------------------                     |
     V         /                |          |          |         |             |                     |
  development                   |          V          V         V             V                     |
               \                |        move   visual_novel  cards   | other_blocks blocks ... |   |
                  \             |       /         /           /            /                        |
                     \          |     /        /         /            /                             |
                        V       V   V       V         V           V                                 |
          ------------------uso_geral  <-------------------------------------------------------------
         |                      /\                          
         |                      |
         |                      |
     (dynamic)            ( compilation )                  
         |                      |                         
         |                      |                       
          ---------- >   Run_time_data 

```                  
 <br>
 
 The important blocks are called "Controladores" :shipit: and they use a singleton logic. 
 
 There are generic types like: 
 - Controlador_audio
 - Controlador_input
 - Controlador_configuracoes
 - Controlador_cursor

And are more specific blocks:
- Controlador_personagens_visual_novel ( used in visual novel ( uou ) )
- Controlador_interativos ( used in movement )
- Controlador_dados_dinamicos ( used to store dynamic data )
- Controlador_save ( used only in Jogo )
- Controlador_multithread 
 
 
 Every block has:
 
 ```C#

 public class Controlador_FUNCTION(){

    public static Controlador_FUNCTION instancia;
    public static Controlador_FUNCTION Pegar_instancia(){ return instancia; };

    public static Controlador_FUNCTION Construir( args ){

        Controlador_FUNCTION controlador = new Controlador_FUNCTION();

               //...
               //...  ( create block )
               //...

        instancia = controlador;
        return instancia;

    }

   // ....
   //.... ( things of the block )
   // ....

    

 }

 ```
The "Construir" is necessary by the way that Unity handles static fields with no reload domain. With the normal check if( instance == null ){ construct(); } tha last object will still be there and give bugs here and there.
 


- [ ] \(Optional) Open a followup issue


> [!WARNING]
> Urgent info that needs immediate user attention to avoid problems.


