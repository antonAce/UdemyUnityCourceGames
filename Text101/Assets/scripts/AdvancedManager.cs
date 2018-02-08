using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Action
{
    public string ButtonName;
    public string Text;
    public string NextArticle;
}

public class Article
{
    public string ArticleName { get; set; }
    public string ArticleText { get; set; }

    public List<Action> ArticleActions = new List<Action>();

    public void AddAction(string button, string text, string article)
    {
        Action tmpAction;
        tmpAction.ButtonName = button;
        tmpAction.Text = text;
        tmpAction.NextArticle = article;
        ArticleActions.Add(tmpAction);
    }

    public string ChangeCurrentStage(string pressedKey)
    {
        // TODO: Complete function, make unit-test
        foreach (Action action in ArticleActions)
        {
            if (action.ButtonName == pressedKey)
                return action.NextArticle;
        }
        return "";
    }
}

public class AdvancedManager : MonoBehaviour
{
    public Text ArticleUIText;
    public List<Article> Articles = new List<Article>();
    private const string Filepath = "Assets/resources/script.xml";
    private string _currentstage;
    private Article _tempArticle, _currentArticle;
    private string _tempStageName, _tempStageText, _tempButtonName, _tempText, _tempNextArticle, _tempStageUINavigator;
    public List<Action> TempActions = new List<Action>();

    void Start ()
	{
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Filepath);
	    XmlElement xRoot = xDoc.DocumentElement;

	    foreach (XmlNode xNode in xRoot)
	    {
            if (xNode.Attributes.Count > 0)
	        {
	            XmlNode attr = xNode.Attributes.GetNamedItem("name");
	            if (attr != null)
	            {
	                _tempStageName = attr.Value;
                    //Debug.Log("Stage: " + _tempStageName);
	            }
            }

	        foreach (XmlNode childNode in xNode.ChildNodes)
	        {
	            if (childNode.Name == "text")
	            {
	                _tempStageText = childNode.InnerText;
                    //Debug.Log("Script: " + _tempStageText);
                }
	            if (childNode.Name == "action")
	            {
	                if (childNode.Attributes.Count > 0)
	                {
	                    Action actn;

                        XmlNode attrKey = childNode.Attributes.GetNamedItem("key");
	                    _tempButtonName = attrKey.Value;

                        XmlNode attrGotoStage = childNode.Attributes.GetNamedItem("gotoStage");
	                    _tempNextArticle = attrGotoStage.Value;

	                    _tempText = childNode.InnerText;

	                    actn.ButtonName = _tempButtonName;
	                    actn.Text = _tempText;
	                    actn.NextArticle = _tempNextArticle;

                        TempActions.Add(actn);
                    }
                }
            }
	        //Debug.Log("   ");
            
            _tempArticle = new Article() {ArticleName = _tempStageName, ArticleText = _tempStageText};

            for (int i = 0; i < TempActions.Count; i++)
                _tempArticle.AddAction(TempActions[i].ButtonName, TempActions[i].Text, TempActions[i].NextArticle);

            Articles.Add(_tempArticle);
	        TempActions.Clear();
	    }

	    _currentstage = Articles[0].ArticleName;
	    _currentArticle = GetArticleByName(Articles, _currentstage);

        //Debug.Log("Current stage: " + _currentstage);

	    _tempStageUINavigator = "";
	    for (int i = 0; i < Articles[0].ArticleActions.Count; i++)
	        _tempStageUINavigator += ("Press '" + Articles[0].ArticleActions[i].ButtonName + "' " + Articles[0].ArticleActions[i].Text + "\n");

        ArticleUIText.text = Articles[0].ArticleText + "\n\n" + _tempStageUINavigator;

        /*
        //_currentstage = Articles[1].ChangeCurrentStage("M");
	    //_currentArticle = GetArticleByName(Articles, _currentstage);

        //Debug.Log("Current stage: " + _currentArticle.ArticleName);
        */
    }
	
	void Update () {
	    foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
	    {
	        if (Input.GetKeyDown(kcode))
	        {
                //Debug.Log(kcode + " is pressed!");
	            _currentstage = _currentArticle.ChangeCurrentStage(Convert.ToString(kcode));
	            _currentArticle = GetArticleByName(Articles, _currentstage);
	            //Debug.Log("Current stage: " + _currentArticle.ArticleName);

	            _tempStageUINavigator = "";
	            for (int i = 0; i < _currentArticle.ArticleActions.Count; i++)
	                _tempStageUINavigator += ("Press '" + _currentArticle.ArticleActions[i].ButtonName + "' " + _currentArticle.ArticleActions[i].Text + "\n");

	            ArticleUIText.text = _currentArticle.ArticleText + "\n\n" + _tempStageUINavigator;
            }
        }
        /*
	    Debug.Log("Current stage: " + _currentArticle.ArticleName);
	    for (int i = 0; i < _currentArticle.ArticleActions.Count; i++)
	        Debug.Log("Current actions: " + _currentArticle.ArticleActions[i].Text);
        */
    }

    Article GetArticleByName(List<Article> articles, string name)
    {
        foreach (Article artc in articles)
        {
            if (artc.ArticleName == name)
                return artc;
        }
        return null; 
    }
}
