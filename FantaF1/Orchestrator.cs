using FantaF1.Action;
using FantaF1.Action.Interfaces;

namespace FantaF1
{
    public class Orchestrator
    {
        #region Interfaces attribute
        public ICampionatiMondialiAction CampionatiMondialiAction { get; set; }
        public ICircuitiAction CircuitiAction { get; set; }
        public IFantaCampionatiAction FantaCampionatiAction { get; set; }
        public IIscrizioniCircuitoCampionatoAction IscrizioniCircuitoCampionatoAction { get; set; }
        public IIscrizioniPilotiCampionatoAction IscrizioniPilotiCampionatoAction { get; set; }
        public IIscrizioniScuderieCampionatoAction IscrizioniScuderieCampionatoAction { get; set; }
        public IIscrizioniUtentiFantaCampionatoAction IscrizioniUtentiFantaCampionatoAction { get; set; }
        public IIscrizioniPilotiScuderieAction IscrizioniPilotiScuderieAction { get; set; }
        public IPilotiAction PilotiAction { get; set; }
        public IPronosticoUtenteFantaCampionatoAction PronosticoUtenteFantaCampionatoAction { get; set; }
        public IPronosticoUtenteGaraAction PronosticoUtenteGaraAction { get; set; }
        public IRegoleCampionatoMondialeAction RegoleCampionatoMondialeAction { get; set; }
        public IRegoleFantaCampionatoAction RegoleFantaCampionatoAction { get; set; }
        public IRisultatoDfnGaraRealeAction RisultatoDfnGaraRealeAction { get; set; }
        public IRisultatoGaraRealeAction RisultatoGaraRealeAction { get; set; }
        public IRisultatoPronosticoAction RisultatoPronosticoAction { get; set; }
        public IScuderieAction ScuderieAction { get; set; }
        public IUtentiAction UtentiAction { get; set; }
        
        #endregion

        public Orchestrator(IDatabaseAction databaseAction)
        {
            InitializeInterfaces(databaseAction);
        }

        private void InitializeInterfaces(IDatabaseAction databaseAction)
        {
            CampionatiMondialiAction = new CampionatiMondialiAction(databaseAction);
            CircuitiAction = new CircuitiAction(databaseAction);
            FantaCampionatiAction = new FantaCampionatiAction(databaseAction);
            IscrizioniCircuitoCampionatoAction = new IscrizioniCircuitoCampionatoAction(databaseAction);
            IscrizioniPilotiCampionatoAction = new IscrizioniPilotiCampionatoAction(databaseAction);
            IscrizioniScuderieCampionatoAction = new IscrizioniScuderieCampionatoAction(databaseAction);
            IscrizioniUtentiFantaCampionatoAction = new IscrizioniUtentiFantaCampionatoAction(databaseAction);
            IscrizioniPilotiScuderieAction = new IscrizioniPilotiScuderieAction(databaseAction);
            PilotiAction = new PilotiAction(databaseAction);
            PronosticoUtenteFantaCampionatoAction = new PronosticoUtenteFantaCampionatoAction(databaseAction);
            PronosticoUtenteGaraAction = new PronosticoUtenteGaraAction(databaseAction);
            RegoleCampionatoMondialeAction = new RegoleCampionatoMondialeAction(databaseAction);
            RegoleFantaCampionatoAction = new RegoleFantaCampionatoAction(databaseAction);
            RisultatoDfnGaraRealeAction = new RisultatoDfnGaraRealeAction(databaseAction);
            RisultatoGaraRealeAction = new RisultatoGaraRealeAction(databaseAction);
            RisultatoPronosticoAction = new RisultatoPronosticoAction(databaseAction);
            ScuderieAction = new ScuderieAction(databaseAction);
            UtentiAction = new UtentiAction(databaseAction);

        }

    }
}