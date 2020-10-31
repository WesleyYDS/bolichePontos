using System;

namespace bolicheCore
{
    public class bolicheScore
    {
        //Quantos pinos foram derrubados [frame, bola], sem influência de multiplicadores
        private int[,] score;
        private int frameAtual;
        private int bolaAtual;
        public int scoreTotal;

        public void jogarBola(int pinosDerrubados)
        {
            score[frameAtual-1, bolaAtual] = pinosDerrubados;
            scoreTotal += pinosDerrubados;

            if (frameAtual > 1)
            {
                if (score[frameAtual-2,0] == 10 && bolaAtual < 2
                || (score[frameAtual-2,0] + score[frameAtual-2,1] == 10) && (bolaAtual == 0))
                {
                    scoreTotal += pinosDerrubados;
                    if (frameAtual > 2 && score[frameAtual-2,0] == 10 && bolaAtual < 1)
                    {
                        if (score[frameAtual-3,0] == 10)
                        {
                            scoreTotal += pinosDerrubados;
                        }
                    }
                }
            }

            if (frameAtual < 10)
            {
                if (score[frameAtual-1, bolaAtual] == 10) bolaAtual++;
                
                bolaAtual++;

                if (bolaAtual > 1)
                {
                    bolaAtual = 0;
                    frameAtual++;
                }
            }
            else
            {
                bolaAtual++;
            }
        }

        public void iniciarPartida()
        {
            score = new int[10,3];
            frameAtual = 1;
            bolaAtual = 0;
            scoreTotal = 0;
        }
    }
}
