using System;

namespace bolicheCore
{
    public class bolicheScore
    {
        //Quantos pinos foram derrubados [frame, bola], sem influência de multiplicadores
        private int[,] pinosDerrubadosPorBola;
        private int frameAtual;
        private int bolaAtual;
        public int scoreTotal;

        public void jogarBolaEContarPontos(int pinosDerrubados)
        {
            somarPontosBase(pinosDerrubados);

            somarPontosExtras(pinosDerrubados);

            if (frameAtual < 9)
            {
                if (foiStrike(frameAtual)) bolaAtual++;
                
                bolaAtual++;

                if (bolaAtual > 1)
                {
                    bolaAtual = 0;
                    frameAtual++;
                }
            }
            else bolaAtual++;
        }

        private void somarPontosBase(int pinosDerrubados)
        {
            pinosDerrubadosPorBola[frameAtual, bolaAtual] = pinosDerrubados;
            scoreTotal += pinosDerrubados;
        }
        
        private void somarPontosExtras(int pinosDerrubados)
        {
            if (valePontosEmDobro())
            {
                scoreTotal += pinosDerrubados;

                if (valePontosEmTriplo()) scoreTotal += pinosDerrubados;
            }
        }

        private bool valePontosEmDobro()
        {
            if(frameAtual > 0)
            {
                if (foiStrike(frameAtual-1) && bolaAtual < 2
                 || foiSpare(frameAtual-1)  && bolaAtual == 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool valePontosEmTriplo()
        {
            if (frameAtual > 1
            && foiStrike(frameAtual-1)
            && bolaAtual == 0)
            {
                if (foiStrike(frameAtual-2))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool foiStrike(int frame)
        {
            if (pinosDerrubadosPorBola[frame,0] == 10)
            {
                return true;
            }
            else return false;
        }

        private bool foiSpare(int frame)
        {
            if ((pinosDerrubadosPorBola[frame,0] + pinosDerrubadosPorBola[frame,1] == 10))
            {
                return true;
            }
            else return false;
        }

        public void iniciarPartida()
        {
            pinosDerrubadosPorBola = new int[10,3];
            frameAtual = 0;
            bolaAtual = 0;
            scoreTotal = 0;
        }
    }
}
