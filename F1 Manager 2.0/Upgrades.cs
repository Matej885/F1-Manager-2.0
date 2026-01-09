using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace F1_Manager
{
    public class Upgrades
    {
        public int ManufacturingLenght;
        public int efectivity;
        public List<string> nameofupgrades = new List<string>();
        public List<string> Parts = new List<string>();

        public void AddUpgrades()
        {
            Parts.Add("Upgrade pohonnej jednotky – Zvýšený výkon motora s lepším využitím hybridného systému");
            Parts.Add("Upgrade predného krídla – Optimalizovaná aerodynamická rovnováha pre lepšie prejazdy zákrutami");
            Parts.Add("Upgrade zadného krídla – Vylepšený prítlak a efektivita DRS");
            Parts.Add("Upgrade zavesenia – Pokročilé zavesenie pre stabilitu a presné ovládanie");
            Parts.Add("Upgrade bŕzd – Vysokovýkonné karbónové brzdy s lepšou odozvou");
            Parts.Add("Upgrade prevodovky – Plynulejšia prevodovka s rýchlejšími zmenami stupňov");
            Parts.Add("Upgrade pneumatík – Pretekárske zmesi pre konzistentnú priľnavosť");
            Parts.Add("Upgrade palivového systému – Efektívne dávkovanie paliva pre stabilný výkon");
            Parts.Add("Upgrade chladiaceho systému – Lepší tepelný manažment motora a ERS");
            Parts.Add("Upgrade ERS – Pokročilý systém rekuperácie energie pre výkonové boosty");
            Parts.Add("Upgrade podlahy – Zvýšený ground effect pre vyšší prítlak");
            Parts.Add("Upgrade bočných pontónov – Lepší airflow a chladenie");
            Parts.Add("Upgrade riadenia – Presnejšia odozva volantu pri vysokých rýchlostiach");
            Parts.Add("Upgrade telemetrie – Detailnejšie dáta pre lepšie nastavenie monopostu");
            Parts.Add("Upgrade aerodynamického balíka – Celkové zníženie odporu vzduchu");
            Parts.Add("Upgrade hmotnosti – Odľahčené komponenty pre lepšiu akceleráciu");
            Parts.Add("Upgrade štartovacieho systému – Lepšie štarty z miesta");
        }

    }
}
