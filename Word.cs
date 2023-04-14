using System;

namespace Ahorcado{
   
    public class Word{
   
        public string significado;
        private List<string> _palabras {get;}
        public Word(){
            this._palabras = new List<string>(){
                "DINOSAURIO", "SATELITE", "ESPIRAL", "MAIZAL"};
            this.significado = this.choose(_palabras);
            //Console.WriteLine(palabraElegida);
        }
        
        private string choose(List<string> plbs){
            Random rnd = new Random();
            var pos = rnd.Next(plbs.Count);
            var retorno = plbs[pos];
            return retorno;
        }
    } 
}