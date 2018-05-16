using System;
using System.Collections.Generic;
using System.Text;

namespace TK_DataComparerLib
{
    public enum Comparison
    {
        LeftOnly, RightOnly, Equals, Differ
    }

    public class ComparisonBoard
    {
        public void CreateComparison(ComparableData inLeftData, ComparableData inRightData)
        {
            _leftData = inLeftData;
            _rightData = inRightData;

            Compare();
            AssociateEntities();
        }

        ComparableData _leftData = null;
        ComparableData _rightData = null;

        List<DataEntity[]> _assocciations = new List<DataEntity[]>();

        Dictionary<DataEntity, Dictionary<DataEntity, Dictionary<string, double>>> _comparisons = new Dictionary<DataEntity, Dictionary<DataEntity, Dictionary<string, double>>>();

        bool fastCompare = true;

        public bool FastCompare
        {
            get
            {
                return fastCompare;
            }
            set
            {
                fastCompare = value;
            }
        }

        public Dictionary<DataEntity, Dictionary<DataEntity, Dictionary<string, double>>> Comparisons
        {
            get { return _comparisons; }
        }

        public string[] GetConfirmedAssociations(string id,bool left)
        {
            string[] rslt = new string[0];

            DataEntity entity = GetEntity(id, left);
            if (entity != null)
            {
                List<DataEntity> entities = GetConfirmedAssociations(entity);
                rslt = new string[entities.Count];

                int counter = 0;
                foreach (DataEntity curEntity in entities)
                {
                    rslt[counter] = curEntity.Id;
                    counter++;
                }
            }

            return rslt;
        }

        public List<DataEntity> GetConfirmedAssociations(DataEntity inEntity)
        {
            List<DataEntity> rslt = new List<DataEntity>();

            foreach (DataEntity[] assoc in _assocciations)
            {
                if (assoc[0] == inEntity)
                {
                    rslt.Add(assoc[1]);
                }
                else if (assoc[1] == inEntity)
                {
                    rslt.Add(assoc[0]);
                }
            }

            return rslt;
        }

        public List<DataEntity> GetPossibleAssociations(DataEntity inEntity)
        {
            List<DataEntity> rslt = new List<DataEntity>();
            
            if (!inEntity.DontAssociate)
            {
                ComparableData otherData = inEntity.Comparable == _leftData ? _rightData : _leftData;
                List<DataEntity> confirmed = GetConfirmedAssociations(inEntity);

                foreach (DataEntity entity in otherData.Entities)
                {
                    if (!confirmed.Contains(entity))
                    {
                        rslt.Add(entity);
                    }
                }
            }
            
            return rslt;
        }

        public void Compare()
        {
            _comparisons.Clear();

            foreach(DataEntity leftentity in _leftData.Entities)
            {
                Dictionary<DataEntity, Dictionary<string, double>> perLeftEntity;
                if (!_comparisons.TryGetValue(leftentity, out perLeftEntity))
                {
                    _comparisons.Add(leftentity, new Dictionary<DataEntity, Dictionary<string, double>>());
                }

                foreach(DataEntity rightentity in _rightData.Entities)
                {
                    Dictionary<DataEntity, Dictionary<string, double>> perRightEntity;
                    if (!_comparisons.TryGetValue(rightentity, out perRightEntity))
                    {
                        _comparisons.Add(rightentity, new Dictionary<DataEntity, Dictionary<string, double>>());
                    }

                    _comparisons[leftentity].Add(rightentity, new Dictionary<string, double>());
                    _comparisons[rightentity].Add(leftentity, new Dictionary<string, double>());

                    int propCounter = 0;
                    foreach(EntityProperty property in leftentity.Properties)
                    {
                        if (property.Active)
                        {
                            double score = property.Compare(rightentity.Properties[propCounter], this);

                            _comparisons[leftentity][rightentity].Add(property.Name, score);
                            _comparisons[rightentity][leftentity].Add(property.Name, score);
                        }

                        propCounter++;
                    }
                }
            }
        }

        public void AssociateEntities()
        {
            List<DataEntity> associatedEntities = new List<DataEntity>();

            foreach (DataEntity entity in _comparisons.Keys)
            {
                entity.AssociatedEntity = null;
            }

            //Calculate scores
            List<ComparisonScore> scores = new List<ComparisonScore>();

            foreach (DataEntity entity in _comparisons.Keys)
            {
                if (entity.DontAssociate || entity.AssociatedEntity != null)
                {
                    continue;
                }

                List<DataEntity> assocs = GetConfirmedAssociations(entity);

                if (assocs.Count > 0)
                {
                    entity.AssociatedEntity = assocs[0];
                    assocs[0].AssociatedEntity = entity;
                    continue;
                }

                foreach (DataEntity otherEntity in _comparisons[entity].Keys)
                {
                    if (!otherEntity.DontAssociate && otherEntity.AssociatedEntity == null)
                    {
                        double score = 0;
                        foreach (string propName in _comparisons[entity][otherEntity].Keys)
                        {
                            score += _comparisons[entity][otherEntity][propName] * entity.GetProperty(propName).Coeff;
                        }

                        scores.Add(new ComparisonScore(entity, otherEntity, score));
                    }
                }
            }

            scores.Sort();
            scores.Reverse();

            foreach (ComparisonScore score in scores)
            {
                if (score.LeftEntity.AssociatedEntity == null && score.RightEntity.AssociatedEntity == null)
                {
                    score.LeftEntity.AssociatedEntity = score.RightEntity;
                    score.RightEntity.AssociatedEntity = score.LeftEntity;
                }
            }
        }

        public Comparison GetSummary(DataEntity comparedEntity, DataEntity dataEntity)
        {
            Dictionary<string, double> comparisons = _comparisons[comparedEntity][dataEntity];

            int propCounter = 0;
            foreach (string propName in comparisons.Keys)
            {
                if (comparedEntity.Properties[propCounter].Mandatory && comparisons[propName] < 1.0)
                {
                    return Comparison.Differ;
                }
                propCounter++;
            }

            return Comparison.Equals;
        }

        public string[] GetPossibleAssociations(string id, bool left)
        {
            string[] rslt = new string[0];

            DataEntity entity = GetEntity(id, left);
            if (entity != null)
            {
                List<DataEntity> entities = GetPossibleAssociations(entity);
                rslt = new string[entities.Count];

                int counter = 0;
                foreach(DataEntity curEntity in entities)
                {
                    rslt[counter] = curEntity.Id;
                    counter++;
                }
            }

            return rslt;
        }

        public DataEntity GetEntity(string id, bool left)
        {
            foreach (DataEntity entity in _comparisons.Keys)
            {
                if (entity.Id == id && (entity.Comparable == _leftData) == left)
                {
                    return entity;
                }
            }

            return null;
        }

        public void Associate(DataEntity inSource, DataEntity inAssociate)
        {
            inSource.DontAssociate = false;
            inAssociate.DontAssociate = false;

            List<DataEntity> confirmed = GetConfirmedAssociations(inSource);
            if(!confirmed.Contains(inAssociate))
            {
                _assocciations.Add(new DataEntity[]{inSource, inAssociate});
            }
            AssociateEntities();
        }

        public void Associate(string idSource, string idAssociate, bool left)
        {
            DataEntity source = GetEntity(idSource, left);
            if (source == null) { return; }

            DataEntity associate = GetEntity(idAssociate, !left);
            if (associate == null) { return; }

            Associate(source, associate);
        }

        public void DeAssociate(string idSource, string idAssociate, bool left)
        {
            DataEntity source = GetEntity(idSource, left);
            if (source == null) { return; }

            DataEntity associate = GetEntity(idAssociate, !left);
            if (associate == null) { return; }

            DeAssociate(source, associate);
        }

        public void DeAssociate(DataEntity inSource, DataEntity inAssociate)
        {
            foreach (DataEntity[] assoc in _assocciations)
            {
                if (inSource == assoc[0])
                {
                    if (inAssociate == assoc[1])
                    {
                        _assocciations.Remove(assoc);
                        AssociateEntities();
                        return;
                    }
                }
                else if (inSource == assoc[1])
                {
                    if (inAssociate == assoc[0])
                    {
                        _assocciations.Remove(assoc);
                        AssociateEntities();
                        return;
                    }
                }
            }
        }

        public string[] GetTransferables(DataEntity currentEntity)
        {
            List<string> transferables = new List<string>();

            foreach (EntityProperty prop in currentEntity.Properties)
            {
                if (prop.Transferable)
                {
                    transferables.Add(prop.Name);
                }
            }

            string[] transfer = new string[transferables.Count];
            transferables.CopyTo(transfer);

            return transfer;
        }

        public double GetCorrelation(int inInt1, int inInt2)
        {
            if (inInt1 == inInt2)
            {
                return 1.0;
            }

            int delta = Math.Abs(inInt1 - inInt2);
            return Math.Min(1.0, Math.Max(0.0, 1.0 - (double)delta / (Math.Abs(inInt1) + Math.Abs(inInt2)) / 2));
        }

        public double GetCorrelation(string inString1, string inString2)
        {
            if (inString1 == inString2)
            {
                return 1.0;
            }

            if (inString1.ToLower() == inString2.ToLower())
            {
                return .98;
            }

            if (fastCompare)
            {
                return 0.0;//(.75 / (Math.Abs(inString1.Length - inString2.Length)) + 1)/100.0;
            }

            double WordsRatio = 0.0;
            double RealWordsRatio = 0.0;
            double ratio = GetSimilarityRatio(inString1, inString2, out WordsRatio, out RealWordsRatio);

            return Math.Min(0.95, ratio/100.0);
        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        static double GetSimilarityRatio(String FullString1, String FullString2, out double WordsRatio, out double RealWordsRatio)
        {
            double theResult = 0;
            String[] Splitted1 = FullString1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            String[] Splitted2 = FullString2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Splitted1.Length < Splitted2.Length)
            {
                String[] Temp = Splitted2;
                Splitted2 = Splitted1;
                Splitted1 = Temp;
            }
            int[,] theScores = new int[Splitted1.Length, Splitted2.Length];//Keep the best scores for each word.0 is the best, 1000 is the starting.
            int[] BestWord = new int[Splitted1.Length];//Index to the best word of Splitted2 for the Splitted1.

            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                for (int loop1 = 0; loop1 < Splitted2.Length; loop1++) theScores[loop, loop1] = 1000;
                BestWord[loop] = -1;
            }
            int WordsMatched = 0;
            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                String String1 = Splitted1[loop];
                for (int loop1 = 0; loop1 < Splitted2.Length; loop1++)
                {
                    String String2 = Splitted2[loop1];
                    int LevenshteinDistance = Compute(String1, String2);
                    theScores[loop, loop1] = LevenshteinDistance;
                    if (BestWord[loop] == -1 || theScores[loop, BestWord[loop]] > LevenshteinDistance) BestWord[loop] = loop1;
                }
            }

            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                if (theScores[loop, BestWord[loop]] == 1000) continue;
                for (int loop1 = loop + 1; loop1 < Splitted1.Length; loop1++)
                {
                    if (theScores[loop1, BestWord[loop1]] == 1000) continue;//the worst score available, so there are no more words left
                    if (BestWord[loop] == BestWord[loop1])//2 words have the same best word
                    {
                        //The first in order has the advantage of keeping the word in equality
                        if (theScores[loop, BestWord[loop]] <= theScores[loop1, BestWord[loop1]])
                        {
                            theScores[loop1, BestWord[loop1]] = 1000;
                            int CurrentBest = -1;
                            int CurrentScore = 1000;
                            for (int loop2 = 0; loop2 < Splitted2.Length; loop2++)
                            {
                                //Find next bestword
                                if (CurrentBest == -1 || CurrentScore > theScores[loop1, loop2])
                                {
                                    CurrentBest = loop2;
                                    CurrentScore = theScores[loop1, loop2];
                                }
                            }
                            BestWord[loop1] = CurrentBest;
                        }
                        else//the latter has a better score
                        {
                            theScores[loop, BestWord[loop]] = 1000;
                            int CurrentBest = -1;
                            int CurrentScore = 1000;
                            for (int loop2 = 0; loop2 < Splitted2.Length; loop2++)
                            {
                                //Find next bestword
                                if (CurrentBest == -1 || CurrentScore > theScores[loop, loop2])
                                {
                                    CurrentBest = loop2;
                                    CurrentScore = theScores[loop, loop2];
                                }
                            }
                            BestWord[loop] = CurrentBest;
                        }

                        loop = -1;
                        break;//recalculate all
                    }
                }
            }
            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                if (theScores[loop, BestWord[loop]] == 1000) theResult += Splitted1[loop].Length;//All words without a score for best word are max failures
                else
                {
                    theResult += theScores[loop, BestWord[loop]];
                    if (theScores[loop, BestWord[loop]] == 0) WordsMatched++;
                }
            }
            int theLength = (FullString1.Replace(" ", "").Length > FullString2.Replace(" ", "").Length) ? FullString1.Replace(" ", "").Length : FullString2.Replace(" ", "").Length;
            if (theResult > theLength) theResult = theLength;
            theResult = (1 - (theResult / theLength)) * 100;
            WordsRatio = ((double)WordsMatched / (double)Splitted2.Length) * 100;
            RealWordsRatio = ((double)WordsMatched / (double)Splitted1.Length) * 100;
            return theResult;
        }

        public void SaveMappings(string inPath)
        {
            SaveAbleMapping mappping = new SaveAbleMapping();

            foreach (DataEntity entity in _comparisons.Keys)
            {
                List<DataEntity> entities = GetConfirmedAssociations(entity);
                if (entities.Count > 0)
                {
                    string items = "";
                    foreach (DataEntity assocEntity in entities)
                    {
                        items += (items == "" ? "" : ";") + assocEntity.Comparable.Name + "|" + assocEntity.Id;
                    }
                    mappping.Mappings.PushItem(entity.Comparable.Name + "|" + entity.Id, items);
                }
                else if(entity.AssociatedEntity != null)
                {
                    mappping.Mappings.PushItem(entity.Comparable.Name + "|" + entity.Id, entity.AssociatedEntity.Comparable.Name + "|" + entity.AssociatedEntity.Id);
                }
            }

            mappping.Save(inPath, true);
        }

        public void LoadMappings(string inPath)
        {
            SaveAbleMapping mappping = new SaveAbleMapping();
            mappping.Load(inPath);
            mappping.Mappings.SyncDic();

            Dictionary<DataEntity, List<DataEntity>> assocs = new Dictionary<DataEntity,List<DataEntity>>();

            foreach (string key in mappping.Mappings.Keys)
            {
                string[] nameSplit = key.Split('|');
                string entityName = nameSplit[1];

                DataEntity entity = GetEntity(entityName, true);
                if (entity != null)
                {
                    string[] mappings = ((string)mappping.Mappings.GetValue(key)).Split(';');
                    foreach (string mapping in mappings)
                    {
                        string[] nameSplit2 = mapping.Split('|');
                        string entityName2 = nameSplit2[1];
                        DataEntity otherEntity = GetEntity(entityName2, false);
                        if(otherEntity != null)
                        {
                            if(assocs.ContainsKey(entity))
                            {
                                assocs[entity].Add(otherEntity);
                            }
                            else
                            {
                                List<DataEntity> entities = new List<DataEntity>();
                                entities.Add(otherEntity);
                                assocs.Add(entity, entities);
                            }
                        }
                    }
                }
            }

            foreach (DataEntity key in assocs.Keys)
            {
                List<DataEntity> newAssocs = assocs[key];
                List<DataEntity> oldAssocs = GetConfirmedAssociations(key);
                if (oldAssocs.Count > 0)
                {
                    foreach (DataEntity assocEntity in oldAssocs)
                    {
                        if (!newAssocs.Contains(assocEntity))
                        {
                            DeAssociate(key, assocEntity);
                        }
                    }
                }
                else
                {
                    if (newAssocs.Count == 1)
                    {
                        if (key.AssociatedEntity != newAssocs[0])
                        {
                            Associate(key, newAssocs[0]);
                        }
                    }
                    else
                    {
                        if (newAssocs.Count == 0)
                        {
                            if (key.AssociatedEntity != null)
                            {
                                key.DontAssociate = true;
                            }
                        }
                        else
                        {
                            foreach (DataEntity assocEntity in newAssocs)
                            {
                                if (!oldAssocs.Contains(assocEntity))
                                {
                                    Associate(key, assocEntity);
                                }
                            }
                        }
                    }
                }
            }

            AssociateEntities();
        }

        internal void SetPropertiesActivation(Dictionary<string, bool> propertiesStatuses)
        {
            foreach (DataEntity entity in _leftData.Entities)
            {
                foreach (EntityProperty prop in entity.Properties)
                {
                    prop.Active = propertiesStatuses[prop.Name];
                }
            }

            foreach (DataEntity entity in _rightData.Entities)
            {
                foreach (EntityProperty prop in entity.Properties)
                {
                    prop.Active = propertiesStatuses[prop.Name];
                }
            }
        }
    }
}
