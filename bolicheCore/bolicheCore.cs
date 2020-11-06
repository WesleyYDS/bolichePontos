namespace BolicheCore
{
    public class bolicheScore
    {
        //Quantos pinos foram derrubados [frame, bola], sem influência de multiplicadores
        private int[,] pinosDerrubadosPorBola;
        private int frameAtual;
        private int bolaAtual;
        private int scoreTotal;

        public int getScoreTotal() { return scoreTotal; }

        public void setScoreTotal(int value) { scoreTotal = value; }

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
            setScoreTotal(getScoreTotal() + pinosDerrubados);
        }
        
        private void somarPontosExtras(int pinosDerrubados)
        {
            if (valePontosEmDobro())
            {
                setScoreTotal(getScoreTotal() + pinosDerrubados);

                if (valePontosEmTriplo()) setScoreTotal(getScoreTotal() + pinosDerrubados);
            }
        }

        private bool valePontosEmDobro()
        {
            if(frameAtual > 0)
            {
                return(foiStrike(frameAtual-1) && bolaAtual < 2
                 || foiSpare(frameAtual-1)  && bolaAtual == 0);
            }
            else return false;
        }

        private bool valePontosEmTriplo()
        {
            if (frameAtual > 1
            && foiStrike(frameAtual-1)
            && bolaAtual == 0)
            {
                return (foiStrike(frameAtual-2));
            }
            else return false;
        }

        private bool foiStrike(int frame)
        {
            return (pinosDerrubadosPorBola[frame,0] == 10);
        }

        private bool foiSpare(int frame)
        {
            return (pinosDerrubadosPorBola[frame,0] + pinosDerrubadosPorBola[frame,1] == 10);
        }

        public void iniciarPartida()
        {
            pinosDerrubadosPorBola = new int[10,3];
            frameAtual = 0;
            bolaAtual = 0;
            setScoreTotal(0);
        }
    }
}
