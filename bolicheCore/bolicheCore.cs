using System;

namespace bolicheCore
{
    public class bolicheCore
    {
        //Quantos pinos foram derrubados [frame, bola], sem influência de multiplicadores
        private int[,] score { get => score; set => score = value; }

        //Em qual frame a partida está: 1 - 10
        private int frameAtual { get => frameAtual; set => frameAtual = value; }

        //Em qual bola o frame atual está: 0, 1 ou 2 (no décimo frame)
        private int bolaAtual { get => bolaAtual; set => bolaAtual = value; }

        //Pontuação atual total: 0 - 300
        private int scoreTotal { get => scoreTotal; set => scoreTotal = value; }

        public void jogarBola(int pinosDerrubados)
        {
            score[frameAtual-1, bolaAtual] = pinosDerrubados;
            scoreTotal += pinosDerrubados;

            if (frameAtual > 1)
            {
                if (score[frameAtual-2,0] == 10
                 || (score[frameAtual-2,0] + score[frameAtual-2,1] == 10) && bolaAtual == 0)
                {
                    scoreTotal += pinosDerrubados;
                    if (frameAtual > 2 && score[frameAtual-2,0] == 10)
                    {
                        if (score[frameAtual-3,0] == 10)
                        {
                            scoreTotal += pinosDerrubados;
                        }
                    }
                }
            }

            bolaAtual++;

            if (frameAtual < 10)
            {
                if (score[frameAtual-1,bolaAtual] == 10) bolaAtual++;

                if (bolaAtual > 1)
                {
                    bolaAtual = 0;
                    frameAtual++;
                }
            }
            else
            {
                if (bolaAtual > 2 ||
                score[frameAtual-1,0] + score[frameAtual-1,1] < 10)
                {
                    //Fim de jogo
                }
            }
        }

        public void iniciarPartida()
        {
            score = new int[10,3];
            frameAtual = 0;
            bolaAtual = 1;
            scoreTotal = 0;
        }
    }
}
