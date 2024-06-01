# yomu


 &nbsp;&nbsp;This is basically the entire game. If you wanna install and change some things it`s fine. But the code is in portuguese, at least 90%. Some people encrypt information with aes, I just use brazil language. I will just not show the files in production, generally in the first draft I make some questionable jokes that just after I read one day later I realise that was written in the worst way possible. The actual content used in the game will be show and can be modified.<br>
 &nbsp;&nbsp;Actual functionality code would be hard to implement, but I will develop in a way that makes create change content/date more easy. Things like change images, alternative visual novel scripts, change character's internal data will be more easy

 The important blocks are called "Controladores" :shipit: and they use a singleton logic. Every block has:
 
 ```
 public class Controlador_generico(){

    public static Controlador_generico instancia;
    public static Controlador_generico Pegar_instancia(){ return instancia; };

    public static Controlador_generico Construir( args ){

        Controlador_generico controlador = new Controlador_generico();

                ...
                ...  ( create block )
                ...
        instancia = controlador;
        return instancia;

    }

    ....
    .... ( things of the block )
    ....

    

 }
 ```

 


- [ ] \(Optional) Open a followup issue


> [!WARNING]
> Urgent info that needs immediate user attention to avoid problems.


