using System;
using System.Collections.Generic;
using System.Linq;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;
using YGOSharp.OCGWrapper.Enums;
namespace WindBot.Game.AI.Decks
{
   
   [Deck("SixSam_5Ds", "AI_SixSam_5Ds")]
    public class SixSam_5DsExecutor: DefaultExecutor
    {
        public class CardId
        {
            // Initialize all normal monsters
            // Initialize all effect monsters
            public const int GrandmasteroftheSixSamurai = 83039729;
            public const int LegendarySixSamuraiKizan = 49721904;
            public const int LegendarySixSamuraiEnishi = 75116619;
            public const int SpiritoftheSixSamurai = 65685470;
            public const int LegendarySixSamuraiKageki = 2511717;
            public const int KagemushaoftheSixSamurai = 1498130;
            public const int TrishulaDragonoftheIceBarrier = 52687916;
            public const int ScrapDragon = 76774528;
            public const int ColossalFighter = 23693634;
            public const int StardustDragon = 44508094;
            public const int BlackRoseDragon = 73580471;
            public const int NaturiaLandoise = 43932460;
            public const int AncientFairyDragon = 25862681;
            public const int NaturiaBarkion = 2956282;
            public const int BrionacDragonoftheIceBarrier = 511002993;
            public const int LegendarySixSamuraiShiEn = 29981921;
            public const int NaturiaBeast = 33198837;
            public const int AllyofJusticeCatastor = 26593852;
            // Initialize all special summonable effect monsters
            // Initialize all pure special summonable effect monsters
            // Initialize all link monsters
            // Initialize all spell and trap cards
            public const int ReinforcementoftheArmy = 32807846;
            public const int GiantTrunade = 42703248;
            public const int DarkHole = 53129443;
            public const int ShiensSmokeSignal = 54031490;
            public const int UpstartGoblin = 70368879;
            public const int MonsterReborn = 83764719;
            public const int MysticalSpaceTyphoon = 5318639;
            public const int BookofMoon = 14087893;
            public const int GatewayoftheSix = 27970830;
            public const int SixSamuraiUnited = 72345736;
            public const int DoubleEdgedSwordTechnique = 21007444;
            public const int MirrorForce = 44095762;
            public const int TorrentialTribute = 53582587;
            public const int DustTornado = 60082869;
            public const int SolemnJudgment = 41420027;
            public const int MusakaniMagatama = 41458579;
            // Initialize all useless cards

         }

        public SixSam_5DsExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            /* TODO */
            /*
             * ~~ set Musakani Magatama only if Bot controls a Six Samurai monster ~~
             * ~~ DustTornado/MST activate on opponent's end phase ~~
             * synchro summon Shi En before or after summoning Kizan(s)???
             * use Shi En second effect to protect from destruction when applicable
             * Use only the second effect of Gateway unless there's a monster that needs to be beaten over
             */

            // first things first
            AddExecutor(ExecutorType.Activate, CardId.GiantTrunade, DefaultGiantTrunade);
            AddExecutor(ExecutorType.Activate, CardId.MysticalSpaceTyphoon, MysticalSpaceTyphoonActivate);
            AddExecutor(ExecutorType.Activate, CardId.DustTornado, DustTornadoActivate);
            AddExecutor(ExecutorType.Activate, CardId.DarkHole, DefaultDarkHole);
            AddExecutor(ExecutorType.Activate, CardId.BookofMoon, DefaultBookOfMoon);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnActivate);
            AddExecutor(ExecutorType.Activate, CardId.SolemnJudgment, DefaultSolemnJudgment);
            AddExecutor(ExecutorType.Activate, CardId.TorrentialTribute, DefaultTorrentialTribute);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, DefaultUniqueTrap);
            AddExecutor(ExecutorType.Activate, CardId.MusakaniMagatama, DefaultTrap);

            // searchers & cycling
            AddExecutor(ExecutorType.Activate, CardId.ShiensSmokeSignal, ShiensSmokeSignalActivate);
            AddExecutor(ExecutorType.Activate, CardId.ReinforcementoftheArmy, ReinforcementoftheArmyActivate);
            AddExecutor(ExecutorType.Activate, CardId.UpstartGoblin, UpstartGoblinActivate);
            AddExecutor(ExecutorType.Activate, CardId.SixSamuraiUnited, SixSamuraiUnitedSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.SixSamuraiUnited, SixSamuraiUnitedActivate);
            AddExecutor(ExecutorType.Activate, CardId.GatewayoftheSix, GatewayoftheSixSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.GatewayoftheSix, GatewayoftheSixActivate);

            // SS
            AddExecutor(ExecutorType.SpSummon, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnNormalSummon);
            AddExecutor(ExecutorType.SpSummon, CardId.GrandmasteroftheSixSamurai, GrandmasteroftheSixSamuraiActivate);
            AddExecutor(ExecutorType.SpSummon, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanActivate);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiActivate);
            //            AddExecutor(ExecutorType.Activate, CardId.DoubleEdgedSwordTechnique, DoubleEdgedSwordTechniqueActivate);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, MonsterRebornActivate);

            // effects on the field
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiActivate);
            AddExecutor(ExecutorType.Activate, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiActivate);

            // summon
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiNormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiNormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiNormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiNormalSummon);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanNormalSummon);

            // extra deck
            AddExecutor(ExecutorType.SpSummon, CardId.TrishulaDragonoftheIceBarrier, TrishulaDragonoftheIceBarrierNormalSummon);

            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
            AddExecutor(ExecutorType.MonsterSet, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiMonsterSet);
            AddExecutor(ExecutorType.MonsterSet, CardId.LegendarySixSamuraiKageki, KagemushaoftheSixSamuraiMonsterSet);

            AddExecutor(ExecutorType.GoToBattlePhase);

            AddExecutor(ExecutorType.SpellSet, CardId.MusakaniMagatama, MusakaniMagatamaSpellSet);
            AddExecutor(ExecutorType.SpellSet, DefaultSpellSet);

            /*
            // Add Executors to all normal monsters
            // Add Executors to all effect monsters
            AddExecutor(ExecutorType.Summon, CardId.GrandmasteroftheSixSamurai, GrandmasteroftheSixSamuraiNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.GrandmasteroftheSixSamurai, GrandmasteroftheSixSamuraiMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.GrandmasteroftheSixSamurai, GrandmasteroftheSixSamuraiRepos);
            AddExecutor(ExecutorType.Activate, CardId.GrandmasteroftheSixSamurai, GrandmasteroftheSixSamuraiActivate);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanRepos);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiKizan, LegendarySixSamuraiKizanActivate);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiRepos);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiEnishi, LegendarySixSamuraiEnishiActivate);
            AddExecutor(ExecutorType.Summon, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiRepos);
            AddExecutor(ExecutorType.Activate, CardId.SpiritoftheSixSamurai, SpiritoftheSixSamuraiActivate);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiRepos);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiKageki, LegendarySixSamuraiKagekiActivate);
            AddExecutor(ExecutorType.Summon, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiRepos);
            AddExecutor(ExecutorType.Activate, CardId.KagemushaoftheSixSamurai, KagemushaoftheSixSamuraiActivate);
            AddExecutor(ExecutorType.Summon, CardId.TrishulaDragonoftheIceBarrier, TrishulaDragonoftheIceBarrierNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.TrishulaDragonoftheIceBarrier, TrishulaDragonoftheIceBarrierMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.TrishulaDragonoftheIceBarrier, TrishulaDragonoftheIceBarrierRepos);
            AddExecutor(ExecutorType.Activate, CardId.TrishulaDragonoftheIceBarrier, TrishulaDragonoftheIceBarrierActivate);
            AddExecutor(ExecutorType.Summon, CardId.ScrapDragon, ScrapDragonNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.ScrapDragon, ScrapDragonMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.ScrapDragon, ScrapDragonRepos);
            AddExecutor(ExecutorType.Activate, CardId.ScrapDragon, ScrapDragonActivate);
            AddExecutor(ExecutorType.Summon, CardId.ColossalFighter, ColossalFighterNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.ColossalFighter, ColossalFighterMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.ColossalFighter, ColossalFighterRepos);
            AddExecutor(ExecutorType.Activate, CardId.ColossalFighter, ColossalFighterActivate);
            AddExecutor(ExecutorType.Summon, CardId.StardustDragon, StardustDragonNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.StardustDragon, StardustDragonMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.StardustDragon, StardustDragonRepos);
            AddExecutor(ExecutorType.Activate, CardId.StardustDragon, StardustDragonActivate);
            AddExecutor(ExecutorType.Summon, CardId.BlackRoseDragon, BlackRoseDragonNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.BlackRoseDragon, BlackRoseDragonMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.BlackRoseDragon, BlackRoseDragonRepos);
            AddExecutor(ExecutorType.Activate, CardId.BlackRoseDragon, BlackRoseDragonActivate);
            AddExecutor(ExecutorType.Summon, CardId.NaturiaLandoise, NaturiaLandoiseNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.NaturiaLandoise, NaturiaLandoiseMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.NaturiaLandoise, NaturiaLandoiseRepos);
            AddExecutor(ExecutorType.Activate, CardId.NaturiaLandoise, NaturiaLandoiseActivate);
            AddExecutor(ExecutorType.Summon, CardId.AncientFairyDragon, AncientFairyDragonNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.AncientFairyDragon, AncientFairyDragonMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.AncientFairyDragon, AncientFairyDragonRepos);
            AddExecutor(ExecutorType.Activate, CardId.AncientFairyDragon, AncientFairyDragonActivate);
            AddExecutor(ExecutorType.Summon, CardId.NaturiaBarkion, NaturiaBarkionNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.NaturiaBarkion, NaturiaBarkionMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.NaturiaBarkion, NaturiaBarkionRepos);
            AddExecutor(ExecutorType.Activate, CardId.NaturiaBarkion, NaturiaBarkionActivate);
            AddExecutor(ExecutorType.Summon, CardId.BrionacDragonoftheIceBarrier, BrionacDragonoftheIceBarrierNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.BrionacDragonoftheIceBarrier, BrionacDragonoftheIceBarrierMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.BrionacDragonoftheIceBarrier, BrionacDragonoftheIceBarrierRepos);
            AddExecutor(ExecutorType.Activate, CardId.BrionacDragonoftheIceBarrier, BrionacDragonoftheIceBarrierActivate);
            AddExecutor(ExecutorType.Summon, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnRepos);
            AddExecutor(ExecutorType.Activate, CardId.LegendarySixSamuraiShiEn, LegendarySixSamuraiShiEnActivate);
            AddExecutor(ExecutorType.Summon, CardId.NaturiaBeast, NaturiaBeastNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.NaturiaBeast, NaturiaBeastMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.NaturiaBeast, NaturiaBeastRepos);
            AddExecutor(ExecutorType.Activate, CardId.NaturiaBeast, NaturiaBeastActivate);
            AddExecutor(ExecutorType.Summon, CardId.AllyofJusticeCatastor, AllyofJusticeCatastorNormalSummon);
            AddExecutor(ExecutorType.MonsterSet, CardId.AllyofJusticeCatastor, AllyofJusticeCatastorMonsterSet);
            AddExecutor(ExecutorType.Repos, CardId.AllyofJusticeCatastor, AllyofJusticeCatastorRepos);
            AddExecutor(ExecutorType.Activate, CardId.AllyofJusticeCatastor, AllyofJusticeCatastorActivate);
            //  Add Executors to all special summonable effect monsters
            //  Add Executors to all pure special summonable effect monsters
            //  Add Executors to all Link monsters
            //  Add Executors to all spell and trap cards
            AddExecutor(ExecutorType.SpellSet, CardId.ReinforcementoftheArmy, ReinforcementoftheArmySpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ReinforcementoftheArmy, ReinforcementoftheArmyActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.GiantTrunade, GiantTrunadeSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.GiantTrunade, GiantTrunadeActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.DarkHole, DarkHoleSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.DarkHole, DarkHoleActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.ShiensSmokeSignal, ShiensSmokeSignalSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.ShiensSmokeSignal, ShiensSmokeSignalActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.UpstartGoblin, UpstartGoblinSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.UpstartGoblin, UpstartGoblinActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.MonsterReborn, MonsterRebornSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.MonsterReborn, MonsterRebornActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.MysticalSpaceTyphoon, MysticalSpaceTyphoonSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.MysticalSpaceTyphoon, MysticalSpaceTyphoonActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.BookofMoon, BookofMoonSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.BookofMoon, BookofMoonActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.GatewayoftheSix, GatewayoftheSixSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.GatewayoftheSix, GatewayoftheSixActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.SixSamuraiUnited, SixSamuraiUnitedSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.SixSamuraiUnited, SixSamuraiUnitedActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.DoubleEdgedSwordTechnique, DoubleEdgedSwordTechniqueSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.DoubleEdgedSwordTechnique, DoubleEdgedSwordTechniqueActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.MirrorForce, MirrorForceSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.MirrorForce, MirrorForceActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.TorrentialTribute, TorrentialTributeSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.TorrentialTribute, TorrentialTributeActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.DustTornado, DustTornadoSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.DustTornado, DustTornadoActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.SolemnJudgment, SolemnJudgmentSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.SolemnJudgment, SolemnJudgmentActivate);
            AddExecutor(ExecutorType.SpellSet, CardId.MusakaniMagatama, MusakaniMagatamaSpellSet);
            AddExecutor(ExecutorType.Activate, CardId.MusakaniMagatama, MusakaniMagatamaActivate);
            */
        }

        public override bool OnSelectHand()
        {
            return true;    // always go first if given the opportunity
        }

        // All Normal Monster Methods

        // All Effect Monster Methods

        private bool GrandmasteroftheSixSamuraiNormalSummon()
        {

            return true;
        }

        private bool GrandmasteroftheSixSamuraiMonsterSet()
        {

            return true;
        }

        private bool GrandmasteroftheSixSamuraiRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool GrandmasteroftheSixSamuraiActivate()
        {

            return true;
        }

        private bool LegendarySixSamuraiKizanNormalSummon()
        {
            if (Bot.HasInHand(CardId.GrandmasteroftheSixSamurai))
                return true;
            return false;
        }

        private bool LegendarySixSamuraiKizanMonsterSet()
        {

            return true;
        }

        private bool LegendarySixSamuraiKizanRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool LegendarySixSamuraiKizanActivate()
        {

            return true;
        }

        private bool LegendarySixSamuraiEnishiNormalSummon()
        {
            if (Bot.HasInHand(CardId.LegendarySixSamuraiKizan) || Bot.HasInHand(CardId.GrandmasteroftheSixSamurai))
                return true;
            if (Bot.MonsterZone.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 1 && Bot.Graveyard.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 2)
                return true;
            return false;
        }

        private bool LegendarySixSamuraiEnishiMonsterSet()
        {

            return true;
        }

        private bool LegendarySixSamuraiEnishiRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool LegendarySixSamuraiEnishiActivate()
        {
            ClientCard target = Util.GetProblematicEnemyMonster();
            if (target == null)
                return false;

            AI.SelectCard(CardId.LegendarySixSamuraiKageki, CardId.KagemushaoftheSixSamurai, CardId.SpiritoftheSixSamurai, CardId.GrandmasteroftheSixSamurai, CardId.LegendarySixSamuraiShiEn);
            AI.SelectNextCard(target);
            return true;
        }

        private bool SpiritoftheSixSamuraiNormalSummon()
        {
            if (Bot.HasInHand(CardId.LegendarySixSamuraiKizan) || Bot.HasInHand(CardId.GrandmasteroftheSixSamurai))
                return true;
            return false;
        }

        private bool SpiritoftheSixSamuraiMonsterSet()
        {

            return true;
        }

        private bool SpiritoftheSixSamuraiRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool SpiritoftheSixSamuraiActivate()
        {

            return true;
        }

        private bool LegendarySixSamuraiKagekiNormalSummon()
        {
            foreach (ClientCard card in Bot.Hand)
                if (card != null && card.IsCode(CardId.KagemushaoftheSixSamurai, CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiEnishi, CardId.LegendarySixSamuraiKizan, CardId.GrandmasteroftheSixSamurai))
                    return true;
            if (Bot.HasInMonstersZone(CardId.KagemushaoftheSixSamurai))
                return true;
            return false;
        }

        private bool LegendarySixSamuraiKagekiMonsterSet()
        {
            if (Duel.Turn == 0 || Enemy.GetMonsterCount() > Bot.GetMonsterCount())
                return true;
            return false;
        }

        private bool LegendarySixSamuraiKagekiRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool LegendarySixSamuraiKagekiActivate()
        {
            AI.SelectCard(CardId.KagemushaoftheSixSamurai, CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiEnishi);
            if (Bot.HasInHand(CardId.KagemushaoftheSixSamurai) || Bot.HasInHand(CardId.SpiritoftheSixSamurai))
                AI.SelectPosition(CardPosition.FaceUpDefence);
            return true;
        }

        private bool KagemushaoftheSixSamuraiNormalSummon()
        {
            if (Bot.HasInHand(CardId.LegendarySixSamuraiKizan) || Bot.HasInHand(CardId.GrandmasteroftheSixSamurai))
                return true;
            if (Bot.HasInMonstersZone(CardId.LegendarySixSamuraiKageki))
                return true;
            return false;
        }

        private bool KagemushaoftheSixSamuraiMonsterSet()
        {
            if (Duel.Turn == 0 || Enemy.GetMonsterCount() > Bot.GetMonsterCount())
                return true;
            return false;
        }

        private bool KagemushaoftheSixSamuraiRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool KagemushaoftheSixSamuraiActivate()
        {

            return true;
        }

        private bool TrishulaDragonoftheIceBarrierNormalSummon()
        {

            return true;
        }

        private bool TrishulaDragonoftheIceBarrierMonsterSet()
        {

            return true;
        }

        private bool TrishulaDragonoftheIceBarrierRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool TrishulaDragonoftheIceBarrierActivate()
        {

            return true;
        }

        private bool ScrapDragonNormalSummon()
        {

            return true;
        }

        private bool ScrapDragonMonsterSet()
        {

            return true;
        }

        private bool ScrapDragonRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool ScrapDragonActivate()
        {

            return true;
        }

        private bool ColossalFighterNormalSummon()
        {

            return true;
        }

        private bool ColossalFighterMonsterSet()
        {

            return true;
        }

        private bool ColossalFighterRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool ColossalFighterActivate()
        {

            return true;
        }

        private bool StardustDragonNormalSummon()
        {

            return true;
        }

        private bool StardustDragonMonsterSet()
        {

            return true;
        }

        private bool StardustDragonRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool StardustDragonActivate()
        {

            return true;
        }

        private bool BlackRoseDragonNormalSummon()
        {

            return true;
        }

        private bool BlackRoseDragonMonsterSet()
        {

            return true;
        }

        private bool BlackRoseDragonRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool BlackRoseDragonActivate()
        {

            return true;
        }

        private bool NaturiaLandoiseNormalSummon()
        {

            return true;
        }

        private bool NaturiaLandoiseMonsterSet()
        {

            return true;
        }

        private bool NaturiaLandoiseRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool NaturiaLandoiseActivate()
        {

            return true;
        }

        private bool AncientFairyDragonNormalSummon()
        {

            return true;
        }

        private bool AncientFairyDragonMonsterSet()
        {

            return true;
        }

        private bool AncientFairyDragonRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool AncientFairyDragonActivate()
        {

            return true;
        }

        private bool NaturiaBarkionNormalSummon()
        {

            return true;
        }

        private bool NaturiaBarkionMonsterSet()
        {

            return true;
        }

        private bool NaturiaBarkionRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool NaturiaBarkionActivate()
        {

            return true;
        }

        private bool BrionacDragonoftheIceBarrierNormalSummon()
        {
            return true;
        }

        private bool BrionacDragonoftheIceBarrierMonsterSet()
        {
            return true;
        }

        private bool BrionacDragonoftheIceBarrierRepos()
        {
            return DefaultMonsterRepos();
        }

        private bool BrionacDragonoftheIceBarrierActivate()
        {
            return true;
        }

        private bool LegendarySixSamuraiShiEnNormalSummon()
        {

            return true;
        }

        private bool LegendarySixSamuraiShiEnMonsterSet()
        {

            return true;
        }

        private bool LegendarySixSamuraiShiEnRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool LegendarySixSamuraiShiEnActivate()
        {
            if (ActivateDescription == Util.GetStringId(CardId.LegendarySixSamuraiShiEn, 0))
                return Duel.LastChainPlayer == 1;
            else if (ActivateDescription == Util.GetStringId(CardId.LegendarySixSamuraiShiEn, 1))
            {
                AI.SelectCard(Bot.MonsterZone.GetMatchingCards(card => card.Name.Contains("Six Samurai")).OrderBy(c => c.Attack).ToList());
                return true;
            }
            return false;
        }

        private bool NaturiaBeastNormalSummon()
        {

            return true;
        }

        private bool NaturiaBeastMonsterSet()
        {

            return true;
        }

        private bool NaturiaBeastRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool NaturiaBeastActivate()
        {

            return true;
        }

        private bool AllyofJusticeCatastorNormalSummon()
        {

            return true;
        }

        private bool AllyofJusticeCatastorMonsterSet()
        {

            return true;
        }

        private bool AllyofJusticeCatastorRepos()
        {

            return DefaultMonsterRepos();
        }

        private bool AllyofJusticeCatastorActivate()
        {

            return true;
        }

            // All Special Summonable Effect Monster Methods

            // All Pure Special Summonable Effect Monster Methods

            // All Link Monster Methods

            // All Spell and Trap Card Methods

        private bool ReinforcementoftheArmySpellSet()
        {

            return DefaultSpellSet();
        }

        private bool ReinforcementoftheArmyActivate()
        {
            if (!Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                AI.SelectCard(CardId.LegendarySixSamuraiKageki);
            else if (Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                AI.SelectCard(CardId.KagemushaoftheSixSamurai);
            else if (Bot.HasInHand(CardId.KagemushaoftheSixSamurai) && Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.LegendarySixSamuraiKizan))
                AI.SelectCard(CardId.LegendarySixSamuraiKizan);
            else if (Bot.HasInHand(CardId.GrandmasteroftheSixSamurai) && !Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
            {
                if (Bot.Graveyard.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 2)
                    AI.SelectCard(CardId.LegendarySixSamuraiEnishi, CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiKizan, CardId.KagemushaoftheSixSamurai);
                else
                    AI.SelectCard(CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiKizan, CardId.KagemushaoftheSixSamurai);
            }
            else
                AI.SelectCard(CardId.LegendarySixSamuraiKizan, CardId.LegendarySixSamuraiKageki);
            return true;
        }

        private bool GiantTrunadeSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool GiantTrunadeActivate()
        {

            return true;
        }

        private bool DarkHoleSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool DarkHoleActivate()
        {

            return true;
        }

        private bool ShiensSmokeSignalSpellSet()
        {
            return DefaultSpellSet();
        }

        private bool ShiensSmokeSignalActivate()
        {
            if (Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                AI.SelectCard(CardId.KagemushaoftheSixSamurai);
            else
                AI.SelectCard(CardId.LegendarySixSamuraiKageki, CardId.SpiritoftheSixSamurai, CardId.KagemushaoftheSixSamurai);

            return true;
        }

        private bool UpstartGoblinSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool UpstartGoblinActivate()
        {

            return true;
        }

        private bool MonsterRebornSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool MonsterRebornActivate()
        {
            /*
            if (Duel.Player == 0 && Duel.CurrentChain.Count > 0)
            {
                // Silver's Cry spsummon Dragon Spirit at chain 2 will miss the timing
                return false;
            }
            if (Duel.Player == 0 && (Duel.Phase == DuelPhase.Draw || Duel.Phase == DuelPhase.Standby))
            {
                // Let Azure-Eyes spsummon first
                return false;
            }
            IList<int> targets = new[] {
                    CardId.HopeHarbingerDragonTitanicGalaxy,
                    CardId.GalaxyEyesDarkMatterDragon,
                    CardId.AlternativeWhiteDragon,
                    CardId.AzureEyesSilverDragon,
                    CardId.BlueEyesSpiritDragon,
                    CardId.WhiteDragon,
                    CardId.DragonSpiritOfWhite
                };
            if (!Bot.HasInGraveyard(targets))
            {
                return false;
            }
            ClientCard floodgate = Enemy.SpellZone.GetFloodgate();
            if (floodgate != null && Bot.HasInGraveyard(CardId.DragonSpiritOfWhite))
            {
                AI.SelectCard(CardId.DragonSpiritOfWhite);
            }
            else
            {
                AI.SelectCard(targets);
            }
            */
            return true;
        }

        private bool MysticalSpaceTyphoonSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool MysticalSpaceTyphoonActivate()
        {
            foreach (ClientCard card in Duel.CurrentChain)
                if (card.IsCode(CardId.MysticalSpaceTyphoon))
                    return false;

            // target card to destroy
            List<ClientCard> spells = Enemy.GetSpells();
            if (spells.Count == 0)
                return false;

            ClientCard selected = Enemy.SpellZone.GetFloodgate();

            if (selected == null)
            {
                if (Duel.Player == 0)
                    selected = spells.FirstOrDefault(card => card.IsFacedown());
                if (Duel.Player == 1)
                {
                    if (Duel.Phase == DuelPhase.End)
                        selected = spells.FirstOrDefault(card => card.IsFacedown());
                    else
                        selected = spells.FirstOrDefault(card => card.HasType(CardType.Continuous) || card.HasType(CardType.Equip) || card.HasType(CardType.Field));
                }
            }

            if (selected == null)
                return false;
            AI.SelectCard(selected);
            return true;
        }

        private bool BookofMoonSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool BookofMoonActivate()
        {

            return true;
        }

        private bool GatewayoftheSixSpellSet()
        {
            if (Card.Location != CardLocation.Hand)
                return false;
            if (Bot.Hand.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 2)
                return Bot.GetSpellCountWithoutField() < 4;
            return false;
        }

        private bool GatewayoftheSixActivate()
        {
            if (Card.Location == CardLocation.Hand)
                return false;
            if (Card.Location == CardLocation.SpellZone && Card.IsFacedown())
                return true;
            if (ActivateDescription == Util.GetStringId(CardId.GatewayoftheSix, 0))
            {
                if (Duel.Phase == DuelPhase.Main2)
                    return false;

                IList<ClientCard> sixsams = Bot.MonsterZone.GetMatchingCards(card => card.Name.Contains("Six Samurai"));
                if (sixsams.Count == 0)
                    return false;

                ClientCard bestatk = sixsams.OrderByDescending(c => c.Attack).FirstOrDefault();
                ClientCard worstatk = sixsams.OrderBy(c => c.Attack).FirstOrDefault();

                // prioritise board advantage if opp's best-power monster is within (Counters + 2*(# of SS-able Kizans and Grandmasters in hand) - 4)/2*500 of bot's best-power monster
                int kizans_and_grandmaster = Main.SpecialSummonableCards.GetMatchingCardsCount(card => card.Name.Contains("Legendary Six Samurai - Kizan"));
                if (Main.SpecialSummonableCards.ContainsCardWithId(CardId.GrandmasteroftheSixSamurai))
                    kizans_and_grandmaster++;
                if (Bot.GetMonsterCount() <= Enemy.GetMonsterCount() && (Card.Counters[3] >= 4 || kizans_and_grandmaster > 0) && 
                    ((Card.Counters[3] + 2*kizans_and_grandmaster - 4)/2*500)+bestatk.Attack > Util.GetBestPower(Enemy))
                {
                    Console.WriteLine("Board adv selection");
                    return false;
                }

                // because of ordering of actions, kizans_and_grandmaster are incorporated into this calculation with the assumption that they will be successfully SS'd
                if (bestatk.Attack <= Util.GetBestPower(Enemy) && bestatk.Attack + 500 * (Card.Counters[3] / 2 + kizans_and_grandmaster) > Util.GetBestPower(Enemy))
                {
                    AI.SelectCard(bestatk);
                    return true;
                }
                else if (Enemy.MonsterZone.GetMonsters().Count == 0 && Util.GetTotalAttackingMonsterAttack(0) < Enemy.LifePoints && Util.GetTotalAttackingMonsterAttack(0) + 500 * (Card.Counters[3] / 2) >= Enemy.LifePoints)
                {
                    AI.SelectCard(worstatk);
                    return true;
                }
                return false;
            }
            if (ActivateDescription == Util.GetStringId(CardId.GatewayoftheSix, 1))
            {
                if (!Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                    AI.SelectCard(CardId.LegendarySixSamuraiKageki);
                else if (Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                    AI.SelectCard(CardId.KagemushaoftheSixSamurai);
                else if (Bot.HasInHand(CardId.KagemushaoftheSixSamurai) && Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && (!Bot.HasInHand(CardId.LegendarySixSamuraiKizan) || !Bot.HasInHand(CardId.GrandmasteroftheSixSamurai)))
                    AI.SelectCard(CardId.LegendarySixSamuraiKizan, CardId.GrandmasteroftheSixSamurai);
                else if (Bot.HasInHand(CardId.GrandmasteroftheSixSamurai) && !Bot.HasInHand(CardId.LegendarySixSamuraiKageki) && !Bot.HasInHand(CardId.KagemushaoftheSixSamurai))
                {
                    if (Bot.Graveyard.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 2)
                        AI.SelectCard(CardId.LegendarySixSamuraiEnishi, CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiKizan, CardId.KagemushaoftheSixSamurai);
                    else
                        AI.SelectCard(CardId.SpiritoftheSixSamurai, CardId.LegendarySixSamuraiKizan, CardId.KagemushaoftheSixSamurai);
                }
                else if (!Bot.HasInExtra(CardId.LegendarySixSamuraiShiEn))
                    AI.SelectCard(CardId.LegendarySixSamuraiShiEn);
                else
                    AI.SelectCard(CardId.LegendarySixSamuraiKizan, CardId.GrandmasteroftheSixSamurai, CardId.LegendarySixSamuraiKageki);
                return true;
            }
            return false;
        }

        private bool SixSamuraiUnitedSpellSet()
        {
            if (Card.Location != CardLocation.Hand)
                return false;
            if (Bot.Hand.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 2 &&
                (Bot.HasInHand(CardId.LegendarySixSamuraiKageki) || Bot.HasInHand(CardId.LegendarySixSamuraiKizan) ||
                (Bot.HasInHand(CardId.KagemushaoftheSixSamurai) || Bot.HasInHand(CardId.SpiritoftheSixSamurai) || Bot.HasInHand(CardId.LegendarySixSamuraiEnishi)) && Bot.HasInHand(CardId.GrandmasteroftheSixSamurai)))
                return true;
            return false;
        }

        private bool SixSamuraiUnitedActivate()
        {
            if (Card.Location == CardLocation.Hand)
                return false;
            if (Card.Location == CardLocation.SpellZone && Card.IsFacedown())
                return true;
            if (Card.Counters[3] == 2)      // don't use six samurai united's eff unless it has 2 bushido counters
                return true;
            return false;
        }

        private bool DoubleEdgedSwordTechniqueSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool DoubleEdgedSwordTechniqueActivate()
        {

            return true;
        }

        private bool MirrorForceSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool MirrorForceActivate()
        {

            return true;
        }

        private bool TorrentialTributeSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool TorrentialTributeActivate()
        {

            return true;
        }

        private bool DustTornadoSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool DustTornadoActivate()
        {
            foreach (ClientCard card in Duel.CurrentChain)
                if (card.IsCode(CardId.DustTornado) || card.IsCode(CardId.MysticalSpaceTyphoon))
                    return false;

            // target card to destroy
            List<ClientCard> spells = Enemy.GetSpells();
            if (spells.Count == 0)
                return false;

            ClientCard selected = Enemy.SpellZone.GetFloodgate();

            if (selected == null)
            {
                if (Duel.Player == 0)
                    selected = spells.FirstOrDefault(card => card.IsFacedown());
                if (Duel.Player == 1)
                {
                    if (Duel.Phase == DuelPhase.End)
                        selected = spells.FirstOrDefault(card => card.IsFacedown());
                    else
                        selected = spells.FirstOrDefault(card => card.HasType(CardType.Continuous) || card.HasType(CardType.Equip) || card.HasType(CardType.Field));
                }
            }

            if (selected == null)
                return false;
            AI.SelectCard(selected);

            // set a facedown afterwards?
            ClientCard toset = Bot.Hand.FirstOrDefault(card => card.HasType(CardType.Trap) || card.HasType(CardType.QuickPlay));
            if (toset == null || Duel.Phase != DuelPhase.End)
            {
                AI.SelectYesNo(false);
                return true;
            }
            AI.SelectNextCard(toset);
            return true;
        }

        private bool SolemnJudgmentSpellSet()
        {

            return DefaultSpellSet();
        }

        private bool SolemnJudgmentActivate()
        {

            return true;
        }

        private bool MusakaniMagatamaSpellSet()
        {
            return Bot.GetSpellCountWithoutField() < 4 && Bot.MonsterZone.GetMatchingCardsCount(card => card.Name.Contains("Six Samurai")) >= 1;
        }

        private bool MusakaniMagatamaActivate()
        {

            return true;
        }

    }
}
