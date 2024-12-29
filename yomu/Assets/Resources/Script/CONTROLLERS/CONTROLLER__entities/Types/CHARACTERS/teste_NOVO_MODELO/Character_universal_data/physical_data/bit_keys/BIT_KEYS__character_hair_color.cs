

public class BIT_KEYS__character_hair_color {

        // ** cores normais : 12 
        // ** sobra 4: nada, black, white, pink?


            // ** 1 BYTE

        public const ushort red         = 0b_0000_0000__0000_0001;
        public const ushort blue        = 0b_0000_0000__0000_0010;
        public const ushort yellow      = 0b_0000_0000__0000_0100;
        public const ushort green       = 0b_0000_0000__0000_1000;

        public const ushort orange      = 0b_0000_0000__0001_0000;
        public const ushort pink        = 0b_0000_0000__0010_0000;
        public const ushort purple      = 0b_0000_0000__0100_0000;
        public const ushort brown       = 0b_0000_0000__1000_0000;



            // ** 2 BYTE

        public const ushort black       = 0b_0000_0001__0000_0000; // very dark colors and black
        public const ushort white       = 0b_0000_0010__0000_0000; // very light colors and white
        public const ushort grey        = 0b_0000_0100__0000_0000; 
        public const ushort nothing     = 0b_0000_1000__0000_0000;

        public const ushort dark_color  = 0b_0001_0000__0000_0000; 
        public const ushort pastel      = 0b_0010_0000__0000_0000; // light colors
        public const ushort rainbow     = 0b_0100_0000__0000_0000;
        public const ushort material    = 0b_1000_0000__0000_0000; // like snakes or some other thing with texture

    
}