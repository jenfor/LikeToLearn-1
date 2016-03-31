﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class Course {

	bool testMode = false;
	int testLevel = 0;
	Dictionary<int, List<string>> questions = new Dictionary<int, List<string>>();
	Dictionary<string, string> answers = new Dictionary<string, string>();
	Dictionary<string, int> results = new Dictionary<string, int>();
	static System.Random rnd = new System.Random();

    private string coursecode;

    public Course(/*string coursecode*/)
    {
        this.coursecode = "testkursen";
    }

   public string getCoursecode()
    {
        return coursecode;
    }

	public virtual Question GetQuestion(int alternatives)
	{
		int level = testMode ? testLevel : CurrentLevel();
		List<string> qs = questions[level];
		string q = qs[rnd.Next(qs.Count)];
		string a = answers[q];
		var added = new List<string>();
		var res = new Question(this, level,  q, a);
		List<string> ans = Enumerable.ToList(answers.Values);
		while (alternatives > 0) {
			string cand = ans[rnd.Next(ans.Count)];
			if (a != cand && added.IndexOf(cand) == -1) {
				added.Add(cand);
				res.AddAlternative(cand);
				alternatives--;
			}
		}
		return res;
	}

	public virtual int CurrentLevel()
	{
		var levels = questions.Keys.ToList();
		levels.Sort();
		int result = 0;
		foreach (int level in levels) {
			if (4 < questions[level].Count(x => results[x] > 0)) {
				result = level + 1;
			} else {
				break;
			}
		}
		return result;
	}

	public virtual void SetTestMode(int level)
	{
		testMode = true;
		testLevel = level;
	}

	public virtual void UnSetTestMode()
	{
		testMode = false;
	}

	public virtual void AddQuestion(int level, string question, string answer)
	{
		if (!questions.ContainsKey(level)) {
			questions[level] = new List<string>();
		}
		if (!questions[level].Exists(q => q == question)) {
			questions[level].Add(question);
		}
		if (!answers.ContainsKey(answer)) {
			answers[question] = answer;
		}
		if (!results.ContainsKey(question)) {
			results[question] = 0;
		}
	}

	public virtual void LogAnswerCorrect(string question)
	{
		++results[question];
	}

}
