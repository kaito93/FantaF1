using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FantaF1.Action
{
    public class PronosticoUtenteGaraAction : IPronosticoUtenteGaraAction
    {
        private List<PronosticoUtenteGara> _pronosticiUtentiGara;
        private readonly IDatabaseAction _databaseAction;
        public PronosticoUtenteGaraAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _pronosticiUtentiGara = databaseAction.GetPronosticiUtenteGara();
        }
        public void SavePronosticiInDatabase(IEnumerable<PronosticoStructure> pronosticiList, int garaId, int fantaCampionatoId, List<Piloti> pilotiList, List<Utenti> utentiList)
        {
            foreach (var pronostico in pronosticiList)
            {
                var pronosticoDb = new PronosticoUtenteGara
                {
                    GaraId = garaId,
                    PrimoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaPrimoClassificato, pilotiList),
                    SecondoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaSecondoClassificato, pilotiList),
                    TerzoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaTerzoClassificato, pilotiList),
                    GiroVelocePilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaGiroVeloce, pilotiList),
                    PolePositionPilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaPolePosition, pilotiList),
                    DFNPilotaId = GetPilotaIdFromNameAndSurname(pronostico.PilotaDfn, pilotiList),
                    Inserimento = pronostico.InserimentoPronostico,
                    UtenteId = GetUtenteIdFromName(pronostico.IdUtente, utentiList),
                    FantaCampionatoId = fantaCampionatoId
                };

                _databaseAction.SavePronosticoUtenteGara(pronosticoDb);
            }

        }

        public List<PronosticoUtenteGara> GetPronosticoUtenteGaraFromFantaCampionatoIdAndCircuitoId(int fantaCampionatoId, int garaId)
        {
            return _pronosticiUtentiGara.FindAll(x => x.FantaCampionatoId == fantaCampionatoId && x.GaraId == garaId);

        }

        public IEnumerable<PronosticoStructure> LoadPronosticiFromFileCsv(FileInformation fileCsv)
        {
            var riga = 0;
            var pronosticiList = new List<PronosticoStructure>();

            var path = Path.GetTempPath();
            fileCsv.File.SaveAs(path + "csvPronosticoFile.csv");

            using (var reader = new StreamReader(path + "csvPronosticoFile.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var pronostico = line?.Split(',').ToList();

                    if (pronostico != null)
                        for (var i = 0; i < pronostico.Count; i++)
                        {
                            pronostico[i] = pronostico[i].Replace("\u0022", "");
                            pronostico[i] = pronostico[i].Replace("CET", "");
                        }


                    if (riga != 0)
                    {
                        var pronosticoParsed = new PronosticoStructure
                        {
                            InserimentoPronostico = DateTime.Parse(pronostico?[0].Split(' ')[0]),
                            IdUtente = pronostico?[1],
                            PilotaPrimoClassificato = pronostico?[2],
                            PilotaSecondoClassificato = pronostico?[3],
                            PilotaTerzoClassificato = pronostico?[4],
                            PilotaPolePosition = pronostico?[5],
                            PilotaGiroVeloce = pronostico?[6],
                            PilotaDfn = pronostico?[7]
                        };

                        pronosticiList.Add(pronosticoParsed);
                    }

                    riga++;

                }
                reader.Close();
            }

            return pronosticiList;
        }

        private static int GetPilotaIdFromNameAndSurname(string nameSurname, IEnumerable<Piloti> piloti)
        {
            var result = piloti.FirstOrDefault(x => nameSurname.ToLower().Contains(x.Cognome.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }
        private static int GetUtenteIdFromName(string name, IEnumerable<Utenti> utenti)
        {
            var result = utenti.FirstOrDefault(x =>
                name.ToLower().Contains(x.Nome.ToLower()) && name.ToLower().Contains(x.Cognome.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }
        public List<PronosticoUtenteGara> GetAllPronostici()
        {
            return new List<PronosticoUtenteGara>(_pronosticiUtentiGara);
        }

    }
}