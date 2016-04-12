using Clothes;
using HotColdProject.commands;
using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private readonly Temperature temperature;
    private readonly List<MorningStep> morningSteps = new List<MorningStep>();
    private readonly Validator<Person> validatePerson;

    private static readonly string FAIL = "fail";

	public Person(Temperature temperature, Validator<Person> validatePerson)
    {
        this.temperature = temperature;
        this.validatePerson = validatePerson;
    }

    public String resultOfMyMorningPreparedness()
    {
        int lastIndex = validatePerson.checkForBadIndexValue(this);
        return processStepResultsForMorning(morningSteps, lastIndex);
    }

    private String processStepResultsForMorning(List<MorningStep> steps, int lastIndex)
    {
        if (lastIndex < 0) return FAIL;

        List<MorningStep> arguments = steps.GetRange(0, lastIndex);
        StringBuilder results = new StringBuilder();

        foreach (MorningStep morningSteps in arguments)
        {
            results.Append(morningSteps.getTempDescription(temperature) + " ");
        }

        if (temperature == Temperature.HOT)
        {
            if (arguments.Count < 6)
            {
                results.Append(FAIL);
            }
        }
        else if (temperature == Temperature.COLD)
        {
            if (arguments.Count < 8)
            {
                results.Append(FAIL);
            }
        }

        return results.ToString();
    }

    public Temperature getTemperature()
    {
        return temperature;
    }

    public List<MorningStep> getMorningSteps()
    {
        return morningSteps;
    }

    public void addMorningSteps(MorningStep steps)
    {
        morningSteps.Add(steps);
    }
}
