using System;

namespace Ahorcado{

    public class Horca{
        private int lifes;
        public Horca(){
            this.lifes=6;
        }

        public void Run(){
            this.DisplayTitle();
            Word _word = new Word();
            char[] _secretWord = new char[_word.significado.Length];
            for(int i=0; i<_secretWord.Length; i++){
                _secretWord[i] = '_';
            }
            //Console.WriteLine("La palabra oculta es: " + new string('_', _word.significado.Length));
            this.building(_secretWord, _word.significado);
        }
        

         private void DisplayTitle(){
            Console.WriteLine(" -- Welcome to the Hangman -- ");
            Thread.Sleep(1000);
        }

        private void building(char[] sw, string wd){
            Player _player = new Player();
            int _hits=0;
            List<char> usedLetter = new List<char>();
            //char letraSeleccionada;
            do{
                Console.WriteLine(sw);
                this.showUsed(usedLetter);
                char letraSeleccionada = _player.ingresarLetra();
                if(usedLetter.Contains(letraSeleccionada)){
                    Console.WriteLine("Letra ya usada, seleccione otra por favor");
                    Thread.Sleep(1500);
                    //break;
                    //letraSeleccionada = _player.ingresarLetra();
                }
                else{
                    usedLetter.Add(letraSeleccionada);
                    Thread.Sleep(1000);
                    bool acerto = false;
                    for(int i=0; i<wd.Length; i++){
                        if(wd[i] == letraSeleccionada){
                            acerto=true;
                         _hits++;
                            sw[i] = letraSeleccionada;
                        }
                    }
                    if(acerto){
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                        Console.WriteLine("ACERTO!!");
                        //Console.WriteLine("");
                        Console.WriteLine("Vidas restantes: " +lifes);
                    }
                    if(!acerto){
                        lifes--;
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                        Console.WriteLine("HA FALLADO");
                        //Console.WriteLine("");
                        Console.WriteLine("Vidas restantes: " +lifes);
                    }
                    //Console.WriteLine(sw);
                    if(_hits==wd.Length) {
                        Thread.Sleep(1500);
                        Console.WriteLine("Felicidades ha ganado el juego");
                        break;
                    }
                    //Console.WriteLine(sw);
                }
            }
            while(lifes>0);
                if(lifes==0){ 
                    Thread.Sleep(1500);
                    Console.WriteLine("Lo sentimos, ha perdido el juego");
                }
        }

        private void showUsed(List<char> ul){
            Console.WriteLine("Letras que ya fueron usadas: ");
            foreach(var i in ul){
                Console.Write(" " + i + " ");
            }
            Console.WriteLine(" ");
        }
    }
}