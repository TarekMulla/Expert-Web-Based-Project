using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NxBRE.InferenceEngine;
using NxBRE.InferenceEngine.IO;
using NxBRE.InferenceEngine.Rules;

namespace AtomLabCoursesV1._0.Expert_System_Layer
{
public class InferenceEngine
{
    private IInferenceEngine engine = new IEImpl(new CustomBinder());

    public void Load_Rules(string Rules_path)
    {
        IRuleBaseAdapter Rules_Adapter = new RuleML09NafDatalogAdapter(
            Rules_path, System.IO.FileAccess.Read);
        engine.LoadRuleBase(Rules_Adapter);
    }

    public void Load_Facts(string Facts_path)
    {
        IFactBaseAdapter Facts_Adapter = new RuleML09NafDatalogAdapter(
            Facts_path, System.IO.FileAccess.Read);
        engine.LoadFacts(Facts_Adapter);
    }

    public void Save_Facts(string Facts_path)
    {
        IFactBaseAdapter Facts_Adapter = new RuleML09NafDatalogAdapter(
            Facts_path, System.IO.FileAccess.Write);
        engine.SaveFacts(Facts_Adapter);
    }

    public void Update_Facts(ListBox Facts_List)
    {
        IEnumerator<Fact> Engine_Facts = engine.Facts;
        Engine_Facts.Reset();
        Facts_List.Items.Clear();
        int i = 0;
        while (Engine_Facts.MoveNext())
        {
            Fact f = Engine_Facts.Current;
            Facts_List.Items.Add("Fact " + i++ + ": " + f.ToString());
        }
    }

    public void Update_Rules(ListBox Rules_List)
    {
        IEnumerator<Implication> Engine_Rules = engine.Implications;
        Engine_Rules.Reset();
        Rules_List.Items.Clear();
        int i = 0;
        while (Engine_Rules.MoveNext())
        {
            Implication imp = Engine_Rules.Current;
            Rules_List.Items.Add("Rule " + i++ + ": " + imp.Label.ToString());
            Rules_List.Items.Add("Deduction : " + imp.Deduction.ToString());
            Rules_List.Items.Add("AtomGroup : " + imp.AtomGroup.ToString());
            Rules_List.Items.Add("Action : " + imp.Action.ToString());
            Rules_List.Items.Add("Priority : " + imp.Priority.ToString());
            Rules_List.Items.Add("----------------------------------------------------------------");

        }
    }

    public void Process()
    {
        engine.Process();
    }

    public List<Fact> Run_Query(string Query)
    {
        IList<IList<Fact>> qrs = engine.RunQuery(Query);
        List<Fact> result = new List<Fact>();
        foreach (IList<Fact> facts in qrs)
            foreach (Fact fact in facts)
                result.Add(fact);
        return result;
    }

    public void Remove_Facts()
    {
        IEnumerator<Fact> Engine_Facts = engine.Facts;
        Engine_Facts.Reset();
        List<Fact> list = new List<Fact>();
        while (Engine_Facts.MoveNext())
        {
            Fact f = Engine_Facts.Current;
            list.Add(f);
        }
        foreach (Fact f in list)
            engine.Retract(f);
    }

    public void Add_Fact(Fact f, string id)
    {
        engine.Modify(id, f);
        if (engine.FactExists(id) == true)
            engine.Modify(id, f);
        else
            engine.Assert(f);
    }

    public bool Fact_Exist(string id)
    {
        return engine.FactExists(id);
    }
}
}


