using System;

namespace Ahorcado{
    
    public class Player{
        public Player(){  
        } 

        public char ingresarLetra(){
            Console.WriteLine("Ingrese una letra: ");
            char info;
            do{
                info = Console.ReadKey().KeyChar;
                Thread.Sleep(1000);
                Console.WriteLine(" ");
                return char.ToUpper(info);
            }
            while(Char.IsAsciiLetterOrDigit(info));

        }
    }
}