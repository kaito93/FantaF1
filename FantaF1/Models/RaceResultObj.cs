namespace FantaF1.Models
{
    public class RaceResultObj
    {
        public int IdIscrizione { get; set; }
        public int IdCampionato { get; set; }
        public int PilotaId { get; set; }
        public int PosizioneFinale { get; set; }
        public bool Dfn { get; set; }
        public bool GiroVeloce { get; set; }
        public bool PolePosition { get; set; }
        public string SprintRacePosition { get; set; }
        public bool RaceCompleted { get; set; }
    }
}